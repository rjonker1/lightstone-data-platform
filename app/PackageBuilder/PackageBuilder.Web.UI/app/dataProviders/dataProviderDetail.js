(function () {
    'use strict';

    var controllerId = 'dataProviderDetail';

    angular
        .module('app')
        .controller(controllerId, dataProviderDetail);

    dataProviderDetail.$inject = ['$scope', '$location', '$routeParams', 'common', 'datacontext'];

    function dataProviderDetail($scope, $location, $routeParams, common, datacontext) {

        $scope.title = 'Data Provider Detail';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logSuccess = getLogFn(controllerId, 'success');
        var logError = getLogFn(controllerId, 'error');

        $scope.test = {};

        $scope.format = 'MMMM Do YYYY, h:mm:ss a';

        $scope.users = [

        { name: 'Al' },
        { name: 'user2' },
        { name: 'user3' }
        ];

        // Defaulted postion for toggle-switch
        //$scope.switch = 'true';
        //$scope.switchAlternate = 'Per Field';

        $scope.toggle = function(state) {

            (state == true) ? $scope.switch = false : $scope.switch = true;
            $scope.dataProvider.response[0].fieldLevelCostPriceOverride = $scope.switch;
            $scope.dataProvider.response[0].costOfSale = 0;
        };

        $scope.selectedGroupIndustry = {};

        $scope.updateFieldIndustry = function(groupIndustry) {

            var provider = null;

            try {

                provider = $scope.dataProvider.response;
            } catch(e) {

                //console.log(e.message);
            }

            if (provider != null) {

                for (var i = 0; i < provider.length; i++) {

                    var providerItem = provider[i];

                    for (var x = 0; x < (providerItem.dataFields).length; x++) {
                        if (providerItem.dataFields[x] == null)
                            continue;

                        providerItem.dataFields[x].industry = groupIndustry;

                        if ((providerItem.dataFields[x].dataFields).length > 0) {

                            for (var j = 0; j < (providerItem.dataFields[x].dataFields).length; j++) {
                                if (providerItem.dataFields[x].dataFields[j] == null)
                                    continue;

                                providerItem.dataFields[x].dataFields[j].industry = groupIndustry;
                            }
                        }
                    }
                }
            }
        };

        $scope.total = function () {

            var valueTotal = 0;
            var items = null;

            try {

                items = $scope.dataProvider.response;
            } catch (e) {

                //console.log(e.message);
            }

            //Validates a check between CoS per request | per field
            if (!$scope.switch) return null;

            //Calculation logic
            if (items != null) {

                for (var i = 0; i < items.length; i++) {

                    var listItem = items[i];

                    for (var x = 0; x < (listItem.dataFields).length; x++) {
                        if (listItem.dataFields[x] == null)
                            continue;

                        valueTotal += listItem.dataFields[x].costOfSale;

                        if ((listItem.dataFields[x].dataFields).length > 0) {

                            var subFields = listItem.dataFields[x].dataFields;

                            for (var j = 0; j < (subFields).length; j++) {

                                valueTotal += subFields[j].costOfSale;

                                var subChildFields = subFields[j].dataFields;
                                for (var k = 0; k < subChildFields.length; k++) {

                                    valueTotal += subChildFields[k].costOfSale;
                                }
                            }
                        }
                    }

                }
            }

            $scope.dataProvider.response[0].costOfSale = valueTotal;
            return valueTotal;
        };

        $scope.totalParChar = function (dataItem) {
            var valueTotal = 0;

            if (dataItem == null)
                return valueTotal;
            
            var subItems = dataItem.dataFields;
            for (var i = 0; i < subItems.length; i++) {

                valueTotal += subItems[i].costOfSale;
                valueTotal += $scope.totalParChar(subItems[i]);
            }

            return valueTotal;
        };
        
        $scope.childIndustryChanged = function (childIndustry, dataField) {
            console.log(dataField);
            console.log(childIndustry);

            selectParentIndustries(dataField);
        };
        
        function selectParentIndustries(dataField) {
            var parentFieldNames = dataField.namespace.split(".");
            var parentFieldName = parentFieldNames[0];
            for (var i = 1; i < parentFieldNames.length - 1; i++) {
                if (i != parentFieldNames.length - 1)
                    parentFieldName = parentFieldName + "." + parentFieldNames[i];
            }

            var parentField = filterDataFields($scope.dataProvider.response[0].dataFields, 'namespace', parentFieldName)[0];
            if (parentField == null)
                return;

            //var selectedIndustries = [];
            //Enumerable.From(parentField.dataFields)
            //    .SelectMany(function(x) { return x.industries; })
            //    .ToLookup(function(x) { return x.isSelected; })
            //    .ToEnumerable()
            //    .ForEach(function(x) {
            //        if (x.Key() == false)
            //            unselectedIndustries.push(x.Distinct("$.name"));
            //        if (x.Key() == true)
            //            selectedIndustries.push(x.Distinct("$.name"));
            //    });

            var selectedIndustries = Enumerable.From(parentField.dataFields)
                .SelectMany(function(x) { return x.industries; })
                .Where("$.isSelected==true")
                .Distinct("$.name")
                .Select(function (x) { return x; });

            Enumerable.From(parentField.industries).ForEach(function(parentIndustry) {
                parentIndustry.isSelected = false;
                var industry = selectedIndustries.Where(function (selectedIndustry) {
                    return selectedIndustry.id == parentIndustry.id;
                }).FirstOrDefault();
                if (industry)
                    parentIndustry.isSelected = industry.isSelected;
            });

            //Enumerable.From(dataField.industries).ForEach(function (ind) {
            //    var industry = Enumerable.From(parentField.industries).Where(function (i) {
            //        return i.id == ind.id;
            //    }).FirstOrDefault();
            //    industry.isSelected = ind.isSelected;
            //});

            if (parentField.namespace != parentFieldNames[0])
                selectParentIndustries(parentField);
        }
        
        function filterDataFields(obj, key, val) {
            var objects = [];
            for (var i in obj) {
                if (!obj.hasOwnProperty(i)) continue;
                if (typeof obj[i] == 'object') {
                    objects = objects.concat(filterDataFields(obj[i], key, val));
                } else if (i == key && obj[key] == val) {
                    objects.push(obj);
                }
            }
            return objects;
        }

        $scope.editProvider = function (providerData) {
            return datacontext.editDataProvider($routeParams.id, providerData).then(function (response) {
                //console.log(response);
                if (response.status === 200) {
                    logSuccess('Data Provider edited!');
                    $location.path('/data-providers');
                } else {
                    logError('Error 404. Please check your connection settings');
                }
            });
        };

        $scope.cancel = function () {
            $location.path('/data-providers');
        };

        activate();

        function activate() {

            common.activateController([getDataProvider($routeParams.id, $routeParams.version), getIndustries()], controllerId)
                .then(function () {
                    log('Activated Data Providers Edit View');
                });
        }

        function getDataProvider(id, version) {

            return datacontext.getDataProvider(id, version).then(function (response) {

                $scope.dataProvider = response.data;
                $scope.switch = $scope.dataProvider.response[0].fieldLevelCostPriceOverride;

                ($scope.switch == true) ? $scope.switchAlternate = 'Per Field' : $scope.switchAlternate = 'Per Request';
            });
        }

        function getIndustries() {

            return datacontext.getIndustries().then(function (response) {

                $scope.industries = response;
            });
        }
    }
})();

