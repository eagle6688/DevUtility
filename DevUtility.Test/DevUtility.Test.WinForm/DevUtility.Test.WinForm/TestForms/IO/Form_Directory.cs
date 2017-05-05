using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.IO
{
    public partial class Form_Directory : BaseForm
    {
        #region Constructor

        public Form_Directory()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_Delete_Click

        private void button_Delete_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.IO.Directory.DeleteService(textBox_inputValue.Text), button_Delete);
        }

        #endregion
    }
}