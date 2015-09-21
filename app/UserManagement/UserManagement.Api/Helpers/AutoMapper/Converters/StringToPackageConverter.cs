using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Converters
{
    public class StringToPackageConverter : TypeConverter<IEnumerable<string>, IEnumerable<Package>>
    {
        private readonly IRepository<Package> _repository;

        public StringToPackageConverter(IRepository<Package> repository)
        {
            _repository = repository;
        }

        protected override IEnumerable<Package> ConvertCore(IEnumerable<string> source)
        {
            if (source == null) yield break;
            var keyValues = source as IList<string> ?? source.ToList();
            foreach (var values in from keyValue in keyValues where !string.IsNullOrEmpty(keyValue) select keyValue.Split('|') into values where values.Length == 2 select values)
            {
                Guid id;
                if (!Guid.TryParse(values[0], out id)) continue;
                if (string.IsNullOrEmpty(values[1])) continue;

                var package = _repository.FirstOrDefault(x => x.PackageId == id);

                yield return package ?? new Package(values[1], id);
            }
        }
    }
}