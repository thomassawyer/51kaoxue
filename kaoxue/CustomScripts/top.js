/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var subjectname = "";
//
//备课资源数量
//
function getbeikecount() {
    $.post("../Home/GetBeikeCount", function (data) {
        $("#beikecount").html("5" + data + "套");
    });
}
function GetUpCountByDay() {
    $.post("../Home/GetBeikeCountByDay", function (data) {
        $("#UpCountByDay").html("5" + data + "套");
    });
}

function MemberCount() {
    $.post("../Home/GetMemberCount", function (data) {
        $("#MemberCount").html("3"+data + "所");
    });
}
//
//试题资源数量
//
function GetShitiCount() {
    $.post("../Home/GetShitiCount", function (data) {
        $("#shiticount").html("3" + data + "套");
    });
}


function shousuo_keyfun(event) {
    var val = $('#shousuo').val();
    if (event.keyCode == 13) {
        location.href = '../Search?keywords=' + val;
    }
}
function GetUserInfo() {
    $.post("../Home/GetUserInfo", function (data) {
        if (data != "0") {
            var temp = eval(data);
            for (var i = 0; i < temp.length; i++) {
                $("#logininfo").html(temp[i].school + "&nbsp;&nbsp;" + getusertype(temp[i].level));
            }
        }
    })
}

function getusertype(level) {
    var temp = "";
    if (level == "0") temp = "普通用户";
    if (level == "1") temp = "试用会员";
    if (level == "2") temp = "高级会员";
    if (level == "3") temp = "包年会员";
    if (level == "4") temp = "业务员";
    if (level == "admin") temp = "管理员";
    return temp;
}

//监听滚轮事件

function getScroll() {
    $(window).scroll(function (event) {

        var winPos = $(window).scrollTop();
        if (winPos > 500) {
            $(".fixed_all").css({ 'display': 'block'});
        } else {
            $(".fixed_all").css({ 'display': 'none' });
        }
    });

    $(".fixed_return").click(function () {
        $("html,body").animate({ scrollTop: 0 }, 1000);
    });
}
//导航选中
function navSelect() {
    var img = $(".maozi1_hover");
    if (subjectname) {
        switch (subjectname) {
            case "语文":
                img.eq(0).css({'display':'block','right':'23px'});
                break;
            case "数学":
                img.eq(1).css({ 'display': 'block', 'right': '23px' });
                break;
            case "英语":
                img.eq(2).css({ 'display': 'block', 'right': '23px' });
                break;
            case "物理":
                img.eq(3).css({ 'display': 'block', 'right': '23px' });
                break;
            case "化学":
                img.eq(4).css({ 'display': 'block', 'right': '23px' });
                break;
            case "生物":
                img.eq(5).css({ 'display': 'block', 'right': '23px' });
                break;
            case "历史":
                img.eq(6).css({ 'display': 'block', 'right': '23px' });
                break;
            case "政治":
                img.eq(7).css({ 'display': 'block', 'right': '23px' });
                break;
            case "地理":
                img.eq(8).css({ 'display': 'block', 'right': '23px' });
                break;
        }
    } else {
        var pahtname = window.location.pathname;
        if (pahtname) {
            switch (pahtname) {
                case "/Grade":
                    if (GetQueryString("level") == 2) {
                        img.eq(12).css({ 'display': 'block', 'right': '23px' });
                    } else {
                        img.eq(11).css({ 'display': 'block', 'right': '23px' });
                    }
                    break;
                case "/Beike_Center":
                    img.eq(0).css({ 'display': 'block', 'right': '45px' });
                    $("#nav_rec_2").html("&nbsp;&gt;&nbsp;备课中心");
                    break;
                case "/Test_Center":
                    $("#nav_rec_2").html("&nbsp;&gt;&nbsp;试题中心");
                    img.eq(1).css({ 'display': 'block', 'right': '45px' });
                    break;
                case "/Past_Exam":
                    img.eq(2).css({ 'display': 'block', 'right': '45px' });
                    $("#nav_rec_2").html("&nbsp;&gt;&nbsp;高考真题");
                    break;
                case "/Elite_School":
                    img.eq(3).css({ 'display': 'block', 'right': '45px' });
                    $("#nav_rec_2").html("&nbsp;&gt;&nbsp;名校试题");
                    break;
                case "/Gaokao_Beikao":
                    img.eq(4).css({ 'display': 'block', 'right': '45px' });
                    $("#nav_rec_2").html("&nbsp;&gt;&nbsp;高考备考");
                    break;
            }
        }
    }
}
$(document).ready(function () {
    subjectname = GetQueryString("subjectname");
    navSelect();
    getbeikecount();
    GetShitiCount();
    GetUserInfo();
    GetUpCountByDay();
    MemberCount();
    getScroll();
});