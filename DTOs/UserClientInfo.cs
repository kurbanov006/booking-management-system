public readonly record struct UserClientCreateInfo(
    string FirstName,
    string LastName,
    string Email,
    int Age,
    int CityId
);

public readonly record struct UserClientReadInfo(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    int Age,
    int CityId,
    DateTime Date
);
public readonly record struct UserClientUpdateInfo(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    int Age,
    int CityId
);

