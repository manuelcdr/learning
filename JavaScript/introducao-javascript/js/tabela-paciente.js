function atualizarTabelaPacientes() {
    var pacientes = document.querySelectorAll(".paciente");

    for (i = 0; i < pacientes.length; i++ ) {
        var trPaciente = pacientes[i]; 
        var paciente = obtemPacienteDoTr(trPaciente);
        atualizaTrPaciente(paciente, trPaciente);
    }
}

function atualizaTrPaciente(paciente, trPaciente) {
    if (paciente.ehValido()) {
        var tdImc = trPaciente.querySelector(".info-imc");
        tdImc.textContent = paciente.calculaIMC();
    } else {
        trPaciente.classList.add("paciente-invalido");
        var tdImc = trPaciente.querySelector(".info-imc");
        var erros = paciente.pegaErros();
        tdImc.textContent = "";
        for (i = 0; i < erros.length; i++) {
            if (i == 0) {
                tdImc.textContent += erros[i];
            } else {
                tdImc.textContent += (" " + erros[i]);
            }
        }
    }
    tdImc.setAttribute("data-search", tdImc.textContent);
}

function montaTdPaciente(classe, valor) {
    var tdPaciente = montaElemento("td", classe, valor.toString());
    tdPaciente.setAttribute("data-search", valor.toString().toLowerCase());
    return tdPaciente;
}

function montaTrPaciente(paciente) {
    
    var trPaciente = montaElemento("tr", "paciente");
    var tdNome = montaTdPaciente("info-nome", paciente.nome);
    var tdPeso = montaTdPaciente("info-peso", paciente.peso);
    var tdAltura = montaTdPaciente("info-altura", paciente.altura);
    var tdGordura = montaTdPaciente("info-gordura", paciente.gordura);
    var tdImc = montaTdPaciente("info-imc", paciente.calculaIMC());

    trPaciente.appendChild(tdNome);
    trPaciente.appendChild(tdPeso);
    trPaciente.appendChild(tdAltura);
    trPaciente.appendChild(tdGordura);
    trPaciente.appendChild(tdImc);

    return trPaciente;
}

function obtemPacienteDoTr(tr) {
    var nome = tr.querySelector(".info-nome").textContent;
    var peso = tr.querySelector(".info-peso").textContent;
    var altura = tr.querySelector(".info-altura").textContent;
    var gordura = tr.querySelector(".info-gordura").textContent;
    var paciente = new Paciente(nome, peso, altura, gordura);
    return paciente;
}

var tabela = pegarElemento("#tabela-pacientes");
tabela.addEventListener("dblclick", function(event) {
    var trPaciente = event.target.parentNode;
    trPaciente.classList.add("esconde-tr");
    setTimeout(function() {
        trPaciente.remove();
    }, 300);
});

var filtro = document.querySelector("#filtrar-tabela");
filtro.addEventListener("input", function(event){
    var trPacientes = document.querySelectorAll(".paciente");
    if (this.value != "") {
        trPacientes.forEach(function(trPaciente){
            var tdSearchPaciente = trPaciente.querySelectorAll("td[data-search*='" + filtro.value.toLowerCase() + "']");
            if (tdSearchPaciente.length > 0) {
                trPaciente.classList.remove("esconde-tr");
            } else if (!trPaciente.classList.contains("esconde-tr")) {
                trPaciente.classList.add("esconde-tr");
            }
        });
    } else {
        trPacientes.forEach(function(trPaciente){
            trPaciente.classList.remove("esconde-tr");
        });
    }
});


var buscarPacientes = document.querySelector("#buscar-pacientes");

buscarPacientes.addEventListener("click", function(event){

    var xhr = new XMLHttpRequest();
    xhr.open("GET", "https://api-pacientes.herokuapp.com/pacientes");
    
    xhr.addEventListener("load", function(event){

        var erroAjax = document.querySelector("#erro-ajax");

        if (xhr.status >= 200 && xhr.status < 300) {

            erroAjax.classList.add("invisivel");

            var request = xhr.responseText;
            var pacientesJson = JSON.parse(request);
            console.log(pacientesJson);
            pacientesJson.forEach(function(pacienteJson){
                var paciente = new Paciente(pacienteJson.nome, pacienteJson.peso, pacienteJson.altura, pacienteJson.gordura);
                console.log(paciente);
                adicionarPacienteNaTabela(paciente);
            });
        } else {

            erroAjax.classList.remove("invisivel");
        }

    });
    
    xhr.send();

});


atualizarTabelaPacientes();