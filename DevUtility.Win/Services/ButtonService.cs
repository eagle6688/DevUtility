using DevUtility.Win.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Win.Services
{
    public class ButtonService
    {
        #region Variable

        private Form form;

        private Button button;

        #endregion

        #region Constructor

        public ButtonService(Form form, Button button)
        {
            this.form = form;
            this.button = button;
        }

        #endregion

        #region Enable

        private void EnableButton(bool isEnabled)
        {
            button.Enabled = isEnabled;
        }

        public void SafeEnableButton(bool isEnabled)
        {
            if (button == null || button.IsDisposed)
            {
                return;
            }

            if (button.InvokeRequired)
            {
                EnableButtonEventDelegate enableButtonEventDelegate = new EnableButtonEventDelegate(EnableButton);
                form.BeginInvoke(enableButtonEventDelegate, isEnabled);
            }
            else
            {
                EnableButton(isEnabled);
            }
        }

        #endregion
    }
}