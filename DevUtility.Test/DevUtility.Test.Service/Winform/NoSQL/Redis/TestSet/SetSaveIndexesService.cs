using DevUtility.Test.Model.Com;
using DevUtility.Test.RedisData.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.TestSet
{
    public class SetSaveIndexesService : BaseAppService
    {
        public override void Start()
        {
            DisplayMessage(DateTime.Now.ToLongTimeString());

            Action Subjects = () =>
            {
                var list = SubjectRDal.Instance.GetList();
                //DisplayMessage(string.Format("Save Subjects' indexes {0}.", SubjectRDal.Instance.SaveIndexes(list) ? "success" : "failed"));
            };

            Subjects();
            DisplayMessage(DateTime.Now.ToLongTimeString());

            Action Teachers = () =>
            {
                var list = TeacherRDal.Instance.GetList();
                //DisplayMessage(string.Format("Save Teachers' indexes {0}.", TeacherRDal.Instance.SaveIndexes(list) ? "success" : "failed"));
            };

            Teachers();
            DisplayMessage(DateTime.Now.ToLongTimeString());
        }
    }
}