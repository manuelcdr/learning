
// document.onload -------------------------------------------------------------------------------------

$(document).ready(function() {
    inicializaTempo();
    inicializaContadores();
    inicializaReiniciar();
    inicializaVerificacaoDigitacao();
});

// document.onload -------------------------------------------------------------------------------------



//#region propriedades ----------------------------------------------------------------------------------------

var campo = $(".campo-digitacao");
var tempoDigitacao = $("#tempo-digitacao");
var contadorCaracteres = $("#contador-caracteres");
var contadorPalavras = $("#contador-palavras");
var contadorPontos = $("#contador-pontos");
var botaoReiniciar = $("#botao-reiniciar");
var frase = $(".frase");

var tempoInicial = tempoDigitacao.text();
var idInterval = 0;

//#endregion propriedades -------------------------------------------------------------------------------------



//#region funções ---------------------------------------------------------------------------------------------

function verificaDigitacao(event) {
    var digitado = campo.val();
    var fraseCortada = frase.text().substr(0, digitado.length);
    console.log(event);
    if (digitado == fraseCortada) {
        console.log("certo");
        campo.addClass("digitado-certo");
        campo.removeClass("digitado-errado");
    } else {
        console.log("errado");
        campo.addClass("digitado-errado");
        campo.removeClass("digitado-certo");
        event.preventDefault();
    }
}

function inicializaVerificacaoDigitacao() {
    campo.on("keypress", verificaDigitacao);
}

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
    
    idInterval = setInterval(function() {
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
    campo.removeClass("digitado-certo");
    campo.removeClass("digitado-errado");
    tempoDigitacao.text(tempoInicial);
    contadorCaracteres.text("0");
    contadorPalavras.text("0");
    contadorPontos.text("0");
    clearInterval(idInterval);
    inicializaTempo();
}

//#endregion funções ---------------------------------------------------------------------------------------------