angular.module("myAppC",
    [
        "$scope", "dataService", function($http, dataService) {
            alert('Hola');
            $scope.catalogo = [];

            getCatalogo();

            function getCatalogo() {
                dataService.getCatalogoss().then(function(result) {
                    $scope.catalogo = result;
                });
            }



        }
    ]);