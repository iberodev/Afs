var app;
(function (app) {
    var businesses;
    (function (businesses) {
        "use strict";
        var ApiRequestsController = (function () {
            function ApiRequestsController(apiRequestsService) {
                this.apiRequestsService = apiRequestsService;
                this.textToEncode = "";
                this.textEncoded = "";
                this.textToDecode = "";
                this.textDecoded = "";
                this.historyRequests = [];
                this.init();
            }
            ApiRequestsController.prototype.encode = function () {
                var _this = this;
                this.textEncoded = "";
                this.apiRequestsService.getEncodedText(this.textToEncode)
                    .then(function (text) {
                    _this.textEncoded = text;
                });
            };
            ApiRequestsController.prototype.decode = function () {
                var _this = this;
                this.textDecoded = "";
                this.apiRequestsService.getDecodedText(this.textToDecode)
                    .then(function (text) {
                    _this.textDecoded = text;
                });
            };
            ApiRequestsController.prototype.init = function () {
                var _this = this;
                this.apiRequestsService.getHistoryRequests()
                    .then(function (historyRequests) {
                    _this.historyRequests = historyRequests;
                });
            };
            ApiRequestsController.$inject = [
                "app.services.ApiRequestsService"
            ];
            return ApiRequestsController;
        }());
        angular
            .module("app.apirequests")
            .controller("app.apirequests.ApiRequestsController", ApiRequestsController);
    })(businesses = app.businesses || (app.businesses = {}));
})(app || (app = {}));

//# sourceMappingURL=apirequests.controller.js.map
