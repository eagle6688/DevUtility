using DevUtility.Com.Application;
using DevUtility.Com.Model;
using DevUtility.Win.Services;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Application
{
    public partial class Form_Application : Form
    {
        #region Variable

        TextBoxService textBoxService;

        #endregion

        #region Constructor

        public Form_Application()
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

        #region Form_Application_FormClosing

        private void Form_Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppServiceHelper.OpenForm("MainForm");
        }

        #endregion

        #region button_RunProgram_Click

        private void button_RunProgram_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(textBox_inputValue.Text);
            var result = ProcessHelper.ExcuteBat(fileInfo.DirectoryName, fileInfo.Name);

            if (fileInfo.Exists)
            {
                if (result.IsSucceeded)
                {
                    textBoxService.SafeAppend(result.Data.ToString());
                }
                else
                {
                    textBoxService.SafeAppend(result.Message);
                }
            }
        }

        #endregion

        #region button_ExcuteCmd_Click

        private void button_ExcuteCmd_Click(object sender, EventArgs e)
        {
            OperationResult result = ProcessHelper.ExcuteCmd("ipconfig");

            if (result.IsSucceeded)
            {
                textBoxService.SafeAppend(result.Data.ToString());
            }
            else
            {
                textBoxService.SafeAppend(result.Message);
            }
        }

        #endregion

        #region button_ServiceStatus_Click

        private void button_ServiceStatus_Click(object sender, EventArgs e)
        {
            string status = DevUtility.Out.Application.ServiceProcessHelper.GetStatus(textBox_inputValue.Text);
            textBoxService.SafeAppend(status);
        }

        #endregion

        #region button_GetAllServices_Click

        private void button_GetAllServices_Click(object sender, EventArgs e)
        {
            var list = Out.Application.ServiceProcessHelper.GetServiceNames();

            foreach (var item in list)
            {
                textBoxService.SafeAppend(item);
            }
        }

        #endregion
    }
}