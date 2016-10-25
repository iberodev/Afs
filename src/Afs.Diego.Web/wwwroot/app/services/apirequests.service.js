var app;
(function (app) {
    var services;
    (function (services) {
        "use strict";
        var ApiRequestsService = (function () {
            function ApiRequestsService() {
            }
            return ApiRequestsService;
        }());
        factory.$inject = [];
        function factory() {
            return new ApiRequestsService();
        }
        angular
            .module("app.services")
            .factory("app.services.ApiRequestsService", factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));

//# sourceMappingURL=apirequests.service.js.map
