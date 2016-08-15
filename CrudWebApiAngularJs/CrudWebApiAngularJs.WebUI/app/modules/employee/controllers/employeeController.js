'use strict';
employee.controller("employeeController", ["$scope", "$uibModalInstance", "employeeEntity", "employeeService", "ngNotify", "departmentService",
    function ($scope, $uibModalInstance, employeeEntity, employeeService, ngNotify, departmentService) {

        //employeeEntity.createdAt = new Date(departmentEntity.createdAt);
        $scope.employeeEntity = employeeEntity;        
        $scope.employeeEntity.age = parseInt(employeeEntity.age);

        $scope.project = {};
        // Get all the user project
        departmentService.getAll().then(function (result) {
            $scope.departments = result;

        }, null);

        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };
        $scope.popup1 = {
            opened: false
        };

        $scope.ok = function () {
            $scope.isSaving = true;
            employeeEntity.save(employeeEntity).then(
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