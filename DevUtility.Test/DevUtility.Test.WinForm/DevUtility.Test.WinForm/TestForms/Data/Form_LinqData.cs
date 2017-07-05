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

        #region button_WhereReference_Click

        private void button_WhereReference_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Data.LinqData.WhereReferenceService(), button_WhereReference);
        }

        #endregion

        #region button_Distinct_Click

        private void button_Distinct_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.Data.LinqData.DistinctService(), button_Distinct);
        }

        #endregion
    }
}