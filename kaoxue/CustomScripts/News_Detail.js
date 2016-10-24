﻿/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
var id;
var typename = ""; //类型名称
//
//高考动态
//
function GetTest_Hot_Download() {
    $.post("../Home/GetNews2", { type: 1 }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title.length > 10 ? temp[i].title.substr(0, 10) + "..." : temp[i].title;
                html += "<li><a href='../News_Detail?id=" + temp[i].id + "'>" + text + "</a></li>";
            }
            $("#hot_download").html(html);
        }
    });
}

//
//教学方法
//
function GetTest_Recommend() {
    $.post("../Home/GetNews2", { type: 6 }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title.length > 10 ? temp[i].title.substr(0, 10) + "..." : temp[i].title;
                html += "<li><a href='../News_Detail?id=" + temp[i].id + "'>" + text + "</a></li>";
            }
            $("#recommend").html(html);
        }
    });
}

//
//获取新闻数据
//
function GetList() {
    $.post("../News_Detail/GetNewsDetail", { id:id }, function (data) {
        if (data) {
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    $("#data_title_title").html(temp[i].title);
                    $("#data_date").html("更新时间:  " + temp[i].pubdate);
                    $("#data_content").html(temp[i].content);
                }
            }
        }
    });
}


$(document).ready(function () {
    id = GetQueryString("id");
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetList();
});