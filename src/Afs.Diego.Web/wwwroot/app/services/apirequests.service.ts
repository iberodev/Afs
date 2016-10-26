namespace app.services {
    "use strict";

    export interface IApiRequestsService {
        getHistoryRequests(): ng.IPromise<Array<models.IApiRequestModel>>;
    }

    class ApiRequestsService implements IApiRequestsService {
        constructor(private apiRequestsRestangular: restangular.IElement) {

        }

        public getHistoryRequests(): ng.IPromise<Array<models.IApiRequestModel>> {
            return this.apiRequestsRestangular
                .customGET("")
                .then((restangularizedRequests: restangular.IElement) => {
                    return restangularizedRequests.plain();
                });
        }
    }

    factory.$inject = [
        "app.services.ApiRequestsRestangular",
    ];

    function factory(apiRequestsRestangular: restangular.IElement) {
        return new ApiRequestsService(apiRequestsRestangular);
    }

    angular
        .module("app.services")
        .factory("app.services.ApiRequestsService", factory);
}