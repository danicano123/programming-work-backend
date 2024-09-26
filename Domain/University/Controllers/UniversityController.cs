using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.University.Controllers;

[ApiController]
[Route("api/v1/University")]
public class UniversityController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetUniversity()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneUniversity(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUniversity(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditUniversity(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        return Ok();
    }
}