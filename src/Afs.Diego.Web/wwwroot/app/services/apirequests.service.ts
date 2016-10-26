namespace app.services {
    "use strict";

    enum EncodeDecodeRequestType {
        Encode = 0,
        Decode = 1
    }

    interface IEncodeDecodeRequest {
        text?: string;
        encodeDecodeRequestType?: EncodeDecodeRequestType;
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
                encodeDecodeRequestType: EncodeDecodeRequestType.Encode,
                text: text
            };

            return this.apiRequestsRestangular
                .customPOST(element)
                .then((text: restangular.IElement) => {
                    return text.plain();
                });
        }

        public getDecodedText(text: string): ng.IPromise<string> {
            let element: IEncodeDecodeRequest = {
                encodeDecodeRequestType: EncodeDecodeRequestType.Decode,
                text: text
            };

            return this.apiRequestsRestangular
                .customPOST(element)
                .then((text: restangular.IElement) => {
                    return text.plain();
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