using DevUtility.Out.NoSQL.Redis;
using DevUtility.Out.NoSQL.Redis.ModelHelper;
using DevUtility.Test.Model.Com;
using DevUtility.Test.Service.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.NoSQL.Redis.Hash.RedisRowHelperTest
{
    //One model is a hash.
    public class SaveListInHashService : BaseAppService
    {
        #region Variables

        int port = 0;

        string host = "", password = "";

        #endregion

        #region Constructor

        public SaveListInHashService(string host, int port, string password)
        {
            this.host = host;
            this.port = port;
            this.password = password;
        }

        #endregion

        #region Start

        public override void Start()
        {
            var subjectIDs = new List<int>();
            var studentIDs = new List<long>();

            var redisConfig = new RedisConfig()
            {
                Host = host,
                Port = port,
                Password = password
            };

            DisplayMessage(DateTime.Now.ToLongTimeString());

            Action Subjects = () =>
            {
                var list = DataProviderService.Instance.GetSubjects();
                subjectIDs = list.Select(q => q.ID).ToList();
                RedisRowHelper<Subject>.CreateInstance(redisConfig).Save(list);
                DisplayMessage(string.Format("Save Subjects success."));
            };

            Subjects();
            DisplayMessage(DateTime.Now.ToLongTimeString());

            Action Teachers = () =>
            {
                var list = DataProviderService.Instance.GetTeachers(50000);
                RedisRowHelper<Teacher>.CreateInstance(redisConfig).Save(list);
                DisplayMessage(string.Format("Save Subjects success."));
            };

            Teachers();
            DisplayMessage(DateTime.Now.ToLongTimeString());

            Action Students = () =>
            {
                var list = DataProviderService.Instance.GetStudents(100000);
                studentIDs = list.Select(q => q.ID).ToList();
                RedisRowHelper<Student>.CreateInstance(redisConfig).Save(list);
                DisplayMessage(string.Format("Save Subjects success."));
            };

            Students();
            DisplayMessage(DateTime.Now.ToLongTimeString());

            Action StudentScores = () =>
            {
                var list = DataProviderService.Instance.GetStudentScores(subjectIDs, studentIDs);
                RedisRowHelper<StudentScore>.CreateInstance(redisConfig).Save(list);
                DisplayMessage(string.Format("Save Subjects success."));
            };

            StudentScores();
            DisplayMessage(DateTime.Now.ToLongTimeString());
        }

        #endregion
    }
}