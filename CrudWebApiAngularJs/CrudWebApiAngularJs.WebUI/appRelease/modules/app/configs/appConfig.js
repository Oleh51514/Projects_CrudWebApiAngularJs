"use strict";app.config(["$httpProvider",function(t){t.interceptors.push("authInterceptorService")}]),app.constant("config",{baseUrl:"http://localhost:13869/",authPath:"token",invitationChalengePath:"api/AppUsers/InvitationChalenge"});