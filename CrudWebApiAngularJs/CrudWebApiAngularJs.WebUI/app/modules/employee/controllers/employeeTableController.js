'use strict';
employee.controller("employeeTableController", ["$scope", "$uibModal", 'employeeService', "ngNotify", "$interval","departmentService",
    function ($scope, $uibModal, employeeService, ngNotify, $interval, departmentService) {

        $scope.$on('tabEmployeeEvent', function (event, data) {
            $scope.paginationOptions.filters = [];
            $scope.paginationOptions.filters.push("DepartmentId =  " + departmentService.selectedId);
            $scope.getPage();
        });

        // Options for pagination on server
        $scope.paginationOptions = {
            skipPageSize: 0,
            takePageSize: 5,
            sortColumns: ["id asc"],
            filters: []
        };
        
        // Options for ui-grid
        $scope.gridOptions = {
            paginationPageSizes: [5, 10, 15],
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            modifierKeysToMultiSelect: true,
            noUnselect: true,
            multiSelect: true,
            paginationPageSize: 5,
            useExternalPagination: true,
            useExternalSorting: true,
            "columnDefs": [
            { name: 'id', visible: false },
            { name: "FirstName", field: "firstName", maxWidth: '300', enableSorting: false },
            { name: 'LastName', field: "lastName", maxWidth: '120', enableSorting: false },
            { name: 'Age', field: "age", maxWidth: '70', enableSorting: false },
            { name: 'Department', field: 'department.name', maxWidth: '250' },
            {
                name: 'action',
                enableSorting: false,
                cellTemplate: '<div class="ui-grid-cell-contents">' +
                                          '<button ng-click="grid.appScope.edit(row)">edit</button>' +
                                          '<button ng-click="grid.appScope.delete(row)">delete</button>' +
                                        '</div>'
            }],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    $scope.paginationOptions.skipPageSize = (newPage - 1) * pageSize;
                    $scope.paginationOptions.takePageSize = pageSize;
                    $scope.getPage();
                });
            }
        };
        // Get page data
        $scope.getPage = function () {
            employeeService.getPageData($scope.paginationOptions).then(function (result) {
                $scope.gridOptions.totalItems = result.totalItems;
                $scope.gridOptions.data = result;
                // Select first row as default in ui-grid
                $interval(function () { $scope.gridApi.selection.selectRow($scope.gridOptions.data[0]); }, 0, 1);
            }, null);
        };
        

        // Delete entity
        $scope.delete = function (row) {
            var modalInstance = $uibModal.open({ templateUrl: 'app/common/templates/modal/confirmationModal.html' });
            modalInstance.result.then(function () {
                employeeService.delete(row.entity.id).then(
                    function (result) {
                        ngNotify.set("Deleted successed", "success");
                        var index = $scope.gridOptions.data.indexOf(row.entity);
                        $scope.getPage();
                    },
                    function (result) {
                        ngNotify.set(result, "error");
                    });
            }, null);
        };

        // edit selected entity timeFrame
        $scope.edit = function (row) {
            var employee = row.entity.clone();
            callEmployeeModal(employee);
        }
        // add new entity timeFrame
        $scope.add = function () {
            var employeeDefault = employeeService.getDefault();
            callEmployeeModal(employeeDefault);
        }

        function callEmployeeModal(employeeEntity) {

            var modalInstance = $uibModal.open({
                templateUrl: 'app/modules/employee/views/employeeModal.html',
                controller: 'employeeController',
                resolve: {
                    employeeEntity: function () {
                        return employeeEntity;
                    }
                }
            });
            modalInstance.result.then(function () {
                //alert("create or update");
                $scope.getPage();
            }, function () {
                // alert("cancel");
            });
        };
    }]);