using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.DataAccess;
using Seaknots.TCMS.Repository;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Service
{
  public class EntityService<TEntity> : Service<TEntity>, IEntityService<TEntity> where TEntity : class, ITrackable
  {
    private readonly IMasterRepository<TEntity> repository;
    protected Logger _logger = new Logger("Seaknots.TCMS.Log");

    public TCMSContext TCMSDb => repository.TCMSDb;

    protected EntityService(IMasterRepository<TEntity> repository) : base(repository)
    {
      this.repository = repository;
    }
  }
}
