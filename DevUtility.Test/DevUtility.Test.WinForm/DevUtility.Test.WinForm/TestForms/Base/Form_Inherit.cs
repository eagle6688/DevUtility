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

namespace DevUtility.Test.WinForm.TestForms.Base
{
    public partial class Form_Inherit : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Inherit()
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

        #region Form_Inherit_FormClosing

        private void Form_Inherit_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_SonToFather_Click

        private void button_SonToFather_Click(object sender, EventArgs e)
        {
            var service = new DevUtility.Test.Service.Winform.Base.InheritService();
            service.AppTextBoxService = textBoxService;
            service.AppButtonService = new ButtonService(this, button_SonToFather);
            AppServiceHelper.RunThread(service);
        }

        #endregion
    }
}