'use strict';
app.factory('appUserService', ['Restangular', function (Restangular) {

    var appUserFactory = {};
    var _getDefault = function () {
        var account = Restangular.one("AppUsers");
        account.userName = "username";
        account.password = "password";
        return account;
    }

    var _get = function (id) {
        return Restangular.one("AppUsers", id).get();
    }

    var _getAll = function () {
        return Restangular.all("AppUsers").getList();
    }

    var _save = function (accuntData) {
        return accuntData.save();
    }

    var _getPagedData = function (paginationOptions) {
        return Restangular.all('AppUsers').customGETLIST("GetPageData", paginationOptions, { "Content-Type": "application/x-www-form-urlencoded, application/x-www-form-urlencoded" });
    }

    var _delete = function (user) {
        return user.remove();
    }

    var _addProject = function (projectId) {
        return Restangular.one("AppUsers", userId).one("Projects", projectId).post();
    }

    var _getProjects = function (userId) {
        return Restangular.one("AppUsers", userId).all("Projects").getList();
    }
    var _getRoles = function (userId) {
        return Restangular.one("AppUsers", userId).all("Roles").getList();
    }

    var _invite = function (appUser) {
        return Restangular.one("AppUsers").post("Invite", appUser);
    }

    appUserFactory.get = _get;
    appUserFactory.getAll = _getAll;
    appUserFactory.getDefault = _getDefault;
    appUserFactory.save = _save;
    appUserFactory.delete = _delete;
    appUserFactory.getProjects = _getProjects;
    appUserFactory.getRoles = _getRoles;
    appUserFactory.addProject = _addProject;
    appUserFactory.getPagedData = _getPagedData;
    appUserFactory.invite = _invite;
    return appUserFactory;
}]);