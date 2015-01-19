using System;
using System.Collections.Generic;

namespace Monitoring.Test.Helper.Builder
{
    public class DataProviderConfigurationBuiler
    {
        public static object ForIvid()
        {
            return new
            {
                HpiServiceClient = new
                {
                    ClientCredentials = new
                    {
                        UserName = "Ivid UserName",
                        Password = "IvidPassword"
                    }
                },
                HttpRequestMessageProperty = new
                {
                    CreateBasicHttpRequestMessageProperty = new
                    {
                        
                    }
                }
            };
        }

        public static object ForIvidTitleHolder()
        {
            return new
            {
                TitleholderQueryRequest = new
                {
                    RequesterDetailsElement = new
                    {
                        UserEmail = "pennyl@lightstone.co.za",
                        UserFirstName = "Penny",
                        UserPhone = "",
                    },
                    vin = "SB1KV58E40F039277"
                }
            };
        }

        public static object ForAudatex()
        {
            return new
            {
                AudatexMessageData = new
                {
                    Header = new
                    {
                        RequestHeader = new
                        {

                        }
                    },
                    Body = new
                    {
                        RequestBody = new
                        {
                            HistoryCheckRequest = new
                            {
                                VIN = "SB1KV58E40F039277",
                                Registration = "XMC167GP",
                                EngineNumber = "",
                                ClaimReferenceNumber = "",
                                AssessmentNumber = "",
                                Originator = ""
                            }
                        }
                    }
                }
            };
        }
    }

    public class DataProviderRequestBuilder
    {
        public static object ForLicensePlateSearch()
        {
            return new
            {
                Request = new
                {
                    Package =
                        new
                        {
                            Name = "License plate search",
                            Description = "",
                            CostOfSale = 10.0,
                            RecommendedSalePrice = 20.0,
                            Action =
                                new
                                {
                                    Criteria =
                                        new
                                        {
                                            Fields =
                                                new
                                                {
                                                    Name = "LicenceNo",
                                                    Label = string.Empty,
                                                    Definition = string.Empty,
                                                    Industries = new {},
                                                    Price = 0.0,
                                                    IsSelected = string.Empty,
                                                    Type = string.Empty,
                                                    DataFields = string.Empty
                                                }
                                        },
                                    Name = "License plate search",
                                    Id = "5e199827-1130-45ee-a15f-c3dd972728a9"
                                },
                            Notes = string.Empty,
                            Industries =
                                new {Name = "Finance", IsSelected = false, Id = "98a9d7a0-1e4c-4233-8e13-15e38675c5d0"},
                            IsSelected = false,
                            Id = "038176a8-aa67-4485-91fc-978c5de17716"
                        },
                    State = new {Id = "c78e07f2-0c30-4704-8577-3db20e5c784b"},
                    DisplayVersion = 0.1,
                    Owner = string.Empty,
                    CreatedDate = "2014-12-19T16=14=33.0849398+02=00",
                    EditedDate = string.Empty,
                    DataProviders = new {},
                    User = new
                    {
                        UserId = "4a17b499-845f-43e2-aa2f-cfcb06920ab6",
                        AggregateId = "72e7523f - 7278 - 408e-8b7f-77d 745412c8a",
                        UserName = string.Empty,
                        UserFirstName = "Penny",
                        UserLastName = string.Empty,
                        UserEmail = "pennyl@lightstone.co.za",
                        UserPhone = string.Empty
                    },
                    Context =
                        new
                        {
                            Product = "VVi+ADX+VPi",
                            ReasonForApplication = string.Empty,
                            SecurityCode = "c99ef6d2-fdea-4a81-b15f-ff8251ac9050"
                        },
                    RequestAggregation = new {AggregateId = "80c39ef1-ab67-43bf-963c-b6afa7acab56"},
                    Vehicle =
                        new
                        {
                            EngineNo = string.Empty,
                            VinOrChassis = string.Empty,
                            Make = string.Empty,
                            RegisterNo = string.Empty,
                            LicenceNo = "XMC167GP",
                            Vin = "SB1KV58E40F039277"
                        },
                    CoOrdinates =
                        new {Latitude = "-26.864250004641011", Longitude = "32.829399989305713", Image = string.Empty},
                    Jis =
                        new
                        {
                            CroppedImage = string.Empty,
                            FullImage = string.Empty,
                            FullImageThumb = string.Empty,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            SightingDate = "0001-01-01T00=00=00",
                            SiteLocation = string.Empty,
                            SiteName = string.Empty,
                            SessionId = 0,
                            UserName = string.Empty,
                            LicensePlateNumber = string.Empty
                        },
                    RequestDate = "2014-12-19T16=14=33.1329013+02=00",
                    SearchTerm = "XMC167GP"
                }

            };
        }
    }

