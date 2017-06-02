using DevUtility.Com.Application;
using DevUtility.Com.Model;
using System;
using System.IO;

namespace DevUtility.Test.WinForm.TestForms.Application
{
    public partial class Form_Application : BaseForm
    {
        #region Constructor

        public Form_Application()
        {
            InitializeComponent();
            Init(textBox_Message);
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

        #region button_GetSection_Click

        private void button_GetSection_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Application.ConfigHelperTest.GetSectionService(textBox_inputValue.Text), button_GetAllServices);
        }

        #endregion
    }
}