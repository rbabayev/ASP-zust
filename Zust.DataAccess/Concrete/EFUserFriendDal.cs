using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFUserFriendDal : EFEntityRepositoryBase<UserFriend, ZustDbContext>, IUserFriendDal
    {
        public EFUserFriendDal(ZustDbContext context) : base(context)
        {
        }
    }
}
