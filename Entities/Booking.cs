public class Bookings : BaseEntity
{
    public int ClientId { get; set; }
    public UserClient? Client { get; set; }

    public int MasterId { get; set; }
    public UserMaster? Master { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public DateTime BookingDate { get; set; } 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Comment { get; set; }
    public string Status { get; set; } = string.Empty;
}