using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Json;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Caching;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Extensions;
using Lace.Domain.Core.Models;
using Newtonsoft.Json;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class IvidResponse : IProvideDataFromIvid, IBuildIvidResponse, IAmCachable
    {
        private const string NotAvailableError = "Error - Not Available";
        public const string CacheKey = "urn:Ivid:{0}";
        
        public IvidResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
        }

        public static IvidResponse Empty()
        {
            return new IvidResponse();
        }

        private IvidResponse(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        public static IvidResponse WithState(DataProviderResponseState state)
        {
            return new IvidResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }

        [DataMember]
        public string ResponseStateMessage
        {
            get { return ResponseState.Description(); }
        }

        public static IvidResponse Build(string statusMessage, string reference, string license, string registration,
            string registrationDate, string vin, string engine,
            string displacement, string tare)
        {
            return new IvidResponse(statusMessage, reference, license, registration, registrationDate, vin, engine, displacement, tare);
        }

        private IvidResponse(string statusMessage, string reference, string license, string registration,
            string registrationDate, string vin, string engine,
            string displacement, string tare)
        {
            StatusMessage = CheckPartial(statusMessage);
            Reference = CheckPartial(reference);
            License = CheckPartial(license);
            Registration = CheckPartial(registration);
            RegistrationDate = CheckPartial(registrationDate);
            Vin = CheckPartial(vin);
            Engine = CheckPartial(engine);
            Displacement = CheckPartial(displacement);
            Tare = CheckPartial(tare);
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItemWithKey(string.Format(CacheKey, Vin), this, DateTime.Now.AddDays(1));
            repository.AddItemWithKey(string.Format(CacheKey, License), this, DateTime.Now.AddDays(1));
            repository.AddItemWithKey(string.Format(CacheKey, Registration), this, DateTime.Now.AddDays(1));
        }

        public void SetErrorFlag(bool check)
        {
            HasErrors |= check;
        }

        public void SetHasIssuesFlag(bool check)
        {
            HasIssues |= check;
        }

        public void SetHasNoRecordsFlag(bool check)
        {
            HasNoRecords |= check;
        }

        public void SetMake(IvidCodePair pair)
        {
            MakeCode = pair.Code;
            MakeDescription = pair.Description;
        }

        public void SetModel(IvidCodePair pair)
        {
            ModelCode = pair.Code;
            ModelDescription = pair.Description;
        }

        public void SetColor(IvidCodePair pair)
        {
            ColourCode = pair.Code;
            ColourDescription = pair.Description;
        }

        public void SetDriven(IvidCodePair pair)
        {
            DrivenCode = pair.Code;
            DrivenDescription = pair.Description;
        }

        public void SetCategory(IvidCodePair pair)
        {
            CategoryCode = pair.Code;
            CategoryDescription = pair.Description;
        }

        public void SetDescription(IvidCodePair pair)
        {
            DescriptionCode = pair.Code;
            Description = pair.Description;
        }

        public void SetEconomicSector(IvidCodePair pair)
        {
            EconomicSectorCode = pair.Code;
            EconomicSectorDescription = pair.Description;
        }

        public void SetLifeStatus(IvidCodePair pair)
        {
            LifeStatusCode = pair.Code;
            LifeStatusDescription = pair.Description;
        }

        public void SetSapMark(IvidCodePair pair)
        {
            SapMarkCode = pair.Code;
            SapMarkDescription = pair.Description;
        }

        public void BuildSpecificInformation()
        {
            SpecificInformation = new VehicleSpecificInformation("Odometer Not Available", ColourDescription,
                Registration, Vin, License, Engine, CategoryDescription);
            SpecificInformation.HasBeenHandled();
            SpecificInformation.AddResponseState(DataProviderResponseState.Successful);
        }

        public void SetCarFullName()
        {
            var carFullName = string.Format("{0} {1}", MakeDescription, ModelDescription);
            CarFullname = string.IsNullOrEmpty(carFullName) ? null : carFullName;
        }

        public void AddReportStatusMessage(string message)
        {
            if(string.IsNullOrEmpty(message))
                return;

            if (ReportStatusMessages == null)
                ReportStatusMessages = new List<string>();

            ReportStatusMessages.Add(message);
        }

        private string CheckPartial(string value)
        {
            if (HasErrors && string.IsNullOrWhiteSpace(value))
            {
                value = NotAvailableError;
            }
            return value;
        }

        [DataMember]
        public IAmIvidStandardRequest Request { get; set; }

        [DataMember, JsonConverter(typeof(JsonTypeResolverConverter))]
        public IProvideVehicleSpecificInformation SpecificInformation { get; private set; }
        [DataMember]
        public string StatusMessage { get; private set; }
        [DataMember]
        public string Reference { get; private set; }
        [DataMember]
        public string License { get; private set; }
        [DataMember]
        public string Registration { get; private set; }
        [DataMember]
        public string RegistrationDate { get; private set; }
        [DataMember]
        public string Vin { get; private set; }
        [DataMember]
        public string Engine { get; private set; }
        [DataMember]
        public string Displacement { get; private set; }
        [DataMember]
        public string Tare { get; private set; }
        [DataMember]
        public string MakeCode { get; private set; }
        [DataMember]
        public string MakeDescription { get; private set; }
        [DataMember]
        public string ModelCode { get; private set; }
        [DataMember]
        public string ModelDescription { get; private set; }
        [DataMember]
        public string ColourCode { get; private set; }
        [DataMember]
        public string ColourDescription { get; private set; }
        [DataMember]
        public string DrivenCode { get; private set; }
        [DataMember]
        public string DrivenDescription { get; private set; }
        [DataMember]
        public string CategoryCode { get; private set; }
        [DataMember]
        public string CategoryDescription { get; private set; }
        [DataMember]
        public string DescriptionCode { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public string EconomicSectorCode { get; private set; }
        [DataMember]
        public string EconomicSectorDescription { get; private set; }
        [DataMember]
        public string LifeStatusCode { get; private set; }
        [DataMember]
        public string LifeStatusDescription { get; private set; }
        [DataMember]
        public string SapMarkCode { get; private set; }
        [DataMember]
        public string SapMarkDescription { get; private set; }
        [DataMember]
        public bool HasIssues { get; private set; }
        [DataMember]
        public bool HasErrors { get; private set; }
        [DataMember]
        public bool HasNoRecords { get; private set; }
        [DataMember]
        public string CarFullname { get; private set; }
        [DataMember]
        public List<string> ReportStatusMessages  { get; private set; }

        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }

        [DataMember]
        public bool Handled { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}
