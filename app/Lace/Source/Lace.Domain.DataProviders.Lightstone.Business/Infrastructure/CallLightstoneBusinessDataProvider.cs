using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Management;
using Workflow.Lace.Identifiers;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure
{
    public class CallLightstoneBusinessDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;


        private DataSet _result;

        private readonly string _username = Credentials.LightstoneBusinessApiEmail();
        private readonly string _password = Credentials.LightstoneBusinessApiPassword();

        public CallLightstoneBusinessDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var webService = new ConfigureSource();
                if (webService.Client.State == CommunicationState.Closed)
                    webService.Client.Open();

                // authenticate
                // call authenticateUser to get the UserToke by email and password
                // email: murray@lightstone.co.za
                //pass: Pass!1234

//RESULT FROM RETURN COMPANIES
//                <NewDataSet xmlns="">
//<companies diffgr:id="companies1" msdata:rowOrder="0">
//<companyid>3479505</companyid>
//<companyname>LIGHTSTONE AUTO</companyname>
//<companyregnumber>2010/018608/07</companyregnumber>
//<VatNo>4740259769</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies2" msdata:rowOrder="1">
//<companyid>3142594</companyid>
//<companyname>LIGHTSTONE BUSINESS SOLUTIONS</companyname>
//<companyregnumber>2009/014520/07</companyregnumber>
//<VatNo>4850261001</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies3" msdata:rowOrder="2">
//<companyid>2618016</companyid>
//<companyname>LIGHTSTONE COMMERCIAL</companyname>
//<companyregnumber>2007/029151/07</companyregnumber>
//<VatNo/>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies4" msdata:rowOrder="3">
//<companyid>1377071</companyid>
//<companyname>LIGHTSTONE CONSUMER</companyname>
//<companyregnumber>2001/013329/07</companyregnumber>
//<VatNo>4570214256</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies5" msdata:rowOrder="4">
//<companyid>3585288</companyid>
//<companyname>LIGHTSTONE EXPLORE</companyname>
//<companyregnumber>2011/112308/07</companyregnumber>
//<VatNo>4550259933</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies6" msdata:rowOrder="5">
//<companyid>2146386</companyid>
//<companyname>LIGHTSTONE GROUP</companyname>
//<companyregnumber>2006/004819/07</companyregnumber>
//<VatNo>4740230646</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies7" msdata:rowOrder="6">
//<companyid>2678992</companyid>
//<companyname>LIGHTSTONE INNOVATION</companyname>
//<companyregnumber>2008/000160/07</companyregnumber>
//<VatNo/>
//<StatusCode>09</StatusCode>
//</companies>
//<companies diffgr:id="companies8" msdata:rowOrder="7">
//<companyid>2850676</companyid>
//<companyname>LIGHTSTONE INVESTMENT AND DEVELOPMENT</companyname>
//<companyregnumber>2008/017493/07</companyregnumber>
//<VatNo/>
//<StatusCode>29</StatusCode>
//</companies>
//<companies diffgr:id="companies9" msdata:rowOrder="8">
//<companyid>2145391</companyid>
//<companyname>LIGHTSTONE PROCESSING</companyname>
//<companyregnumber>2006/004664/07</companyregnumber>
//<VatNo>4090230659</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies10" msdata:rowOrder="9">
//<companyid>1707642</companyid>
//<companyname>LIGHTSTONE PROPERTY</companyname>
//<companyregnumber>2003/029525/07</companyregnumber>
//<VatNo>4670224890</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies11" msdata:rowOrder="10">
//<companyid>3577610</companyid>
//<companyname>LIGHTSTONE STEEL</companyname>
//<companyregnumber>2011/105935/07</companyregnumber>
//<VatNo>4770258970</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//<companies diffgr:id="companies12" msdata:rowOrder="11">
//<companyid>2779273</companyid>
//<companyname>LIGHTSTONE TRADING</companyname>
//<companyregnumber>2008/090750/23</companyregnumber>
//<VatNo/>
//<StatusCode>29</StatusCode>
//</companies>
//</NewDataSet>

                var token = webService.Client.authenticateUser(_username, _password);

                var request =
                    new GetBusinessRequest()
                        //TODO: uncomment after updating package builder requests nuget new GetBusinessRequest(_dataProvider.GetRequest<IAmBusinessRequest>)
                        .Map()
                        .Validate();
                _logCommand.LogConfiguration(new {request}, null);

                if (!request.RequestIsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Business request has not been met with user_token {0} ",
                            request.UserToken));

                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new {request});

                _result = webService.Client.returnCompanies(token.ToString(), request.CompanyName, request.CompanyRegnum,
                    request.CompanyVatnumber);

                //call confirm company

                webService.CloseSource();
                _logCommand.LogResponse(_result != null ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new {_result});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Data Provider {0}", ex);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Business Data Provider"});
                LightstoneBusinessResponseFailed(response);
            }
        }

        private static void LightstoneBusinessResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneBusinessResponse = new LightstoneBusinessResponse();
            lightstoneBusinessResponse.HasBeenHandled();
            response.Add(lightstoneBusinessResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneBusinessResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result ?? new LightstoneBusinessResponse(new List<IRespondWithBusiness>()), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}

