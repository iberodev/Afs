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
            this.textEncoded = "loading..";
            this.apiRequestsService.getEncodedText(this.textToEncode)
                .then((text: string) => {
                    this.textEncoded = text;
                    this.refreshRequestHistory();
                }, (error: any) => {
                    console.error(error);
                    this.textEncoded = "There was an error!";
                    this.refreshRequestHistory();
                });
        }

        public decode(): void {
            this.textDecoded = "loading..";
            this.apiRequestsService.getDecodedText(this.textToDecode)
                .then((text: string) => {
                    this.textDecoded = text;
                    this.refreshRequestHistory();
                }, (error: any) => {
                    console.error(error);
                    this.textDecoded = "There was an error!";
                    this.refreshRequestHistory();
                })
        }
        
        private init(): void {
            this.refreshRequestHistory();
        }

        private refreshRequestHistory(): void {
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