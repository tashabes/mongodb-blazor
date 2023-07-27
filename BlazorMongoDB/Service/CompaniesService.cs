using BlazorMongoDB.Data;
using BlazorMongoDB.IService;
using MongoDB.Driver;
using System.Data;

namespace BlazorMongoDB.Service
{
    public class CompaniesService : ICompaniesService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Companies> _companyTable = null;

        public CompaniesService()
        {
            _mongoClient = new MongoClient("mongodb://passkeydemo:EATgFnoPVE0Z8yvhOmxxAeaIQqSrZo15vH82SW4VVww5CziwapruXawT7hYewXVNR9HEk5Pk4qGLACDbqvEYzw==@passkeydemo.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@passkeydemo@");
            _database = _mongoClient.GetDatabase("PasskeyLogin");
            _companyTable = _database.GetCollection<Companies>("Companies");
        }
        public string Delete(string companyId)
        {
            _companyTable.DeleteOne(x => x.Id == companyId);
            return "Deleted";

        }

        public List<Companies> GetCompanies()
        {
            return _companyTable.Find(FilterDefinition<Companies>.Empty).ToList();
        }

        public Companies GetCompany(string name)
        {
            return _companyTable.Find(x => x.Name == name).FirstOrDefault();
        }

        public void SaveOrUpdate(Companies company)
        {
            var studentObj = _companyTable.Find(x => x.Id == company.Id).FirstOrDefault();
            if (studentObj == null)
            {
                _companyTable.InsertOne(company);
            }
            else
            {
                _companyTable.ReplaceOne(x => x.Id == company.Id, company);
            }
        }

    }
}
