'use strict';
app.factory('authInterceptorService', ['$q', '$injector', '$location', 'localStorageService', function ($q, $injector, $location, localStorageService) {

    var authInterceptorServiceFactory = {};

    // Add token data to request
    var _request = function (config) {
        config.headers = config.headers || {};
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }
        return config;
    }

    // Redirect to "Login" page if request status (401) unauthorized
    var _responseError = function (rejection) {
        var authService = $injector.get('authService');
        var authData = localStorageService.get('authorizationData');
        if (rejection.status === 401 && authData === undefined) {

            authService.logOut();
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;
    return authInterceptorServiceFactory;
}]);