using DevUtility.Win.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Win.Extension.SystemWindows.Forms
{
    public static class TextBoxExt
    {
        #region Clear message

        public static void Clear(this TextBox textBox)
        {
            textBox.Text = null;
        }

        #endregion

        #region Append message into TextBox

        public static void Append(this TextBox textBox, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                textBox.AppendText(message);
                textBox.AppendText("\r\n");
                textBox.ScrollToCaret();
                textBox.Focus();
            }
        }

        #endregion
    }
}