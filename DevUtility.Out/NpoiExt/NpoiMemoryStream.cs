using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NpoiExt
{
    public class NpoiMemoryStream : MemoryStream
    {
        #region Properties

        public bool AllowClose { get; set; }

        #endregion

        #region Constructor

        public NpoiMemoryStream()
        {
            AllowClose = true;
        }

        #endregion

        #region Close

        public override void Close()
        {
            if (AllowClose)
            {
                base.Close();
            }
        }

        #endregion
    }
}