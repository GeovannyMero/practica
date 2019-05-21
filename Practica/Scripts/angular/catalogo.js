//Obtener Datos con Angular.JS
angular.module("myApp", [], function ($interpolateProvider) {
    $interpolateProvider.startSymbol('<%');
    $interpolateProvider.endSymbol('%>');
}).controller("myCtrl",
    function ($scope, $http) {
        //// debugger;
        $scope.getCatalogos = function () {
            $http({
                method: "get",
                url: "/CatalogoAngular/Datos"
            }).then(function (response) {
                $scope.catalogos = response.data;
                //console.log(response.data);
            }).catch(function (err) {
                alert(err);
            });
        }
    });
