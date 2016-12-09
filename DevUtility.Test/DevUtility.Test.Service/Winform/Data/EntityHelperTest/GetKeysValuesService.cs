﻿using DevUtility.Com.Base;
using DevUtility.Com.Data;
using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.EntityHelperTest
{
    public class GetKeysValuesService : BaseAppService
    {
        public override void Start()
        {
            StudentScore studentScore = new StudentScore();
            studentScore.StudentID = 1;
            var properties = PropertyHelper.GetAllProperties<StudentScore>(studentScore);
            var primaryKeysProperties = PropertyHelper.GetPrimaryKeyProperties(properties);

            EntityHelper.GetKeysValues<StudentScore>(studentScore, primaryKeysProperties).ForEach((string keyvalue) =>
            {
                DisplayMessage(keyvalue);
            });
        }
    }
}