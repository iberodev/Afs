namespace app.businesses {
    "use strict";

    export interface IApiRequestsController {
    }

    class ApiRequestsController implements IApiRequestsController {
        public static $inject: string[] = [
            
        ];

        constructor() {
            this.init();
        }
        
        private init(): void {
            console.log("Hello api requests");
        }
    }

    angular
        .module("app.apirequests")
        .controller("app.apirequests.ApiRequestsController", ApiRequestsController);
}