using DevUtility.Out.Net.Http;
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
    public partial class Form_Net : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Net()
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
        }

        #endregion

        #region button_HttpHelper_Using_Click

        private void button_HttpHelper_Using_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Net.Http.TestHttpHelperUsingService(textBox_inputValue.Text);
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_HttpHelper_Using);
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_HttpHelper_Post_Click

        private void button_HttpHelper_Post_Click(object sender, EventArgs e)
        {
            string result = HttpHelper.Post("http://localhost:8888/None", "asd");
            textBox_Message.Text = result;
        }

        #endregion
    }
}