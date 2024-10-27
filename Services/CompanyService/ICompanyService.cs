public interface ICompanyService
{
    Task<bool> Create(CompanyCreateInfo companyCreate);
    Task<bool> Update(CompanyUpdateInfo companyUpdate);
    Task<bool> Delete(int id);
    Task<CompanyReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<CompanyReadInfo>>? GetAll(CompanyFilter filter);
}