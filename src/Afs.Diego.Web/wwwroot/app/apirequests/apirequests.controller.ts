namespace app.businesses {
    "use strict";

    export interface IApiRequestsController {
        textToEncode: string;
        textToDecode: string;
        historyRequests: Array<models.IApiRequestModel>;
        encode(): void;
        decode(): void;
    }

    class ApiRequestsController implements IApiRequestsController {
        public static $inject: string[] = [
            "app.services.ApiRequestsService"
        ];

        constructor(private apiRequestsService: services.IApiRequestsService) {
            this.init();
        }

        textToEncode: string = "";

        textToDecode: string = "";

        historyRequests: Array<models.IApiRequestModel> = [];

        public encode(): void {

        }

        public decode(): void {

        }
        
        private init(): void {
            this.apiRequestsService.getHistoryRequests()
                .then((historyRequests: Array<models.IApiRequestModel>) => {
                    this.historyRequests = historyRequests;
                });
        }
    }

    angular
        .module("app.apirequests")
        .controller("app.apirequests.ApiRequestsController", ApiRequestsController);
}