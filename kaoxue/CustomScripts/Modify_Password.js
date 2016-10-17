/// <reference path="../Scripts/jquery-1.8.2.js" />


function save() {
    //老密码
    var oldpass = $("#oldpass").val();
    //新密码
    var newpass = $("#newpass").val();
    $.post("../Member_Center/Update_Password", {
        oldpass: oldpass,
        newpass:newpass
    }, function (data) {
        if (data == "3") {
            location.href = "../Login?return_url=../Member_Center/Modify_Password?controlid=xgmm";
        }

        if (data == "1") {
            message("更改密码成功");
        } else if (data == "0") {
            message("更改密码失败");
        } else if (data == "2") {
            message("原密码错误");
        }
    });
}

function message(text) {
    $("#message_content").html("系统提示: " + text);
    $("#message_start").click();
}

//
//退出登录
//
function ClearSession() {
    $.post("../Member_Center/ClearSession", function (data) {
        if (data == "1") {
            location.href = "../Login?return_url=../Member_Center/Modify_Password?controlid=xgmm";
        }
    });
}