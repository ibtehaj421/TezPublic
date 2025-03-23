using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("org")]
public class OrganizationController : ControllerBase {

    public IUserService _userService;
    public OrganizationController(IUserService userService) {
        _userService = userService;
    }

    [Authorize]
    [HttpPost("admin/register")]
    public string RegisterAdmin([FromBody] Register request) {
        return "success";
    }
}
