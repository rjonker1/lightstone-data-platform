using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Implementation
{
    public class MessageSender : IMessageSender
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly string _name;
        private readonly string _insertQuery;

        public MessageSender(IDbConnectionFactory connectionFactory, string name, string tableName)
        {
            _connectionFactory = connectionFactory;
            this._name = name;
            _insertQuery =
                string.Format(
                    "INSERT INTO {0} (Body, DeliveryDate, CorrelationId) VALUES (@Body, @DeliveryDate, @CorrelationId)",
                    tableName);
        }

        /// <summary>
        ///     Sends the specified message.
        /// </summary>
        public void Send(Message message)
        {
            using (DbConnection connection = _connectionFactory.CreateConnection(_name))
            {
                connection.Open();

                InsertMessage(message, connection);
            }
        }

        /// <summary>
        ///     Sends a batch of messages.
        /// </summary>
        public void Send(IEnumerable<Message> messages)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (DbConnection connection = _connectionFactory.CreateConnection(_name))
                {
                    connection.Open();

                    foreach (Message message in messages)
                    {
                        InsertMessage(message, connection);
                    }
                }

                scope.Complete();
            }
        }

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities",
            Justification = "Does not contain user input.")]
        private void InsertMessage(Message message, DbConnection connection)
        {
            using (var command = (SqlCommand) connection.CreateCommand())
            {
                command.CommandText = _insertQuery;
                command.CommandType = CommandType.Text;

                command.Parameters.Add("@Body", SqlDbType.NVarChar).Value = message.Body;
                command.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = message.DeliveryDate.HasValue
                    ? (object) message.DeliveryDate.Value
                    : DBNull.Value;
                command.Parameters.Add("@CorrelationId", SqlDbType.NVarChar).Value = (object) message.CorrelationId ??
                                                                                     DBNull.Value;

                command.ExecuteNonQuery();
            }
        }
    }
}
