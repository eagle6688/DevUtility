using DevUtility.Win.Extension.SystemWindows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm
{
    public partial class MainForm : Form
    {
        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region Init

        private void Init()
        {
            this.StandardInit();
        }

        #endregion

        #region MainForm_FormClosed

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Open Form

        private void OpenForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        #endregion

        #region button_Security_Click

        private void button_Security_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.Data.Form_Security());
        }

        #endregion

        #region button_Net_Click

        private void button_Net_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Net.Form_Net());
        }

        #endregion

        #region button_Mail_Click

        private void button_Mail_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Net.Form_Mail());
        }

        #endregion

        #region button_Application_Click

        private void button_Application_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Application.Form_Application());
        }

        #endregion

        #region button_DataTable_Click

        private void button_DataTable_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.Data.Form_DataTable());
        }

        #endregion

        #region button_Concurrency_Click

        private void button_Concurrency_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.Data.Form_Concurrency());
        }

        #endregion

        #region button_Inherit_Click

        private void button_Inherit_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.Base.Form_Inherit());
        }

        #endregion

        #region button_Redis_Click

        private void button_Redis_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.NoSQL.Form_Redis());
        }

        #endregion

        #region button_Redis1_Click

        private void button_Redis1_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.NoSQL.Form_Redis1());
        }

        #endregion

        #region button_Random_Click

        private void button_Random_Click(object sender, EventArgs e)
        {
            OpenForm(new DevUtility.Test.WinForm.TestForms.Data.Form_Random());
        }

        #endregion

        #region button_Attribute_Click

        private void button_Attribute_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Base.Form_Attribute());
        }

        #endregion

        #region button_FileHelper_Click

        private void button_FileHelper_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.IO.Files.Form_FileHelper());
        }

        #endregion

        #region button_SystemExt_Click

        private void button_SystemExt_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Extension.Form_SystemExt());
        }

        #endregion

        #region button_EntityHelper_Click

        private void button_EntityHelper_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Data.Form_EntityHelper());
        }

        #endregion

        #region button_RedisHash_Click

        private void button_RedisHash_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.NoSQL.Form_Redis_Hash());
        }

        #endregion

        #region button_RedisSet_Click

        private void button_RedisSet_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.NoSQL.Form_Set());
        }

        #endregion

        #region button_MultiThreads1_Click

        private void button_MultiThreads1_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.MultiThreads.Form_MultiThreads1());
        }

        #endregion

        #region button_FTP_Click

        private void button_FTP_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Net.Form_FTP());
        }

        #endregion

        #region button_Unicode_Click

        private void button_Unicode_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Research.Form_Unicode());
        }

        #endregion

        #region button_Reflection_Click

        private void button_Reflection_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Base.Form_Reflection());
        }

        #endregion

        #region button_MemoryFootprint_Click

        private void button_MemoryFootprint_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Data.Form_MemoryFootprint());
        }

        #endregion

        #region button_DBHelper_Click

        private void button_DBHelper_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Database.Form_DBHelper());
        }

        #endregion

        #region button_Convert_Click

        private void button_Convert_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Data.Form_Convert());
        }

        #endregion

        #region button_Research_Click

        private void button_Research_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Research.Form_Research());
        }

        #endregion

        #region button_Linq_Click

        private void button_Linq_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.Data.Form_LinqData());
        }

        #endregion

        #region button_Directory_Click

        private void button_Directory_Click(object sender, EventArgs e)
        {
            OpenForm(new TestForms.IO.Form_Directory());
        }

        #endregion
    }
}