using DevUtility.Win.Services.AppService;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Database.MongoDBTest
{
    public class QueryService : BaseAppService
    {
        #region Variables

        string connectionString = "";

        #endregion

        #region Constructor

        public QueryService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Start

        public override void Start()
        {
            MongoUrl mongoUrl = MongoUrl.Create(connectionString);
            IMongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(mongoUrl.DatabaseName);
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Profiles");
            var filter = Builders<BsonDocument>.Filter.Eq("User", "1300023121843");
            var fields = Builders<BsonDocument>.Projection.Exclude("_id").Include("User");
            var result = collection.Find(filter).Project(fields).FirstOrDefault();
            var dic = BsonSerializer.Deserialize<Dictionary<string, string>>(result);
            DisplayMessage(dic["User"]);

            filter = Builders<BsonDocument>.Filter.Eq("DMU.Name", "American Express Global Business Travel"); // & Builders<BsonDocument>.Filter.BitsAllSet("DMU.$", 1)
            fields = Builders<BsonDocument>.Projection.Exclude("_id").Include("DMU.$");
            result = database.GetCollection<BsonDocument>("GlobalAccounts").Find(filter).Project(fields).FirstOrDefault();

            if (result != null)
            {
                var dResult = BsonSerializer.Deserialize<Dictionary<string, BsonArray>>(result);
                DisplayMessage(dResult["DMU"].ToJson());

                var bArray = dResult["DMU"];
                dic = BsonSerializer.Deserialize<Dictionary<string, string>>(bArray[0].AsBsonDocument);
                DisplayMessage(dic["ID"]);
            }
            else
            {
                DisplayMessage("No data!");
            }
        }

        #endregion
    }
}