function montaElemento(tagElemento, classElemento, contentElemento) {
    var elemento = document.createElement(tagElemento);
    
    if (classElemento != null) {
        elemento.classList.add(classElemento);
    }
    
    if (contentElemento != null) {
        elemento.textContent = contentElemento;
    }

    return elemento;
}

function limparElemento(elemento) {
    elemento.innerHTML = "";
}

function pegarElemento(seletor) {
    var elemento = document.querySelector(seletor);
    return elemento;
}

function pegarElementos(seletor) {
    var elementos = document.querySelectorAll(seletor);
    return elementos;
}