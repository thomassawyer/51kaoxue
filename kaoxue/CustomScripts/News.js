/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var type=""; //类型编号
var typename = ""; //类型名称
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
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
    $.post("../News/GetList", {pageindex: pageindex, type: type }, function (data) {
        if (data) {

            var html = "<div class=\"xwliebiao\">\
                            <div class=\"fl xwsc\">\
                                <img src=\"img/xwtpshucai.png\" />\
                            </div>\
                        <div class=\"fl cswx\">";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].title.length > 40 ? temp[i].title.substr(0, 40) : temp[i].title;
                    html += "<b class=\"xwlbzt\">" + text + "</b>\
                    <p class=\"xwwby\">"+ temp[i].content.substr(0,80);+"</p>";
                    html+="<img src=\"img/wenhao.png\" class=\"xwimg\" />\
                    <span class=\"xwgxsj\">\
                        更新时间	 <span>" + temp[i].pubdate + "</span>\
                    </span>\
                    <a class=\"xqhsankz\"  href='../News_Detail?id=" + temp[i].id + "'><img src=\"img/xqhsan.png\" /></a>";
                    
                    html += "</div>\
                        </div>";
                    if (i < (temp.length - 1)) {
                        html += "</div>\
                                </div>\
                                <div class=\"xwliebiao dkmgxz\">\
                                    <div class=\"fl xwsc\">\
                                        <img src=\"img/xwtpshucai.png\" />\
                                    </div>\
                                    <div class=\"fl cswx\">";
                    }
                    
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
    $.post("../News/GetDataCount", { pageindex: pageindex, type: type }, function (data) {
        if (data) {
            $("#all_data_count").html("该章节（" + data + "份）");

            if (Number(data) % 10 == 0) {
                pagecount = data / 10;
            } else {
                pagecount = Math.floor((data / 10)) + 1;
            }
            $.ajaxSetup({
                async: true
            });
        }
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
        <a class=\"an87\" id=\"data_go\" onclick=\"anchor(this),Go()\">G O</a>";
    $("#pages").html(html);
}
//
//解析类型名称
//
function Produce_TypeName(category) {
    var name = "";
    switch (category) {
        case "1":
            name = "试题";
            break;
        case "2":
            name = "课件";
            break;
        case "3":
            name = "教案";
            break;
        case "4":
            name = "学案";
            break;
        case "6":
            name = "同步";
            break;
        case "5":
            name = "素材";
            break;
        case "7":
            name = "论文";
            break;
        case "8":
            name = "套题";
            break;
        case "9":
            name = "备课";
            break;
        default:
            break;
    }
    return name;
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
//类型选项被点击时
//
function type_selected(num) {
    pageindex = 1;
    category = num;
    GetDataCount();
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

//
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#data_list_td").offset().top }, 500);
}

$(document).ready(function () {
    typename = GetQueryString("typename");
    type = GetQueryString("type");
    if (typename != "" && typename != undefined && typename != null) {
        $("#title_left").html(typename);
    }
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetDataCount();
    GetList();
});