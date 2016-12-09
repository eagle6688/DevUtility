using DevUtility.Test.Service.Winform.Data.Concurrency;
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
    public partial class Form_Concurrency : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Concurrency()
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

        #region Form_Concurrency_FormClosing

        private void Form_Concurrency_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_InsertData_Click

        private void button_InsertData_Click(object sender, EventArgs e)
        {
            List<InsertDataService> services = new List<InsertDataService>();

            for (int i = 0; i < 4; i++)
            {
                var service = new InsertDataService();
                service.AppTextBoxService = textBoxService;
                service.AppButtonService = new ButtonService(this, button_InsertData);
                services.Add(service);
            }

            foreach (var service in services)
            {
                service.Start();
                //AppServiceHelper.RunThread(service);
            }
        }

        #endregion

        #region button_InsertDuplicateData_Click

        private void button_InsertDuplicateData_Click(object sender, EventArgs e)
        {
            List<InsertDuplicateDataService> services = new List<InsertDuplicateDataService>();

            for (int i = 0; i < 4; i++)
            {
                var service = new InsertDuplicateDataService(textBox_inputValue.Text);
                service.AppTextBoxService = textBoxService;
                service.AppButtonService = new ButtonService(this, button_InsertData);
                services.Add(service);
            }

            foreach (var service in services)
            {
                AppServiceHelper.RunThread(service);
            }
        }

        #endregion
    }
}