public readonly record struct BookingCreateInfo(
    int ClientId,
    int MasterId,
    int CompanyId,
     DateTime BookingDate,
     DateTime StartTime,
     DateTime EndTime,
     string? Comment,
     string Status
);

public readonly record struct BookingReadInfo(
    int Id,
    int ClientId,
    int MasterId,
    int CompanyId,
     DateTime BookingDate,
     DateTime StartTime,
     DateTime EndTime,
     string? Comment,
     string Status
);

public readonly record struct BookingUpdateInfo(
    int Id,
    int ClientId,
    int MasterId,
    int CompanyId,
     DateTime BookingDate,
     DateTime StartTime,
     DateTime EndTime,
     string? Comment,
     string Status
);



public readonly record struct InfoBooking(
    int Id,
    int ClientId,
    string FullNameClient,
    int MasterId,
    string FullNameMaster,
    DateTime DateBooking,
    DateTime StartTime,
    DateTime EndTime
);