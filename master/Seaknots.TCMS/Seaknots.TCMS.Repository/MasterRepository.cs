using Seaknots.TCMS.Core.Concrete.Trackable;
using Seaknots.TCMS.DataAccess;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Repository
{
  public class MasterRepository<TEntity> : TrackableRepository<TEntity>, IMasterRepository<TEntity> where TEntity : class, ITrackable
  {
    public MasterRepository(TCMSContext ctx) : base(ctx)
    {
      TCMSDb = ctx;
    }

    public TCMSContext TCMSDb { get; set; }
  }
}
