using TEZ.Models;
using TEZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TEZ.DbContext;

namespace TEZ.Repositories.Implementations {
    public class UserRepository : IUserRepository {

        private readonly TezDbContext _context;

        public UserRepository(TezDbContext context) {
            _context = context;
        }

        public async Task<UserBase?> GetByEmailAsync(string Email) {
            var user = await _context.UserBases.FirstOrDefaultAsync(u=>u.Email == Email);
            if (user == null){
                return null;
            }
            return user;
        }

        // public async Task<User> GetByUsernameAsync(string name) {
        //     return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        // }
        public async Task RegisterUserAsync(UserBase user) {
            // var exists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            // if (exists != null) {
            //     throw new InvalidOperationException("User with the same email already exists.");
            // }
            await _context.UserBases.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task<int> GetCount(){
            return await _context.UserBases.CountAsync();
        }
    }
}