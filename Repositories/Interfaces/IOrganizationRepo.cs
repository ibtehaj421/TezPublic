using TEZ.Models;

namespace TEZ.Repositories.Interfaces {
    public interface IOrganizationRepository {
        Task<Organization?> GetById(long id);
        Task<Organization?> GetByName(string name);

        Task RegisterOrganization(Organization request);
    }
}
