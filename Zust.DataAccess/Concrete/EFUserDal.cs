using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFUserDal : EFEntityRepositoryBase<User, ZustDbContext>, IUserDal
    {
        public EFUserDal(ZustDbContext context) : base(context)
        {
        }
    }
}
