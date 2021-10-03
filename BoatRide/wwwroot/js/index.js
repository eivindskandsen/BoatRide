// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    const id = window.location.search.substring(1);
    const url = "Kunde/HentEn?" + id;

    $.get(url, function (kunde) {
        $("#id").val(kunde.id);
        $("#Name").val(kunde.forNavn);
        $("#Mail").val(kunde.email);
    });
});

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
        fra: $("#fra").val(),
        til: $("#til").val(),
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

function byttNavn() {

    console.log("Her");
    /* $("#elementId :selected").val();
   

};

$('#demolist').on('click', function () {

   $('#dropdownMenuButton1').$(this).text().html;
});

*/
    var e = document.getElementById("fra");
    var str = e.value;

    console.log(str)


}
