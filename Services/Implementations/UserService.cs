using Microsoft.AspNetCore.Http.HttpResults;
using TEZ.Models;
using TEZ.Repositories.Interfaces;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;
    private readonly JwtServices _jwtServices;
    public UserService(IUserRepository userRepository,JwtServices jwtServices) {
        _userRepository = userRepository;
        _jwtServices = jwtServices;
    }

    public async Task<string> RegisterUserAsync(Register request){
        var exists = await _userRepository.GetByEmailAsync(request.email!);
        if (exists != null){
            throw new ArgumentException("User already exists");
        }
        // Console.WriteLine(request.name);
        // Console.WriteLine(request.email);
        // Console.WriteLine(request.password);
        // Console.WriteLine(request.role);
        UserBase user = new User {
            Name = request.name!,
            Email = request.email!,
            Password = BCrypt.Net.BCrypt.HashPassword(request.password),
            Pass = 0,
            Role = getRole(request.role!)
        };
        await _userRepository.RegisterUserAsync(user);
        return "User Registered successfully";
    }

    //login
    public async Task<GetLogin?> LoginUser(Login request) {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null) {
            throw new ArgumentException("User not found");
        }
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) {
            throw new ArgumentException("Invalid password");
        }
        var token = _jwtServices.GenerateJwtToken(user);
        //var dto;
        if (user is Admin admin){
            return new GetLogin {
            id = user.Id,
            name = user.Name,
            email = user.Email,
            password = user.Password,
            token = token,
            orgid = admin.OrgId,
            userid = admin.AdminId
            //role = user.Role
        };
            
        }
        else if (user is Driver driver){
            return new GetLogin {
            id = user.Id,
            name = user.Name,
            email = user.Email,
            password = user.Password,
            token = token,
            level = driver.Level,
            orgid = driver.OrgId,
           //role = "DRIVER"
            
             };
        }
        else if( user is User user1){
            return new GetLogin {
            //default user type return.
            id = user1.Id,
            name = user1.Name,
            email = user1.Email,
            password = user1.Password,
            token = token,
            role = user1.Role
        };
        }
        return new GetLogin {
            //default empty object.
        };
    }
    private Role getRole(string role){
        if (role.Equals("STUDENT")){
            return Role.STUDENT;
        }
        else {
            return Role.BASIC;
        }
    }

    
}