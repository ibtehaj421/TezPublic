using TEZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TEZ.DbContext;
using TEZ.Models;
namespace TEZ.Repositories.Implementations {

    public class OrganizationRepository : IOrganizationRepository {
        private readonly TezDbContext _context;

        public OrganizationRepository(TezDbContext context) {
            _context = context;
        }

        public async Task<Organization?> GetById(long id) {
            return await _context.Organizations.FindAsync(id);
        }
        public async Task<Organization?> GetByName(string name) {
            return await _context.Organizations.FirstOrDefaultAsync(u=>u.Name == name);
        }

        public async Task RegisterOrganization(Organization add) {
            await _context.Organizations.AddAsync(add);
            await _context.SaveChangesAsync();
        }

    }
}