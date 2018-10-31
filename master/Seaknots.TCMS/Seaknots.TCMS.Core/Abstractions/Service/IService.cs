using Seaknots.TCMS.Core.Abstractions.Trackable;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Core.Abstractions.Service
{
    public interface IService<TEntity> : ITrackableRepository<TEntity> where TEntity : class, ITrackable {}
}
