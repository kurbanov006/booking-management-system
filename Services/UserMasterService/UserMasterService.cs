
public class UserMasterService(AppDbContext context) : IUserMasterService
{
    public async Task<bool> Create(UserMasterCreateInfo master)
    {
        try
        {
            string? email = (from u in context.UserMasters
                             where u.Email == master.Email
                             select u.Email).FirstOrDefault();

            if (email is not null)
                return false;

            await context.UserMasters.AddAsync(master.CreateUserMasterToUserMaster());
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
            UserMaster? master = await context.UserMasters.FindAsync(id);
            if (master is null)
                return false;

            master.IsDeleted = true;
            master.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<UserMasterReadInfo>>? GetAll(UserMasterFilter filter)
    {
        try
        {
            IQueryable<UserMaster> masters = context.UserMasters;
            if (masters is null)
                return null;

            IQueryable<UserMasterReadInfo> userMasters =
            (from c in masters
             where c.IsDeleted == false
             select c)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.UserMasterToUserMasterReadInfo());

            if (userMasters is null)
                return null;

            int totalRecords = userMasters.Count();

            return PaginationResponse<IEnumerable<UserMasterReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, userMasters);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<UserMasterReadInfo?> GetById(int id)
    {
        try
        {
            UserMaster? master = await context.UserMasters.FindAsync(id);
            if (master is null)
                return null;

            if (master.IsDeleted == false)
                return master.UserMasterToUserMasterReadInfo();

            else
                return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(UserMasterUpdateInfo master)
    {
        try
        {
            UserMaster? masterUpdate = await context.UserMasters.FindAsync(master.Id);
            if (masterUpdate is null)
                return false;

            if (masterUpdate.IsDeleted == true)
                return false;

            masterUpdate.UpdateAt = DateTime.UtcNow;
            context.Update(masterUpdate.UserMasterUpdateToUserMaster(master));
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