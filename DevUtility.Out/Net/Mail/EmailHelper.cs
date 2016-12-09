using DevUtility.Com.Application.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace DevUtility.Out.Net.Mail
{
    public class EmailHelper : IDisposable
    {
        #region Properties

        public string MailToken { set; get; }

        public bool EnableSSL { set; get; }

        public bool EnablePasswordAuthentication { set; get; }

        public MailPriority EMailPriority { set; get; }

        #endregion

        #region Variables

        int smtpPort = 0;

        string smtpServer, loginName, password;

        object callbackData = null;

        SendCompletedCallbackEventDelegate sendCompletedCallbackEvent = null;

        SmtpClient smtpClient;

        MailMessage mailMessage;

        #endregion

        #region Constructed function

        public EmailHelper(EmailCredential credential)
            : this(credential.SmtpPort, credential.SmtpServer, credential.LoginName, credential.Password)
        { }

        public EmailHelper(int smtpPort, string smtpServer, string loginName, string password)
        {
            this.smtpPort = smtpPort;
            this.smtpServer = smtpServer;
            this.loginName = loginName;
            this.password = password;
            Init();
        }

        #endregion

        #region Init

        private void Init()
        {
            EnableSSL = false;
            EnablePasswordAuthentication = true;
            MailToken = "Token_SendingMessage";
            EMailPriority = MailPriority.Normal;
        }

        #endregion

        #region Send

        public static void SendAsync(EmailCredential credential, EmailHelperModel model)
        {
            using (EmailHelper emailHelper = new EmailHelper(credential))
            {
                emailHelper.SendAsync(model);
            }
        }

        public void SendAsync(EmailHelperModel model)
        {
            sendCompletedCallbackEvent += model.SendCompletedCallbackEvent;
            SendAsync(model.SenderEmail, model.SenderName, model.ToList, model.CCList, model.Title, model.AttachedFiles, model.Content, model.IsBodyHtml, model.CallbackData);
        }

        public void SendAsync(string senderEmail, string senderName, List<string> toList, List<string> ccList, string title, List<string> attachedFiles, string content, bool isBodyHtml = false, object callbackData = null)
        {
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail, senderName);
            this.callbackData = callbackData;

            if (toList != null)
            {
                foreach (var to in toList)
                {
                    mailMessage.To.Add(to);
                }
            }

            if (ccList != null)
            {
                foreach (var cc in ccList)
                {
                    mailMessage.CC.Add(cc);
                }
            }

            if (attachedFiles != null)
            {
                AddAttachments(attachedFiles);
            }

            mailMessage.Subject = title;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = content;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Priority = EMailPriority;

            smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.Host = smtpServer;
            smtpClient.EnableSsl = EnableSSL;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            if (EnablePasswordAuthentication)
            {
                NetworkCredential networkCredential = new NetworkCredential(loginName, password);
                smtpClient.Credentials = networkCredential.GetCredential(smtpServer, smtpPort, "NTLM");
            }
            else
            {
                smtpClient.Credentials = new NetworkCredential(loginName, password);
            }

            try
            {
                smtpClient.SendAsync(mailMessage, MailToken);
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
            }
        }

        #endregion

        #region Add attachments

        private void AddAttachments(List<string> files)
        {
            if (mailMessage == null || files == null)
            {
                return;
            }

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.Exists)
                {
                    Attachment attachment = new Attachment(file, MediaTypeNames.Application.Octet);
                    ContentDisposition contentDisposition = attachment.ContentDisposition;
                    contentDisposition.CreationDate = fileInfo.CreationTime;
                    contentDisposition.ModificationDate = fileInfo.LastWriteTime;
                    contentDisposition.ReadDate = fileInfo.LastAccessTime;
                    contentDisposition.Size = fileInfo.Length;
                    contentDisposition.FileName = fileInfo.Name;
                    mailMessage.Attachments.Add(attachment);
                }
            }
        }

        #endregion

        #region Send Completed Callback

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            string token = asyncCompletedEventArgs.UserState as string;

            if (asyncCompletedEventArgs.Cancelled)
            {
                ExcuteSendCompletedCallbackEvent(false, "Cancelled");
                return;
            }

            if (asyncCompletedEventArgs.Error != null)
            {
                ExcuteSendCompletedCallbackEvent(false, asyncCompletedEventArgs.Error.ToString());
                return;
            }

            if (MailToken != token)
            {
                ExcuteSendCompletedCallbackEvent(false, "Token error");
                return;
            }

            ExcuteSendCompletedCallbackEvent(true, "OK");
        }

        #endregion

        #region Excute Send Completed Callback Event

        private void ExcuteSendCompletedCallbackEvent(bool isSucceeded, string result)
        {
            if (mailMessage != null)
            {
                mailMessage.Dispose();
                mailMessage = null;
            }

            if (smtpClient != null)
            {
                smtpClient.Dispose();
                smtpClient = null;
            }

            if (sendCompletedCallbackEvent == null)
            {
                DisposeAfterSendCompleted();
                return;
            }

            sendCompletedCallbackEvent(isSucceeded, result, callbackData);
            DisposeAfterSendCompleted();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            smtpPort = 0;
            smtpServer = null;
            loginName = null;
            password = null;
        }

        private void DisposeAfterSendCompleted()
        {
            callbackData = null;
            sendCompletedCallbackEvent = null;
            GC.Collect();
        }

        #endregion
    }
}