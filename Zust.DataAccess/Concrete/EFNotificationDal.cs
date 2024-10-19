using Zust.Core.Concrete.EntityFramework;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Concrete
{
    public class EFNotificationDal : EFEntityRepositoryBase<Notification, ZustDbContext>, INotificationDal
    {
        public EFNotificationDal(ZustDbContext context) : base(context)
        {
        }
    }
}
