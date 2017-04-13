var btnAdicionarPaciente = document.querySelector("#adicionar-paciente");

btnAdicionarPaciente.addEventListener("click", function(event) {
    event.preventDefault();
    
    var form = document.querySelector("#novo-paciente");
    var paciente = obtemPacientedoForm(form);
    
    if (paciente.ehValido()) {
        limparMensagensDeErros();
        adicionarPacienteNaTabela(paciente);
    } else {
        mostrarErro(paciente.pegaErros());
        return;
    }
    
    form.reset();
})

function adicionarPacienteNaTabela(paciente) {
    var tabelaPacientes = document.querySelector("#tabela-pacientes");
    var trPaciente = montaTrPaciente(paciente);
    tabelaPacientes.appendChild(trPaciente);
    atualizaTrPaciente(paciente, trPaciente);
}

function obtemPacientedoForm(form) {
    return new Paciente(form.nome.value, form.peso.value, form.altura.value, form.gordura.value);
}

function limparMensagensDeErros() {
    var ulErros = pegarElemento("#mensagem-erro");
    limparElemento(ulErros);
}

function mostrarErro(msgs) {
    var ulErros = pegarElemento("#mensagem-erro");
    limparElemento(ulErros);

    for (i = 0; i < msgs.length; i++) {
        var liErro = montaElemento("li", null, msgs[i]);
        ulErros.appendChild(liErro);
    }

    ulErros.style.display = "block";
    console.log(ulErros);
}