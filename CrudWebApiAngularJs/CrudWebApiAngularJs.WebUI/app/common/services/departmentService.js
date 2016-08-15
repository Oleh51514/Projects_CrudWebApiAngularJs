'use strict';
app.factory('departmentService', ['Restangular', '$q', function (Restangular, $q) {
    var departmentServiceFactory = {};

    var _getDefault = function () {
        var department = Restangular.one("Departments");
        department.name = "";
        department.createdAt = new Date();
        return department;
    }

    var _get = function (id) {
        return Restangular.one('Departments', id).get();
    }
    var _getAll = function () {
        return Restangular.all('Departments').getList();
    }

    var _getPageData = function (paginationOptions) {
        return Restangular.all('Departments').customGETLIST("GetPageData", paginationOptions, { "Content-Type": "application/x-www-form-urlencoded, application/x-www-form-urlencoded" });
    }

    var _save = function (departmentData) {
        return departmentData.save();
    }

    var _delete = function (departmentId) {
        return Restangular.one("Departments", departmentId).remove();
    }

    departmentServiceFactory.getPageData = _getPageData;
    departmentServiceFactory.getAll = _getAll;
    departmentServiceFactory.get = _get;
    departmentServiceFactory.save = _save;
    departmentServiceFactory.delete = _delete;
    departmentServiceFactory.getDefault = _getDefault;
    departmentServiceFactory.selectedId = undefined;
    return departmentServiceFactory;
}]);