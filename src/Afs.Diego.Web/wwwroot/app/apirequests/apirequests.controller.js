var app;
(function (app) {
    var businesses;
    (function (businesses) {
        "use strict";
        var ApiRequestsController = (function () {
            function ApiRequestsController(apiRequestsService) {
                this.apiRequestsService = apiRequestsService;
                this.textToEncode = "";
                this.textToDecode = "";
                this.historyRequests = [];
                this.init();
            }
            ApiRequestsController.prototype.encode = function () {
            };
            ApiRequestsController.prototype.decode = function () {
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
