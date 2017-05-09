using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Net
{
    public partial class Form_FTP : BaseForm
    {
        #region Constructor

        public Form_FTP()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_Upload_Click

        private void button_Upload_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Net.FTP.UploadService(textBox_User.Text, textBox_Pwd.Text), button_Upload);
        }

        #endregion

        #region button_ListDirectoryDetails_Click

        private void button_ListDirectoryDetails_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Net.FTP.ListDirectoryDetailsService(textBox_Input.Text, textBox_User.Text, textBox_Pwd.Text), button_ListDirectoryDetails);
        }

        #endregion

        #region button_ListDirectory_Click

        private void button_ListDirectory_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Net.FTP.ListDirectoryService(textBox_Input.Text, textBox_User.Text, textBox_Pwd.Text), button_ListDirectory);
        }

        #endregion

        #region button_Exists_Click

        private void button_Exists_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Net.FTP.ExistsService(), button_Exists);
        }

        #endregion

        #region button_Download_Click

        private void button_Download_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Net.FTP.DownloadService(), button_Download);
        }

        #endregion
    }
}