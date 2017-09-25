using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.ThirdPart
{
    public partial class Form_NPOI : BaseForm
    {
        #region Constructor

        public Form_NPOI()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_AppendExcel_Click

        private void button_AppendExcel_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.ThirdPart.NPOI.AppendExcelService(textBox_inputValue.Text), button_AppendExcel);
        }

        #endregion
    }
}