/////<reference path="~/Scripts/jasmine/jasmine.js"/>
/////<reference path="~/Scripts/angular.js"/>
/////<reference path="~/Scripts/angular-mocks.js"/>
/////<reference path="~/Scripts/angular-resource.min.js"/>
/////<reference path="~/Scripts/angular-animate.min.js"/>
/////<reference path="~/Scripts/angular-route.min.js"/>
/////<reference path="~/Scripts/angular-sanitize.min.js"/>
/////<reference path="~/Scripts/ui-grid3.js"/>
/////<reference path="~/Scripts/angular-ui-tree.min.js"/>
/////<reference path="~/Scripts/angular-multi-select.js"/>

/////<reference path="~/App/app.js"/>
/////<reference path="~/App/common/common.js"/>
/////<reference path="~/App/common/bootstrap/bootstrap.dialog.js"/>
/////<reference path="~/Scripts/ui-bootstrap-tpls-0.10.0.min.js"/>
/////<reference path="~/App/services/apiProviders.js"/>
/////<reference path="~/App/resources/industryResources.js"/>
/////<reference path="~/App/resources/stateResources.js"/>


/////<reference path="~/App/dataProviders/dataProviders.js"/>

////Test suite
//describe('Controller: DataProvider', function () {

//    var scope, controller, common, datacontext;

//    //Setup Mocks for common and datacontext services
//    beforeEach(function() {

//        var commonMock = {};
//        var datacontextMock = {};

//        //module('common', function ($provide) {
//        //    $provide.value('common', commonMock);
//        //});

//        module('app', function($provide) {
//            $provide.value('datacontext', datacontextMock);
//        });

//        inject(function($q) {
//            datacontextMock.data = [
//                { name: 'Name' },
//                { description: 'Description' },
//                { owner: 'Owner' },
//                { createdDate: 'Created Date' },
//                { editedDate: 'Edited Date' },
//                { version: 'Version' }
//            ];

//            //commonMock.logger = function () {
                
//            //};

//            datacontextMock.getAllDataProviders = function () {
//                var defer = $q.defer();

//                defer.resolve(this.data);

//                return defer.promise;
//            };

//        });
//    });

//    //Load dependencies and set up the controller for the test
//    beforeEach(inject(function ($controller, $rootScope, _common_, _datacontext_) {
//        scope = $rootScope;
//        //common = _common_;
//        datacontext = _datacontext_;

//    }));

//    //Instantaite the controller
//    beforeEach(inject(function ($controller, $rootScope, _common_, _datacontext_) {
//        scope = $rootScope.$new();
//        common = _common_;
//        datacontext = _datacontext_;

//        controller = $controller("dataProviders", { $scope: scope });

//        scope.$digest(); // $digest to resolve all promises setup on the mock service
//    }));

//    it('should have title set to "Data Providers"', function() {

//        //expect(scope.title).toEqual('Data Providers');
//        expect(scope.title).toEqual(1);
//    });

//});