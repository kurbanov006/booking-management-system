public static class CompanyMapping
{
    public static Company CompanyCreateToCompany(this CompanyCreateInfo companyCreate)
    {
        return new Company()
        {
            CompanyName = companyCreate.CompanyName,
            CityId = companyCreate.CityId
        };
    }

    public static CompanyReadInfo CompanyToCompanyRead(this Company company)
    {
        return new CompanyReadInfo()
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            CityId = company.CityId
        };
    }

    public static Company CompanyUpdateToCompany(this Company company, CompanyUpdateInfo companyUpdate)
    {
        company.CompanyName = companyUpdate.CompanyName;
        company.CityId = companyUpdate.CityId;

        return company;
    }
}