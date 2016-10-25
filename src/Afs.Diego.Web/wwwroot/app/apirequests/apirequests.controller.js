var app;
(function (app) {
    var businesses;
    (function (businesses) {
        "use strict";
        var ApiRequestsController = (function () {
            function ApiRequestsController() {
                this.init();
            }
            ApiRequestsController.prototype.init = function () {
                console.log("Hello api requests");
            };
            ApiRequestsController.$inject = [];
            return ApiRequestsController;
        }());
        angular
            .module("app.apirequests")
            .controller("app.apirequests.ApiRequestsController", ApiRequestsController);
    })(businesses = app.businesses || (app.businesses = {}));
})(app || (app = {}));

//# sourceMappingURL=apirequests.controller.js.map
