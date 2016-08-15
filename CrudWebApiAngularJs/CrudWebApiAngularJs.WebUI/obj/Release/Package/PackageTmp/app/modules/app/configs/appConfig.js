'use strict'

app.config(["$httpProvider", function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
}]);

app.constant('config', {
    baseUrl: 'http://localhost:13869/',
    authPath: 'token',
    invitationChalengePath: 'api/AppUsers/InvitationChalenge'
});
