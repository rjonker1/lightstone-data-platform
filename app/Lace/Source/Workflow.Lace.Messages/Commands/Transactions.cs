﻿using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using EasyNetQ;

namespace Workflow.Lace.Messages.Commands
{
    [Queue("DataPlatform.DataProvider.Sender", ExchangeName = "DataPlatform.DataProvider.Sender")]
    [DataContract]
    public class CreateTransactionCommand
    {
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public Guid PackageId { get; private set; }
        [DataMember]
        public long PackageVersion { get; private set; }
        [DataMember]
        public double PackageCostPrice { get; private set; }
        [DataMember]
        public double PackageRecommendedPrice { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public Guid UserId { get; private set; }
        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public Guid ContractId { get; private set; }

        [DataMember]
        public long ContractVersion { get; private set; }
        [DataMember]
        public string System { get; private set; }

        [DataMember]
        public DataProviderResponseState State { get; private set; }

        [DataMember]
        public DataProviderNoRecordState NoRecordState { get; private set; }

        [DataMember]
        public string AccountNumber { get; private set; }

        public CreateTransactionCommand(Guid id, Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId, Guid contractId,
            string system, long contractVersion, DataProviderResponseState state, string accountNumber, double packageCostPrice, double packageRecommendedPrice,DataProviderNoRecordState noRecordState)
        {
            Id = id;
            PackageId = packageId;
            PackageVersion = packageVersion;
            PackageCostPrice = packageCostPrice;
            PackageRecommendedPrice = packageRecommendedPrice;
            Date = date;
            UserId = userId;
            RequestId = requestId;
            ContractId = contractId;
            System = system;
            State = state;
            ContractVersion = contractVersion;
            AccountNumber = accountNumber;
            NoRecordState = noRecordState;
        }
    }
}
