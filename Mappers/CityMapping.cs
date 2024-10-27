public static class CityMapping
{
    public static City CityCreateToCity(this CityCreateInfo cityCreate)
    {
        return new City()
        {
            CityName = cityCreate.CityName,
            CountryId = cityCreate.CountryId
        };
    }

    public static CityReadInfo CityToCityRead(this City city)
    {
        return new CityReadInfo()
        {
            Id = city.Id,
            CityName = city.CityName,
            CountryId = city.CountryId,
            Date = city.CreatedAt
        };
    }

    public static City CityUpdateToCity(this City city, CityUpdateInfo cityUpdate)
    {
        city.CityName = cityUpdate.CityName;
        city.CountryId = cityUpdate.CountryId;

        return city;
    }
}