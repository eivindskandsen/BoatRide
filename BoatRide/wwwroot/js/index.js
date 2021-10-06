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

    var date = $("#picker").val();
    console.log(date)
    var dag = date.split("/")[1];
    var måned = date.split("/")[0];
    var år = date.split("/")[2];

    console.log(dag + måned + år);

    const billett = {
        fra: $("#select").val(),
        til: $("#select2").val(),
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



$(function () {
    $("#picker").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true
        //value: 
    });
});