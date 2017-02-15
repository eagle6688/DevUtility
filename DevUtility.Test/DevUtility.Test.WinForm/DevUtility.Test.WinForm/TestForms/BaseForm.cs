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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms
{
    public partial class BaseForm : Form
    {
        #region Variable

        protected TextBoxService textBoxService;

        #endregion

        #region Constructor

        public BaseForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Init

        protected void Init(TextBox textBox)
        {
            textBoxService = new TextBoxService(this, textBox);
            this.StandardInit();
            this.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                AppServiceHelper.OpenForm("MainForm");
            });
        }

        #endregion

        #region Execute Service

        protected void ExecuteService(BaseAppService service, Button button)
        {
            service.AppButtonService = new ButtonService(this, button);
            service.AppTextBoxService = textBoxService;
            AppServiceHelper.RunThread(service);
        }

        #endregion
    }
}