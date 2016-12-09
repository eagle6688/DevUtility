using DevUtility.Test.Service.Winform.IO.Files.TestFileHelper;
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

namespace DevUtility.Test.WinForm.TestForms.IO.Files
{
    public partial class Form_FileHelper : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_FileHelper()
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

        #region FormClosing

        private void Form_FileHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region Execute Service

        private void ExecuteService(BaseAppService service, Button button)
        {
            service.AppButtonService = new ButtonService(this, button);
            service.AppTextBoxService = textBoxService;
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_GetChecksumSHA1_Click

        private void button_GetChecksumSHA1_Click(object sender, EventArgs e)
        {
            ExecuteService(new ChecksumSHA1Service(textBox_inputValue.Text), button_GetChecksumSHA1);
        }

        #endregion

        #region button_GetExtension_Click

        private void button_GetExtension_Click(object sender, EventArgs e)
        {
            textBoxService.SafeAppend(System.IO.Path.GetExtension(textBox_inputValue.Text));
            textBoxService.SafeAppend(System.IO.Path.GetFileNameWithoutExtension(textBox_inputValue.Text));
            textBoxService.SafeAppend(Com.IO.PathHelper.GetFullExtension(textBox_inputValue.Text));
        }

        #endregion
    }
}