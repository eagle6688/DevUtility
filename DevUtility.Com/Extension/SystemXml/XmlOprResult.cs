using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemXml
{
    /// <summary>
    /// Xml file's operating code
    /// </summary>
    public enum XmlOprResult : short
    {
        OK = 0,
        NoFile,
        FailedLoad,
        Repeated,
        NonExistence
    }
}