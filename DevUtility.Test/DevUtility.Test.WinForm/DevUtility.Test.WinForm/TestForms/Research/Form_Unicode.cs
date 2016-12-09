using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Research
{
    public partial class Form_Unicode : BaseForm
    {
        #region Constructor

        public Form_Unicode()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_Dollar_Click

        private void button_Dollar_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Research.Unicode.DollarService(textBox_Value.Text), button_Dollar);
        }

        #endregion
    }
}