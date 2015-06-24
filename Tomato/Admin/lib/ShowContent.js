$(function () {
    // lay checkbox co id=chkAll 
    var $chkBox = $("input:checkbox[id$=chkAll]");
    // lay mang cac checkbox co name = cid 
    var $tblChkBox = $("table.list input:checkbox[name$=cid]");
    // them su kien click cho chkAll 
    $chkBox.click(function () {
        $tblChkBox
            .attr('checked', $chkBox
            .is(':checked'));
    });

    // them su kien cho cac check box co name = cid 
    // khi bo check thi chkAll cung tro ve trang thai uncheck 
    $tblChkBox.click(
       function (e) {
           if (!$(this)[0].checked) {
               $chkBox.attr("checked", false);
           }
       });

       //----------------------------------Cap nhat khao sat/ Dung cho form tieu chi chon
       // lay checkbox co id=chkAllOn 
       var $chkBoxOn = $("input:checkbox[id$=chkAllOn]");
       // lay mang cac checkbox co name = cidOn 
       var $tblChkBoxOn = $("table.list input:checkbox[name$=cidOn]");
       // them su kien click cho chkAll 
       $chkBoxOn.click(function () {
           $tblChkBoxOn
            .attr('checked', $chkBoxOn
            .is(':checked'));
       });

       // them su kien cho cac check box co name = cid 
       // khi bo check thi chkAll cung tro ve trang thai uncheck 
       $tblChkBoxOn.click(
       function (e) {
           if (!$(this)[0].checked) {
               $chkBoxOn.attr("checked", false);
           }
       });

       //----------------------------------Cap nhat khao sat/ Dung cho form mon hoc
       // lay checkbox co id=chkAllOn 
       var $chkBoxmh = $("input:checkbox[id$=chkAllmh]");
       // lay mang cac checkbox co name = cidOn 
       var $tblChkmh = $("table.listSelectSmall input:checkbox[name$=cidmh]");
       // them su kien click cho chkAll 
       $chkBoxmh.click(function () {
           $tblChkmh
            .attr('checked', $chkBoxmh
            .is(':checked'));
       });

       // them su kien cho cac check box co name = cid 
       // khi bo check thi chkAll cung tro ve trang thai uncheck 
       $tblChkmh.click(
       function (e) {
           if (!$(this)[0].checked) {
               $chkBoxmh.attr("checked", false);
           }
       });

       //----------------------------------Cap nhat khao sat/ Dung cho form mon hoc chon
       // lay checkbox co id=chkAllOn 
       var $chkBoxMonHocChon = $("input:checkbox[id$=chkAllmhc]");
       // lay mang cac checkbox co name = cidOn 
       var $tblChkBoxMonHocChon = $("table.listSelectSmall input:checkbox[name$=cidmhc]");
       // them su kien click cho chkAll 
       $chkBoxMonHocChon.click(function () {
           $tblChkBoxMonHocChon
            .attr('checked', $chkBoxMonHocChon
            .is(':checked'));
       });

       // them su kien cho cac check box co name = cid 
       // khi bo check thi chkAll cung tro ve trang thai uncheck 
       $tblChkBoxMonHocChon.click(
       function (e) {
           if (!$(this)[0].checked) {
               $chkBoxMonHocChon.attr("checked", false);
           }
       });
       
    // hien thong bao nhac nho nguoi dung co that su muon xoa cac muc da chon hay khong 
    $("input.multidelete").click(function () {
        var n = $("table.list input:checkbox[name$=cid]:checked").length;
        if (n == 0) {
            alert('Vui lòng chọn ít nhất một dòng để xóa!');
            return false;
        }
        else {
            return confirm('Chú ý: Các hàng được chọn sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
        }
    });

    // hien thong bao nhac nho nguoi dung co that su muon chọn để cấp quyen khong
    $("input.execuChek").click(function () {
        var n = $("table.list input:checkbox[name$=cid]:checked").length;
        if (n == 0) {
            alert('Vui lòng chọn ít nhất một dòng để thực hiện chức năng!');
            return false;
        }
        else {
            return confirm('Chú ý: Các hàng được chọn sẽ được hệ thống xử lý. Bạn có muốn tiếp tục không?');
        }
    });
});
//
$(function () {
    // hien thong bao nhac nho nguoi dung co that su muon xoa bai dang khong
    $("input.btnDeleteAlbum").click(function () {
        return confirm('Chú ý: Bài đăng sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
    });

    $("input.btnCamDangAlbum").click(function () {
        return confirm('Chú ý: Bạn có thật sự muốn cấm đăng Album này không?');
    });
});

$(function () {
    // hien thong bao nhac nho nguoi dung co that su muon xoa bai dang khong
    $("input.linkRemovealbum").click(function () {
        return confirm('Chú ý: Album sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
    });
    $("input.linkRemovevideo").click(function () {
        return confirm('Chú ý: Video sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
    }); 
    $("input.linkRemovemin").click(function () {
        return confirm('Chú ý: Hổ trợ này sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
    });
    $("input.icon-remove").click(function () {
        return confirm('Chú ý: Đối tượng sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
    });
});

// Them mot the loai
$(document).ready(function () {
    var $firstPara = $('#feedback');
    $firstPara.hide();
    $('a.moreTheLoai').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form thêm') {
            $link.text('Thêm mới thể loại');
        } else {
            $link.text('Ẩn form thêm');
        }
        return false;
    });
});
// Ẩn hiện Loại 
$(document).ready(function () {
    var $firstPara = $('#feedback');
    $firstPara.hide();
    $('a.morefbLoai').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form') {
            $link.text('Thêm loại');
        } else {
            $link.text('Ẩn form');
        }
        return false;
    });
}); 

