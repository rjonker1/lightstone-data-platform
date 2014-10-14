using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Interfaces
{
    public interface IRepository : IDisposable
    {
        void Save<TAggregate>(TAggregate aggregate) where TAggregate : IAggregate;
        void CommitChanges();

        TAggregate GetById<TAggregate>(String aggregateId) where TAggregate : IAggregate;

        TAggregate[] GetById<TAggregate>(params string[] aggregateIds) where TAggregate : IAggregate;
    }
}