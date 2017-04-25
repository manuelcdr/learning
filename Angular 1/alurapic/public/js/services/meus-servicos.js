angular.module('meusServicos', ['ngResource'])
.factory('recursoFoto', function($resource){

    var recurso = $resource('/v1/fotos/:fotoId', null, {
        'update' : {
            method : "PUT"
        }
    });

    return recurso;
})
.factory('recursoGrupo', function($resource){

    var recurso = $resource('/v1/grupos/:grupoId', null, {
        'update' : {
            method : "PUT"
        }
    });

    return recurso;

})
.factory('servicoFoto', function(recursoFoto, $q, $rootScope){

    var servico = {};

    servico.upsert = function(foto) {
        return $q(function(resolve, reject) {

            if (foto._id) {
                
                recursoFoto.update({ fotoId : foto._id }, foto,
                function() {
                    $rootScope.$broadcast('fotoCadastrada');
                    resolve({
                            mensagem : "A foto " + foto.titulo + " foi editada com sucesso",
                            inclusao : false,
                            alteracao : true
                    });
                },
                function(erro){
                    console.log(erro);
                    reject({
                            mensagem : "Ops! Ocorreu um erro, a foto " + foto.titulo + " não foi editada"
                    });
                });
            
            } else {
                
                recursoFoto.save(foto, 
                function() {
                    $rootScope.$broadcast('fotoCadastrada');
                    resolve({
                        mensagem : 'Foto cadastrada com sucesso! :D',
                        inclusao : true,
                        alteracao : false
                    });
                },
                function(erro){
                    console.log(erro);
                    reject({
                        mensagem : 'Ops! Ocorreu um erro. Foto não cadastrada.'
                    });
                });

            }
        });
    };

    return servico;
});