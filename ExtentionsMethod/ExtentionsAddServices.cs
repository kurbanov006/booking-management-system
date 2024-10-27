public static class ExtentionsAddServices
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IUserClientService, UserClientService>();
        services.AddScoped<IUserMasterService, UserMasterService>();
        services.AddScoped<IBookingService, BookingService>();
    }
}