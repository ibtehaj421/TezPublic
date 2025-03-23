using System.Threading.Tasks;
using TEZ.Models;
using TEZ.Repositories.Interfaces;
public class AdminServices {
    // Admin-specific services go here.
    private readonly IUserRepository _userRepository;
    private readonly IOrganizationRepository _organizationRepository;
    public AdminServices(IUserRepository userRepository, IOrganizationRepository organizationRepository) {
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
    }

    public async Task<string> RegisterAdmin(Register request){
        var exists = await _userRepository.GetByEmailAsync(request.email!);
        if (exists != null){
            throw new ArgumentException("User already exists");
        }
        var org = await _organizationRepository.GetByName(request.orgName!);
        UserBase user = new Admin {
            Name = request.name!,
            Email = request.email!,
            Password = BCrypt.Net.BCrypt.HashPassword(request.password),
            //Role = "Admin",
            OrgId = Convert.ToInt32(org!.Id),
            AdminId = generateAdminID(request.orgName!, await _userRepository.GetCount()+1) // Placeholder for admin ID generation. Replace with actual logic.
        };
        await _userRepository.RegisterUserAsync(user);
        return "Admin added successfully";
    }

    private string generateAdminID(string name,int id){
        return name + "_" + id;
    }
}