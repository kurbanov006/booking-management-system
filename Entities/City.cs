public class City : BaseEntity
{
    public string CityName { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public List<BaseUser> Users { get; set; } = [];

}