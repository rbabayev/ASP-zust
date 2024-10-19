using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFFriendRequest : EFEntityRepositoryBase<FriendRequest, ZustDbContext>, IFriendRequestDal
    {
        public EFFriendRequest(ZustDbContext context) : base(context)
        {
        }
    }
}
