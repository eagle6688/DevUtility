using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.Mail
{
    public delegate void SendCompletedCallbackEventDelegate(bool isSucceeded, string result, object callbackData);
}