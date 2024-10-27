using System.Runtime.CompilerServices;

public readonly record struct UserMasterCreateInfo(
    string FirstName,
    string LastName,
    string Email,
    string Specialist,
    int CompanyId,
    int Age,
    int CityId
);

public readonly record struct UserMasterReadInfo(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Specialist,
    int CompanyId,
    int Age,
    int CityId,
    DateTime Date
);
public readonly record struct UserMasterUpdateInfo(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Specialist,
    int CompanyId,
    int Age,
    int CityId
);

