using Npgsql.Internal;

public static class CountryMapping
{
    public static Country CreateCountryToCountry(this CountryCreateInfo countryCreate)
    {
        return new Country()
        {
            CountryName = countryCreate.CountryName,

        };
    }

    public static CountryReadInfo CountryToCountryReadInfo(this Country country)
    {
        return new CountryReadInfo()
        {
            Id = country.Id,
            CountryName = country.CountryName,
            Date = country.CreatedAt
        };
    }

    public static Country CountryUpdateToCountry(this Country country, CountryUpdateInfo countryUpdate)
    {
        country.CountryName = countryUpdate.CountryName;
        return country;
    }
}