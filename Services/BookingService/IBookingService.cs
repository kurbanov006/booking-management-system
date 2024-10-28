public interface IBookingService
{
    Task<bool> Create(BookingCreateInfo createInfo);
    Task<bool> Update(BookingUpdateInfo bookingUpdate);
    Task<bool> Delete(int id);
    Task<BookingReadInfo?> GetById(int id);
    PaginationResponse<IEnumerable<BookingReadInfo>>? GetAll(BookingsFilter filter);
    // Получает информацию о бронировании за всё время 
    PaginationResponse<IEnumerable<InfoBooking>> GetAllInfoBooking(BookingsFilter filter);
    // Получает информацию о бронировании за указаный день 
    PaginationResponse<IEnumerable<InfoBooking>> GetInfoBookingCurrentDay(BookingsFilter filter, int day);
    // Получаем Город и Количество где бывают бронирование 
    PaginationResponse<IEnumerable<GetCountryAndCountClient>> GetCountryAndCountClient(BookingsFilter filter);
}