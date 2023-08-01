using BlazorMongoDB.Data;

namespace BlazorMongoDB.IService
{
    public interface ICompaniesService
    {
        void SaveOrUpdate(Companies company);

        Companies GetCompany(string id);

        List<Companies> GetCompanies();

        string Delete(string companyId);
    }
}
