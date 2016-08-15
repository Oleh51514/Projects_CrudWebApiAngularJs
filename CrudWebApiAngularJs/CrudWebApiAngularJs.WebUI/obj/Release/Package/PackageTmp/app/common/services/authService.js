'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', '$state', 'config', '$rootScope', function ($http, $q, localStorageService, $state, config, $rootScope) {

    var authServiceFactory = {};
    var baseUrl = config.baseUrl;

    var _authentication = {
        isAuth: false,
        userEmail: "",
        userName: "",
        userRoles: [],
        userId: ""
    };

    // Authorization user in state "ui-router"
    var _isAuthState = function (data) {
        var accessRoles = data;
        var userRoles = authServiceFactory.authentication.userRoles;
        var coincideRoles = [];

        for (var i = 0; i < userRoles.length; ++i) {
            for (var j = 0; j < accessRoles.length; ++j) {
                // Compare elements
                if (userRoles[i] == accessRoles[j]) {
                    coincideRoles.push(userRoles[i]);
                }
            }
        }
        return (coincideRoles.length > 0)
    }

    // Authentication user in system
    var _login = function (loginData) {
        var userName = loginData.userName;
        var loginData = "grant_type=password&username=" + userName + "&password=" + loginData.password;
        var deferred = $q.defer();
        var req = {
            method: 'POST',
            url: baseUrl + config.authPath,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            data: loginData
        }
        $http(req).success(function (response) {
            // Set data authentification
            _authentication.isAuth = true;
            _authentication.userEmail = response.userEmail;
            _authentication.userName = response.userName;
            _authentication.userId = response.userId;
            _authentication.userRoles = response.roles.split(",");
            // Set data for local strage and return result
            localStorageService.set('authorizationData', {
                token: response.access_token,
                userEmail: _authentication.userEmail,
                userName: _authentication.userName,
                roles: _authentication.userRoles,
                userId: _authentication.userId,
                refreshToken: "",
                useRefreshTokens: false
            });
            deferred.resolve(response);
        }).error(function (err, status) {
            // Reset data authentication and return error
            _logOut();
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _signUp = function (signUpData) {
        var userName = signUpData.userName;
        var password = signUpData.password;
        var req = {
            method: 'POST',
            url: baseUrl + config.invitationChalengePath,
            data: signUpData
        }
        $http(req).success(function (response) {

            var loginData = {
                userName: userName,
                password: password
            };
            _login(loginData).then(function (responce) {
                $state.go("workspace.work");
            }, null);

        }).error(function (err, status) {

        });
        return deferred.promise;
    };

    // LogOut and reset data authentication
    var _logOut = function () {
        localStorageService.remove('authorizationData');
        _authentication.isAuth = false;
        _authentication.userEmail = "";
        _authentication.userName = "";
        _authentication.userId = "";
        $rootScope.$emit('logout', "logOut");
    };

    // 
    var _fillAuthData = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userEmail = authData.userEmail;
            _authentication.userName = authData.userName;
            _authentication.userRoles = authData.roles;
            _authentication.userId = authData.userId;
        }
    };
    _fillAuthData();

    var _checkAccess = function (arr) {
        var access = false;
        for (var i in arr) {
            if (_authentication.userRoles.indexOf(arr[i]) !== -1) {
                access = true;
            }
        }
        return access;
    };

    //if (_authentication.isAuth == true) {
    //    $rootScope.$emit('login', _authentication);
    //}

    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.isAuthState = _isAuthState;
    authServiceFactory.login = _login;
    authServiceFactory.signUp = _signUp;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.checkAccess = _checkAccess;
    return authServiceFactory;
}]);