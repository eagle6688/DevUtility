using DevUtility.Out.Net.Mail;
using DevUtility.Win.Services;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Net
{
    public partial class Form_Mail : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Mail()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Init();
        }

        #endregion

        #region Init

        private void Init()
        {
            textBoxService = new TextBoxService(this, textBox_Message);
            textBox_Server.Text = "smtp.126.com";
            textBox_ServerPort.Text = "25";
            textBox_UserName.Text = "";
            textBox_Password.Text = "";
            textBox_Sender.Text = "";
            textBox_To.Text = "";
            textBox_MailTitle.Text = "Test";
            textBox_Body.Text = "Test";
        }

        #endregion

        #region Form_Mail_FormClosing

        private void Form_Mail_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_Send_Click

        private void button_Send_Click(object sender, EventArgs e)
        {
            EmailCredential emailCredential = new EmailCredential();
            emailCredential.SmtpPort = int.Parse(textBox_ServerPort.Text);
            emailCredential.SmtpServer = textBox_Server.Text;
            emailCredential.LoginName = textBox_UserName.Text;
            emailCredential.Password = textBox_Password.Text;

            EmailHelperModel model = new EmailHelperModel();
            model.SenderEmail = textBox_Sender.Text;
            model.SenderName = textBox_Sender.Text;
            model.ToList.Add(textBox_To.Text);
            model.Title = textBox_MailTitle.Text;
            model.Content = textBox_Body.Text;
            model.AttachedFiles.Add(@"E:\Downloads\China High-speed Railway Lines Network.jpg");
            model.IsBodyHtml = true;
            model.SendCompletedCallbackEvent += new SendCompletedCallbackEventDelegate(SendCallback);
            model.CallbackData = "123456";

            EmailHelper.SendAsync(emailCredential, model);

            //using (EmailHelper emailHelper = new EmailHelper(emailCredential))
            //{
            //    emailHelper.SendAsync(model);
            //}

            //EmailHelper emailHelper = new EmailHelper(int.Parse(textBox_ServerPort.Text), textBox_Server.Text, textBox_UserName.Text, textBox_Password.Text);
            //emailHelper.Send(
            //    textBox_Sender.Text, 
            //    textBox_Sender.Text, 
            //    new List<string>() { textBox_To.Text }, 
            //    null, 
            //    textBox_MailTitle.Text, 
            //    new List<string>() { @"E:\Downloads\China High-speed Railway Lines Network.jpg" }, 
            //    textBox_Body.Text);
        }

        #endregion

        #region SendCallback

        private void SendCallback(bool isSucceeded, string result, object callbackData)
        {
            textBoxService.SafeAppend(string.Format("IsSucceeded: {0}", isSucceeded ? "成功" : "失败"));
            textBoxService.SafeAppend(string.Format("Result: {0}", result));
            textBoxService.SafeAppend(string.Format("CallbackData: {0}", callbackData.ToString()));
        }

        #endregion
    }
}