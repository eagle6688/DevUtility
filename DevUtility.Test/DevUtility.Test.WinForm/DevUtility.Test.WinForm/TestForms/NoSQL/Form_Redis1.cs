using DevUtility.Win.Extension.SystemWindows.Forms;
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

namespace DevUtility.Test.WinForm.TestForms.NoSQL
{
    public partial class Form_Redis1 : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Redis1()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region Init

        private void Init()
        {
            textBoxService = new TextBoxService(this, textBox_Message);
            this.StandardInit();
            this.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                AppServiceHelper.OpenForm("MainForm");
            });
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

        #region button_PerformanceTest_Click

        private void button_PerformanceTest_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.ESP.PerformanceTestService(textBox_Host.Text, textBox_Pwd.Text), button_PerformanceTest);
        }

        #endregion

        #region button_SetAll_Click

        private void button_SetAll_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.ModelHelper.SetAllService(textBox_Host.Text, textBox_Pwd.Text), button_SetAll);
        }

        #endregion

        #region button_GetESPData_Click

        private void button_GetESPData_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.ESP.GetESPDataService(textBox_Host.Text, textBox_Pwd.Text), button_SetAll);
        }

        #endregion
    }
}