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
    public partial class Form_FileHelper : BaseForm
    {
        #region Constructor

        public Form_FileHelper()
        {
            InitializeComponent();
            Init(textBox_Message);
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

        #region button_Combine_Click

        private void button_Combine_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.IO.Path.CombineService(), button_Combine);
        }

        #endregion
    }
}