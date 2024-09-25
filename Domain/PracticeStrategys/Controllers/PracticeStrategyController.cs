using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.PracticeStrategys.Controllers;

[ApiController]
[Route("api/v1/practice-strategy")]
public class PracticeStrategysController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetPracticeStrategys()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOnePracticeStrategys(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePracticeStrategy(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditPracticeStrategy(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeletePracticeStrategys(int id)
    {
        return Ok();
    }
}