'use strict';

department.controller("departmentController", ["$scope", "$uibModalInstance", "departmentEntity", "departmentService", "ngNotify",
    function ($scope, $uibModalInstance, departmentEntity, departmentService, ngNotify) {

        departmentEntity.createdAt = new Date(departmentEntity.createdAt);
        $scope.departmentEntity = departmentEntity;        

        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };
        $scope.popup1 = {
            opened: false
        };

        $scope.ok = function () {
            $scope.isSaving = true;
            departmentEntity.save(departmentEntity).then(
                function (result) {
                    ngNotify.set(result.description + " updated", "success");
                    $scope.isSaving = false;
                    $uibModalInstance.close(result);
                },
                function (result) {
                    ngNotify.set(result.message, "error");
                    $scope.isSaving = false;
                });
        };
        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }]);