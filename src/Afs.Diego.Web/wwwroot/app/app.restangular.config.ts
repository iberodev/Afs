((): void => {
    "use strict";

    angular
        .module("app")
        .config(configRestangular);

    configRestangular.$inject = [
        "RestangularProvider"
    ];

    function configRestangular(restangularProvider: restangular.IProvider) {
        restangularProvider.setBaseUrl("/api/");
    }
})();
