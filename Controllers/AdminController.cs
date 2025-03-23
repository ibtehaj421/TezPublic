using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("admin")]

public class AdminController : ControllerBase {

    public readonly DriverServices _driver;
    public AdminController(DriverServices driver)
    {
        _driver = driver;
    }
    [HttpPost("register/driver")]
    public async Task<string> AddDriver([FromBody] Register request){
        return await _driver.RegisterDriver(request);
    }
}