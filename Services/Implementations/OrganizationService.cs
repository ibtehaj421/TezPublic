using TEZ.Models;
using TEZ.Repositories.Interfaces;


public class OrganizationService : IOrganizationService {
    private readonly IOrganizationRepository _organizationRepository;
    private readonly JwtServices _jwtServices;
    public OrganizationService(IOrganizationRepository organizationRepository, JwtServices jwtServices) {
        _organizationRepository = organizationRepository;
        _jwtServices = jwtServices;
    }

    public async Task<string> RegisterOrganization(OrganizationDTO request){
        var exists = await _organizationRepository.GetByName(request.Name);
        if (exists != null){
            throw new ArgumentException("Organization already exists");
        }
        Organization add;
        if (request.type == "CORP_ADMIN") {
            add = new CorpAdmin {
                Name = request.Name!,
                //Company = request.Institue,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };
        }
        else {
            add = new EduAdmin {
                Name = request.Name!,
                //Institute = request.Institue,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };
        }
        await _organizationRepository.RegisterOrganization(add);
        return "Organization Registered successfully";
    }

    public async Task<OrganizationDTO?> LoginOrganization(OrganizationDTO request){
        var org = await _organizationRepository.GetByName(request.Name);
        if (org == null) {
            throw new ArgumentException("Org not found");
        }
        if (!BCrypt.Net.BCrypt.Verify(request.Password, org.Password)) {
            throw new ArgumentException("Invalid password");
        }
        var token = _jwtServices.GenerateJwtTokenOrg(org);
        var dto = new OrganizationDTO {
            Name = org.Name,
            //Institute = org.Institute,
            type = org.GetType().Name,
            Password = org.Password,
            Id = org.Id,
            token = token
        };
        return dto;
    }
}