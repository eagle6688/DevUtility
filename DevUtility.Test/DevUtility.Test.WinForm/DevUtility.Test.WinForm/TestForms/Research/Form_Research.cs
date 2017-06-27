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
    public partial class Form_Research : BaseForm
    {
        #region Constructor

        public Form_Research()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_ADLogin_Click

        private void button_ADLogin_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Research.AD.ADLoginService(textBox_Value.Text), button_ADLogin);
        }

        #endregion

        #region button_StaticProperty_Click

        private void button_StaticProperty_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Research.Others.StaticPropertyService(), button_StaticProperty);
        }

        #endregion
    }
}