    public class DataProviderResponseBuilder
    {
        public static object FromIvidTitleHolder()
        {
            return new
            {
                TitleholderQueryResponse = new
                {
                    accountClosedDate = DateTime.Now.AddYears(-5),
                    accountNumber = "00009009838",
                    accountClosedDateSpecified = true,
                    accountOpenDate = DateTime.Now.AddYears(-10),
                    accountOpenDateSpecified = true,
                    bankName = "WesBank",
                    engineNumber = "",
                    flaggedOnAnpr = false,
                    make = "Toyota",
                    model = "Hilux",
                    partialResponse = false,
                    vin = "AHT31UNK408007735",
                    yearOfLiabilityForLicensing = ""
                }
            };
        }

        public static object FromIvid()
        {
            return
                new
                {
                    HpiStandardQueryRequest =
                        new
                        {
                            ividQueryResult = 1,
                            issuesTypes = string.Empty,
                            IvidReference = "IVD - 01468460493",
                            partialResponseSpecified = false,
                            licenceNumber = "XMC167GP",
                            registerNumber = "CNC407L",
                            vin = "SB1KV58E40F039277",
                            engineNumber = "1ZRU041295",
                            titleHolderIdNumber = string.Empty,
                            titleHolderIdTypeSpecified = false,
                            vehicleStatusCode = 11,
                            vehicleStatusCodeSpecified = true,
                            engineDisplacement = 1598,
                            make = new {CodeDescription = new {code = "T05", description = "Toyota"}},
                            model = new {CodeDescription = new {code = "D166", description = "AURIS"}},
                            colour = new {CodeDescription = new {code = "3", description = "White"}},
                            driven = new {CodeDescription = new {code = "1", description = "Self-propelled"}},
                            tare = 1276,
                            GVM = 1750,
                            category =
                                new
                                {
                                    CodeDescription =
                                        new {code = "B", description = "Light passenger mv(less than 12 persons)"}
                                },
                            description = new {CodeDescription = new {code = "18", description = "Hatch back"}},
                            economicSector = new {CodeDescription = new {code = 1, description = "Private"}},
                            lifeStatus = new {CodeDescription = new {code = 2, description = "Used"}},
                            sapMark = new {CodeDescription = new {code = 99, description = "None"}},
                            registrationDate = "2/18/2014"
                        }
                };

        }
        public static object FromAudatex()
        {
            return new
            {
                GetDataResult = new
                {
                    AdditionalInfo = string.Empty,
                    ErrorCode = 0,
                    ErrorMessage = "OK",
                    MessageEnvelope =
                        "<MsgData><Header><MsgTypeIdentifier /><Reference /></Header><Body><EntityList><HistoryCheckResponse><AssessmentNumber>4243</AssessmentNumber><ClaimReferenceNumber>94411</ClaimReferenceNumber><CreationDate>2011-01-12T00:00:00</CreationDate><DataSource>Santam</DataSource><InsuredName>Lightstone</InsuredName><Manufacturer>Hyundai</Manufacturer><Model>Atos</Model><Originator>Audatex</Originator><PolicyNumber>3U7WDLX0</PolicyNumber><Registration>BB30DPGP</Registration><RepairCostExVAT>10000</RepairCostExVAT><RepairCostIncVAT>14000</RepairCostIncVAT><VersionDate>2012-08-08T14:42:18.3328811+02:00</VersionDate><VIN>MALAC51HLAM496530</VIN><WorkproviderReference /></HistoryCheckResponse></EntityList></Body></MsgData>",
                    MessageId = 0,
                    MessageTypeIdentifier = "MSGTYPE_HISTORYRESPONSE",
                    QueueDepth = 0
                }
            };
        }

