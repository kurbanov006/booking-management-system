public interface ICountryService
{
    Task<bool> Create(CountryCreateInfo countryCreate);
    Task<bool> Update(CountryUpdateInfo countryUpdate);
    Task<bool> Delete(int id);
    Task<CountryReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<CountryReadInfo>>? GetAll(CountryFilter? filter);
}