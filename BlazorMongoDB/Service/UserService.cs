using BlazorMongoDB.Data;
using BlazorMongoDB.IService;
using Microsoft.JSInterop;
using MongoDB.Driver;
using System;
using System.Data;
using Windows.Security.Cryptography.Core;
using Microsoft.JSInterop;

namespace BlazorMongoDB.Service
{
    public class UserService : IUserService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Users> _userTable = null;
        private readonly IJSRuntime _jsRuntime;

        public UserService(IJSRuntime jsRuntime)

        {
            _mongoClient = new MongoClient("mongodb://passkeydemo:EATgFnoPVE0Z8yvhOmxxAeaIQqSrZo15vH82SW4VVww5CziwapruXawT7hYewXVNR9HEk5Pk4qGLACDbqvEYzw==@passkeydemo.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@passkeydemo@");
            _database = _mongoClient.GetDatabase("PasskeyLogin");
            _userTable = _database.GetCollection<Users>("Users");
            _jsRuntime = jsRuntime;

        }
        public string Delete(string userId)
        {
            
            _userTable.DeleteOne(x=>x.Id == userId);
            DeleteUniqueIdentifier();

            return "Deleted";

        }
        private async Task DeleteUniqueIdentifier()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "userUniqueIdentifier");
        }

        public Users GetUser(string systemDetail, string ipAddress)
        {
            return _userTable.Find(x => x.SystemDetail == systemDetail && x.IPAddress == ipAddress).FirstOrDefault();
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


