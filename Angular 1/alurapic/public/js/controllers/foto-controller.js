angular.module('alurapic').controller('FotoController', function($scope, servicoFoto, recursoFoto, $routeParams) {

    $scope.foto = {};

    $scope.mensagem = '';

    if ($routeParams.fotoId) {

        recursoFoto.get({ fotoId : $routeParams.fotoId }, 
        function(foto){
            $scope.foto = foto;
        },
        function(erro){
            $scope.mensagem = "Não foi possível recuperar a foto";
            console.log(erro);
        });
    }

    $scope.submeter = function () {

        if ($scope.formulario.$valid) {

            servicoFoto.upsert($scope.foto)
                .then(function(retorno) {
                    $scope.mensagem = retorno.mensagem;
                    if (retorno.inclusao) {
                        $scope.foto = {};
                        $scope.formulario.$setPristine();
                    }
                })
                .catch(function(retorno){
                    $scope.mensagem = retorno.mensagem;
            });

        } // end if $scope.formulario.$valid
    };

});