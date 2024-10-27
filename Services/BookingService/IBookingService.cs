public interface IBookingService
{
    Task<bool> Create(BookingCreateInfo createInfo);
    Task<bool> Update(BookingUpdateInfo bookingUpdate);
    Task<bool> Delete(int id);
    Task<BookingReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<BookingReadInfo>>? GetAll(BookingsFilter filter);
    PaginationResponse<IEnumerable<InfoBooking>> GetAllInfoBooking(BookingsFilter filter);
}