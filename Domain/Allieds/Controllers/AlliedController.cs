using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Allieds.Controllers;

[ApiController]
[Route("api/v1/allied")]
public class AlliedsController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllieds()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneAllieds(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAllied(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditAllied(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAllieds(int id)
    {
        return Ok();
    }
}