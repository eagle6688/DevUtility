using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NpoiExt
{
    public static class IFontExt
    {
        #region Clone without Boldweight

        public static IFont CloneWithoutBoldweight(this IFont original, IWorkbook workbook)
        {
            IFont font = workbook.CreateFont();
            font.Charset = original.Charset;
            font.Color = original.Color;
            font.FontHeight = original.FontHeight;
            font.FontHeightInPoints = original.FontHeightInPoints;
            font.FontName = original.FontName;
            font.IsItalic = original.IsItalic;
            font.IsStrikeout = original.IsStrikeout;
            font.TypeOffset = original.TypeOffset;
            font.Underline = original.Underline;
            return font;
        }

        #endregion
    }
}