
using System.Net.Http.Headers;

public class CountryService(AppDbContext context) : ICountryService
{
    public async Task<bool> Create(CountryCreateInfo countryCreate)
    {
        try
        {
            string? countryName = (from c in context.Countries
                                   where c.CountryName == countryCreate.CountryName
                                   select c.CountryName).FirstOrDefault();
            if (countryName is not null)
                return false;

            await context.Countries.AddAsync(countryCreate.CreateCountryToCountry());
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
            Country? country = await context.Countries.FindAsync(id);
            if (country is null)
                return false;

            country.IsDeleted = true;
            country.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<CountryReadInfo>>? GetAll(CountryFilter? filter)
    {
        try
        {
            IQueryable<Country> countries = context.Countries;
            if (countries is null)
                return null;

            IQueryable<CountryReadInfo> countryReads =
            (from c in countries
             where c.IsDeleted == false
             select c)
            .Skip((filter!.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.CountryToCountryReadInfo());

            if (countryReads is null)
                return null;
            int totalRecords = countryReads.Count();

            return PaginationResponse<IEnumerable<CountryReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, countryReads);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<CountryReadInfo?> GetById(int id)
    {
        try
        {
            Country? country = await context.Countries.FindAsync(id);
            if (country is null)
                return null;

            if (country.IsDeleted == false)
                return country!.CountryToCountryReadInfo();

            else
                return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(CountryUpdateInfo countryUpdate)
    {
        try
        {
            Country? country = await context.Countries.FindAsync(countryUpdate.Id);
            if (country is null)
                return false;

            if (country.IsDeleted == true)
                return false;

            country.UpdateAt = DateTime.UtcNow;
            context.Update(country.CountryUpdateToCountry(countryUpdate));
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