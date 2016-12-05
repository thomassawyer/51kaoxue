var bhide = true;
function chakan_fun() {
    if (bhide) {
        $(".chakan_more_content").show();
        $(".chakan_more_content").animate({ height: 1455 + "px" }, 500);
        $(".chakan_more_btn").css({ 'background-image': 'url(../img/jiantou_up.png)' });
        
        bhide = false;
    } else {
        $(".chakan_more_content").animate({ height: 0 + "px" }, 500, function () { $(".chakan_more_content").hide(); });

        $(".chakan_more_btn").css({ 'background-image': 'url(../img/jiantou_down.png)' });
        bhide = true;
    }
}

//获取用户登录状态
function GetUserZhuangtai() {
    $.post("../Home/GetUserInfo", function (data) {
        if (data != "0") {
            var temp = eval(data);
            for (var i = 0; i < temp.length; i++) {
                //$("#logininfo").html(temp[i].school + "&nbsp;&nbsp;" + getusertype(temp[i].level) + "&nbsp;&nbsp;<a target=\"_blank\">[退出]</a>");
                $(".username").html(temp[i].school + "&nbsp;&nbsp;" + getusertype(temp[i].level));
                $(".weidenglu").hide();
                $(".denglu").show();
                $(".zhuangxie_btn").click(function () {
                    window.open('../AdviseWrite');
                });
            }
        } else {
            $(".weidenglu").show();
            $(".denglu").hide();
            $(".zhuangxie_btn").click(function () {
                window.open('../Login');
            });
        }
    })
}

$(document).ready(function () {
    GetUserZhuangtai();
});