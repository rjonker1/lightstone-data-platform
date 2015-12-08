namespace Lim.Test.Helper.Fakes
{
    public class FakeResponse
    {
        public static string JsonFromPackage()
        {
            return
                @"[{'id':'9fce37f2-fcb0-43b1-9436-ab031f280d10','name':4,'description':null,'costOfSale':0,'sourceConfiguration':{'isApiConfiguration':true,'url':null,'username':null,'password':null,'connectionString':''},'responseType':null,'fieldLevelCostPriceOverride':false,'owner':null,'createdDate':'0001-01-01T00:00:00.0000000+02:00','editedDate':null,'requestFields':[],'dataFields':[{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'CarId','name':'CarId','label':null,'value':'107483','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.Nullable`1[System.Int32]','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'Year','name':'Year','label':null,'value':'2008','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.Nullable`1[System.Int32]','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'ImageUrl','name':'ImageUrl','label':null,'value':'http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.String','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'Quarter','name':'Quarter','label':null,'value':'3rd Quarter','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.String','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'CarFullname','name':'CarFullname','label':null,'value':'TOYOTA Auris 1.6 RT 5-dr','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.String','dataFields':[]}],'version':0}]";
        }

        public static string JsonPackageWithState()
        {
            return @"[
    {
        'requestId': 'a25a0e42-7373-4c14-9dbd-34ffd8abb752',
        'responseState': 1,
        'responseStateMessage': 'Successful Response'
    },
    {
        'name': 0,
        'responseState': 1,
        'dataFields': [
            {
                'namespace': 'License',
                'label': null,
                'value': 'BZ11VPGP',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Registration',
                'label': null,
                'value': 'FFB715K',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'RegistrationDate',
                'label': null,
                'value': '2012-07-19',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Vin',
                'label': null,
                'value': 'WAUZZZ8K8DA074674',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Engine',
                'label': null,
                'value': 'CJE022000',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Displacement',
                'label': null,
                'value': '1798',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Tare',
                'label': null,
                'value': '1395',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'MakeCode',
                'label': null,
                'value': 'A07',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'MakeDescription',
                'label': null,
                'value': 'AUDI',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'ModelCode',
                'label': null,
                'value': 'E017',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'ModelDescription',
                'label': null,
                'value': 'AU 481-A4',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'ColourCode',
                'label': null,
                'value': '03',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'ColourDescription',
                'label': null,
                'value': 'White',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'DrivenCode',
                'label': null,
                'value': '1',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'DrivenDescription',
                'label': null,
                'value': 'Self-propelled',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'CategoryCode',
                'label': null,
                'value': 'B',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'CategoryDescription',
                'label': null,
                'value': 'Light passenger mv(less than 12 persons)',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'DescriptionCode',
                'label': null,
                'value': '12',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Description',
                'label': null,
                'value': 'Sedan (closed top)',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            }
        ]
    },
    {
        'name': 4,
        'responseState': 1,
        'dataFields': [
            {
                'namespace': 'VehicleValuation',
                'label': null,
                'value': null,
                'definition': null,
                'order': 0,
                'type': null,
                'dataFields': [
                    {
                        'namespace': 'VehicleValuation.EstimatedValue',
                        'label': null,
                        'value': null,
                        'definition': null,
                        'order': 0,
                        'type': null,
                        'dataFields': [
                            {
                                'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel',
                                'label': null,
                                'value': null,
                                'definition': null,
                                'order': 0,
                                'type': null,
                                'dataFields': [
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.RetailEstimatedValue',
                                        'label': null,
                                        'value': 'R224 100,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.RetailEstimatedLow',
                                        'label': null,
                                        'value': 'R200 400,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.RetailEstimatedHigh',
                                        'label': null,
                                        'value': 'R250 600,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.RetailConfidenceValue',
                                        'label': null,
                                        'value': '73',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.RetailConfidenceLevel',
                                        'label': null,
                                        'value': 'Medium',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.TradeEstimatedValue',
                                        'label': null,
                                        'value': 'R201 200,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.TradeEstimatedLow',
                                        'label': null,
                                        'value': 'R179 900,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.TradeEstimatedHigh',
                                        'label': null,
                                        'value': 'R219 520,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.TradeConfidenceValue',
                                        'label': null,
                                        'value': '50',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.TradeConfidenceLevel',
                                        'label': null,
                                        'value': 'Low',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.AuctionEstimate',
                                        'label': null,
                                        'value': 'R138 500,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.CostLow',
                                        'label': null,
                                        'value': 'R169 500,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.CostHigh',
                                        'label': null,
                                        'value': 'R211 900,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    },
                                    {
                                        'namespace': 'VehicleValuation.EstimatedValue.EstimatedValueModel.CostValue',
                                        'label': null,
                                        'value': 'R189 500,00',
                                        'definition': null,
                                        'order': 0,
                                        'type': 'System.String',
                                        'dataFields': []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        'namespace': 'VehicleValuation.LastFiveSales',
                        'label': null,
                        'value': null,
                        'definition': null,
                        'order': 0,
                        'type': null,
                        'dataFields': []
                    },
                    {
                        'namespace': 'VehicleValuation.Prices',
                        'label': null,
                        'value': null,
                        'definition': null,
                        'order': 0,
                        'type': null,
                        'dataFields': []
                    }
                ]
            },
            {
                'namespace': 'CarId',
                'label': null,
                'value': '111668',
                'definition': null,
                'order': 0,
                'type': 'System.Nullable`1[System.Int32]',
                'dataFields': []
            },
            {
                'namespace': 'Year',
                'label': null,
                'value': '2012',
                'definition': null,
                'order': 0,
                'type': 'System.Nullable`1[System.Int32]',
                'dataFields': []
            },
            {
                'namespace': 'Vin',
                'label': null,
                'value': 'WAUZZZ8K8DA074674',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'ImageUrl',
                'label': null,
                'value': 'http://www.rgt.co.za/photos/AUDI/111668_1_P.jpg',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Quarter',
                'label': null,
                'value': '3rd Quarter',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'CarFullname',
                'label': null,
                'value': 'AUDI A4 1.8T FSI S 125kW',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            },
            {
                'namespace': 'Model',
                'label': null,
                'value': 'A4 1.8T FSI S 125kW',
                'definition': null,
                'order': 0,
                'type': 'System.String',
                'dataFields': []
            }
        ]
    }
]";
        }
    }
}
