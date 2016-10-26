(function () {
    "use strict";
    angular
        .module("app")
        .config(configRestangular);
    configRestangular.$inject = [
        "RestangularProvider"
    ];
    function configRestangular(restangularProvider) {
        restangularProvider.setBaseUrl("/api/");
    }
})();
