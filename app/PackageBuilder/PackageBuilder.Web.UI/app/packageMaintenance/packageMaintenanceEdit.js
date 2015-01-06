(function () {
    'use strict';

    var controllerId = 'packageMaintenanceEdit';

    angular
        .module('app')
        .controller(controllerId, packageMaintenanceCreate);

    packageMaintenanceCreate.$inject = ['$scope', '$location', '$routeParams', '$parse', '$http', 'common', 'datacontext'];

    function packageMaintenanceCreate($scope, $location, $routeParams, $parse, $http, common, datacontext) {

        $scope.title = 'Package Maintenance - Edit';
        var filterVal = 'All';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.users = [

        { name: 'Al' },
        { name: 'user2' },
        { name: 'user3' }
        ];

        $scope.format = 'MMMM Do YYYY, h:mm:ss a';

        $scope.dataProvsPkg = {};
        //Prevent $modelValue undefined error
        $scope.dataProvsPkg.Package = { 'mock' : 'mock' }


        $scope.editPackage = function (packageData) {

            return datacontext.editPackage($routeParams.id, packageData).then(function (response) {

                console.log(response);
                (response.status === 200) ? logSuccess('Package edited!') : logError('Error 404. Please check your connection settings');
            });
        }

        $scope.cancel = function () {

            $location.path('/packages');
        };

        $scope.filterIndustry = function (field) {

            var fieldIndustries = field.industries;

            for (var i = 0; i < fieldIndustries.length; i++) {

                for (var j = 0; j < filterVal.length; j++) {

                    if ((fieldIndustries[i].name === filterVal[j].name) && (fieldIndustries[i].isSelected)) {

                        return field;
                    }

                }

            }

            return null;
        };

        $scope.filterData = function (filterIndustries) {

            filterVal = filterIndustries;
        }

        $scope.total = function () {

            var rspCreate = angular.element(document.getElementById('rsp'));
            var valueTotal = 0;
            var items = null;

            try {

                items = $scope.dataProvsPkg.Package[0].dataProviders; //Require array type for Package due to response build-up of NancyFx
                console.log(items);

            } catch (e) {

                //console.log(e.message);
            }

            if (items != null) {

                for (var i = 0; i < items.length; i++) {

                    var listItem = items[i];

                    switch (listItem.fieldLevelCostPriceOverride) {
                        case true:
                            //Tier 1
                            for (var x = 0; x < (listItem.dataFields).length; x++) {

                                if (listItem.dataFields[x].isSelected === true) {

                                    var parent = listItem.dataFields[x];
                                    var children = listItem.dataFields[x].dataFields;

                                    if (children.length > 0) {

                                        for (var m = 0; m < children.length; m++) {

                                            children[m].isSelected = false;

                                            //subChildren override
                                            if (children[m].dataFields.length > 0) {

                                                for (var n = 0; n < children[m].dataFields.length; n++) {

                                                    children[m].dataFields[n].isSelected = false;
                                                }
                                            }

                                        }
                                    }

                                    valueTotal += parent.price;
                                }
                                //Tier 2
                                for (var j = 0; j < (listItem.dataFields[x].dataFields).length; j++) {

                                    if (listItem.dataFields[x].dataFields[j].isSelected === true) {

                                        var child = listItem.dataFields[x].dataFields[j];
                                        var subChildren = listItem.dataFields[x].dataFields[j].dataFields;

                                        if (subChildren.length > 0) {

                                            for (var l = 0; l < subChildren.length; l++) {

                                                subChildren[l].isSelected = false;
                                            }
                                        }

                                        valueTotal += child.price;
                                    }
                                    //Tier 3
                                    for (var k = 0; k < (listItem.dataFields[x].dataFields[j].dataFields).length; k++) {

                                        if (listItem.dataFields[x].dataFields[j].dataFields[k].isSelected === true) {

                                            valueTotal += listItem.dataFields[x].dataFields[j].dataFields[k].price;
                                        }
                                    }
                                }

                            }

                            break;
                        case false:

                            for (var x = 0; x < (listItem.dataFields).length; x++) {

                                if (listItem.dataFields[x].isSelected === true) {

                                    valueTotal += listItem.costOfSale;
                                    break;
                                }

                                for (var j = 0; j < (listItem.dataFields[x].dataFields).length; j++) {

                                    if (listItem.dataFields[x].dataFields[j].isSelected === true) {

                                        valueTotal += listItem.costOfSale;
                                    }
                                }
                            }

                            break;

                        default:
                            break;
                    }

                }
            }

            $scope.dataProvsPkg.Package.CostOfSale = valueTotal;

            if (valueTotal > rspCreate[0].value) {

                $scope.warning = true;
                $scope.rspCreateStyle = { 'color': 'red' };
            } else {

                $scope.warning = false;
                $scope.rspCreateStyle = { 'color': 'none' };
            }

            return valueTotal;
        };

        $scope.totalChildren = function (parent, children) {

            var totalChildrenVal = 0;

            for (var i = 0; i < children.length; i++) {

                totalChildrenVal += children[i].price;
            }

            parent.price = totalChildrenVal;

            return totalChildrenVal;
        }


        activate();

        function activate() {

            common.activateController([getDataProvider($routeParams.id, $routeParams.version), getStates(), getIndustries()], controllerId)
               .then(function () { log('Activated Package Maintenance View'); });
        }

        function getDataProvider(id, version) {

            return datacontext.getPackage(id, version).then(function (response) {

                console.log(response);

                if (response.status === 200) {

                    $scope.dataProvsPkg.Package = response.data.response;
                    //Manipulate current state of Pakage at load to reflect alias of enum from API

                    logSuccess('Data Providers loaded!');

                }

                if (response.status === 404) {

                    //Load MOCK data
                    $http({
                        method: 'GET',
                        url: '/app/packageMaintenance/DataProviders.json'
                    }).success(function (data, status, headers, config) {

                        $scope.dataProvsPkg = data;

                    }).error(function (data, status, headers, config) {

                    });

                    logError('Error 404. Please check your connection settings');
                }

            });
        }

        function getStates() {

            return datacontext.getStates().then(function (response) {

                $scope.states = response;
            });
        }

        function getIndustries() {

            return datacontext.getIndustries().then(function (response) {

                $scope.industries = response;
                //$scope.filteredConstraint = $scope.industries[0];

                var bootFilters = [];

                for (var i = 0; i < $scope.industries.length; i++) {

                    $scope.industries[i].isSelected = true;
                    bootFilters.push($scope.industries[i]);
                }

                $scope.filterData(bootFilters);
            });
        }

    }
})();
