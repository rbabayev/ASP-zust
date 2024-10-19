using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task AddUser(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userDal.GetAllAsync();
        }

        public async Task<User?> GetUserById(string id)
        {
            var user = await _userDal.GetAsync(u => u.Id == id);
            return user;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _userDal.GetAsync(u => u.UserName == username);
        }
    }
}
