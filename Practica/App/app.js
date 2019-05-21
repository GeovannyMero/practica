var app = angular.module('myApp', ['ngRoute']);

app.config(function($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix("");
    $routeProvider
        .when("/",
            {
                controller: 'myAppCtrl2',
                templateUrl: '/App/Template/Catalogos.html'
            })
        .when("/details/:id",
            {
                controller: 'myAppCtrl3',
                templateUrl: '/App/Template/detalles.html'
            })
        .when("/nuevo",
            {
                controller: 'myAppCtrl2',
                templateUrl: '/App/Template/nuevo.html'
            })
        .otherwise({ redirectTo: "/" });;
});