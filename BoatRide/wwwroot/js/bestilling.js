function lagreKjop() {
    validerSåLagreBillett();
    validerSåLagreKunde();
}

function validerSåLagreBillett() {
    const okAntall = validerAntall($("#antall").val());

    if (okAntall) {
        lagreBillett();
    }
}

function lagreBillett() {
    const billett = {
        fra: document.getElementById("select").value,
        til: getValueSelect2(),
        antall: $("#antall").val(),
        dag: $("#dag").val(),
        måned: $("#måned").val(),
        år: $("#år").val()
    }

    console.log(billett);

    $.post("Billett/LagreBillett", billett, function (ok) {
        console.log(billett);
    });
}

function validerSåLagreKunde() {
    const okForNavn = validerFornavn($("#forNavn").val());
    const okEtterNavn = validerEtternavn($("#etterNavn").val());
    const okEpost = validerEpost($("#epost").val());

    if (okForNavn && okEtterNavn && okEpost) {
        lagreKunde();
    }
}
function lagreKunde() {
    const kunde = {
        forNavn: $("#forNavn").val(),
        etterNavn: $("#etterNavn").val(),
        epost: $("#epost").val()
    }

    console.log(kunde);

    $.post("Kunde/LagreKunde", kunde, function (ok) {
        console.log(kunde);
    });
}
