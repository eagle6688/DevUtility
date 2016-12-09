using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemText
{
    public static class StringBuilderExt
    {
        #region Append ext

        public static void AppendExt(this StringBuilder builder, string content, string tail)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            builder.Append(content);
            builder.Append(tail);
        }

        #endregion

        #region Append txt head line

        public static void AppendTxtHeadLine(this StringBuilder builder, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            builder.Insert(0, Environment.NewLine);
            builder.Insert(0, content);
            builder.Insert(0, Environment.NewLine);
        }

        #endregion
    }
}