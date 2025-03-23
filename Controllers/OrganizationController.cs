using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("org")]
public class OrganizationController : ControllerBase {

    public IUserService _userService;
    public AdminServices _adminServices;
    public OrganizationController(IUserService userService, AdminServices admin) {
        _userService = userService;
        _adminServices = admin;
    }

    [Authorize]
    [HttpPost("register/admin")]
    public async Task<string> RegisterAdmin([FromBody] Register request) {
        return await _adminServices.RegisterAdmin(request);
    }
}
