using System.Collections.Generic;
using LightstoneApp.Infrastructure.Data.Core.Commits;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    public interface ICommitDispatchScheduler
    {
        bool IsSynchronous { get; }
        void ScheduleDispatch(Commit commit);
        void ScheduleDispatch(IEnumerable<Commit> commits);
    }
}