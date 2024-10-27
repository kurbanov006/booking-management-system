public static class UserClientMapping
{
    public static UserClient CreateUserClientToUserClient(this UserClientCreateInfo createInfo)
    {
        return new UserClient()
        {
            FirstName = createInfo.FirstName,
            LastName = createInfo.LastName,
            Email = createInfo.Email,
            Age = createInfo.Age,
            CityId = createInfo.CityId
        };
    }

    public static UserClientReadInfo UserClientToUserClientReadInfo(this UserClient client)
    {
        return new UserClientReadInfo()
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Age = client.Age,
            Date = client.CreatedAt,
            CityId = client.CityId
        };
    }

    public static UserClient UserClientUpdateToUserClient(
        this UserClient client, UserClientUpdateInfo updateInfo)
    {
        client.FirstName = updateInfo.FirstName;
        client.LastName = updateInfo.LastName;
        client.Email = updateInfo.Email;
        client.Age = updateInfo.Age;
        client.CityId = updateInfo.CityId;

        return client;
    }
}