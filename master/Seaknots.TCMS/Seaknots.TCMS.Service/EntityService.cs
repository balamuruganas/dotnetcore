using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Repository;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Service
{
  public class EntityService<TEntity> : Service<TEntity>, IEntityService<TEntity> where TEntity : class, ITrackable
  {
    private readonly IMasterRepository<TEntity> repository;

    protected EntityService(IMasterRepository<TEntity> repository) : base(repository)
    {
      this.repository = repository;
    }
  }
}
