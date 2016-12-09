using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemExt
{
    public static class ExceptionExt
    {
        #region Get exception content

        public static string ToExceptionString(this Exception exception)
        {
            return exception.ToExceptionContent().ToString();
        }

        public static StringBuilder ToExceptionContent(this Exception exception)
        {
            StringBuilder content = new StringBuilder("");
            content.Append(Environment.NewLine);
            content.Append(DateTime.Now.ToLongDateTimeString());

            content.Append(Environment.NewLine);
            content.Append(exception.GetType().Name);

            content.Append(Environment.NewLine);
            content.Append(exception.Message);

            content.Append(Environment.NewLine);
            content.Append(exception.Source);

            if (exception.TargetSite != null)
            {
                content.Append(Environment.NewLine);
                content.Append(exception.TargetSite);
            }

            content.Append(Environment.NewLine);
            content.Append(exception.StackTrace);

            if (!string.IsNullOrEmpty(exception.HelpLink))
            {
                content.Append(Environment.NewLine);
                content.Append(exception.HelpLink);
            }

            return content;
        }

        #endregion
    }
}