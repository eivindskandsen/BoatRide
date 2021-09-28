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
    lagreBillett();
    lagreKunde();
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

function lagreKunde() {
    console.log("HEI")
    const kunde = {
        forNavn: $("#forNavn").val(),
        etterNavn: $("#etterNavn").val(),
        epost: $("#epost").val()
    }

    $.post("Kunde/lagreKunde", kunde, function (OK){
        if (OK) {
            window.location.href = 'bestilling.html'
        } else {
            $(".mb - 3 form - check").append("Feil i db")
        }
    })
    console.log(kunde);

    $.post("Kunde/LagreKunde", kunde, function (ok) {
        console.log(kunde);
    });
}
