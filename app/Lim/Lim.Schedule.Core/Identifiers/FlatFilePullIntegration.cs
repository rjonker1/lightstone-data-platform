using System;
using System.Runtime.Serialization;
using Lim.Core;
using Lim.Dtos;
using Lim.Enums;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class FlatFilePullIntegration
    {
      
        public readonly IPull<FlatFileInitializePullCommand> Puller;

        public FlatFilePullIntegration(Guid key, FlatFileIndentifier file, PullClientIdentifier pullClient, FrequencyIdentifier frequency, IPull<FlatFileInitializePullCommand> puller)
        {
            Key = key;
            File = file;
            Puller = puller;
            PullClient = pullClient;
            Frequency = frequency;
        }
        

        [DataMember]
        public Guid Key { get; private set; }
        [DataMember]
        public FlatFileIndentifier File { get; private set; }
        [DataMember]
        public PullClientIdentifier PullClient { get; private set; }
        [DataMember]
        public FrequencyIdentifier Frequency { get; private set; }

        [DataMember]
        public FlatFileInitializePullCommand Command
        {
            get
            {
                return new FlatFileInitializePullCommand((Frequency) Frequency.Id, (PullClient) PullClient.Id,
                    new FileInformationDto(File.FilePath, File.FileName, File.Password, File.Extension, File.FirstRowIsColumnName, File.HasPassword));
            }
        }
    }

    [DataContract]
    public class FlatFilePushIntegration
    {

        public FlatFilePushIntegration(Guid key, FlatFileIndentifier file, FrequencyIdentifier frequency)
        {
            Key = key;
            File = file;
            Frequency = frequency;
        }

        [DataMember]
        public Guid Key { get; private set; }
        [DataMember]
        public FlatFileIndentifier File { get; private set; }
        [DataMember]
        public FrequencyIdentifier Frequency { get; private set; }
    }
}