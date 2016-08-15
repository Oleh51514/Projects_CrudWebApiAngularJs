'use strict';
department.controller("departmentTableController", ["$scope", "$uibModal", 'departmentService', "ngNotify", "$interval",
    function ($scope, $uibModal, departmentService, ngNotify, $interval) {

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
            { name: "Department Name", field: "name", maxWidth: '300', enableSorting: false },
            { name: 'Description', field: "description", maxWidth: '120', enableSorting: false },
            { name: 'Date of creation', field: "createdAt", cellFilter: 'date: "dd.MM.yyyy HH:mm"', maxWidth: '185', enableSorting: false },
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
                    $scope.paginationOptions.skipPageSize = (newPage-1) * pageSize;
                    $scope.paginationOptions.takePageSize = pageSize;                    
                    $scope.getPage();
                });
                gridApi.selection.on.rowSelectionChanged($scope, function (row) {                    
                    departmentService.selectedId = row.entity.id;
                });
            }
        };
        // Get page data
        $scope.getPage = function () {
            departmentService.getPageData($scope.paginationOptions).then(function (result) {
                $scope.gridOptions.totalItems = result.totalItems;                
                $scope.gridOptions.data = result;
                // Select first row as default in ui-grid
                $interval(function (){ $scope.gridApi.selection.selectRow($scope.gridOptions.data[0]); }, 0, 1);
            }, null);
        };
        $scope.getPage();

        // Delete entity
        $scope.delete = function (row) {
            var modalInstance = $uibModal.open({ templateUrl: 'app/common/templates/modal/confirmationModal.html' });
            modalInstance.result.then(function () {
                departmentService.delete(row.entity.id).then(
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
            var department = row.entity.clone();
            callDepartmentModal(department);
        }
        // add new entity timeFrame
        $scope.add = function () {
            var departmentDefault = departmentService.getDefault();
            callDepartmentModal(departmentDefault);
        }

        function callDepartmentModal(departmentEntity) {

            var modalInstance = $uibModal.open({
                templateUrl: 'app/modules/department/views/departmentModal.html',
                controller: 'departmentController',
                resolve: {
                    departmentEntity: function () {
                        return departmentEntity;
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