using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/countries/")]
public class CountryController(ICountryService countryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CountryCreateInfo countryCreate)
    {
        bool res = await countryService.Create(countryCreate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] CountryUpdateInfo countryUpdate)
    {
        bool res = await countryService.Update(countryUpdate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await countryService.Delete(id);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        CountryReadInfo? country = await countryService.GetById(id);
        if (country is null)
            return NotFound(ApiResponse<CountryReadInfo?>.Fail(null, country));

        return Ok(ApiResponse<CountryReadInfo?>.Succes(null, country));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromQuery] CountryFilter filter)
    {
        PaginationResponse<IEnumerable<CountryReadInfo>>? res =
        countryService.GetAll(filter);

        if (res is null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<CountryReadInfo>>>.Fail(null, res));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<CountryReadInfo>>>.Succes(null, res));
    }
}