/// <reference path="../Scripts/jquery-1.8.2.js" />

//
//获取会员信息
//
function getuserinfo() {

    $.post("../Member_Center/GetUserInfo", function (data) {
        if (data) {
            if (data != "]") {
                if (data == "0") {
                    location.href = "../Login?return_url=../Member_Center";
                }
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    //真实姓名
                    $("#name").val(temp[i].name);
                    //所在学校
                    $("#school").val(temp[i].school);
                    //移动手机
                    $("#mobile").val(temp[i].mobile);
                    //固定电话
                    $("#tel").val(temp[i].tel);
                    //详细地址
                    $("#address").val(temp[i].address);
                }
            }
            
        }
    });
}

//
//保存
//
function save() {
    //真实姓名
    var name =$("#name").val();
    //所在学校
    var school =$("#school").val();
    //移动手机
    var mobile =$("#mobile").val();
    //固定电话
    var tel = $("#tel").val();
    //详细地址
    var address =$("#address").val();

    $.post("../Member_Center/Save", {
        name: name,
        school: school,
        mobile: mobile,
        tel: tel,
        address:address
    }, function (data) {
        if (data == "1") {
            //保存成功
            message("保存成功");
        } else {
            //保存失败
            message("保存失败");
        }
    });
}

//
//退出登录
//
function ClearSession() {
    $.post("../Member_Center/ClearSession", function (data) {
        if (data == "1") {
            location.href = "../Login?return_url=../Member_Center";
        }
    });
}

function message(text) {
    $("#message_content").html("系统提示: " + text);
    $("#message_start").click();
    
}
$(document).ready(function () {
    getuserinfo();
});