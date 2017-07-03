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
    public partial class Form_Property : BaseForm
    {
        #region Constructor

        public Form_Property()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_FiltrateNullDateTime_Click

        private void button_FiltrateInvalidDateTime_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Base.Property.FiltrateInvalidDateTimeService(), button_FiltrateInvalidDateTime);
        }

        #endregion
    }
}