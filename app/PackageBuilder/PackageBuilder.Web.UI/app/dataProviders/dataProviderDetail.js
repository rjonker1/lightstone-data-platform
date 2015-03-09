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

        $scope.toggle = function (state) {

            (state == true) ? $scope.switch = false : $scope.switch = true;
            $scope.dataProvider.response[0].fieldLevelCostPriceOverride = $scope.switch;
            $scope.dataProvider.response[0].costOfSale = 0;
        }

        $scope.selectedGroupIndustry = {};

        $scope.updateFieldIndustry = function (groupIndustry) {

            var provider = null;

            try {

                provider = $scope.dataProvider.response;
            } catch (e) {

                //console.log(e.message);
            }

            if (provider != null) {

                for (var i = 0; i < provider.length; i++) {

                    var providerItem = provider[i];

                    for (var x = 0; x < (providerItem.dataFields).length; x++) {

                        providerItem.dataFields[x].industry = groupIndustry;

                        if ((providerItem.dataFields[x].dataFields).length > 0) {

                            for (var j = 0; j < (providerItem.dataFields[x].dataFields).length; j++) {


                                providerItem.dataFields[x].dataFields[j].industry = groupIndustry;
                            }
                        }
                    }

                }
            }
        }

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


                        valueTotal += listItem.dataFields[x].price;

                        if ((listItem.dataFields[x].dataFields).length > 0) {

                            var subFields = listItem.dataFields[x].dataFields;

                            for (var j = 0; j < (subFields).length; j++) {

                                valueTotal += subFields[j].price;

                                var subChildFields = subFields[j].dataFields;
                                for (var k = 0; k < subChildFields.length; k++) {

                                    valueTotal += subChildFields[k].price;
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
            var items = dataItem;
            var subItems = items.dataFields;

            for (var i = 0; i < subItems.length; i++) {

                valueTotal += subItems[i].price;

                var subChildItems = subItems[i].dataFields;

                for (var j = 0; j < subChildItems.length; j++) {

                    valueTotal += subChildItems[j].price;
                }

            }


            return valueTotal;
        };


        $scope.childIndustryChanged = function (childIndustry, parent) {

            console.log(parent);
            console.log(childIndustry);

            var industries = $scope.industries;

            for (var i = 0; i < industries.length; i++) {

                if (industries[i].id == childIndustry.id) {

                    //Returns an Array of the fields that currently occupy said Industry.
                    var getChildrenSelected = $scope.checkChildren(childIndustry.name);
                    if (getChildrenSelected.length <= 0) {

                        parent.industries[i].isSelected = false;
                        continue;
                    }

                    parent.industries[i].isSelected = true;
                }

            }

        };

        $scope.checkChildren = function(childIndusName) {

            var childArray = [];
            var items = null;

            try {

                items = $scope.dataProvider.response;
            } catch(e) {

                //console.log(e.message);
            }

            if (items != null) {

                for (var i = 0; i < items.length; i++) {

                    var listItem = items[i];

                    for (var x = 0; x < (listItem.dataFields).length; x++) {


                        if ((listItem.dataFields[x].dataFields).length > 0) {

                            var subFields = listItem.dataFields[x].dataFields;

                            for (var j = 0; j < (subFields).length; j++) {

                                var industries = subFields[j].industries;

                                //Child Industries
                                for (var k = 0; k < (industries).length; k++) {

                                    if ((industries[k].name == childIndusName) && (industries[k].isSelected == true)) {

                                        childArray.push(subFields[j].name);
                                    } else {

                                        var subChildFields = subFields[j].dataFields;
                                        for (var l = 0; l < (subChildFields).length; l++) {

                                            //Sub-child Industries
                                            var subIndustries = subChildFields[l].industries;
                                            for (var kk = 0; kk < (industries).length; kk++) {

                                                if ((subIndustries[kk].name == childIndusName) && (subIndustries[kk].isSelected == true)) {

                                                    childArray.push(subChildFields[l].name);
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                        }
                    }

                }
            }

            return childArray;
        };

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

