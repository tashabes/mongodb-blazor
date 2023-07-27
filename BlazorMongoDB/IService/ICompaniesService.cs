using BlazorMongoDB.Data;

namespace BlazorMongoDB.IService
{
    public interface ICompaniesService
    {
        void SaveOrUpdate(Companies company);

        Companies GetCompany(string name);

        List<Companies> GetCompanies();

        string Delete(string companyId);
    }
}
