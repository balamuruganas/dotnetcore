using Microsoft.EntityFrameworkCore;
using Seaknots.TCMS.Core.Concrete.Trackable;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Repository
{
  public class MasterRepository<TEntity> : TrackableRepository<TEntity>, IMasterRepository<TEntity> where TEntity : class, ITrackable
  {
    public MasterRepository(DbContext context) : base(context)
    {
    }
  }
}
