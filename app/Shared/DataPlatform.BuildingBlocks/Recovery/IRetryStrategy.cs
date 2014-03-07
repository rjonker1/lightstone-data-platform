using System;
using DataPlatform.BuildingBlocks.Fluency;

namespace DataPlatform.BuildingBlocks.Recovery
{
    public interface IRetryStrategy
    {
        Seconds InitialDelay { get; }
        Seconds Delay { get; }
        void Attempt();
        bool Done(Func<bool> successCondition);
        bool Done();
    }
}