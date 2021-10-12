function validerFraOgTil(fra, til) {
    if (fra == til) {
        $("#feilDestination").html("Til og Fra kan ikke være det samme");
        return false;
    } else {
        $("#feilDestination").html("");
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
    const regexp = /^[a-zA-ZæøåÆØÅ0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)$/;
    const confirm = regexp.test(epost);
    if (!confirm) {
        $("#feilEpost").html("Invalid email");

    } else {
        $("#feilEpost").html("");
        return true;
    }
}

function validerBrukernavn(brukernavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,25}$/;
    const confirm = regexp.test(brukernavn);
    if (!confirm) {
        $("#feilBrukernavn").html("Brukernavnet må bestå av 2 til 25 bokstaver");
    } else {
        $("#feilBrukernavn").html("");
        return true;
    }
}

function validerPassord(passord) {
    const regexp = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/;
    const confirm = regexp.test(passord);
    if (!confirm) {
        $("#feilPassord").html("Passordet må bestå av minimum 6 tegn, minst en bokstav og et tall");
    } else {
        $("#feilPassord").html("");
        return true;
    }
}

