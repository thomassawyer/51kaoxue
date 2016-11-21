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
                var text = temp[i].testname;
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp\">●</span>&nbsp;<a target='_blank' class=\"rmxzaa\"  href='../Download?cid=1&id=" + temp[i].id + "' target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'>" + text + "</a></li>";
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
                var text = temp[i].testname;
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' class=\"rmxzaa rmxz2hv\" href='../Download?cid=1&id=" + temp[i].id + "' target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'>" + text + "</a></li>";
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
                                <a target='_blank' class=\"wdk fl\" href='../Download?id=" + temp[i].id + "&cid=" + temp[i].category + "'  target='_blank' ></a>\
                                <div class=\"wenbenkui fl\">\
                                    <a target='_blank' class=\"b320 font_size16 overf_com font_wb\" href='../Download?id=" + temp[i].id + "&cid=" + temp[i].category + "'  target='_blank'  title='" + text + "'>" + text + "</a><br>\
                                    <span class=\"lxcsp320\">" + temp[i].uploadtime + "</span>\
                                </div>\
                                <div class=\"xiazai fr\" style='position:static;width:45px;height:45px;margin-right: 30px;'>\
                                    <a target='_blank' class=\"xztb2 fr\" href='../Download?id=" + temp[i].id + "&cid=" + temp[i].category + "'  target='_blank' ></a>\
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
    $("#" + controlid).html("<div class=\"waiting_bg_1\"></div>");
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