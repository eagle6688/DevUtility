using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Net
{
    public partial class Form_WCF : BaseForm
    {
        #region Constructor

        public Form_WCF()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_PushMessage_Click

        private void button_PushMessage_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Net.WCF.PushMessageService(textBox_inputValue.Text), button_PushMessage);
        }

        #endregion
    }
}