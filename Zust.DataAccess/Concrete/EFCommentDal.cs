using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFCommentDal : EFEntityRepositoryBase<Comment, ZustDbContext>, ICommentDal
    {
        public EFCommentDal(ZustDbContext context) : base(context)
        {
        }
    }
}
