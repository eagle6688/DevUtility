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
    public partial class Form_DBHelper : BaseForm
    {
        #region Constructor

        public Form_DBHelper()
        {
            InitializeComponent();
            Init(textBox_Message);
        }

        #endregion

        #region button_BulkInsert_Click

        private void button_BulkInsert_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Database.DBHelper.BigDataHelper.InsertListService(), button_BulkInsert);
        }

        #endregion
    }
}