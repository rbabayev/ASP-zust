using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserById(string id);

    }
}
