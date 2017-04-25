angular.module('alurapic').controller('FotosController', function($scope, recursoFoto) {

    $scope.fotos = [];

    $scope.filtro = ''; // não precisaria desse comando .. o Angular criaria automaticamente o $scope.filtro

    recursoFoto.query(function(fotos){
        $scope.fotos = fotos;
    },
    function(erro){
        console.log(erro);
    });

// remover foto -----------------------------------------
    $scope.remover = function(foto) {
        recursoFoto.delete({fotoId : foto._id}, 
        function() {
            var indexFoto = $scope.fotos.indexOf(foto);
            $scope.fotos.splice(indexFoto, 1);
        },
        function(erro){
            console.log(erro);
        });
    }
// remover foto -----------------------------------------


});