//using System.Threading.Tasks;
using TEZ.Models;

namespace TEZ.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserBase?> GetByEmailAsync(string email);
        Task RegisterUserAsync(UserBase user);
    }
}