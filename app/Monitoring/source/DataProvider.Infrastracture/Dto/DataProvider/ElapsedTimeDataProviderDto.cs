﻿using System;
using System.Runtime.Serialization;

namespace DataProvider.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class ElapsedTimeDataProviderDto
    {
        public ElapsedTimeDataProviderDto()
        {

        }

        public ElapsedTimeDataProviderDto(string dateProviderName, int dataProviderId, string elapsedTime)
        {
            //DataProviderName = @event.Payload.MetadataObject.Results.Name;
            //ElapsedTime = @event.Payload.MetadataObject.Results.ElapsedTime;

            DataProviderName = dateProviderName;
            DataproviderId = dataProviderId;
            ElapsedTime = elapsedTime;
        }

        [DataMember]
        public string DataProviderName { get; set; }

        [DataMember]
        public int DataproviderId { get; private set; }

        [DataMember]
        public string ElapsedTime { get; private set; }

        [DataMember]
        public TimeSpan ElapsedTimeSpan
        {
            get
            {
                var time = new TimeSpan(0);
                TimeSpan.TryParse(ElapsedTime, out time);
                return time;
            }
        }

    }
}