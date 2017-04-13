
// document.onload -------------------------------------------------------------------------------------

$(document).ready(function() {
    inicializaTempo();
    inicializaContadores();
    inicializaReiniciar();
});

// document.onload -------------------------------------------------------------------------------------



//#region propriedades ----------------------------------------------------------------------------------------

var campo = $(".campo-digitacao");
var tempoDigitacao = $("#tempo-digitacao");
var contadorCaracteres = $("#contador-caracteres");
var contadorPalavras = $("#contador-palavras");
var contadorPontos = $("#contador-pontos");
var botaoReiniciar = $("#botao-reiniciar");

var tempoInicial = tempoDigitacao.text();

//#endregion propriedades -------------------------------------------------------------------------------------



//#region funções ---------------------------------------------------------------------------------------------

function inicializaTempo() {
    campo.val("");
    campo.one("focus", iniciarTempo);
}

function inicializaContadores() {
    campo.on("input", atualizarContadores);
}

function inicializaReiniciar() {
    botaoReiniciar.click(reiniciarJogo);
}

function iniciarTempo() {
    tempo = tempoInicial;
    
    var idInterval = setInterval(function() {
        tempo--
        tempoDigitacao.text(tempo);
        if (tempo < 1) {
            campo.attr("disabled", true);
            clearInterval(idInterval);
        }
    }, 1000);
};

function atualizarContadores() {
    var caracteres = 0;
    var palavras = 0;
    caracteres += campo.val().length;
    palavras += campo.val().split(/\S+/).length - 1;

    contadorCaracteres.text(campo.val().length);
    contadorPalavras.text(campo.val().split(/\S+/).length - 1);
    contadorPontos.text(caracteres * palavras);
}


function reiniciarJogo() {
    campo.val("");
    campo.attr("disabled", false);
    tempoDigitacao.text(tempoInicial);
    contadorCaracteres.text("0");
    contadorPalavras.text("0");
    contadorPontos.text("0");
    inicializaTempo();
}

//#endregion funções ---------------------------------------------------------------------------------------------