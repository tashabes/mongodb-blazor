using BlazorMongoDB.Data;
using BlazorMongoDB.IService;
using MongoDB.Driver;
using System.Data;

namespace BlazorMongoDB.Service
{
    public class UserService : IUserService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Users> _userTable = null;

        public UserService()
        {
            _mongoClient = new MongoClient("mongodb://passkeydemo:EATgFnoPVE0Z8yvhOmxxAeaIQqSrZo15vH82SW4VVww5CziwapruXawT7hYewXVNR9HEk5Pk4qGLACDbqvEYzw==@passkeydemo.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@passkeydemo@");
            _database = _mongoClient.GetDatabase("PasskeyLogin");
            _userTable = _database.GetCollection<Users>("Users");
        }
        public string Delete(string userId)
        {
            _userTable.DeleteOne(x=>x.Id == userId);
            return "Deleted";

        }

        public Users GetUser(string systemDetail)
        {
           return _userTable.Find(x=>x.SystemDetail == systemDetail).FirstOrDefault();

        }

        public List<Users> GetUsers()
        {
            return _userTable.Find(FilterDefinition<Users>.Empty).ToList();
        }

        public void SaveOrUpdate(Users user)
        {
            var studentObj = _userTable.Find(x=>x.Id ==user.Id).FirstOrDefault();
            if(studentObj == null)
            {
                _userTable.InsertOne(user);
            } else
            {
                _userTable.ReplaceOne(x => x.Id == user.Id, user);
            }
        }
    }
}
