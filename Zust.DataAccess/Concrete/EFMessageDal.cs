using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFMessageDal : EFEntityRepositoryBase<Message, ZustDbContext>, IMessageDal
    {
        public EFMessageDal(ZustDbContext context) : base(context)
        {
        }
    }
}
