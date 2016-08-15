'use strict';
app.controller("loginController", ["$scope", 'authService', '$state', '$timeout', function ($scope, authService, $state, $timeout) {
    if (authService.authentication.isAuth) {
        $state.go('workspace.workHub.work');
    }


    $scope.successfully = false;
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    // // Authorization user in system
    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
            $scope.message = "login successfully";
            $scope.successfully = true;
            startTimer();
        },
        function (err) {
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
            $scope.message = "Failed to login user due to:" + errors.join(' ');
        });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $state.go('workspace.workHub.work');
        }, 2000);
    }
}]);