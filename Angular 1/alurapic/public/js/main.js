angular.module('alurapic', ['minhasDiretivas', 'meusServicos', 'ngAnimate', 'ngRoute'])

.config(function($routeProvider, $locationProvider) {

    $locationProvider.html5Mode(true);

    $routeProvider.when('/fotos', {
        templateUrl : 'partials/principal.html',
        controller : 'FotosController'
    });

    $routeProvider.when('/', {
        redirectTo : '/fotos'
    });

    $routeProvider.when('/fotos/new', {
        templateUrl : 'partials/foto.html',
        controller : 'FotoController'
    });

    $routeProvider.when('/fotos/edit/:fotoId', {
        templateUrl : 'partials/foto.html',
        controller : 'FotoController'
    });

    $routeProvider.when('/fotos/titulos', {
        templateUrl : 'partials/titulos.html'
    });

    $routeProvider.otherwise({
        templateUrl : 'partials/404.html'
    });

    

});