using DevUtility.Com.Extension.SystemExt;
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

namespace DevUtility.Test.WinForm.TestForms.Extension
{
    public partial class Form_SystemExt : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_SystemExt()
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

        #region button_GetExceptionContent_Click

        private void button_GetExceptionContent_Click(object sender, EventArgs e)
        {
            try
            {
                int number1 = 0,
                    number2 = 1;

                var result = number2 / number1;
            }
            catch (Exception exception)
            {
                textBoxService.SafeAppend(exception.ToExceptionString());
                textBoxService.SafeAppend("ToString:");
                textBoxService.SafeAppend(exception.ToString());
            }
        }

        #endregion
    }
}