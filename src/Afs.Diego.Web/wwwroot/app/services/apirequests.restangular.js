var app;
(function (app) {
    var services;
    (function (services) {
        "use strict";
        factory.$inject = ["Restangular"];
        function factory(restangular) {
            return restangular.all("apirequests");
        }
        angular
            .module("app.services")
            .factory("app.services.ApiRequestRestangular", factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
