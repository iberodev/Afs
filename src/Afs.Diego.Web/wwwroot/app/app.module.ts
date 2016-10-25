/// <reference path="../../typings/globals/angular/index.d.ts" />
/// <reference path="../../typings/globals/jquery/index.d.ts" />
/// <reference path="../../typings/globals/restangular/index.d.ts" />

((): void => {
    "use strict";

    angular
        .module("app", [
            "app.core",
            "app.apirequests",
            "app.services"
        ]);
})();