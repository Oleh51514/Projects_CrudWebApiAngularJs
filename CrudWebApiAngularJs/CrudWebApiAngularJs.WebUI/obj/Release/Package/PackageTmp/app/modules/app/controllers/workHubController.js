'use strict';
app.controller("workHubController", ["$scope", "$rootScope", function ($scope, $rootScope) {
    $scope.tabs = [
        { title: "Departments", route: "department", active: false },
        { title: "Employees", route: "employee", active: true },
    ];
    $rootScope.$watch(function () {
        return $scope.tabs[1].active;
    }, function watchCallback(newValue, oldValue) {
        if (newValue == true) {
            var ccc = "wdwd";
        }        
    });
    $scope.goToEmployee = function () {
        $scope.$broadcast('tabEmployeeEvent', {
            someProp: 'Sending you an Object!' 
        });
    };
}]);