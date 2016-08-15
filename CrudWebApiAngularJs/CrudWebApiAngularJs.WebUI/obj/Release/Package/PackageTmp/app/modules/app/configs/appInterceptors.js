app.config(['RestangularProvider', function (RestangularProvider) {

    RestangularProvider.addResponseInterceptor(function (data, operation, what, url, response, deferred) {
        var extractedData;
        if (operation === "getList" && what === "GetPageData") {
            extractedData = data.items;
            extractedData.totalItems = data.totalItems;
        } else {
            extractedData = data;
        }
        return extractedData;
    });

}]);