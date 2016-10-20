/// <reference path="../Scripts/jquery-1.8.2.js" />



//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

var id;
var way;

//
//热门下载
//
function GetTest_Hot_Download() {
    $.post("../Elite_School/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp\">●</span>&nbsp;<a class=\"rmxzaa\">"+text+"</a></li>";
            }
            $("#hot_download").html(html);
        }
    });
}

//
//相关推荐
//
function GetTest_Recommend() {
    $.post("../Elite_School/GetTest_Recommend", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < 11; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
            }
            $("#recommend").html(html);
        }
    });
}

//
//获取试题数据
//
function GetList() {
    $.post("../SpecialSubject/GetList", { id: id}, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    var cid;
                    if (way == 1) {
                        cid = 1;
                    } else if (way == 2) {
                        cid = 2;
                    }
                    html += "<div class=\"lxc_320\">\
                                <div class=\"wdk fl\"></div>\
                                <div class=\"wenbenkui fl\">\
                                    <a ><b class=\"b320\">"+text+"</b></a><br>\
                                    <span class=\"lxcsp320\">" + temp[i].uploadtime + "</span>\
                                </div>\
                                <div class=\"xiazai fl\">\
                                    <a  class=\"xztb1 fl\"><img src=\"img/yulan.png\" ><img src=\"img/hover-31.png\"  class=\"dpnone\"></a>\
                                    <a  class=\"xztb2 fl\"><img src=\"img/xiazaitb.png\" ><img src=\"img/yll.png\"  class=\"yll\"></a>\
                                </div>\
                            </div>";
                }
            }
            $("#data_list_td").html(html);
        }
    });
}

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}

$(document).ready(function () {
    StartReading("data_list_td");
    GetTest_Hot_Download();
    GetTest_Recommend();
    id = GetQueryString("id");
    var name = GetQueryString("name");
    $("#title_left").html(name);
    $("#name_title").html(name);
    GetList();
});