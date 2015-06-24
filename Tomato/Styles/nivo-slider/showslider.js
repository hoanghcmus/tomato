$(document).ready(function() {
    $('#slider').nivoSlider({
        effect:'sliceDown', //Specify sets like: 'fold,fade,sliceDown'
        directionNav:true, //Next & Prev
        directionNavHide:true, //Only show on hover
        controlNav:true, //1,2,3...
        keyboardNav:true, //Use left & right arrows
        animSpeed: 800,// Tốc độ trượt ảnh, quy định 1000 = 1giây
        pauseTime: 4000, // Tốc độ chuyển ảnh A sang ảnh B
    });
});