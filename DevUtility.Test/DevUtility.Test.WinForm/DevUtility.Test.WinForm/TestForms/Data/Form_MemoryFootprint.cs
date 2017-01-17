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
    public partial class Form_MemoryFootprint : BaseForm
    {
        #region Constructor

        public Form_MemoryFootprint()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_Products_Click

        private void button_Products_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Data.MemoryFootprint.ProductsService(int.Parse(textBox_inputValue.Text)), button_Products);
        }

        #endregion
    }
}