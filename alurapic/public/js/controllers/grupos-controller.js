angular.module('alurapic').controller('GruposController', function($scope, recursoGrupo){

    $scope.grupos = [];

    recursoGrupo.query(
        function(grupos) {
            $scope.grupos = grupos;
        },
        function (erro){
            console.log("erro ao buscar grupos: " + erro);
        });

});