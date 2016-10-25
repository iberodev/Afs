namespace app.services {
    "use strict";

    export interface IApiRequestsService {

    }

    class ApiRequestsService implements IApiRequestsService {
        constructor() {

        }
        
    }

    factory.$inject = [
    ];

    function factory() {
        return new ApiRequestsService();
    }

    angular
        .module("app.services")
        .factory("app.services.ApiRequestsService", factory);
}