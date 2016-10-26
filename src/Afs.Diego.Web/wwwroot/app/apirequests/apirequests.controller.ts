namespace app.businesses {
    "use strict";

    export interface IApiRequestsController {
        textToEncode: string;
        textEncoded: string;
        textToDecode: string;
        textDecoded: string;
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

        textEncoded: string = "";

        textToDecode: string = "";

        textDecoded: string = "";

        historyRequests: Array<models.IApiRequestModel> = [];

        public encode(): void {
            this.textEncoded = "";
            this.apiRequestsService.getEncodedText(this.textToEncode)
                .then((text: string) => {
                    this.textEncoded = text;
                })
        }

        public decode(): void {
            this.textDecoded = "";
            this.apiRequestsService.getDecodedText(this.textToDecode)
                .then((text: string) => {
                    this.textDecoded = text;
                })
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