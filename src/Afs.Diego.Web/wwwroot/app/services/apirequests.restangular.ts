namespace app.services {
    "use strict";

    factory.$inject = ["Restangular"];

    function factory(restangular: restangular.IService): restangular.ICollection {
        return restangular.all("apirequests");
    }

    angular
        .module("app.services")
        .factory("app.services.ApiRequestRestangular", factory);
}