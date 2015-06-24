// Them mot the loai
$(document).ready(function () {
    var $firstPara = $('#feedbackLetter');
    $firstPara.hide();
    $('a.moreletter').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn hỏi đáp') {
            $link.text('Nhập thông tin hỏi đáp');
        } else {
            $link.text('Ẩn hỏi đáp');
        }
        return false;
    });
});