using System.Data;
using System.Data.Entity;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Infrastructure.Data.Core
{
    public class TrackUtils
    {
        public static EntityState GetEntityState(TrackState? entityState)
        {
            switch (entityState)
            {
                case TrackState.Added:
                    return EntityState.Added;
                case TrackState.Deleted:
                    return EntityState.Deleted;
                case TrackState.Modified:
                    return EntityState.Modified;
                case TrackState.Unchanged:
                    return EntityState.Unchanged;
                default:
                    return EntityState.Detached;
            }
        }
    }
}