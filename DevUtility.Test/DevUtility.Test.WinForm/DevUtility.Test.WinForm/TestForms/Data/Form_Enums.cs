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
    public partial class Form_Enums : BaseForm
    {
        #region Constructor

        public Form_Enums()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_GetType_Click

        private void button_GetType_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Data.Enums.GetTypeService(textBox_inputValue.Text), button_GetType);
        }

        #endregion
    }
}