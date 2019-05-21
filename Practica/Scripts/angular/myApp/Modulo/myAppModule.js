(function () {
    'use strict';

    angular
        .module("myApp", ['ngRoute'])
        .config([
            "$routeProvider", function($routeProvider) {

                $routeProvider
                    .when('/Home/About',
                        {
                            controller: "myAppC",
                            templateUrl: "../Template/catalogos.html"
                        })
                    .otherwise({ redirectTo: '/' });
            }
        ]);


})