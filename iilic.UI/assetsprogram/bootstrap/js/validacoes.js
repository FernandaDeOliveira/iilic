function validarvalor() {
    var vd = valor.valorDeslocamento.value;
    var va = valor.valorAtendimento.value;
    if (vd < 20) {
        alert("Por favor, insira um valor de deslocamento maior que 20");
        valor.vd.focus();
        return false;
    }
    if (va < 35) {
        alert("Por favor, insira um valor de atendimento maior que 35");
        valor.va.focus();
        return false;
    }
}

function validarcadusuario() {
    var nomeu = cadusuario.nomeUsuario.value;
    var cpfu = cadusuario.cpfUsuario.value;
    var dddu = cadusuario.ddd.value;
    var telefoneu = cadusuario.telefone.value;
    var sexou = cadusuario.sexo.value;
    if (nomeu == null) {
        alert("Por favor, insira seu nome.");
        cadusuario.nomeUsuario.focus();
        return false;
    }
    if (cpfu == null) {
        alert("Por favor, insira seu cpf.");
        cadusuario.cpfu.focus();
        return false;
    }
    if (dddu == null) {
        alert("Por favor, insira seu ddd.");
        cadusuario.ddd.focus();
        return false;
    }
    if (telefoneu == null) {
        alert("Por favor, insira seu telefone.");
        cadusuario.cpfu.focus();
        return false;
    }
    if (sexou == null) {
        alert("Por favor, insira seu sexo.");
        cadusuario.sexo.focus();
        return false;
    }
    /*
    cidade.cep
    cidade.nomeEstado
    cidade.nomeCidade
    acesso.login
    acesso.senha
    */
}