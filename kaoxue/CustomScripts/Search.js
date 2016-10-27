/// <reference path="../Scripts/jquery-1.8.2.js" />

var keywords = "";
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

//
//点击A标签时,改变A标签背景
//
function a_selected(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("condition_selected");
    });
    $(obj).addClass("condition_selected");
}



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
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp\">●</span>&nbsp;<a  class=\"rmxzaa\">" + text + "</a></li>";
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
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#data_list_td").offset().top }, 500);
}

//
//获取试题数据
//
function GetList() {
    $("#data_list_td").html("<div class=\"lxclan\">\
                <b class=\"bix\">数据读取中……</b>\
            </div>");
    $.post("../Search/GetList", {pageindex: pageindex, keywords:keywords }, function (data) {
        if (data) {
            var html = "<div class=\"lxclan\">\
                <b class=\"bix\">关键字："+keywords+"</b>\
            </div>";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    html += "<div class=\"lxc_320\">\
                                <div class=\"wdk fl\"></div>\
                                <div class=\"wenbenkui fl\">\
                                    <a><b class=\"b320\">"+ text + "</b></a><br>\
                                    <span class=\"lxcsp320\">时间：" + temp[i].pubdate + "</span>\
                                </div>\
                                <div class=\"xiazai fl\" style='position:static;width:45px;height:45px;margin-left:160px;'>\
                                    <a class=\"xztb2 fl\"  href='../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' target='_blank')><img src=\"img/xiazaitb.png\"></a>\
                                </div>\
                            </div>";
                }
            }
            $("#data_list_td").html(html);
            Produce_A_Signs();
        }
    });
}


//
//上一页
//
function pre_page() {
    if (pageindex >= 2) {
        StartReading("data_list_td");
        pageindex--;
        GetList();
    } else {
        alert('已到达第一页');
    }
}
//
//下一页
//
function next_page() {
    if (pageindex <= (pagecount - 1)) {
        StartReading("data_list_td");
        pageindex++;
        GetList();
    }
}

//
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../Search/GetDataCount", { pageindex: pageindex, keywords: keywords }, function (data) {
        if (data) {
            if (Number(data) % 10 == 0) {
                pagecount = data / 10;
            } else {
                pagecount = Math.floor((data / 10)) + 1;
            }
        }
    });
    $.ajaxSetup({
        async: true
    });
}

//
//分页页码
//
function Produce_A_Signs() {
    var html = "<a  class=\"anniu1 syy1\" onclick=\"anchor(this),pre_page()\">上一页</a>";
    var signs_length;
    if (pageindex >= pagecount - 3) {
        signs_length = (pagecount - pageindex) + 1;
    } else {
        signs_length = 5;
    }
    if (pageindex >= 2) {
        html += "<span class=\"anniusp1\">...</span>";
    }
    for (var i = 0; i < signs_length; i++) {
        flag = (i + 1);
        html += "<a  onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ") class=\"an" + flag + "\"><span class=\"ysp" + flag + "\">" + (pageindex + i) + "</span></a>";

        //if (i == 0) {
        //    html += "<a class='pages_href_selected' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        //} else {
        //    html += "<a class='pages_href_normal' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        //}
    }
    if (pageindex <= pagecount - 5) {
        html += "<span class=\"anniusp\">...</span>";
    }
    html += "<a class=\"anniu1 xiaan2 xyy1\" onclick=\"anchor(this),next_page()\">下一页</a>\
        <span class=\"anniusp2\">跳转到</span>\
        <input type=\"text\" class=\"tzsr\" id=\"page_size\" value=\"\">\
        <span class=\"an87\" id=\"data_go\" onclick=\"anchor(this),Go()\">G O</span>";
    $("#pages").html(html);
}

//
//页码被点击时
//
function A_Signs_selected(num) {
    pageindex = num;
    StartReading("data_list_td");
    GetList();
}

//
//Go按钮被点击时
//
function Go() {
    pageindex = Number($("#page_size").val());
    StartReading("data_list_td");
    GetList();
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
    keywords = GetQueryString("keywords");
    $("#keyword").html("<a class='condition_selected'>"+keywords+"</a>");
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetDataCount();
    GetList();
});