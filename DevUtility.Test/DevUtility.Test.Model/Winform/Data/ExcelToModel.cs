using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Winform.Data
{
    public class ExcelToModel
    {
        [ReportField("ASD Name")]
        public string Name { set; get; }

        public string Gender { set; get; }
    }
}