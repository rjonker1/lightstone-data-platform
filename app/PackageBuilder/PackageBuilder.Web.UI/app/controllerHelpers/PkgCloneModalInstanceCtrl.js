(function () {
    'use strict';

    angular.module('app').controller('PkgCloneModalInstanceCtrl', function ($scope, $modalInstance, datacontext, common,
                                                            items, packageName, packageId) {

        var controllerId = 'packages';

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        $scope.packageName = packageName;
        $scope.packageId = packageId;

        $scope.items = items;
        $scope.selected = {
            item: $scope.items[0]
        };

        $scope.ok = function (cloneName) {

            datacontext.clonePackage(packageId, cloneName).then(function(result) {

                if (result.status == 200) {

                    log('New Package: ' + cloneName + ' has been cloned successfully');
                    $modalInstance.close();
                } else {
                    logError(result);
                }
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

})();
