using BlazorMongoDB.Data;

namespace BlazorMongoDB.IService
{
    public interface IUserService
    {
        void SaveOrUpdate(Users user);

        Users GetUser(string systemDetail, string ipAddress);

        List<Users> GetUsers();

        string Delete(string userId);
    }
}
