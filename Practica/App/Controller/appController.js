//Controller
app.controller("myAppCtrl2",
    [
        '$scope', 'catalogoService', function ($scope, catalogoService) {
            //alert('Hola desde controlador');
            $scope.catalogos = [];
            //$scope.getDetalles = function (id) {
            //    catalogoService
            //         .getCatalogoById(id)
            //         .then(function (result) {
            //             $scope.catalogos = result;
            //             console.log(result);
            //         }).catch(function (err) {
            //             alert(err);
            //         });
            //}

            getCatalogos2();

            function getCatalogos2() {
                catalogoService
                    .getCatalogoss()
                    .then(function (result) {
                        $scope.catalogos = result;
                        //alert($scope.catalogos);
                    }).catch(function (err) {
                        alert(err);
                    });
            }

            $scope.nuevo =  function () {
               catalogoService.nuevoCatalogo()
                    .then(function () {

                    }).catch(function (err) {
                        alert(err);
                    });
            }
            $scope.Existe = function (id) {
                catalogoService
                    .existCatalogo(id)
                    .then(function (result) {
                        $scope.existe = result;
                        alert(result);
                    }).catch(function (err) {
                        alert(err);
                    });
            }
        }
    ]);

app.controller("myAppCtrl3",
    [
        '$scope', '$routeParams', '$location', 'catalogoService',
        function ($scope, $routeParams, $location, catalogoService) {
            $scope.catalogo = {};

            catalogoService.getCatalogoById($routeParams.id).then(function (result) {
                $scope.catalogo = result;
                console.log(result);
            }).catch(function (err) {
                alert(err);
            });
        }
    ]);

app.controller("addCatalogo",
    [
        "$scope", "$location", "catalogoService", function ($scope, $location, catalogoService) {
            catalogoService.nuevoCatalogo()
                .then(function () { })
                .catch(function (err) {
                    console.log(err);
                });
        }
    ]);