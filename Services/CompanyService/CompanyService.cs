
using Microsoft.AspNetCore.Routing.Template;

public class CompanyService(AppDbContext context) : ICompanyService
{
    public async Task<bool> Create(CompanyCreateInfo companyCreate)
    {
        try
        {
            string? nameCompany = (from c in context.Companies
                                   where c.CompanyName == companyCreate.CompanyName
                                   select c.CompanyName).FirstOrDefault();

            if (nameCompany is not null)
                return false;

            await context.Companies.AddAsync(companyCreate.CompanyCreateToCompany());
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Company? company = await context.Companies.FindAsync(id);
            if (company is null)
                return false;

            company.IsDeleted = true;
            company.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<CompanyReadInfo>>? GetAll(CompanyFilter filter)
    {
        try
        {
            IQueryable<Company> companies = context.Companies;
            if (companies is null)
                return null;

            IQueryable<CompanyReadInfo> companyReads =
            (from c in companies
             where c.IsDeleted == false
             select c)
            .Skip((filter!.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.CompanyToCompanyRead());

            if (companyReads is null)
                return null;

            int totalRecords = companyReads.Count();

            return PaginationResponse<IEnumerable<CompanyReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, companyReads);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<CompanyReadInfo?> GetById(int id)
    {
        try
        {
            Company? company = await context.Companies.FindAsync(id);
            if (company is null)
                return null;

            if (company.IsDeleted == false)
                return company!.CompanyToCompanyRead();

            else
                return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(CompanyUpdateInfo companyUpdate)
    {
        try
        {
            Company? company = await context.Companies.FindAsync(companyUpdate.Id);
            if (company is null)
                return false;

            if (company.IsDeleted == true)
                return false;

            company.UpdateAt = DateTime.UtcNow;
            context.Update(company.CompanyUpdateToCompany(companyUpdate));
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }
}
