using DevUtility.Win.Common;
using DevUtility.Win.Extension.SystemWindows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Win.Services
{
    public class TextBoxService
    {
        #region Variable

        private Form form;

        private TextBox textBox;

        #endregion

        #region Constructor

        public TextBoxService(Form form, TextBox textBox)
        {
            this.form = form;
            this.textBox = textBox;
        }

        #endregion

        #region Append

        private void Append(string message)
        {
            textBox.Append(message);
        }

        public void SafeAppend(string message)
        {
            if (textBox.IsDisposed)
            {
                return;
            }

            if (textBox.InvokeRequired)
            {
                AppendEventDelegate appendEventDelegate = new AppendEventDelegate(Append);
                form.BeginInvoke(appendEventDelegate, new object[] { message });
            }
            else
            {
                Append(message);
            }
        }

        #endregion

        #region Get TextBox value

        public StringBuilder GetTextBoxValue()
        {
            return new StringBuilder(textBox.Text);
        }

        #endregion
    }
}