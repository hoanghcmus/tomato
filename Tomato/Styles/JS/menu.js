$(document).ready(function () {

    $("#navtop ul.child").removeClass("child");

    $("#navtop li").has("ul").hover(function () {
        $(this).addClass("current").children("ul").show(300);
    }, function () {
        $(this).removeClass("current").children("ul").hide();
    });
});