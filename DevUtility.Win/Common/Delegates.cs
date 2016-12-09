using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Win.Common
{
    #region TextBox

    public delegate void AppendEventDelegate(string message);

    public delegate StringBuilder GetTextBoxValueEventDelegate();

    #endregion

    #region Button

    public delegate void EnableButtonEventDelegate(bool isEnabled);

    #endregion

    #region Log

    public delegate void LogEventDelegate(string content);

    #endregion
}