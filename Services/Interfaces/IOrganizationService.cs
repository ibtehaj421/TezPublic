public interface IOrganizationService {
    Task<string> RegisterOrganization(OrganizationDTO request);
    Task<OrganizationDTO?> LoginOrganization(OrganizationDTO request);
}