//FINAL Resutl to be sent back - i.e. ls busienss response
//<xs:element name="company">
//<xs:complexType>
//<xs:sequence>
//<xs:element name="ID" type="xs:int" minOccurs="0"/>
//<xs:element name="EnterpriseType" type="xs:string" minOccurs="0"/>
//<xs:element name="ShortenType" type="xs:string" minOccurs="0"/>
//<xs:element name="CompanyRegNumber" type="xs:string" minOccurs="0"/>
//<xs:element name="OldRegistrationNumber" type="xs:string" minOccurs="0"/>
//<xs:element name="TypeDate" type="xs:string" minOccurs="0"/>
//<xs:element name="CompanyName" type="xs:string" minOccurs="0"/>
//<xs:element name="ShortName" type="xs:string" minOccurs="0"/>
//<xs:element name="TranslatedName" type="xs:string" minOccurs="0"/>
//<xs:element name="RegistrationDate" type="xs:string" minOccurs="0"/>
//<xs:element name="BusinessStartDate" type="xs:string" minOccurs="0"/>
//<xs:element name="WithdrawnPublic" type="xs:string" minOccurs="0"/>
//<xs:element name="StatusCode" type="xs:string" minOccurs="0"/>
//<xs:element name="StatusDate" type="xs:string" minOccurs="0"/>
//<xs:element name="SicCode" type="xs:string" minOccurs="0"/>
//<xs:element name="FinancialYearEnd" type="xs:string" minOccurs="0"/>
//<xs:element name="FinancialEffectiveDate" type="xs:string" minOccurs="0"/>
//<xs:element name="PhysicalAddress1" type="xs:string" minOccurs="0"/>
//<xs:element name="PhysicalAddress2" type="xs:string" minOccurs="0"/>
//<xs:element name="PhysicalAddress3" type="xs:string" minOccurs="0"/>
//<xs:element name="PhysicalAddress4" type="xs:string" minOccurs="0"/>
//<xs:element name="PhysicalPostCode" type="xs:string" minOccurs="0"/>
//<xs:element name="PostalAddress1" type="xs:string" minOccurs="0"/>
//<xs:element name="PostalAddress2" type="xs:string" minOccurs="0"/>
//<xs:element name="PostalAddress3" type="xs:string" minOccurs="0"/>
//<xs:element name="PostalAddress4" type="xs:string" minOccurs="0"/>
//<xs:element name="PostalPostCode" type="xs:string" minOccurs="0"/>
//<xs:element name="CountryCode" type="xs:string" minOccurs="0"/>
//<xs:element name="CountryOfOrigin" type="xs:string" minOccurs="0"/>
//<xs:element name="RegionCode" type="xs:string" minOccurs="0"/>
//<xs:element name="AuthorisedCapital" type="xs:double" minOccurs="0"/>
//<xs:element name="AuthorisedShares" type="xs:double" minOccurs="0"/>
//<xs:element name="IssuedCapital" type="xs:double" minOccurs="0"/>
//<xs:element name="IssuedShares" type="xs:double" minOccurs="0"/>
//<xs:element name="FormReceivedDate" type="xs:string" minOccurs="0"/>
//<xs:element name="FormDate" type="xs:string" minOccurs="0"/>
//<xs:element name="ConversionNumber" type="xs:string" minOccurs="0"/>
//<xs:element name="TaxNumber" type="xs:string" minOccurs="0"/>
//<xs:element name="CPA" type="xs:boolean" minOccurs="0"/>
//<xs:element name="StatusCodeDesc" type="xs:string" minOccurs="0"/>
//<xs:element name="RegionCodeDesc" type="xs:string" minOccurs="0"/>
//<xs:element name="SIC_Description" type="xs:string" minOccurs="0"/>
//</xs:sequence>
//</xs:complexType>
//</xs:element>




