﻿using DataPlatform.BuildingBlocks.Extentions;
using DataPlatform.BuildingBlocks.Recovery.Strategies;

namespace DataPlatform.Workflow.RabbitMQ.Tests.Fakes
{
    public class TestingRetryStrategy : RetryStrategy
    {
        public TestingRetryStrategy() : base(2.Times(), 0.Seconds(), 0.Seconds())
        {
        }
    }
}