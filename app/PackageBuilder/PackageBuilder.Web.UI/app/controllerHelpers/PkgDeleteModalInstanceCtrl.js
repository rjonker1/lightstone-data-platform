(function () {
    'use strict';

    angular.module('app').controller('PkgDeleteModalInstanceCtrl', function ($scope, $modalInstance, datacontext, common,
                                                            packageName, packageId) {

        var controllerId = 'packages';

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        $scope.packageName = packageName;
        $scope.packageId = packageId;

        $scope.ok = function () {

            datacontext.deletePackage(packageId).then(function (result) {

                if (result.status == 200) {

                    log('Package: ' + packageName + ' was removed successfully');
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
