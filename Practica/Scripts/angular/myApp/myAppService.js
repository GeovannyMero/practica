angular.module("myApp")
    .factory("catalogoService", ["$http", "$q", function($http, $q) {
        var service = {};
            service.getCatalogoss = function() {
                var deferred = $q.defer();
                $http.get("/CatalogoAngular/Datos")
                    .then(function (result) {
                        deferred.resolve = result.data;
                    }, function() {
                        deferred.reject();
                    });
                alert(deferred.promise);
                return deferred.promise;
            }

        return service;
    }])