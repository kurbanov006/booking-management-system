
public class BookingService(AppDbContext context) : IBookingService
{
    public async Task<bool> Create(BookingCreateInfo createInfo)
    {
        try
        {
            var masterBooking = from b in context.Bookings
                                where b.MasterId == createInfo.MasterId && b.BookingDate.Date == createInfo.BookingDate.Date
                                select b;

            bool checkMaster = masterBooking.All(x => createInfo.StartTime >= x.EndTime);

            if (!checkMaster)
                return false;

            await context.Bookings.AddAsync(createInfo.BookingCreateInfoToBooking());
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Bookings? booking = await context.Bookings.FindAsync(id);
            if (booking is null)
                return false;

            booking.IsDeleted = true;
            booking.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<BookingReadInfo>>? GetAll(BookingsFilter filter)
    {
        try
        {
            IQueryable<Bookings> bookings = context.Bookings;
            if (bookings is null)
                return null;

            IQueryable<BookingReadInfo> bookingReads =
            (from b in bookings
             where b.IsDeleted == false
             select b)
            .Skip((filter!.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.BookinkgToBookingReadInfo());

            if (bookingReads is null)
                return null;

            int totalRecords = bookingReads.Count();

            return PaginationResponse<IEnumerable<BookingReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, bookingReads);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<BookingReadInfo?> GetById(int id)
    {
        try
        {
            Bookings? booking = await context.Bookings.FindAsync(id);
            if (booking is null)
                return null;

            if (booking.IsDeleted == false)
                return booking!.BookinkgToBookingReadInfo();

            else
                return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(BookingUpdateInfo bookingUpdate)
    {
        try
        {
            Bookings? booking = await context.Bookings.FindAsync(bookingUpdate.Id);
            if (booking is null)
                return false;

            if (booking.IsDeleted == true)
                return false;

            booking.UpdateAt = DateTime.UtcNow;
            context.Update(booking.BookingsUpdateToBookings(bookingUpdate));
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<InfoBooking>> GetAllInfoBooking(BookingsFilter filter)
    {
        IQueryable<InfoBooking> bookingInfo =
        from m in context.UserMasters
        join b in context.Bookings on m.Id equals b.MasterId
        join c in context.UserClients on b.ClientId equals c.Id
        where m.IsDeleted == false && b.IsDeleted == false && c.IsDeleted == false
        select new InfoBooking()
        {
            Id = b.Id,
            ClientId = c.Id,
            FullNameClient = c.FirstName + " " + c.LastName,
            MasterId = m.Id,
            FullNameMaster = m.FirstName + " " + m.LastName,
            DateBooking = b.BookingDate,
            StartTime = b.StartTime,
            EndTime = b.EndTime

        };

        if (bookingInfo is null)
            return null!;

        int totalRecords = bookingInfo.Count();

        return PaginationResponse<IEnumerable<InfoBooking>>
        .Create(filter.PageNumber, filter.PageSize, totalRecords, bookingInfo);
    }
}