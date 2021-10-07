$(function () {
    const bestilling = JSON.parse(localStorage.getItem("bestilling"));

    $.get("Kunde/HentKundePaaNavn?fornavn=" + bestilling.forNavn + "&etternavn=" + bestilling.etterNavn, function (kunde){
        printKunde(kunde);
        printBilletter(kunde.billetter);
    });

});

function hentKundePåId(kundeID) {
    const url = "Kunde/HentEnKunde?kid=" + kundeID;
    $.get(url, function (kunde) {
        printKunde(kunde);
    });
}

function printKunde(kunde) {
    var ut = "<tr>" +
        "<td>" + kunde.kId + "</td>" +
        "<td>" + kunde.forNavn + "</td>" +
        "<td>" + kunde.etterNavn + "</td>" +
        "<td>" + kunde.epost + "</td></tr>";
    $("#kundeTabell").html(ut);
}

function hentAlleKunder() {
    $.get("Kunde/HentAlle", function (kunder) {
        const liste = kunder;
        liste.forEach(element => console.log(element));
        printKunder(kunder);
    });
}

function printKunder(kunder) {
    const liste = kunder;
    var ut = "";
    liste.forEach(kunde => ut += "<tr>" +
        "<td>" + kunde.kId + "</td>" +
        "<td>" + kunde.forNavn + "</td>" +
        "<td>" + kunde.etterNavn + "</td>" +
        "<td>" + kunde.epost + "</td>"
    )
    $("#kundeTabell").html(ut);
}

function hentKundesBilletter(kundeID) {
    const kid = kundeID;
    const url = "Billett/HentKundesBilletter?kid="+ kid;

    $.get(url, function (billetter) {
        var liste = billetter;
        printBilletter(liste);
    });
}

function hentAlleBilletter() {
    $.get("Billett/HentAlleBilletter", function (billetter) {

        const liste = billetter;
        liste.forEach(element => console.log(element));
        printBilletter(liste);
    });
};

function printBilletter(billetter) {
    const liste = billetter;
    var ut = "";
    liste.forEach(billett => ut += "<tr>" +
        "<td>" + billett.bId + "</td>" +
        "<td>" + billett.fra + "</td>" +
        "<td>" + billett.til + "</td>" +
        "<td>" + billett.dag + "/" + billett.måned + "-" + billett.år + "</td>" +
        "<td>" + billett.antall + "</td></tr>"
    )
    $("#billettTabell").html(ut);
}
