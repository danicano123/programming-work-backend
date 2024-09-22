using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.NormativeAspects.Controllers;

[ApiController]
[Route("api/v1/normative-aspects")]
public class NormativeAspectsController : ControllerBase{

    [HttpGet]
    public async Task<IActionResult> GetNormativeAspects(){
        return Ok();
    }
}