//DIRECTOR return directors
//<directors diffgr:id="directors1" msdata:rowOrder="0">
//<directorid>1669624</directorid>
//<firstname>MURRAY GRANT</firstname>
//<surname>WOOLFSON</surname>
//<idnumber>7902065199085</idnumber>
//</directors>

//Confirm Direcotrs

//return director report

//list of this stuff
//<company diffgr:id="company1" msdata:rowOrder="0">
//<ID>3206619</ID>
//<EnterpriseType>Close Corporation (CC)</EnterpriseType>
//<ShortenType>(CC)</ShortenType>
//<CompanyRegNumber>2009/202656/23</CompanyRegNumber>
//<CompanyName>SOUTHERN HEMISPHERE CORPORATION</CompanyName>
//<ShortName/>
//<TranslatedName/>
//<RegistrationDate>2009/11/03</RegistrationDate>
//<BusinessStartDate>2009/11/03</BusinessStartDate>
//<WithdrawnPublic>False</WithdrawnPublic>
//<StatusCode>03</StatusCode>
//<StatusDate/>
//<SicCode>88</SicCode>
//<FinancialYearEnd>2</FinancialYearEnd>
//<FinancialEffectiveDate>2009/11/03</FinancialEffectiveDate>
//<PhysicalAddress1>48 BELLAIRS VIEW</PhysicalAddress1>
//<PhysicalAddress2>137 BELLAIRS DRIVE</PhysicalAddress2>
//<PhysicalAddress3>NORTHRIDING</PhysicalAddress3>
//<PhysicalAddress4>GAUTENG</PhysicalAddress4>
//<PhysicalPostCode>2169</PhysicalPostCode>
//<PostalAddress1>PO BOX 501</PostalAddress1>
//<PostalAddress2>DOUGLASDALE</PostalAddress2>
//<PostalAddress3>DOUGLASDALE</PostalAddress3>
//<PostalAddress4>GAUTENG</PostalAddress4>
//<PostalPostCode>2165</PostalPostCode>
//<CountryCode/>
//<CountryOfOrigin/>
//<RegionCode>7</RegionCode>
//<AuthorisedCapital>-1</AuthorisedCapital>
//<AuthorisedShares>-1</AuthorisedShares>
//<IssuedCapital>-1</IssuedCapital>
//<IssuedShares>-1</IssuedShares>
//<FormReceivedDate/>
//<FormDate/>
//<ConversionNumber/>
//<TaxNumber/>
//<AppointmentDate>2009/11/03</AppointmentDate>
//<SIC_Description>Other business activities</SIC_Description>
//</company>