using System;
using BuildingBlocks.Fluency;

namespace BuildingBlocks.Recovery
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