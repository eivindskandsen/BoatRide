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