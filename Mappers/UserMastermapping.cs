public static class UserMasterMapping
{
    public static UserMaster CreateUserMasterToUserMaster(this UserMasterCreateInfo master)
    {
        return new UserMaster()
        {
            FirstName = master.FirstName,
            LastName = master.LastName,
            Email = master.Email,
            Age = master.Age,
            Specialist = master.Specialist,
            CompanyId = master.CompanyId,
            CityId = master.CityId
        };
    }

    public static UserMasterReadInfo UserMasterToUserMasterReadInfo(this UserMaster master)
    {
        return new UserMasterReadInfo()
        {
            Id = master.Id,
            FirstName = master.FirstName,
            LastName = master.LastName,
            Email = master.Email,
            Age = master.Age,
            Date = master.CreatedAt,
            Specialist = master.Specialist,
            CompanyId = (int)master.CompanyId!,
            CityId = master.CityId
        };
    }

    public static UserMaster UserMasterUpdateToUserMaster(
        this UserMaster master, UserMasterUpdateInfo updateInfo)
    {
        master.FirstName = updateInfo.FirstName;
        master.LastName = updateInfo.LastName;
        master.Email = updateInfo.Email;
        master.CompanyId = updateInfo.CompanyId;
        master.Specialist = updateInfo.Specialist;
        master.Age = updateInfo.Age;
        master.CityId = updateInfo.CityId;

        return master;
    }
}