// Ẩn hiện Letter
$(document).ready(function () {
    var $firstPara = $('#feedbackLetter');
    $firstPara.hide();
    $('a.moreAdminletter').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form hỏi đáp') {
            $link.text('Gửi hỏi đáp');
        } else {
            $link.text('Ẩn form hỏi đáp');
        }
        return false;
    });
});


// Ẩn hiện Add
$(document).ready(function () {
    var $firstPara = $('#feedback');
    $firstPara.hide();
    $('a.morefbnd').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form thêm') {
            $link.text('Thêm người dùng mới');
        } else {
            $link.text('Ẩn form thêm');
        }
        return false;
    });
});

// Ẩn hiện Add
$(document).ready(function () {
    var $firstPara = $('#feedback');
    $firstPara.hide();
    $('a.morefbpnnd').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form phân nhóm') {
            $link.text('Phân nhóm người dùng mới');
        } else {
            $link.text('Ẩn form phân nhóm');
        }
        return false;
    });
});


$(document).ready(function () {
    var $firstPara = $('#feedbackAdd');
    $firstPara.hide();
    $('a.moreNhieuMonHoc').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form thêm từ file') {
            $link.text('Thêm môn học từ file');
        } else {
            $link.text('Ẩn form thêm từ file');
        }
        return false;
    });
});

// Them mot ho tro
$(document).ready(function () {
    var $firstPara = $('#feedback');
    $firstPara.hide();
    $('a.moreHoTro').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form thêm') {
            $link.text('Thêm loại văn bản');
        } else {
            $link.text('Ẩn form thêm');
        }
        return false;
    });
});


// Them nhieu sinh vien dang ky mon hoc
$(document).ready(function () {
    var $firstPara = $('#feedbackAdd');
    $firstPara.hide();
    $('a.moreNhapFile').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form thêm từ file') {
            $link.text('Thêm từ file');
        } else {
            $link.text('Ẩn form thêm từ file');
        }
        return false;
    });
});

// Ẩn hiện Updata
$(document).ready(function () {
    var $firstPara = $('#feedback');
    $firstPara.hide();
    $('a.morefbUpdata').click(function () {
        $firstPara.slideToggle('slow');
        var $link = $(this);
        if ($link.text() == 'Ẩn form') {
            $link.text('Cập nhật mật khẩu');
        } else {
            $link.text('Ẩn form');
        }
        return false;
    });
});
