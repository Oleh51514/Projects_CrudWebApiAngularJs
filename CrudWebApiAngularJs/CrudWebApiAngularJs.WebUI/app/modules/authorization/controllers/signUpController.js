'use strict';
app.controller("signUpController", ["$scope", "$stateParams", "authService", "invitationService", "$state", function ($scope, $stateParams, authService, invitationService, $state) {
    $scope.message = "";
    $scope.appUser = {};
    $scope.appUser.invitationToken = $stateParams.token;

    $scope.signUp = function () {
        invitationService.confirm($scope.appUser).then(function (responce) {
            authService.logOut();
            var loginData = {
                userName: $scope.appUser.userName,
                password: $scope.appUser.password
            };
            authService.login(loginData).then(function (responce) {
                $state.go("workspace.workSection.timetrackerTable");
            }, null);
        }, function (response) {
            $scope.message = response.data;
            $scope.successfully = false;
        });
    }
}]);