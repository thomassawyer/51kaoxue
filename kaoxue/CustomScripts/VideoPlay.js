/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function GetUserInfo() {
    $.post("../Home/GetUserInfo", function (data) {
        if (data != "0") {
            var temp = eval(data);
            var m = temp[0];
            $("#title1").html(m.title);
            $("#title2").html(m.title);
            $("#title3").html(m.title);
            $("#teacher").html("课程主讲：" + m.teacher);
            var date = new Date(m.updateTime);
            var time = date.getYear().toString() + "-" + ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
            $("#updateTime").html("课程日期：" + m.updateTime);
            $("#videoTime").html("视频时长："+m.videoTime);
        } 
    })
}

//
//获取视频信息
//
function GetInformation() {
    $.post("../VideoPlay/GetInformation", function (data) {
        if (data != "0") {
            var temp = eval(data);
            
        } 
    })
}

//
//视频观看记录
//
function Watching_Record() {
    $.post("../VideoPlay/Watching_Record", function (data) {
        if (data != "0") {
            var temp = eval(data);
            for (var i = 0; i < temp.length; i++) {

            }
        }
    })
}

//
//视频排行榜
//
function Video_List() {
    $.post("../VideoPlay/Video_List", function (data) {
        if (data != "0") {
            var temp = eval(data);
            for (var i = 0; i < temp.length; i++) {

            }
        }
    })
}

//
//相关推荐
//
function Related_Videos() {
    $.post("../VideoPlay/Video_List", function (data) {
        if (data != "0") {
            var temp = eval(data);
            for (var i = 0; i < temp.length; i++) {

            }
        }
    })
}
