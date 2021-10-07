$(function () {
    //readyfunction
});

$(function () {
    $("#picker").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true
    });
});

function gaVidere() {
    validerSåGåVidere();
}

function lagreBestilling() {
    var date = $("#picker").val();
    
    const bestilling = {
        fra: $("#fraDestinasjon").val(),
        til: $("#tilDestinasjon").val(),
        antall: $("#antall").val(),
        dag: date.split("/")[1],
        måned: date.split("/")[0],
        år: date.split("/")[2]
    }
    
    localStorage.setItem("bestilling", JSON.stringify(bestilling));
}


function validerSåGåVidere() {

    const okAntall = validerAntall($("#antall").val());
    const OkFraOgTil = validerFraOgTil($("fraDestinasjon").val(), $("tilDestinasjon").val());

    if (okAntall && OkFraOgTil) {
        lagreBestilling();
        window.location.href = "bestilling.html";
    }
}


