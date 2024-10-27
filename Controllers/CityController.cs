using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/cities/")]
public class CityController(ICityService cityService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CityCreateInfo cityCreate)
    {
        bool res = await cityService.Create(cityCreate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] CityUpdateInfo cityUpdate)
    {
        bool res = await cityService.Update(cityUpdate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await cityService.Delete(id);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        CityReadInfo? city = await cityService.GetById(id);
        if (city is null)
            return NotFound(ApiResponse<CityReadInfo?>.Fail(null, city));

        return Ok(ApiResponse<CityReadInfo?>.Succes(null, city));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromQuery] CityFilter filter)
    {
        PaginationResponse<IEnumerable<CityReadInfo>>? res =
        cityService.GetAll(filter);

        if (res is null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<CityReadInfo>>>.Fail(null, res));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<CityReadInfo>>>.Succes(null, res));
    }
}