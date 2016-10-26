var app;
(function (app) {
    var services;
    (function (services) {
        "use strict";
        var ApiRequestType;
        (function (ApiRequestType) {
            ApiRequestType[ApiRequestType["Encode"] = 0] = "Encode";
            ApiRequestType[ApiRequestType["Decode"] = 1] = "Decode";
        })(ApiRequestType || (ApiRequestType = {}));
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
            ApiRequestsService.prototype.getEncodedText = function (text) {
                var element = {
                    apiRequestType: ApiRequestType.Encode,
                    text: text
                };
                return this.apiRequestsRestangular
                    .customPOST(element)
                    .then(function (text) {
                    return text.plain();
                });
            };
            ApiRequestsService.prototype.getDecodedText = function (text) {
                var element = {
                    apiRequestType: ApiRequestType.Decode,
                    text: text
                };
                return this.apiRequestsRestangular
                    .customPOST(element)
                    .then(function (text) {
                    return text.plain();
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
