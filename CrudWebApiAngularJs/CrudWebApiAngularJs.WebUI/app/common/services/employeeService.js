'use strict';
app.factory('employeeService', ['Restangular', '$q', function (Restangular, $q) {
    var employeeServiceFactory = {};

    var _getDefault = function () {
        var employee = Restangular.one("Employees");
        //employee.name = "";
        //employee.appUsers = [];
        return employee;
    }
    
    var _get = function (id) {
        return Restangular.one('Employees', id).get();
    }
    var _getAll = function () {
        return Restangular.all('Employees').getList();
    }

    var _getPageData = function (paginationOptions) {
        return Restangular.all('Employees').customGETLIST("GetPageData", paginationOptions, { "Content-Type": "application/x-www-form-urlencoded, application/x-www-form-urlencoded" });
    }

    var _save = function (employeeData) {
        return employeeData.save();
    }

    var _delete = function (employeeId) {
        return Restangular.one("Employees", employeeId).remove();
    }    

    employeeServiceFactory.getPageData = _getPageData;
    employeeServiceFactory.getAll = _getAll;
    employeeServiceFactory.get = _get;
    employeeServiceFactory.save = _save;
    employeeServiceFactory.delete = _delete;
    employeeServiceFactory.getDefault = _getDefault;
    
    return employeeServiceFactory;
}]);