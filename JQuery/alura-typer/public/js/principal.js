
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
var campoUsuario = $("#usuario");

var tempoInicial = tempoDigitacao.text();
var idInterval = 0;

//#endregion propriedades -------------------------------------------------------------------------------------



//#region funções ---------------------------------------------------------------------------------------------

function verificaDigitacao(event) {
    var digitado = campo.val();
    if (frase.text().startsWith(digitado)) {
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
            clearInterval(idInterval);
            finalizaJogo();   
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

function adicionarPontuacaoNaTabela(usuario, pontos) {
    var corpoTabela = $(".placar").find("tbody");
    var linha = $("<tr>");

    var icone = $("<i>").addClass("red small material-icons").text("delete");
    var botaoRemover = $("<a>").addClass("btn-floating red").append(icone);

    var tdUsuario = $("<td>").text(usuario);
    var tdPontos = $("<td>").text(pontos);
    var tdRemove = $("<td>").append(botaoRemover);

    linha.append(tdUsuario);
    linha.append(tdPontos);
    linha.append(tdRemove);

    botaoRemover.click(function(event) {
        event.preventDefault();
        $(this).parent().parent().remove();
    });

    corpoTabela.prepend(linha);
}

function finalizaJogo() {
    campo.attr("disabled", true);
    usuario = campoUsuario.val();
    if (usuario.trim() == "") {
        usuario = "Anônimo";
    }
    adicionarPontuacaoNaTabela(usuario, contadorPontos.text());
}

//#endregion funções ---------------------------------------------------------------------------------------------