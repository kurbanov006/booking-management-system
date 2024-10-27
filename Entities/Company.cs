public class Company : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;
    public int CityId { get; set; }
    public City? City { get; set; }
    public List<UserMaster> UserMasters { get; set; } = [];
}