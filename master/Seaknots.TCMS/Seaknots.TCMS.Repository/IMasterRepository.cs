namespace Seaknots.TCMS.Repository
{
    using Seaknots.TCMS.Core.Abstractions.Trackable;
    using TrackableEntities.Common.Core;

    public interface IMasterRepository<TEntity> : ITrackableRepository<TEntity> where TEntity : class, ITrackable
    {
    }
}