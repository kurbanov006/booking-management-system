using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/bookings/")]
public class BookingController(IBookingService bookingService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] BookingCreateInfo bookingCreate)
    {
        bool res = await bookingService.Create(bookingCreate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] BookingUpdateInfo updateInfo)
    {
        bool res = await bookingService.Update(updateInfo);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await bookingService.Delete(id);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        BookingReadInfo? booking = await bookingService.GetById(id);
        if (booking is null)
            return NotFound(ApiResponse<BookingReadInfo?>.Fail(null, booking));

        return Ok(ApiResponse<BookingReadInfo?>.Succes(null, booking));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromQuery] BookingsFilter filter)
    {
        PaginationResponse<IEnumerable<BookingReadInfo>>? res =
        bookingService.GetAll(filter);

        if (res is null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<BookingReadInfo>>>.Fail(null, res));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<BookingReadInfo>>>.Succes(null, res));
    }

    [HttpGet("get-info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAllInfoBooking([FromQuery] BookingsFilter filter)
    {
        PaginationResponse<IEnumerable<InfoBooking>>? res =
        bookingService.GetAllInfoBooking(filter);

        if (res is null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<InfoBooking>>>.Fail(null, res));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<InfoBooking>>>.Succes(null, res));
    }
}