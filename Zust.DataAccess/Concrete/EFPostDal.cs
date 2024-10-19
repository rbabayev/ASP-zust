using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFPostDal : EFEntityRepositoryBase<Post, ZustDbContext>, IPostDal
    {
        public EFPostDal(ZustDbContext context) : base(context)
        {
        }
    }
}
