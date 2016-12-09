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
    public partial class Form_Random : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Random()
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

        #region Form_Random_FormClosing

        private void Form_Random_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_GetRandomNumber_Click

        private void button_GetRandomNumber_Click(object sender, EventArgs e)
        {
            ExecuteService(new DevUtility.Test.Service.Winform.Data.RandomHelper.GetRandomNumberService(), button_GetRandomNumber);
        }

        #endregion
    }
}