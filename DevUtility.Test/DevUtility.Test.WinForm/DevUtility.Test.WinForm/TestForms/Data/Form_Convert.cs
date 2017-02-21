using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Data
{
    public partial class Form_Convert : BaseForm
    {
        #region Constructor

        public Form_Convert()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_ToDateTime_Click

        private void button_ToDateTime_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.MinValue;
            DateTime.TryParse(null, out time);
            textBoxService.SafeAppend(time.ToString());
        }

        #endregion
    }
}