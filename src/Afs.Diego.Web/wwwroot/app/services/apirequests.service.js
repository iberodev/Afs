var app;
(function (app) {
    var services;
    (function (services) {
        "use strict";
        var EncodeDecodeRequestType;
        (function (EncodeDecodeRequestType) {
            EncodeDecodeRequestType[EncodeDecodeRequestType["Encode"] = 0] = "Encode";
            EncodeDecodeRequestType[EncodeDecodeRequestType["Decode"] = 1] = "Decode";
        })(EncodeDecodeRequestType || (EncodeDecodeRequestType = {}));
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
                    encodeDecodeRequestType: EncodeDecodeRequestType.Encode,
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
                    encodeDecodeRequestType: EncodeDecodeRequestType.Decode,
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

//# sourceMappingURL=apirequests.service.js.map
