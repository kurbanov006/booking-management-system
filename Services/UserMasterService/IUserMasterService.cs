public interface IUserMasterService
{
    Task<bool> Create(UserMasterCreateInfo master);
    Task<bool> Update(UserMasterUpdateInfo master);
    Task<bool> Delete(int id);
    Task<UserMasterReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<UserMasterReadInfo>>? GetAll(UserMasterFilter filter);
}