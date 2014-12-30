using System;

namespace Monitoring.Projection.Core.Models.DataProviders
{
    public class ElapsedTimeResult
    {
        public readonly string ElapsedTime;
        public readonly string Name;

        public ElapsedTimeResult(string elapsedTime, string name)
        {
            ElapsedTime = elapsedTime;
            Name = name;
        }
    }
}
