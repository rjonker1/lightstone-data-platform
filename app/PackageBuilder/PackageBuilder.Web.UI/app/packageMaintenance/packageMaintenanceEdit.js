﻿(function () {
    'use strict';

    var controllerId = 'packageMaintenanceEdit';

    angular
        .module( 'app' )
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
        
        $scope.toggleDataFieldColor = function (dataField) {

            if (dataField.dataFields.length > 0) return $scope.dataFieldColor = 'background-color: #4D4D4D !important';
            if (dataField.dataFields.length <= 0) return $scope.dataFieldColor = 'background-color: #4C7E80 !important';
        }

        $scope.rollupSummary = false;

        $scope.toggleDataField = function (value) {

            if (value == true) return $scope.rollupSummary = false;
            if (value == false) return $scope.rollupSummary = true;
        }

        $scope.format = 'MMMM Do YYYY, h:mm:ss a';

        $scope.dataProvsPkg = {};
        //Prevent $modelValue undefined error
        $scope.dataProvsPkg.Package = { };

        //http://stackoverflow.com/questions/14788652/how-to-filter-key-value-with-ng-repeat-in-angularjs
        //pre-filter method
        $scope.filterDataProviders = function (items) {
            var result = {};
            angular.forEach(items, function (value, key) {
                if (key == 'dataProviders') {
                    result[key] = value;
                }
            });
            return result;
        };

        $scope.editPackage = function(packageData) {
            return datacontext.editPackage($routeParams.id, packageData).then(function(response) {
                console.log(response);
                if (response.status === 200) {
                    logSuccess('Package edited!');
                    $location.path('/packages');
                } else {
                    logError('Error 404. Please check your connection settings');
                } 
            }, function (error) {
                logError(error.data.errorMessage);
            });
        };

        $scope.cancel = function () {
            $location.path('/packages');
        };

        $scope.filterIndustry = function (field) {
            if (field == null) return null;
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

        $scope.filterData = function(filterIndustries) {
            filterVal = filterIndustries;
            $scope.dataProvsPkg.Package.Industries = filterIndustries;
        };
        
        $scope.total = function () {
            var rspEdit = angular.element(document.getElementById('rsp'));
            var valueTotal = 0;
            var items = null;

            try {
                items = $scope.dataProvsPkg.Package[0].dataProviders; //Require array type for Package due to response build-up of NancyFx
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
                                if (listItem.dataFields[x] == null)
                                    continue;

                                if (listItem.dataFields[x].isSelected === true) {

                                    var parent = listItem.dataFields[x];

                                //    //var children = listItem.dataFields[x].dataFields;

                                //    //if (children.length > 0) {

                                //    //    for (var m = 0; m < children.length; m++) {

                                //    //        children[m].isSelected = false;

                                //    //        //subChildren override
                                //    //        //if (children[m].dataFields.length > 0) {

                                //    //        //    for (var n = 0; n < children[m].dataFields.length; n++) {

                                //    //        //        children[m].dataFields[n].isSelected = false;
                                //    //        //    }
                                //    //        //}

                                //    //    }
                                //    //}

                                    //valueTotal += parent.costOfSale;
                                    if (parent.dataFields.length <= 0) valueTotal += parent.costOfSale;
                                }
                                //Tier 2
                                for (var j = 0; j < (listItem.dataFields[x].dataFields).length; j++) {
                                    if (listItem.dataFields[x].dataFields[j] == null)
                                        continue;

                                    if (listItem.dataFields[x].dataFields[j].isSelected === true) {

                                        var child = listItem.dataFields[x].dataFields[j];
                                        //var subChildren = listItem.dataFields[x].dataFields[j].dataFields;

                                        //if (subChildren.length > 0) {

                                        //    for (var l = 0; l < subChildren.length; l++) {

                                        //        subChildren[l].isSelected = false;
                                        //    }
                                        //}

                                        valueTotal += child.costOfSale;
                                    }
                                    //Tier 3
                                    for (var k = 0; k < (listItem.dataFields[x].dataFields[j].dataFields).length; k++) {
                                        if (listItem.dataFields[x].dataFields[j].dataFields[k] == null)
                                            continue;

                                        if (listItem.dataFields[x].dataFields[j].dataFields[k].isSelected === true) {

                                            valueTotal += listItem.dataFields[x].dataFields[j].dataFields[k].costOfSale;
                                        }
                                    }
                                }

                            }

                            break;
                        case false:

                            for (var x = 0; x < (listItem.dataFields).length; x++) {
                                if (listItem.dataFields[x] == null)
                                    continue;
                                if (listItem.dataFields[x].isSelected === true) {

                                    valueTotal += listItem.costOfSale;
                                    break;
                                }

                                for (var j = 0; j < (listItem.dataFields[x].dataFields).length; j++) {
                                    if (listItem.dataFields[x].dataFields[j] == null)
                                        continue;
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

            if (valueTotal > rspEdit[0].value) {
                $scope.warning = true;
                $scope.rspEditStyle = { 'color': 'red' };
            } else {
                $scope.warning = false;
                $scope.rspEditStyle = { 'color': 'none' };
            }

            return valueTotal;
        };

        $scope.totalChildren = function(parent, children) {
            var totalChildrenVal = 0;
            for (var i = 0; i < children.length; i++) {
                if (children[i].isSelected) totalChildrenVal += children[i].costOfSale;
            }

            parent.costOfSale = totalChildrenVal;

            return totalChildrenVal;
        };

        activate();

        function activate() {
            common.activateController([getDataProvider($routeParams.id, $routeParams.version), getStates(), getIndustries(), getPackageEventTypes()], controllerId).then(function () {
                log('Activated Package Maintenance View');
            }, function(error) {
                logError(error.data.errorMessage);
            });
        }

        function getDataProvider(id, version) {
            return datacontext.getPackage(id, version).then(function (response) {
                console.log(response);

                //$scope.dataProvsPkg.Package.state = 'Draft';

                if (response.status === 200) {
                    $scope.dataProvsPkg.Package = response.data.response;
                    // Manipulate current state of Pakage at load to reflect alias of enum from API
                    var $lv1 = $(".angular-ui-tree");
                    $lv1.attr('ui-tree-nodes', '');
                    $lv1.find('li').attr('ui-tree-node', '');
                    // State comparison
                    for (var i = 0; i < $scope.states.length; i++) {
                        if ($scope.dataProvsPkg.Package[0].state.id == $scope.states[i].id) {
                            $scope.dataProvsPkg.Package[0].state = $scope.states[i];
                        }
                    }

                    logSuccess('Data Providers loaded!');
                }
            }, function (error) {
                logError(error.data.errorMessage);
            });
        }

        function getStates() {
            return datacontext.getStates().then(function (response) {
                $scope.states = response;
            }, function (error) {
                logError(error.data.errorMessage);
            });
        }
        
        function getIndustries() {
            return datacontext.getIndustries().then(function (response) {
                $scope.industries = response;

                var bootFilters = [];

                for (var i = 0; i < $scope.industries.length; i++) {

                    $scope.industries[i].isSelected = true;
                    bootFilters.push($scope.industries[i]);
                }

                $scope.filterData(bootFilters);
            }, function (error) {
                logError(error.data.errorMessage);
            });
        }

        function getPackageEventTypes() {
            return datacontext.getPackageEventTypes().then(function (response) {
                $scope.packageEventTypes = response;
            }, function (error) {
                logError(error.data.errorMessage);
            });
        }
        
        $scope.filterDataProvierFields = function (dp) {
            for (var i = 0; i < dp.dataFields.length; i++) {
                if (dp.dataFields[i].isSelected) {
                    return true;
                }
            }
            return false; 
        };
    }
})();
