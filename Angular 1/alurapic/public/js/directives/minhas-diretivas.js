angular.module('minhasDiretivas', ['meusServicos'])

.directive('meuPainel', function() {

    var ddo = {};

    ddo.transclude = true;
    ddo.restrict = "AE";
    ddo.templateUrl = "js/directives/meu-painel.html";

    ddo.scope = {
        titulo : "@",
        url : "@"
    };

    return ddo;
})

.directive('meuTituloPrincipal', function() {

    var ddo = {};

    ddo.restrict = "AE";

    ddo.templateUrl = "js/directives/meu-titulo-principal.html";

    ddo.scope = {
        titulo : "@"
    };

    return ddo;

})

.directive('meuTituloSecundario', function() {
    
    var ddo = {};

    ddo.restrict = "A";

    ddo.template = "<h3 class='panel-title text-center'>{{titulo}}</h3>";

    ddo.scope = {
        titulo : "@"
    };

    return ddo;
})

.directive('minhaFoto', function() {
    var ddo = {};

    ddo.restrict = "AE";
    ddo.template = "<img class='img-responsive center-block' src='{{url}}' alt='{{titulo}}'>";

    ddo.scope = {
        titulo : "@",
        url : "@"
    }

    return ddo;
})

.directive('meuBotaoPerigo', function() {
    var ddo = {};

    ddo.restrict = "E";
    ddo.scope = {
        nome : "@",
        acao : "&"
    }

    ddo.template = '<button ng-click="acao()" class="btn btn-danger btn-block" >{{nome}}</button>'

    return ddo;
})

.directive('meuFocus', function() {

    var ddo = {};

    ddo.restrict = "A";

    ddo.link = function(scope, element) {
        scope.$on('fotoCadastrada', function(){
            element[0].focus();
        });
    };

    return ddo;
})

.directive('meusTitulos', function(){
    var ddo = {};

    ddo.restrict = "E";

    ddo.template = "<ul><li ng-repeat='titulo in titulos'>{{titulo}}</li></ul>";

    ddo.controller = function($scope, recursoFoto) {
        recursoFoto.query(function(fotos){
            $scope.titulos = fotos.map(function(foto){ return foto.titulo });
        })
    };

    return ddo;
});