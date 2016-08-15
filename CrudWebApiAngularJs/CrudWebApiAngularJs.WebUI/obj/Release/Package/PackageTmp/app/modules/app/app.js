/// <reference path="~/wwwroot/lib/angular/angular.js"/>
var app = angular.module("App", ['ui.router', 'LocalStorageModule', 'restangular', 'ui.bootstrap', 'ngNotify', 'ngSanitize', 'ui.select', 'valdr',
                                                    'department', 'employee', 'invitation', 'home', 'authorization']);

app.run(['ngNotify', '$rootScope', 'appRoles', 'authService', '$state', 'localStorageService', function (ngNotify, $rootScope, appRoles, authService, $state, localStorageService) {

    $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams) {
        if (toState.data.accessState) {
            // Verification of access to states for unauthorized user
            if (toState.data.accessRoles[0] !== appRoles.unauthorized) {
                // If user no authorize go to 'login' state
                if (authService.authentication.isAuth) {
                    // Verification of access to states for uthorized user by user roles
                    if (!authService.isAuthState(toState.data.accessRoles)) {
                        event.preventDefault();
                    }
                }
                else {
                    event.preventDefault();
                    $state.go('login');
                }
            }
        }
        else {
            event.preventDefault();
        }
    });

    ngNotify.config({
        position: 'top',
        duration: 3000,
        button: true
    });
}]);

