using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/clients/")]
public class UserClientController(IUserClientService clientService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] UserClientCreateInfo clientCreate)
    {
        bool res = await clientService.Create(clientCreate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UserClientUpdateInfo clientUpdate)
    {
        bool res = await clientService.Update(clientUpdate);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await clientService.Delete(id);

        if (!res)
            return BadRequest(ApiResponse<bool>.Fail(null, res));

        return Ok(ApiResponse<bool>.Succes(null, res));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        UserClientReadInfo? client = await clientService.GetById(id);
        if (client is null)
            return NotFound(ApiResponse<UserClientReadInfo?>.Fail(null, client));

        return Ok(ApiResponse<UserClientReadInfo?>.Succes(null, client));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromQuery] UserClientFitler filter)
    {
        PaginationResponse<IEnumerable<UserClientReadInfo>>? res =
        clientService.GetAll(filter);

        if (res is null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<UserClientReadInfo>>>.Fail(null, res));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<UserClientReadInfo>>>.Succes(null, res));
    }
}