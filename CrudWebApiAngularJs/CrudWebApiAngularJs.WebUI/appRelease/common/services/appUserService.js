"use strict";app.factory("appUserService",["Restangular",function(e){var t={},r=function(){var t=e.one("AppUsers");return t.userName="username",t.password="password",t},n=function(t){return e.one("AppUsers",t).get()},s=function(){return e.all("AppUsers").getList()},o=function(e){return e.save()},u=function(t){return e.all("AppUsers").customGETLIST("GetPageData",t,{"Content-Type":"application/x-www-form-urlencoded, application/x-www-form-urlencoded"})},a=function(e){return e.remove()},p=function(t){return e.one("AppUsers",userId).one("Projects",t).post()},c=function(t){return e.one("AppUsers",t).all("Projects").getList()},i=function(t){return e.one("AppUsers",t).all("Roles").getList()},l=function(t){return e.one("AppUsers").post("Invite",t)};return t.get=n,t.getAll=s,t.getDefault=r,t.save=o,t["delete"]=a,t.getProjects=c,t.getRoles=i,t.addProject=p,t.getPagedData=u,t.invite=l,t}]);