using DevUtility.Com.Application.ComAttributes;
using DevUtility.Com.Base;
using DevUtility.Test.Model.Com;
using DevUtility.Test.Model.ESP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Base.TestAttributeHelper
{
    public class ExistsAttributeService : BaseAppService
    {
        public override void Start()
        {
            bool isExisted = AttributeHelper.ExistsAttribute<StudentScore, RedisIndexAttribute>();
            DisplayMessage(string.Format("Class StudentScore has{0} RedisIndex attribute.", isExisted ? "" : " not"));

            isExisted = AttributeHelper.ExistsAttribute<StudentScore, NoDatabaseFieldAttribute>();
            DisplayMessage(string.Format("Class StudentScore has{0} NoDatabaseFieldAttribute attribute.", isExisted ? "" : " not"));

            isExisted = AttributeHelper.ExistsAttribute<RPublish_Relation, RelationTableAttribute>();
            DisplayMessage(string.Format("Class RPublish_Relation has{0} RelationTableAttribute attribute.", isExisted ? "" : " not"));
        }
    }
}