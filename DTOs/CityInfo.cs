using Microsoft.AspNetCore.Identity.Data;

public readonly record struct CityCreateInfo(
    string CityName,
    int CountryId
);

public readonly record struct CityUpdateInfo(
    int Id,
    string CityName,
    int CountryId
);

public readonly record struct CityReadInfo(
    int Id,
    string CityName,
    DateTime Date,
    int CountryId
);



