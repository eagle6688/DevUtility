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
    public partial class Form_Set : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Set()
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

            textBox_Host.Text = "10.122.11.176";
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

        #region button_CheckValue_Click

        private void button_CheckValue_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.SetHelper.CheckValueService(textBox_Host.Text, textBox_Pwd.Text, textBox_Key.Text, textBox_Value.Text), button_CheckValue);
        }

        #endregion

        #region button_GetValues_Click

        private void button_GetValues_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.SetHelper.GetValuesService(textBox_Host.Text, textBox_Pwd.Text, textBox_Key.Text, textBox_Value.Text), button_GetValues);
        }

        #endregion
    }
}