"use strict";app.factory("departmentService",["Restangular","$q",function(e,t){var n={},r=function(){var t=e.one("Departments");return t.name="",t.createdAt=new Date,t},a=function(t){return e.one("Departments",t).get()},o=function(){return e.all("Departments").getList()},u=function(t){return e.all("Departments").customGETLIST("GetPageData",t,{"Content-Type":"application/x-www-form-urlencoded, application/x-www-form-urlencoded"})},c=function(e){return e.save()},i=function(t){return e.one("Departments",t).remove()};return n.getPageData=u,n.getAll=o,n.get=a,n.save=c,n["delete"]=i,n.getDefault=r,n.selectedId=void 0,n}]);