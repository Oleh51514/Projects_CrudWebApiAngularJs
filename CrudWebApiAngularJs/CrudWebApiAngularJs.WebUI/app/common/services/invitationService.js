'use strict';
app.factory('invitationService', ['Restangular', function (Restangular) {
    var invitationServiceFactory = {};

    var _getDefault = function () {
        var invitation = Restangular.one("Invitations");
        invitation.userEmail = "";
        invitation.roleName = "";
        invitation.projectId = 0;
        return invitation;
    }

    var _get = function (id) {
        return Restangular.one('Invitations', id).get();
    }
    var _getAll = function () {
        return Restangular.all('Invitations').getList();
    }

    var _save = function (invitationData) {
        return invitationData.save();
    }

    var _delete = function (invitationId) {
        return Restangular.one("Invitations", invitationId).remove();
    }

    var _confirm = function (appUserData) {
        return Restangular.all("Invitations").all("Confirm").post(appUserData);
    }

    invitationServiceFactory.getAll = _getAll;
    invitationServiceFactory.get = _get;
    invitationServiceFactory.save = _save;
    invitationServiceFactory.delete = _delete;
    invitationServiceFactory.confirm = _confirm;
    invitationServiceFactory.getDefault = _getDefault;
    return invitationServiceFactory;
}]);