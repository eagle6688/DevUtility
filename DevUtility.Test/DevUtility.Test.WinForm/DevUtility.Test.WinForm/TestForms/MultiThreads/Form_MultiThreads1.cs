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

namespace DevUtility.Test.WinForm.TestForms.MultiThreads
{
    public partial class Form_MultiThreads1 : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_MultiThreads1()
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
            AppServiceHelper.Run(service);
        }

        #endregion

        #region button_BeginInvoke_Click

        private void button_BeginInvoke_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.MultiThreads.BeginInvokeService(), button_BeginInvoke);
        }

        #endregion

        #region button_AsyncAndAwait_Click

        private void button_AsyncAndAwait_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.MultiThreads.AsyncAndAwaitService(), button_AsyncAndAwait);
        }

        #endregion
    }
}