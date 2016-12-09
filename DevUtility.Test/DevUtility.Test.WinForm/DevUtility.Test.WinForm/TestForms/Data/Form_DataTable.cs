using DevUtility.Test.Service.Winform.Data.DataTableExt;
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
    public partial class Form_DataTable : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_DataTable()
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

        #region Form_DataTable_FormClosing

        private void Form_DataTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_TestDataTable_Click

        private void button_TestDataTable_Click(object sender, EventArgs e)
        {
            var service = new TestDataTableService();
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_TestDataTable);
            AppServiceHelper.RunThread(service);
        }

        #endregion
    }
}