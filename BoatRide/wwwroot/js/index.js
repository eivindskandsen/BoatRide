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

function lagreKunde() {
    console.log("HEI")
    const kunde = {
        etterNavn: $("#forNavn").val(),
        etterNavn: $("#navn").val(),
        epost: $("#epost").val()
    }

    $.post("Kunde/lagreKunde", kunde, function (OK){
        if (OK) {
            window.location.href = 'bestilling.html'
        } else {
            $(".mb - 3 form - check").append("Feil i db")
        }
    })
}
