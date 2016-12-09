using DevUtility.Com.Base;
using DevUtility.Com.Data;
using DevUtility.Test.Model.Com;
using DevUtility.Test.Model.Winform.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Com
{
    public class DataProviderService : SingletonInstance<DataProviderService>
    {
        #region TestToModels

        public List<TestToModel> TestToModels
        {
            get
            {
                List<TestToModel> list = new List<TestToModel>();

                for (int i = 0; i < 100; i++)
                {
                    list.Add(new TestToModel
                    {
                        ID = i + 1,
                        LongID = i + 1000,
                        Name = string.Format("My Test{0}", (i + 1).ToString()),
                        Age = 29
                    });
                }

                return list;
            }
        }

        #endregion

        #region Get Subjects

        public List<Subject> GetSubjects()
        {
            List<Subject> list = new List<Subject>();

            list.Add(new Subject
            {
                ID = 1,
                Name = "语文"
            });

            list.Add(new Subject
            {
                ID = 2,
                Name = "数学"
            });

            list.Add(new Subject
            {
                ID = 3,
                Name = "英语"
            });

            list.Add(new Subject
            {
                ID = 4,
                Name = "物理"
            });

            list.Add(new Subject
            {
                ID = 5,
                Name = "生物"
            });

            list.Add(new Subject
            {
                ID = 6,
                Name = "化学"
            });

            list.Add(new Subject
            {
                ID = 7,
                Name = "政治"
            });

            list.Add(new Subject
            {
                ID = 8,
                Name = "历史"
            });

            list.Add(new Subject
            {
                ID = 9,
                Name = "地理"
            });

            list.Add(new Subject
            {
                ID = 10,
                Name = "美术"
            });

            list.Add(new Subject
            {
                ID = 11,
                Name = "体育"
            });

            list.Add(new Subject
            {
                ID = 12,
                Name = "音乐"
            });

            return list;
        }

        #endregion

        #region Get Teachers

        public List<Teacher> GetTeachers(long num)
        {
            List<Teacher> list = new List<Teacher>();

            for (int i = 0; i < num; i++)
            {
                int id = i + 1;

                list.Add(new Teacher
                {
                    ID = id,
                    Name = string.Format("Teacher{0}", id.ToString()),
                    Gender = RandomHelper.GetRandomNumber(0, 2),
                    Age = RandomHelper.GetRandomNumber(21, 61),
                    SubjectID = RandomHelper.GetRandomNumber(1, 13)
                });
            }

            return list;
        }

        #endregion

        #region Get Students

        public List<Student> GetStudents(long num)
        {
            List<Student> list = new List<Student>();

            for (int i = 0; i < num; i++)
            {
                int id = i + 1;

                list.Add(new Student
                {
                    ID = id,
                    Name = string.Format("Student{0}", id.ToString()),
                    Gender = RandomHelper.GetRandomNumber(0, 2),
                    Age = RandomHelper.GetRandomNumber(14, 20)
                });
            }

            return list;
        }

        #endregion

        #region Get StudentScores

        public List<StudentScore> GetStudentScores(List<int> subjectIDs, List<long> studentIDs)
        {
            List<StudentScore> list = new List<StudentScore>();

            foreach (int subjectID in subjectIDs)
            {
                foreach (long studentID in studentIDs)
                {
                    list.Add(new StudentScore
                    {
                        StudentID = studentID,
                        SubjectID = subjectID,
                        Score = RandomHelper.GetRandomNumber(20, 101)
                    });
                }
            }

            return list;
        }

        #endregion
    }
}