(function () {
    'use strict';

    angular.module('app').controller('ModalInstanceCtrl', function ($scope, $modalInstance, datacontext,
                                                            items, packageName, packageId) {

        $scope.packageName = packageName;
        $scope.packageId = packageId;

        $scope.items = items;
        $scope.selected = {
            item: $scope.items[0]
        };

        $scope.ok = function (cloneName) {

            datacontext.clonePackage(packageId, cloneName);
            $modalInstance.close($scope.packageId);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

})();
