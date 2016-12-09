using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.Mail
{
    public class EmailHelperModel
    {
        public string SenderEmail { set; get; }

        public string SenderName { set; get; }

        public List<string> ToList { set; get; }

        public List<string> CCList { set; get; }

        public string Title { set; get; }

        public string Content { set; get; }

        public bool IsBodyHtml { set; get; }

        public List<string> AttachedFiles { set; get; }

        public object CallbackData { set; get; }

        public SendCompletedCallbackEventDelegate SendCompletedCallbackEvent { set; get; }

        public EmailHelperModel()
        {
            ToList = new List<string>();
            CCList = new List<string>();
            IsBodyHtml = false;
            AttachedFiles = new List<string>();
            CallbackData = null;
            SendCompletedCallbackEvent = null;
        }
    }
}