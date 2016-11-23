(function ValidarCPF(cpf) {
  
        //999.999.999-99
        var xPos = PosicaoCursor(campo);
        evt = getEvent(evt);
        var tecla = getKeyCode(evt);
        if (!teclaValida(tecla))
            return;
        vr = campo.value = filtraNumeros(filtraCampo(campo));
        tam = vr.length;
        if (tam >= 3 && tam < 6)
            campo.value = vr.substr(0, 3) + '.' + vr.substr(3);
        else if (tam >= 6 && tam < 9)
            campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(6);
        else if (tam >= 9)
            campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(6, 3) + '-' + vr.substr(9);
        MovimentaCursor(campo, xPos);
    
});