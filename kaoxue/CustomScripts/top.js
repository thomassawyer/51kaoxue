﻿/// <reference path="../Scripts/jquery-1.8.2.js" />


//
//备课资源数量
//
function getbeikecount() {
    $.post("../Home/GetBeikeCount", function (data) {
        $("#beikecount").html(data + "套");
    });
}


//
//试题资源数量
//
function GetShitiCount() {
    $.post("../Home/GetShitiCount", function (data) {
        $("#shiticount").html(data + "套");
    });
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

$(document).ready(function () {
    getbeikecount();
    GetShitiCount();
    GetUserInfo();
});