        public static object FromAudatexWithLaceResponse()
        {
            return new
            {
                LaceResponse = new
                {
                    RgtVinResponse = new
                    {
                        CarFullname = "TOYOTA Auris 1.6 RT 5-dr",
                        Colour = "STANDARD WHITE",
                        Month = 2,
                        Price = 0,
                        Quarter = 0,
                        RgtCode = string.Empty,
                        VehicleMake = "TOYOTA",
                        VehicleModel = "Auris 1.6 RT 5-dr",
                        VehicleType = string.Empty,
                        Vin = "SB1KV58E40F039277",
                        Year = 2008
                    }
                },
                LightstoneResponse = new
                {
                    CarFullname = "TOYOTA Auris 1.6 RT 5-dr",
                    CarId = 107483,
                    ImageUrl = "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg",
                    Model = "Auris 1.6 RT 5-dr",
                    Quarter = "3rd Quarter",
                    Vin = "SB1KV58E40F039277",
                    Year = "2008",
                    VehicleValuation = new
                    {
                        AccidentDistribution = new {},
                        AmortisationFactors = new {},
                        AmortisedValues = new {},
                        AreaFactors = new {},
                        AuctionFactors = new {},
                        Confidence = new {},
                        EstimatedValue = new {},
                        Frequency = new {},
                        ImageGauges = new {},
                        LastFiveSales = new {},
                        Prices = new {},
                        RepairIndex = new {},
                        TotalSalesByAge = new {},
                        TotalSalesByGender = new {},
                    }
                }
            };
        }

        public static object FromLightstone()
        {
            return new
            {
                BaseRetrievalMetric = new
                {
                    LastFiveSalesMetric = new {},
                    EstimatedValuesMetric = new {},
                    TotalSalesByGenderMetric = new {},
                    TotalSalesByAgeMetric = new {},
                    RepairIndexMetric = new {},
                    AuctionFactorsMetric = new {},
                    AmortisedValueMetric = new {},
                    AccidentDistributionMetric = new {},
                    ImageGaugesMetric = new {}
                },
                CarInfo = new
                {
                    CarId = 107483,
                    Year = 2008,
                    ImageUrl = "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg",
                    Quarter = "3rd Quarter",
                    CarFullname = "TOYOTA Auris 1.6 RT 5-dr",
                    CarModel = "Auris 1.6 RT 5-dr"
                }
            };
        }

        public static object FromRgt()
        {
            return new
            {
                CarSpecification = new
                {
                    ManufacturerName = "",
                    ModelYear = 0,
                    CarTypeName = "",
                    TopSpeed = "",
                    Kilowatts = "",
                    FuelEconomy = "",
                    Acceleration = "",
                    Torque = "",
                    Emissions = "",
                    EngineSize = "",
                    BodyShape = "",
                    FuelType = "",
                    TransmissionType = "",
                    CarFullname = "",
                    Colour = "",
                    RainSensorWindscreenWipers = "",
                    HeadUpDisplay = "",
                    VehicleType = "",
                    CarModel = "",
                    Make = "",
                    CarType = "",
                }
            };
        }

        public static object FromRgtVin()
        {
            return new
            {
                Vin = new
                {
                    Vin_ID = 0,
                    VIN = "",
                    Car_ID = 0,
                    MakeName = "",
                    CarTypeName = "",
                    CarModel = "",
                    Year_ID = 0,
                    Period = "",
                    Month = "",
                    Colour = "",
                    Source = ""
                }
            };
        }
    }

    public class DataProviderTransformationBuilder
    {

        public static object ForIvidTitleHolder()
        {
            return new
            {
                IvidTitleHolderResponse = new
                {
                    BankName = "",
                    AccountNumber = "",
                    DateOpened = DateTime.Now,
                    FinancialInterestsHeading = "",
                    AccountOpenDate = "",
                    AccountClosedDate = "",
                    AgreementType = "",
                    YearOfLiabilityForLicensing = "",
                    RequestFinancialInterestInvite = "",
                    FinancialInterestAvailable = false,
                    PartialResponse = false,
                    HasErrors = false,
                    ExpiredMessage = ""
                }
            };
        }

