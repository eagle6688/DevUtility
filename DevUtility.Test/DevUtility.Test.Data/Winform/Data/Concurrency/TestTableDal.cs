using DevUtility.Com.Base;
using DevUtility.Com.Data;
using DevUtility.Test.Common.Winform;
using DevUtility.Test.Model.Winform.Data.Concurrency;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Data.Winform.Data.Concurrency
{
    public class TestTableDal : BaseDal<TestTableDal>
    {
        #region Add

        public long Add(TestTable entity)
        {
            var properties = PropertyHelper.GetPropertiesForDatabase<TestTable>(entity, "ID");
            var sqlString = EntityHelper.GetInsertSqlWithIdentity("TestTable", properties);
            var parameters = EntityHelper.GetSqlParameters<TestTable>(entity, properties);
            return GetValue<long>(AppConfigHelper.TestDBConn, sqlString, parameters);
        }

        public long Add(string name)
        {
            string sqlString = @"declare @ID int
                                select @ID = ID
                                from TestTable
                                where Name = @Name and IsDeleted = 0
                                if(@ID > 0)
                                begin
                                select @ID
                                end
                                else
                                begin
                                    insert into TestTable(Name, IsDeleted) values(@Name, 0)
	                                select @@IDENTITY;
                                end";

            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name)
            };

            return GetValue<long>(AppConfigHelper.TestDBConn, sqlString, sqlParameters);
        }

        #endregion
    }
}