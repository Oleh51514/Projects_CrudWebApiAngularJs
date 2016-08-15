'use strict';
app.controller("workspaceController", ['$state', 'authService', "$scope", "$rootScope", function ($state, authService, $scope, $rootScope) {
    $scope.userData = {
        name: authService.authentication.userName,
        email: authService.authentication.userEmail
    }
    $scope.$state = $state;

    $scope.logOut = function () {
        authService.logOut();
        $state.go('login');
    }
}]);