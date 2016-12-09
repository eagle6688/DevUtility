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

namespace DevUtility.Test.WinForm.TestForms.Data
{
    public partial class Form_Security : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Security()
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

        #region Execute Service

        private void ExecuteService(BaseAppService service, Button button)
        {
            service.AppButtonService = new ButtonService(this, button);
            service.AppTextBoxService = textBoxService;
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region Form_Security_FormClosing

        private void Form_Security_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_AESHelper_Encrypt_Click

        private void button_AESHelper_Encrypt_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Data.Cryptography.AESHelperTest.TestEncryptService(textBox_inputValue.Text);
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_AESHelper_Encrypt);
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_AESHelper_Decrypt_Click

        private void button_AESHelper_Decrypt_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Data.Cryptography.AESHelperTest.TestDecryptService(textBox_inputValue.Text);
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_AESHelper_Decrypt);
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_MD5Encrypt_Click

        private void button_MD5Encrypt_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Data.Cryptography.MD5HelperTest.TestMD5Service(textBox_inputValue.Text);
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_MD5Encrypt);
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_SHA1Encrypt_Click

        private void button_SHA1Encrypt_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Data.Cryptography.SHA1HelperTest.TestSHA1Service(textBox_inputValue.Text);
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_MD5Encrypt);
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_SHA256Encrypt_Click

        private void button_SHA256Encrypt_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Data.Cryptography.SHA256HelperTest.TestSHA256Service(textBox_inputValue.Text);
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_MD5Encrypt);
            AppServiceHelper.RunThread(service);
        }

        #endregion

        #region button_FileSHA1Encrypt_Click

        private void button_FileSHA1Encrypt_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.Data.Cryptography.SHA1HelperTest.TestFileSHA1Service(textBox_inputValue.Text), button_SHA256Encrypt);
        }

        #endregion

        #region button_FileMD5Encrypt_Click

        private void button_FileMD5Encrypt_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Data.Cryptography.FileMD5EncryptService(textBox_inputValue.Text), button_FileMD5Encrypt);
        }

        #endregion
    }
}