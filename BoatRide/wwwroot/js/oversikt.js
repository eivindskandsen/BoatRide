$(function () {
    hentAlleBilletter();
});

function hentAlleBilletter() {
    $.get("Billett/HentAlleBilletter", function (billetter) {
        
        const liste = billetter
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
        $("#ordre").html(billetten.order)
        $("#fra").html(billetten.from)
        $("#til").html(billetten.to)
        $("#dato").html(billetten.date)
        $("#pris").html(billetten.price)
    });
});

*/