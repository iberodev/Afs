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

//# sourceMappingURL=app.restangular.config.js.map
