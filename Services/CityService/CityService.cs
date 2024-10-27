
public class CityService(AppDbContext context) : ICityService
{
    public async Task<bool> Create(CityCreateInfo cityCreate)
    {
        try
        {
            string? cityName = (from c in context.Cities
                                where c.CityName == cityCreate.CityName
                                select c.CityName).FirstOrDefault();

            if (cityName is not null)
                return false;

            await context.Cities.AddAsync(cityCreate.CityCreateToCity());
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
            City? city = await context.Cities.FindAsync(id);
            if (city is null)
                return false;

            city.IsDeleted = true;
            city.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<CityReadInfo>>? GetAll(CityFilter filter)
    {
        try
        {
            IQueryable<City> cities = context.Cities;
            if (cities is null)
                return null;

            IQueryable<CityReadInfo> cityRead =
            (from c in cities
             where c.IsDeleted == false
             select c)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.CityToCityRead());

            if (cityRead is null)
                return null;

            int totalRecords = cityRead.Count();

            return PaginationResponse<IEnumerable<CityReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, cityRead);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<CityReadInfo?> GetById(int id)
    {
        try
        {
            City? city = await context.Cities.FindAsync(id);
            if (city is null)
                return null;

            if (city.IsDeleted == false)
                return city.CityToCityRead();

            else
                return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(CityUpdateInfo cityUpdate)
    {
        try
        {
            City? city = await context.Cities.FindAsync(cityUpdate.Id);
            if (city is null)
                return false;

            if (city.IsDeleted == true)
                return false;

            city.UpdateAt = DateTime.UtcNow;
            context.Update(city.CityUpdateToCity(cityUpdate));
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