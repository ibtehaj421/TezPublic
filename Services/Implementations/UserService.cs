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
        Console.WriteLine(request.name);
        Console.WriteLine(request.email);
        Console.WriteLine(request.password);
        Console.WriteLine(request.role);
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
        var dto = new GetLogin {
            id = user.Id,
            name = user.Name,
            email = user.Email,
            password = user.Password,
            token = token,
        };
        return dto;
    }
    private Role getRole(string role){
        if (role.Equals("STUDENT")){
            return Role.STUDENT;
        }
        else {
            return Role.BASIC;
        }
    }

    private string generateAdminID(string name,int id){
        return name + "_" + id;
    }
}