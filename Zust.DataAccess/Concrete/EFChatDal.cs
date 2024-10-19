using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFChatDal : EFEntityRepositoryBase<Chat, ZustDbContext>, IChatDal
    {
        public EFChatDal(ZustDbContext context) : base(context)
        {
        }
    }
}
