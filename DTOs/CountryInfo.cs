public readonly record struct CountryCreateInfo(
    string CountryName
);

public readonly record struct CountryUpdateInfo(
    int Id,
    string CountryName
);

public readonly record struct CountryReadInfo(
    int Id,
    string CountryName,
    DateTime Date
);

