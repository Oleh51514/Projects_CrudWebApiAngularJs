"use strict"
app.config([
            "RestangularProvider",
            "config",
        function (
            RestangularProvider,
            config) {
            RestangularProvider.setBaseUrl(config.baseUrl + "api/");

        }
]);