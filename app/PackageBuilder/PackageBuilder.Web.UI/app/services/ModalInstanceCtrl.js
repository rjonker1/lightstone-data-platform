(function () {
    'use strict';

    angular.module('app').controller('ModalInstanceCtrl', function ($scope, $modalInstance,
                                                            items, packageName, packageId) {

        $scope.packageName = packageName;
        $scope.packageId = packageId;

        $scope.items = items;
        $scope.selected = {
            item: $scope.items[0]
        };

        $scope.ok = function () {
            $modalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

})();
