using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;
using Workflow.Lace.Domain;

namespace Workflow.Lace.Mappers
{
    public class DataProviderCommandMapper : TypeMapper
    {
        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "CommitSequence", "Payload", "DataProvider", "DataProviderId", "CommandType", "CommandTypeId",
                    "Type"
                };
            }
        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var command = instance as DataProviderCommand;
            var sql = GenerateInsertStatement();

            var values = new
            {
                Id = command.Command.Id,
                CommitSequence = command.Command.Payload.CommitSequence,
                Payload = command.Command.Payload.Payload,
                DataProvider = command.Command.Payload.DataProvider,
                DataProviderId = command.Command.Payload.DataProviderId,
                CommandType = command.Command.Payload.CommandType,
                CommandTypeId = command.Command.Payload.CommandTypeId,
                Type = command.Command.Payload.TypeStringValue
            };
            connection.Execute(sql, values);
        }

        protected override string TableName
        {
            get { return "CommandLog"; }
        }
    }
}
