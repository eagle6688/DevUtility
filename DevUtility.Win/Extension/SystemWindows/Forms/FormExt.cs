using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUtility.Win.Extension.SystemWindows.Forms
{
    public static class FormExt
    {
        public static void StandardInit(this Form form)
        {
            form.MaximizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
    }
}