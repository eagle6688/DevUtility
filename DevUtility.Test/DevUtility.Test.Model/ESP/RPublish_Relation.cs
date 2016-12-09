using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.ESP
{
    [RelationTable]
    public class RPublish_Relation
    {
        [PrimaryKey]
        public long FixIID { set; get; }

        public string Target { set; get; }

        [PrimaryKey]
        public long TargetFixIID { set; get; }

        [PrimaryKey]
        public string RelationType { set; get; }
    }
}