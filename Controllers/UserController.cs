using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("user")]

public class UserController : ControllerBase {

    [Authorize]
    [HttpGet("get/test")]
    public IActionResult Get() {
        return Ok(new { message = "route successfully tested for auth." });
    }
}