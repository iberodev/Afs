namespace app.services {
    "use strict";

    factory.$inject = ["Restangular"];

    function factory(restangular: restangular.IService): restangular.IElement {
        return restangular.all("apirequests");
    }

    angular
        .module("app.services")
        .factory("app.services.ApiRequestsRestangular", factory);
}