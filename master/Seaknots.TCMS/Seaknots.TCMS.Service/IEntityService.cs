using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.DataAccess;
using Seaknots.TCMS.Repository;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Service
{
  public interface IEntityService<TEntity> : IService<TEntity>, IMasterRepository<TEntity> where TEntity : class, ITrackable
  {
    new TCMSContext TCMSDb { get; }
  }
}
