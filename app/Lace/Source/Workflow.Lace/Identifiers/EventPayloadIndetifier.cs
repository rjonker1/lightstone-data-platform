﻿using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Domain;

namespace Workflow.Lace.Identifiers
{
    public class EventPayloadIndentifier
    {

        public EventPayloadIndentifier(byte[] payload, int commitSequence, DataProviderCommandSource dataProvider,
            CommandType commandType, Type type)
        {
            Payload = payload;
            CommitSequence = commitSequence;
            DataProvider = dataProvider.ToString();
            DataProviderId = (int) dataProvider;
            CommandType = commandType.ToString();
            CommandTypeId = (int) commandType;
            Type = type;
        }

        public byte[] Payload { get; private set; }
        public int CommitSequence { get; private set; }
        public int DataProviderId { get; private set; }
        public string DataProvider { get; private set; }
        public string CommandType { get; private set; }
        public int CommandTypeId { get; private set; }
        public Type Type { get; private set; }

        public string TypeStringValue
        {
            get
            {
                return Type == null ? string.Empty : Type.AssemblyQualifiedName;
            }
        }
    }
}
