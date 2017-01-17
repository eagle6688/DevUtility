using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Base
{
    public partial class Form_Reflection : BaseForm
    {
        #region Constructor

        public Form_Reflection()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_Upload_Click

        private void button_AssemblyLoad_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Base.Reflection.AssemblyLoadService(textBox_inputValue.Text), button_AssemblyLoad);
        }

        #endregion

        #region button_AssemblyLoadFile_Click

        private void button_AssemblyLoadFile_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Base.Reflection.AssemblyLoadFileService(textBox_inputValue.Text), button_AssemblyLoadFile);
        }

        #endregion

        #region button_LockerHelper_Click

        private void button_LockerHelper_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Base.Reflection.LockerHelperService(), button_LockerHelper);
        }

        #endregion
    }
}