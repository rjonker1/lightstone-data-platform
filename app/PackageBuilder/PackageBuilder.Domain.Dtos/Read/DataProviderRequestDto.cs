﻿using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;

namespace PackageBuilder.Domain.Dtos.Read
{
    public interface IDataProviderRequest
    {
        Guid Id { get; }
        string Name { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
    }
    public class DataProviderRequestDto : IDataProviderRequest
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<IDataProvider> DataProviders { get; private set; }

        public DataProviderRequestDto() { }

        public DataProviderRequestDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
