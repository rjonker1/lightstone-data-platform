﻿namespace Monitoring.Test.Helper.Builder
{
    public class DataProviderConfigurationBuiler
    {
        public static string ForIvid()
        {
            return string.Empty;
        }
    }

    public class DataProviderRequestBuilder
    {
        public static string ForIvid()
        {
            return
                @"{'Package':{'Name':'License plate search','Description':'','CostOfSale':10.0,'RecommendedSalePrice':20.0,'Action':{'Criteria':{'Fields':[{'Name':'LicenceNo','Label':null,'Definition':null,'Industries':[],'Price':0.0,'IsSelected':null,'Type':null,'DataFields':null}]},'Name':'License plate search','Id':'5e199827-1130-45ee-a15f-c3dd972728a9'},'Notes':'','Industries':[{'Name':'Finance','IsSelected':false,'Id':'98a9d7a0-1e4c-4233-8e13-15e38675c5d0'},{'Name':'Automotive','IsSelected':false,'Id':'038176a8-aa67-4485-91fc-978c5de17716'}],'State':{'Id':'c78e07f2-0c30-4704-8577-3db20e5c784b'},'DisplayVersion':0.1,'Owner':'','CreatedDate':'2014-12-19T16:14:33.0849398+02:00','EditedDate':null,'DataProviders':[]},'User':{'UserId':'4a17b499-845f-43e2-aa2f-cfcb06920ab6','AggregateId':'72e7523f-7278-408e-8b7f-77d745412c8a','UserName':null,'UserFirstName':'Penny','UserLastName':null,'UserEmail':'pennyl@lightstone.co.za','UserPhone':null},'Context':{'Product':'VVi+ADX+VPi','ReasonForApplication':null,'SecurityCode':'c99ef6d2-fdea-4a81-b15f-ff8251ac9050'},'RequestAggregation':{'AggregateId':'80c39ef1-ab67-43bf-963c-b6afa7acab56'},'Vehicle':{'EngineNo':null,'VinOrChassis':null,'Make':null,'RegisterNo':null,'LicenceNo':'XMC167GP','Vin':'SB1KV58E40F039277'},'CoOrdinates':{'Latitude':-26.864250004641011,'Longitude':32.829399989305713,'Image':''},'Jis':{'CroppedImage':'','FullImage':'','FullImageThumb':'','Latitude':0.0,'Longitude':0.0,'SightingDate':'0001-01-01T00:00:00','SiteLocation':'','SiteName':'','SessionId':0,'UserName':'','LicensePlateNumber':''},'RequestDate':'2014-12-19T16:14:33.1329013+02:00','SearchTerm':'XMC167GP'}";

        }
    }

    public class DataProviderResponseBuilder
    {
        public static string FromIvid()
        {
            return
                @"{'ividQueryResult':1,'issuesTypes':null,'IvidReference':'IVD - 01468460493','partialResponseSpecified':false,'licenceNumber':'XMC167GP','registerNumber':'CNC407L','vin':'SB1KV58E40F039277','engineNumber':'1ZRU041295','titleHolderIdNumber':null,'titleHolderIdTypeSpecified':false,'vehicleStatusCode':11,'vehicleStatusCodeSpecified':true,'engineDisplacement':'1598','make':{'code':'T05','description':'Toyota'},'model':{'code':'D166','description':'AURIS'},'colour':{'code':'3','description':'White'},'driven':{'code':'1','description':'Self-propelled'},'tare':'1276','GVM':'1750','category':{'code':'B','description':'Light passenger mv(less than 12 persons)'},'description':{'code':'18','description':'Hatch back'},'economicSector':{'code':'1','description':'Private'},'lifeStatus':{'code':'2','description':'Used'},'sapMark':{'code':'99','description':'None'},'registrationDate':'2/18/2014'}";

        }
    }

    public class DataProviderTransformationBuilder
    {
        public static string ForIvid()
        {
            return
                @"{'SpecificInformation':{'Odometer':'Odometer Not Available','Colour':'White','RegistrationNumber':'CNC407L','VinNumber':'SB1KV58E40F039277','LicenseNumber':'XMC167GP','EngineNumber':'1ZRU041295','CategoryDescription':'Light passenger mv(less than 12 persons)'},'StatusMessage':'NO_ISSUES','Reference':'IVD - 01468460493','License':'XMC167GP','Registration':'CNC407L','RegistrationDate':'2/18/2014','Vin':'SB1KV58E40F039277','Engine':'1ZRU041295','Displacement':'1598','Tare':'1276','MakeCode':'T05','MakeDescription':'Toyota','ModelCode':'D166','ModelDescription':'AURIS','ColourCode':'3','ColourDescription':'White','DrivenCode':'1','DrivenDescription':'Self-propelled','CategoryCode':'B','CategoryDescription':'Light passenger mv(less than 12 persons)','DescriptionCode':'18','Description':'Hatch back','EconomicSectorCode':'1','EconomicSectorDescription':'Private','LifeStatusCode':'2','LifeStatusDescription':'Used','SapMarkCode':'99','SapMarkDescription':'None','HasIssues':false,'HasErrors':false,'CarFullname':'Toyota AURIS'}";
        }
    }
}
