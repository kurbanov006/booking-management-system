public class UserMaster : BaseUser
{
    public string Specialist { get; set; } = string.Empty;
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
}