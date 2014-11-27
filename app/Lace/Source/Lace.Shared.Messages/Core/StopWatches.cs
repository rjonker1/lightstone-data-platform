﻿using System;
using System.Diagnostics;
using Lace.Shared.Extensions;

namespace Lace.Shared.Monitoring.Messages.Core
{
    [Serializable]
    public class DataProviderStopWatch : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private bool _isRunning;
        private readonly string _name;

        public DataProviderStopWatch()
        {
        }

        public DataProviderStopWatch(string name)
        {
            _name = name;
            _stopwatch = new Stopwatch();
        }

        private TimeSpan Elapsed
        {
            get { return _stopwatch.Elapsed; }
        }

        public void Start()
        {
            if (_isRunning)
                return;

            _isRunning = true;
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            _isRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }

        public override string ToString()
        {
            return new StopWatchResults(Elapsed, _name).ObjectToJson();
        }
    }

    [Serializable]
    public class StopWatchResults
    {
        public TimeSpan ElapsedTime { get; private set; }
        public string Name { get; private set; }

        public StopWatchResults(TimeSpan elapsedTime, string name)
        {
            ElapsedTime = elapsedTime;
            Name = name;
        }
    }
}
