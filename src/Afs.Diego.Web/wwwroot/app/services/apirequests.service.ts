namespace app.services {
    "use strict";

    enum ApiRequestType {
        Decode = 0,
        Encode = 1
    }

    interface IEncodeDecodeRequest {
        text?: string;
        apiRequestType?: ApiRequestType;
    }

    export interface IApiRequestsService {
        getHistoryRequests(): ng.IPromise<Array<models.IApiRequestModel>>;
        getEncodedText(text: string): ng.IPromise<string>;
        getDecodedText(text: string): ng.IPromise<string>;
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

        public getEncodedText(text: string): ng.IPromise<string> {
            let element: IEncodeDecodeRequest = {
                apiRequestType: ApiRequestType.Encode,
                text: text
            };

            return this.apiRequestsRestangular
                .customPOST(element)
                .then((text: string) => {
                    return text;
                });
        }

        public getDecodedText(text: string): ng.IPromise<string> {
            let element: IEncodeDecodeRequest = {
                apiRequestType: ApiRequestType.Decode,
                text: text
            };

            return this.apiRequestsRestangular
                .customPOST(element)
                .then((text: string) => {
                    return text;
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