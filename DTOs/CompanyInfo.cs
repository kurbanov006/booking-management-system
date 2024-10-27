public readonly record struct CompanyCreateInfo(
    string CompanyName,
    int CityId
);
public readonly record struct CompanyReadInfo(
    int Id,
    string CompanyName,
    DateTime Date,
    int CityId
);
public readonly record struct CompanyUpdateInfo(
    int Id,
    string CompanyName,
    int CityId
);