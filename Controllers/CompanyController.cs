using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/companies/")]
public class CompanyController(ICompanyService companyService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CompanyCreateInfo companyCreate)
    {
        bool res = await companyService.Create(companyCreate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] CompanyUpdateInfo companyUpdate)
    {
        bool res = await companyService.Update(companyUpdate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await companyService.Delete(id);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        CompanyReadInfo? company = await companyService.GetById(id);
        if (company is null)
            return NotFound(ApiResponse<CompanyReadInfo?>.Fail(null, company));

        return Ok(ApiResponse<CompanyReadInfo?>.Succes(null, company));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromQuery] CompanyFilter filter)
    {
        PaginationResponse<IEnumerable<CompanyReadInfo>>? res =
        companyService.GetAll(filter);

        if (res is null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<CompanyReadInfo>>>.Fail(null, res));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<CompanyReadInfo>>>.Succes(null, res));
    }
}