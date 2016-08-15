"use strict"
app.config(['$stateProvider', '$urlRouterProvider', 'localStorageServiceProvider', 'appRoles',
    function ($stateProvider, $urlRouterProvider, localStorageServiceProvider, appRoles) {

        localStorageServiceProvider.setPrefix('auth');
        $urlRouterProvider.otherwise('/workspace/workHub/work');

        $stateProvider
            // Unauthorized states
            .state('login', {
                url: '/login',
                templateUrl: 'app/modules/authorization/views/login.html',
                controller: 'loginController',
                data: {
                    accessState: true,
                    accessRoles: [appRoles.unauthorized]
                }
            })
            // Unauthorized states
            .state('invitaion', {
                url: '/invitaion/:token',
                templateUrl: 'app/modules/invitaion/views/invitaion.html',
                controller: 'signUpController',
                data: {
                    accessState: true,
                    accessRoles: [appRoles.unauthorized]
                }
            })

            // Layout state workspace
            // workspace
            .state('workspace', {
                url: '/workspace',
                templateUrl: 'app/layouts/workspace.html',
                controller: 'workspaceController',
                data: {
                    accessState: true,
                    accessRoles: [appRoles.user, appRoles.manager]
                }
            })
            // workspace > home
            .state('workspace.home', {
                url: '/home',
                templateUrl: 'app/modules/home/views/home.html',
                controller: 'homeController',
                data: {
                    accessState: true,
                    accessRoles: [appRoles.user, appRoles.manager]
                }
            })
            // workspace > inviteUser
            .state('workspace.inviteUser', {
                url: '/inviteUser',
                templateUrl: 'app/modules/invitation/views/inviteUser.html',
                controller: 'inviteUserController',
                data: {
                    accessState: true,
                    accessRoles: [appRoles.manager]
                }
            })
            // workspace > workHub
            .state('workspace.workHub', {
                url: '/workHub',
                templateUrl: 'app/modules/app/views/workHub.html',
                controller: 'workHubController',
                data: {
                    accessState: true,
                    accessRoles: [appRoles.user, appRoles.manager]
                }
            })
            // workspace > workHub > work
            .state('workspace.workHub.work', {
                url: '/work',
                views: {
                    'department': {
                        templateUrl: 'app/modules/department/views/departmentTable.html',
                        controller: 'departmentTableController',
                    },
                    'employee': {
                        templateUrl: 'app/modules/employee/views/employeeTable.html',
                        controller: 'employeeTableController',
                    }                    
                },
                data: {
                    accessState: true,
                    accessRoles: [appRoles.user, appRoles.manager]
                }
            })
    }]);