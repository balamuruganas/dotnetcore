namespace Seaknots.TCMS.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Seaknots.TCMS.Core.Concrete.Trackable;
    using TrackableEntities.Common.Core;

    public class MasterRepository<TEntity> : TrackableRepository<TEntity>, IMasterRepository<TEntity>
        where TEntity : class, ITrackable
    {
        public MasterRepository(DbContext context) : base(context)
        {
        }
    }
}