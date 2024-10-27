using Npgsql.Internal;
using Npgsql.Replication;

public static class BookingMapping
{
    public static Bookings BookingCreateInfoToBooking(this BookingCreateInfo bookingCreate)
    {
        return new Bookings()
        {
            ClientId = bookingCreate.ClientId,
            MasterId = bookingCreate.MasterId,
            CompanyId = bookingCreate.CompanyId,
            BookingDate = bookingCreate.BookingDate,
            StartTime = bookingCreate.StartTime,
            EndTime = bookingCreate.EndTime,
            Comment = bookingCreate.Comment,
            Status = bookingCreate.Status
        };
    }

    public static BookingReadInfo BookinkgToBookingReadInfo(this Bookings booking)
    {
        return new BookingReadInfo()
        {
            Id = booking.Id,
            ClientId = booking.ClientId,
            MasterId = booking.MasterId,
            CompanyId = booking.CompanyId,
            BookingDate = booking.BookingDate,
            StartTime = booking.StartTime,
            EndTime = booking.EndTime,
            Comment = booking.Comment,
            Status = booking.Status
        };
    }

    public static Bookings BookingsUpdateToBookings(this Bookings bookings, BookingUpdateInfo updateInfo)
    {
        bookings.ClientId = updateInfo.ClientId;
        bookings.MasterId = updateInfo.MasterId;
        bookings.CompanyId = updateInfo.CompanyId;
        bookings.BookingDate = updateInfo.BookingDate;
        bookings.StartTime = updateInfo.StartTime;
        bookings.EndTime = updateInfo.EndTime;
        bookings.Comment = updateInfo.Comment;
        bookings.Status = updateInfo.Status;
        return bookings;
    }
}