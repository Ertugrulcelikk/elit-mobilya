$(document).ready(function() {
    $("#menu-toggle").click(function(e) {
        e.preventDefault();
        $(".sidebar").toggleClass("toggled");
        $(".main-content").toggleClass("toggled");
    });
}); 