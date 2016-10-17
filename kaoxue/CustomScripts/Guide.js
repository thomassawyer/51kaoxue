
/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var subjectname="";
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
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
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#content_container").offset().top }, 500);
}

//
//获取试题数据
//
function GetList() {
    $.post("../Guide/GetList", { subject: subjectname, pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                var time="";
                for (var i = 1; i <= temp.length; i++) {
                    if (temp[i-1].updatetime != null && temp[i-1].updatetime != undefined && temp[i-1].updatetime != "") {
                        date = new Date(temp[i - 1].updatetime);
                        time = date.getFullYear() + "-" + date.getMonth() + "-" + date.getDate();
                    }
                    var text = temp[i - 1].name.length > 40 ? temp[i - 1].name.substr(0, 40) : temp[i - 1].name;
                    if (i % 4 == 0) {
                        html += "<div class='content_container_child'><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top' style='background-color: #58acc7;'><div class='content_container_child_top_text'>" + temp[i - 1].name + "</div></a><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top_text2'>" + temp[i - 1].name + "</div></a><div class='content_container_child_top_text3'><span class='content_container_child_top_text3_left'>" + time + "</span><span class='content_container_child_top_text3_right'></span></div></div></div>";
                    } else if (i % 3 == 0) {
                        html += "<div class='content_container_child'><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top' style='background-color: #5deeb9;'><div class='content_container_child_top_text'>" + temp[i - 1].name + "</div></a><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top_text2'>" + temp[i - 1].name + "</div></a><div class='content_container_child_top_text3'><span class='content_container_child_top_text3_left'>" + time + "</span><span class='content_container_child_top_text3_right'></span></div></div></div>";
                    } else if (i % 2 == 0) {
                        html += "<div class='content_container_child'><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top' style='background-color: #e2a54e;'><div class='content_container_child_top_text'>" + temp[i - 1].name + "</div></a><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top_text2'>" + temp[i - 1].name + "</div></a><div class='content_container_child_top_text3'><span class='content_container_child_top_text3_left'>" + time + "</span><span class='content_container_child_top_text3_right'></span></div></div></div>";
                    } else {
                        html += "<div class='content_container_child'><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top' style='background-color: #ea4343;'><div class='content_container_child_top_text'>" + temp[i - 1].name + "</div></a><a href='../SpecialSubject?id=" + temp[i - 1].id + "&name=" + temp[i - 1].name + "'><div class='content_container_child_top_text2'>" + temp[i - 1].name + "</div></a><div class='content_container_child_top_text3'><span class='content_container_child_top_text3_left'>" + time + "</span><span class='content_container_child_top_text3_right'></span></div></div></div>";
                    }
                    
                }
            }
            $("#content_container").html(html);
            Produce_A_Signs();
        }
    });
}


//
//上一页
//
function pre_page() {
    if (pageindex >= 2) {
        StartReading("content_container");
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
        StartReading("content_container");
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
    $.post("../Guide/GetDataCount", { subject: subjectname, pageindex: pageindex }, function (data) {
        if (data) {
            $("#all_data_count").html("该章节（" + data + "份）");

            if (Number(data) % 20 == 0) {
                pagecount = data / 20;
            } else {
                pagecount = Math.floor((data / 20)) + 1;
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
    var html = "";
    var signs_length;
    if (pageindex >= pagecount - 3) {
        signs_length = (pagecount - pageindex) + 1;
    } else {
        signs_length = 5;
    }
    if (pageindex >= 2) {
        html += "<span>…</span>";
    }
    for (var i = 0; i < signs_length; i++) {
        if (i == 0) {
            html += "<a class='pages_href_selected' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        } else {
            html += "<a class='pages_href_normal' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        }
    }
    if (pageindex <= pagecount - 5) {
        html += "<span>…</span>";
    }
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
    StartReading("content_container");
    GetList();
}

//
//Go按钮被点击时
//
function Go() {
    pageindex = Number($("#page_size").val());
    StartReading("content_container");
    GetList();
}


//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}

//点击span时，改变span样式
function change_css_span(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("nav_normal_select");
        $(this).addClass("nav_normal");
    });
    $(obj).removeClass("nav_normal");
    $(obj).addClass("nav_normal_select");
}

function changesubject(obj, subject) {
    pageindex = 1;
    subjectname = subject;
    change_css_span(obj);
    GetDataCount();
    GetList();
}

$(document).ready(function () {
    GetDataCount();
    GetList();
});