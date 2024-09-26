using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Focuses.Controllers;

[ApiController]
[Route("api/v1/focus")]
public class FocusController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetFocus()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneFocus(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFocus(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditFocus(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteFocus(int id)
    {
        return Ok();
    }
}