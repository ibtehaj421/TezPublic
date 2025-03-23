using System.Threading.Tasks;
using TEZ.Models;
using TEZ.Repositories.Interfaces;

public class DriverServices {
    private readonly IUserRepository _userRepository;
    private readonly IOrganizationRepository _organizationRepository; ///
    public DriverServices(IUserRepository userRepository, IOrganizationRepository organizationRepository) {
        _userRepository = userRepository;
        _organizationRepository = organizationRepository; //
    }

    public async Task<string> RegisterDriver(Register request){
        var exists = await _userRepository.GetByEmailAsync(request.email!);
        if (exists!= null){
            throw new ArgumentException("User already exists");
        }
        //var org = await _organizationRepository.GetById(request.orgId);
        UserBase user = new Driver {
            Name = request.name!,
            Email = request.email!,
            Password = BCrypt.Net.BCrypt.HashPassword(request.password),
            Level = request.level,
            OrgId = request.orgId
            //Role = request.role
        };
        await _userRepository.RegisterUserAsync(user);
        return "Driver registered successfully";
    }
}
