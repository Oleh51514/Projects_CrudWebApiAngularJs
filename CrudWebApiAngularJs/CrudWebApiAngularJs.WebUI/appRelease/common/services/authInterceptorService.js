"use strict";app.factory("authInterceptorService",["$q","$injector","$location","localStorageService",function(t,e,r,a){var o={},n=function(t){t.headers=t.headers||{};var e=a.get("authorizationData");return e&&(t.headers.Authorization="Bearer "+e.token),t},i=function(o){var n=e.get("authService"),i=a.get("authorizationData");return 401===o.status&&void 0===i&&(n.logOut(),r.path("/login")),t.reject(o)};return o.request=n,o.responseError=i,o}]);