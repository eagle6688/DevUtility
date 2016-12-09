using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Test.WinForm.TestForms.NoSQL
{
    public partial class Form_Redis : BaseForm
    {
        #region Variable

        /// <summary>
        /// 10.100.97.64
        /// </summary>
        //string ip = "192.168.1.113";
        string ip = "10.100.97.64";

        int port = 6379;

        string password = "111111";

        #endregion

        #region Constructor

        public Form_Redis()
        {
            InitializeComponent();
            Init(textBox_Message);
            textBox_Host.Text = "10.38.34.189";
            comboBox_DB.SelectedItem = "0";
        }

        #endregion

        #region button_IsConnected_Click

        private void button_IsConnected_Click(object sender, EventArgs e)
        {
            ExecuteService(new Service.NoSQL.Redis.RedisHelperTest.IsConnectedService(textBox_Host.Text, textBox_Pwd.Text), button_IsConnected);
        }

        #endregion

        #region button_GetValue_Click

        private void button_GetValue_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.GetService(ip, port, password, textBox_Key.Text), button_GetValue);
        }

        #endregion

        #region button_SetValue_Click

        private void button_SetValue_Click(object sender, EventArgs e)
        {
            string[] array = textBox_Key.Text.Split(':');
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.SetService(ip, port, password, array[0], array[1]), button_SetValue);
        }

        #endregion

        #region button_Remove_Click

        private void button_Remove_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.RemoveService(ip, port, password, textBox_Key.Text), button_Remove);
        }

        #endregion

        #region button_ExecuteLua_Click

        private void button_ExecuteLua_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.LuaService(ip, port, password, textBox_Key.Text), button_ExecuteLua);
        }

        #endregion

        #region button_GetModelKey_Click

        private void button_GetModelKey_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.TestRedisRelationDataHelper.GetModelKeyService(ip, port, password), button_GetModelKey);
        }

        #endregion

        #region button_GetValueFromDB1_Click

        private void button_GetValueFromDB1_Click(object sender, EventArgs e)
        {
            ExecuteService(new Test.Service.Winform.NoSQL.Redis.GetValueFromDB1Service(ip, port, password, textBox_Key.Text), button_GetValueFromDB1);
        }

        #endregion
    }
}