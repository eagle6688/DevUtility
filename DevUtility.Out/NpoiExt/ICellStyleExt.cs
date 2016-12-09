using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NpoiExt
{
    public static class ICellStyleExt
    {
        #region Clone

        public static ICellStyle Clone(this ICellStyle original, IWorkbook workbook)
        {
            if (original == null)
            {
                return null;
            }

            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = original.Alignment;
            style.BorderBottom = original.BorderBottom;
            style.BorderDiagonal = original.BorderDiagonal;
            style.BorderDiagonalColor = original.BorderDiagonalColor;
            style.BorderDiagonalLineStyle = original.BorderDiagonalLineStyle;
            style.BorderLeft = original.BorderLeft;
            style.BorderRight = original.BorderRight;
            style.BorderTop = original.BorderTop;
            style.BottomBorderColor = original.BottomBorderColor;
            style.DataFormat = original.DataFormat;
            style.FillBackgroundColor = original.FillBackgroundColor;
            style.FillForegroundColor = original.FillForegroundColor;
            style.FillPattern = original.FillPattern;
            style.Indention = original.Indention;
            style.LeftBorderColor = original.LeftBorderColor;
            style.RightBorderColor = original.RightBorderColor;
            style.Rotation = original.Rotation;
            style.ShrinkToFit = original.ShrinkToFit;
            style.TopBorderColor = original.TopBorderColor;
            style.VerticalAlignment = original.VerticalAlignment;
            style.WrapText = original.WrapText;

            IFont font = original.GetFont(workbook);
            style.SetFont(font.CloneWithoutBoldweight(workbook));
            return style;
        }

        #endregion
    }
}