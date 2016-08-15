'use strict';
app.factory('roleService', ['Restangular', function (Restangular) {
    var roleFactory = {};


    var _get = function (roleId) {
        return Restangular.one('Roles', roleId).get();
    }
    var _getAll = function () {
        return Restangular.all('Roles').getList();
    }

    var _save = function (roleData) {
        return roleData.save();
    }

    var _delete = function (roleData) {
        return roleData.remove();
    }
    roleFactory.get = _get;
    roleFactory.getAll = _getAll;
    roleFactory.save = _save;
    roleFactory.delete = _delete;
    return roleFactory;
}]);