using DevUtility.Com.IO.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Application.Log
{
    public class LogHandler
    {
        #region Variable

        string directory = "";

        StringBuilder content = new StringBuilder("");

        #endregion

        #region Constructor

        public LogHandler(string directory, StringBuilder content)
        {
            if (!string.IsNullOrWhiteSpace(directory))
            {
                this.directory = directory;
            }

            if (content != null && content.Length > 0)
            {
                this.content = content;
            }
        }

        #endregion

        #region Save

        public void Save()
        {
            string file = LogConfig.LogFileName;
            string path = Path.Combine(directory, file);
            TxtHelper.Append(path, content);
        }

        #endregion
    }
}