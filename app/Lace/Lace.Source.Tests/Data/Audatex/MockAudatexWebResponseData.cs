﻿using System.Resources;
using Lace.Models.Lightstone.Dto;
using Lace.Models.RgtVin.Dto;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;

namespace Lace.Source.Tests.Data.Audatex
{
    public static class MockAudatexWebResponseData
    {
        public static GetDataResult GetAudatextWebServiceResponse()
        {
            return new GetDataResult()
            {
                AdditionalInfo = null,
                ErrorCode = 0,
                ErrorMessage = "OK",
                MessageEnvelope =
                    "<MsgData><Header><MsgTypeIdentifier>MSGTYPE_HISTORYRESPONSE</MsgTypeIdentifier><Reference>TU12345</Reference></Header><Body><EntityList Type=\"HistoryCheckResponse\">\n</EntityList>\n</Body></MsgData>",
                MessageId = 0,
                MessageTypeIdentifier = "MSGTYPE_HISTORYRESPONSE",
                QueueDepth = 0
            };
        }


        public static GetDataResult GetAudatexWebServiceResultWithHyundaiHistoryResponseInformation()
        {
            return new GetDataResult()
            {
                AdditionalInfo = null,
                ErrorCode = 0,
                ErrorMessage = "OK",
                MessageEnvelope = "<MsgData><Header><MsgTypeIdentifier /><Reference /></Header><Body><EntityList><HistoryCheckResponse><AssessmentNumber>4243</AssessmentNumber><ClaimReferenceNumber>94411</ClaimReferenceNumber><CreationDate>2011-01-12T00:00:00</CreationDate><DataSource>Santam</DataSource><InsuredName>Lightstone</InsuredName><Manufacturer>Hyundai</Manufacturer><Model>Atos</Model><Originator>Audatex</Originator><PolicyNumber>3U7WDLX0</PolicyNumber><Registration>BB30DPGP</Registration><RepairCostExVAT>10000</RepairCostExVAT><RepairCostIncVAT>14000</RepairCostIncVAT><VersionDate>2012-08-08T14:42:18.3328811+02:00</VersionDate><VIN>MALAC51HLAM496530</VIN><WorkproviderReference /></HistoryCheckResponse></EntityList></Body></MsgData>",
                MessageId = 0,
                MessageTypeIdentifier = "MSGTYPE_HISTORYRESPONSE",
                QueueDepth = 0
            };
        }

        public static ILaceResponse GetLaceResponseToUserInAudatexRequest()
        {
            return new LaceResponse()
            {
                RgtVinResponse = new RgtVinResponse()
                {
                    VehicleMake = "Hyundai"
                },
                LightstoneResponse = new LightstoneResponse()
                {
                    Year = 2011
                }
            };
        }
    }
}