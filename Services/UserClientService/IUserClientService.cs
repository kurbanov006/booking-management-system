public interface IUserClientService
{
    Task<bool> Create(UserClientCreateInfo createUser);
    Task<bool> Update(UserClientUpdateInfo updateUser);
    Task<bool> Delete(int id);
    Task<UserClientReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<UserClientReadInfo>>? GetAll(UserClientFitler filter);
}