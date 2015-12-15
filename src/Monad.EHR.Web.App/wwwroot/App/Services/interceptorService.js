(function () {
    'use strict';
    angular.module('interceptorServiceModule', []).factory('interceptorService', function ($q, $rootScope) {
        return {
            request: function (config) {
                return config || $q.when(config);
            },
            requestError: function (request) {
                return $q.reject(request);
            },
            response: function (response) {
                return response || $q.when(response);
            },
            responseError: function (response) {
                if (response && response.status === 403) {
                    console.log(response);
                    window.location = "#/accessDenied";
                }
                if (response && response.status === 404) {
                    console.log(response);
                    window.location = "#/notFound";
                }
                if (response && response.status >= 500) {
                    window.location = "#/internalServerError";
                }
                return $q.reject(response);
            }
        };
    });
})();