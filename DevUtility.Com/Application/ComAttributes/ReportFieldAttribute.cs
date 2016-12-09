using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Application.ComAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReportFieldAttribute : Attribute
    {
        #region Attribute

        public string Name { set; get; }

        #endregion

        #region Constructor

        public ReportFieldAttribute(string name)
        {
            Name = name;
        }

        #endregion
    }
}