        public static object ForIvid()
        {
            return new
            {
                IvidResponse = new
                {
                    SpecificInformation = new
                    {
                        Odometer = "Odometer Not Available",
                        Colour = "White",
                        RegistrationNumber = "CNC407L",
                        VinNumber = "SB1KV58E40F039277",
                        LicenseNumber = "XMC167GP",
                        EngineNumber = "1ZRU041295",
                        CategoryDescription = "Light passenger mv(less than 12 persons)",
                        StatusMessage = "NO_ISSUES",
                        Reference = "IVD - 01468460493",
                        License = "XMC167GP",
                        Registration = "CNC407L",
                        RegistrationDate = "2/18/2014",
                        Vin = "SB1KV58E40F039277",
                        Engine = "1ZRU041295",
                        Displacement = 1598,
                        Tare = 1276,
                        MakeCode = "T05",
                        MakeDescription = "Toyota",
                        ModelCode = "D166",
                        ModelDescription = "AURIS",
                        ColourCode = 3,
                        ColourDescription = "White",
                        DrivenCode = 1,
                        DrivenDescription = "Self-propelled",
                        CategoryCode = "B",
                        DescriptionCode = 18,
                        Description = "Hatch back",
                        EconomicSectorCode = 1,
                        EconomicSectorDescription = "Private",
                        LifeStatusCode = 2,
                        LifeStatusDescription = "Used",
                        SapMarkCode = 99,
                        SapMarkDescription = "None",
                        HasIssues = false,
                        HasErrors = false,
                        CarFullname = "Toyota AURIS"
                    }
                }
            };
        }

        public static object ForAudatex()
        {
            return new
            {
                AudatexResponse = new
                {
                    AccidentClaims = new
                    {
                        AccidentClaim = new
                        {
                            AccidentDate = string.Empty,
                            AssessmentNumber = string.Empty,
                            ClaimReferenceNumber = string.Empty,
                            CreationDate = string.Empty,
                            CreationDateString = string.Empty,
                            DataSource = string.Empty,
                            InsuredName = string.Empty,
                            Manufacturer = string.Empty,
                            Mileage = string.Empty,
                            Model = string.Empty,
                            Originator = string.Empty,
                            PolicyNumber = string.Empty,
                            Registration = string.Empty,
                            RepairCostExVat = string.Empty,
                            RepairCostIncVat = string.Empty,
                            VersionDate = string.Empty,
                            Vin = string.Empty,
                            WorkproviderReference = string.Empty,
                            MatchType = string.Empty,
                            QuoteValueIndicator = string.Empty,
                        }
                    },
                    HasAccidentClaims = true,
                    QuoteValueIndicatorNote = "* Indicates the repair quote band segment",
                    LowConfidenceLevelIndicatorNote = "! Indicates that we have a low confidence in the record returned",
                    RegistrationNumberOnlyIndicatorNote = "** This record is matched on Registration number only"
                }
            };
        }

        public static object ForLightstone()
        {
            return new
            {
                LaceResponse = new
                {
                    LightstoneResponse = new
                    {
                        CarFullname = "TOYOTA Auris 1.6 RT 5-dr",
                        CarId = 107483,
                        ImageUrl = "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg",
                        Model = "Auris 1.6 RT 5-dr",
                        Quarter = "3rd Quarter",
                        Vin = "SB1KV58E40F039277",
                        Year = "2008",
                        VehicleValuation = new
                        {
                            AccidentDistribution = new { },
                            AmortisationFactors = new { },
                            AmortisedValues = new { },
                            AreaFactors = new { },
                            AuctionFactors = new { },
                            Confidence = new { },
                            EstimatedValue = new { },
                            Frequency = new { },
                            ImageGauges = new { },
                            LastFiveSales = new { },
                            Prices = new { },
                            RepairIndex = new { },
                            TotalSalesByAge = new { },
                            TotalSalesByGender = new { },
                        }
                    }
                }
            };
        }

        public static object ForRgt()
        {
            return new
            {
                RgtResponse = new
                {
                    Manufacturer = "",
                    ModelYear = "",
                    ModelType = "",
                    TopSpeed = "",
                    Kilowatts = "",
                    FuelEconomy = "",
                    Acceleration = "",
                    Torque = "",
                    Emissions = "",
                    EngineSize = "",
                    BodyShape = "",
                    FuelType = "",
                    TransmissionType = "",
                    CarFullname = "",
                    Colour = "",
                    RainSensorWindscreenWipers = "",
                    HeadUpDisplay = "",
                    VehicleType = "",
                    Model = "",
                    Make = "",
                    CarType = ""

                }
            };
        }

        public static object ForRgtVin()
        {
            return new
            {
                RgtVinResponse = new
                {
                    CarFullname = "TOYOTA Auris 1.6 RT 5-dr",
                    Colour = "STANDARD WHITE",
                    Month = 2,
                    Price = 0,
                    Quarter = 0,
                    RgtCode = string.Empty,
                    VehicleMake = "TOYOTA",
                    VehicleModel = "Auris 1.6 RT 5-dr",
                    VehicleType = string.Empty,
                    Vin = "SB1KV58E40F039277",
                    Year = 2008
                }
            };
        }
    }
}
