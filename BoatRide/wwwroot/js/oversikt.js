$(function () { 
    hentAlleBilletter();
    hentAlleKunder();
    hentKundesBilletter(3);
});

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
    console.log(url);

    $.get(url, function (billetter) {
        var liste = billetter;
        liste.forEach(element => console.log(element));
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

/*
    <tbody id="billettTabell" og id="kundeTabell">
            <tr>
                <td id="ordre">812934791283749812</td>
                <td id="fra">Bergen</td>
                <td id="til">Oslo</td>
                <td id="dato">24/09-2021</td>
                <td id="pris">598</td>
            </tr>
    </tbody>
 
*/

 /*
$(function () {
    $.post("Kunde/HentEn", function (billetten) {
        $("#navn").html(billetten.navn)
        $("#epost").html(billetten.mail)
@ -48,6 +8,4 @@ $(function () {
        $("#dato").html(billetten.date)
        $("#pris").html(billetten.price)
    });
});

*/