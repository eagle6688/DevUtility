using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.Database
{
    public partial class Form_MongoDB : BaseForm
    {
        #region Constructor

        public Form_MongoDB()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_Query_Click

        private void button_Query_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Database.MongoDBTest.QueryService(textBox_inputValue.Text), button_Query);
        }

        #endregion
    }
}