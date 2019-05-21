/*!
 Servicio De Catalogos
 */
app.factory('catalogoService', ["$http", "$q", function ($http, $q) {
    var service = {};

    service.getCatalogoss = function () {
        var deferred = $q.defer();
        $http.get('/Catalogo2/Catalogos').then(function (result) {
            deferred.resolve(result.data);
        },
            function () {
                deferred.reject();
            });
        return deferred.promise;
    };

    //getCatalogosById
    service.getCatalogoById = function (idCatalogo) {
        var deferred = $q.defer();
        $http.get('/Catalogo2/GetCatalogoById/' + idCatalogo).then(function (result) {
            deferred.resolve(result.data);
        },
            function () {
                deferred.reject();
            });
        return deferred.promise;
    }

    //
    service.existCatalogo = function (idCatalogo) {
        var deferred = $q.defer();
        $http.get('/Catalogo2/ExistCatalogo/' + idCatalogo).then(function (result) {
            deferred.resolve(result.data);
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    }


    service.nuevoCatalogo = function (catalogo) {
        var deferred = $q.defer();
        $http.post('/Catalogo2/nuevo', catalogo).then(function (result) {
            deferred.resolve();
        }).catch(function (err) {
            deferred.reject();
            console.log(deferred.reject());
            console.log(err);
        });
    }

    return service;
}
]);


