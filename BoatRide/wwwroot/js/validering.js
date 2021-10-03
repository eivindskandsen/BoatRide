function validerFornavn(forNavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,30}$/;
    const confirm = regexp.test(forNavn);
    if (!confirm) {
        $("#feilForNavn").html("Fornavnet må bestå av 2 - 30 bokstaver");

    } else {
        $("#feilForNavn").html("");
        return true;
    }
}

function validerEtternavn(etternNavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,40}$/;
    const confirm = regexp.test(etternNavn);
    if (!confirm) {
        $("#feilEtterNavn").html("Etternavnet må bestå av 2 - 40 bokstaver");

    } else {
        $("#feilEtterNavn").html("");
        return true;
    }
}

function validerEpost(epost) {
    const regexp = /^[a-zA-ZæøåÆØÅ0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    const confirm = regexp.test(epost);
    if (!confirm) {
        $("#feilEpost").html("Invalid email");

    } else {
        $("#feilEpost").html("");
        return true;
    }
}

function validerAntall(antall) {
    const regexp = /^[0-9]{1,4}$/;
    const confirm = regexp.test(antall);
    if (!confirm) {
        $("#feilAntall").html("Antall kan kun være tall");

    } else {
        $("#feilAntall").html("");
        return true;
    }
}