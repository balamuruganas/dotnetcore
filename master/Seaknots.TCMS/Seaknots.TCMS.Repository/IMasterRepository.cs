using Seaknots.TCMS.Core.Abstractions.Trackable;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Repository
{
  public interface IMasterRepository<TEntity> : ITrackableRepository<TEntity> where TEntity : class, ITrackable
  {
  }
}
