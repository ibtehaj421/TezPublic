using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;


[ApiController]
[Route("auth")]
public class AuthController : ControllerBase {

    public IUserService _userService;
    public IOrganizationService _organizationService;
    public AuthController(IUserService userService,IOrganizationService organizationService) {
        _userService = userService;
        _organizationService = organizationService;
    }


    //logins
    [HttpPost("login/user")]
    public async Task<GetLogin?> Login([FromBody] Login request) {
        return await _userService.LoginUser(request);
    }

    [HttpPost("login/org")]
    public async Task<OrganizationDTO?> LoginOrg([FromBody] OrganizationDTO request) {
        return await _organizationService.LoginOrganization(request);
    }

    //registration
    [HttpPost("register/user")]
    public async Task<string> Register([FromBody] Register request) {
        if (request == null){
            return "Invalid user data";
        }
        return await _userService.RegisterUserAsync(request);
    }

    [HttpPost("register/admin")]
    public string RegisterAdmin([FromBody] Register request) {
        return "Success";
    }

    [HttpPost("register/driver")]
    public string RegisterDriver([FromBody] Register request) {
        return "Success";
    }

    [HttpPost("register/org")]
    public async Task<string> RegisterOrg([FromBody] OrganizationDTO request) {
        if(request == null){
            return "Invalid request";
        }
        return await _organizationService.RegisterOrganization(request);
    }
}