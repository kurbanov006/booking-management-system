
public class UserClientService(AppDbContext context) : IUserClientService
{
    public async Task<bool> Create(UserClientCreateInfo createUser)
    {
        try
        {
            string? email = (from uc in context.UserClients
                             where uc.Email == createUser.Email
                             select uc.Email).FirstOrDefault();

            if (email is not null)
                return false;

            await context.UserClients.AddAsync(createUser.CreateUserClientToUserClient());
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
            UserClient? client = await context.UserClients.FindAsync(id);
            if (client is null)
                return false;

            client.IsDeleted = true;
            client.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<UserClientReadInfo>>? GetAll(UserClientFitler filter)
    {
        try
        {
            IQueryable<UserClient> clients = context.UserClients;
            if (clients is null)
                return null;

            IQueryable<UserClientReadInfo> clientRead =
            (from c in clients
             where c.IsDeleted == false
             select c)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.UserClientToUserClientReadInfo());

            if (clientRead is null)
                return null;

            int totalRecords = clientRead.Count();

            return PaginationResponse<IEnumerable<UserClientReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, clientRead);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<UserClientReadInfo?> GetById(int id)
    {
        try
        {
            UserClient? client = await context.UserClients.FindAsync(id);
            if (client is null)
                return null;

            if (client.IsDeleted == false)
                return client.UserClientToUserClientReadInfo();

            else
                return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(UserClientUpdateInfo updateUser)
    {
        try
        {
            UserClient? client = await context.UserClients.FindAsync(updateUser.Id);
            if (client is null)
                return false;

            if (client.IsDeleted == true)
                return false;

            client.UpdateAt = DateTime.UtcNow;
            context.Update(client.UserClientUpdateToUserClient(updateUser));
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