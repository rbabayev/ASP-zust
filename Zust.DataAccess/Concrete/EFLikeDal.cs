using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFLikeDal : EFEntityRepositoryBase<Like, ZustDbContext>, ILikeDal
    {
        public EFLikeDal(ZustDbContext context) : base(context)
        {
        }
    }
}
