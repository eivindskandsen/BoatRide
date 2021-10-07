$(function () {
    //Readyfunction
});


function validerSåLagreKunde() {
    const okForNavn = validerFornavn($("#forNavn").val());
    const okEtterNavn = validerEtternavn($("#etterNavn").val());
    const okEpost = validerEpost($("#epost").val());

    if (okForNavn && okEtterNavn && okEpost) {
        lagreBestilling();
    }
}


function lagreBestilling() {
    const innBestilling = JSON.parse(localStorage.getItem("bestilling"));

    const utvidetBestilling = {
        forNavn : $("#forNavn").val(),
        etterNavn : $("#etterNavn").val(),
        epost : $("#epost").val(),
        fra : innBestilling.fra,
        til : innBestilling.til,
        antall : innBestilling.antall,
        dag : innBestilling.dag,
        måned : innBestilling.måned,
        år : innBestilling.år
    }

    const bestilling = JSON.stringify(utvidetBestilling);

    localStorage.setItem("bestilling", bestilling);

    $.ajax({
        type: "POST",
        url: "Billett/LagreBillett/",
        data: bestilling,
        success: () => {
            console.log("Success!"), window.location.href = "oversikt.html"},
        error: () => { $("#feil").html("Feil på server - prøv igjen senere")},
        contentType: "application/json"
    });
}
