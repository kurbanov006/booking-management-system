public interface ICityService
{
    Task<bool> Create(CityCreateInfo cityCreate);
    Task<bool> Update(CityUpdateInfo cityUpdate);
    Task<bool> Delete(int id);
    Task<CityReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<CityReadInfo>>? GetAll(CityFilter filter);
}