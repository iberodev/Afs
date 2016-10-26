namespace app.models {
    "use strict";

    export interface IApiRequestModel {
        id?: string;
        createdOn?: Date;
        requestBeginTime?: Date;
        requestEndTime?: Date;
        requestUrl?: string;
        httpMethodText?: string;
        apiRequestTypeText?: string;
        responseText?: string;
        responseCode?: number;
        error?: string;
    }
}