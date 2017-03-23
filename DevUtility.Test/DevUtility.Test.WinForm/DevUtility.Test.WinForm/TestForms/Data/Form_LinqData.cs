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
    public partial class Form_LinqData : BaseForm
    {
        #region Constructor

        public Form_LinqData()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_NullInLinq_Click

        private void button_NullInLinq_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Data.LinqData.NullInLinqService(), button_NullInLinq);
        }

        #endregion
    }
}