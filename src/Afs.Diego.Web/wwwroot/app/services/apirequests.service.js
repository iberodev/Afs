var app;
(function (app) {
    var services;
    (function (services) {
        "use strict";
        var ApiRequestsService = (function () {
            function ApiRequestsService(apiRequestsRestangular) {
                this.apiRequestsRestangular = apiRequestsRestangular;
            }
            ApiRequestsService.prototype.getHistoryRequests = function () {
                return this.apiRequestsRestangular
                    .customGET("")
                    .then(function (restangularizedRequests) {
                    return restangularizedRequests.plain();
                });
            };
            return ApiRequestsService;
        }());
        factory.$inject = [
            "app.services.ApiRequestsRestangular",
        ];
        function factory(apiRequestsRestangular) {
            return new ApiRequestsService(apiRequestsRestangular);
        }
        angular
            .module("app.services")
            .factory("app.services.ApiRequestsService", factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));

//# sourceMappingURL=apirequests.service.js.map
