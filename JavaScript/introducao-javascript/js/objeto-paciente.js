function Paciente(nome, peso, altura, gordura) {
        this.nome = nome;
        this.peso = peso;
        this.altura = altura;
        this.gordura = gordura;
        this.calculaIMC = function() { return calcularIMC(this.peso, this.altura); };
        this.pesoEhValido = function() { return (this.peso >= 30 && this.peso <= 300); };
        this.alturaEhValida = function() { return (altura >= 0.50 && altura <= 3.00); };
        this.ehValido = function() { return this.pesoEhValido() && this.alturaEhValida(); };
        this.pegaErros = function() {
            var erros = [];
            if (!this.pesoEhValido()) {
                erros.push("Peso inválido.");
            }
            if (!this.alturaEhValida()) {
                erros.push("Altura inválida.")
            }
            console.log(erros);
            return erros;
        };
}

function calcularIMC(peso, altura, digitos = 2) {
    var imc = peso / (altura * altura);
    return imc.toFixed(digitos);
}