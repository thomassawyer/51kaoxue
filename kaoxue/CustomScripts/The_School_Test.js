/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
var id;
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

function GetList() {
    $.post("../The_School_Test/GetList", { id: id,pageindex:pageindex }, function (data) {
        if (data) {
            if (data != "]") {
                var temp = eval(data);
                var html = "";
                
                for (var i = 0; i < temp.length; i++) {
                    var date = new Date(temp[i].uploadtime);
                    date = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    html += "<a target='_blank' href='../Download?id="+temp[i].id+"&cid=1'><div class=\"school_tests_container\">\
                                    <div class=\"school_tests_container_left\">"+temp[i].testname+"</div>\
                                    <div class=\"school_tests_container_right\">"+date+"</div>\
                                </div></a>";
                }
                $("#school_testss").html(html);
                Produce_A_Signs();
            }
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
    $.post("../The_School_Test/GetDataCount", {  pageindex: pageindex, id:id }, function (data) {
        if (data) {
            if (Number(data) % 17 == 0) {
                pagecount = data / 17;
            } else {
                pagecount = Math.floor((data / 17)) + 1;
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
            html += "<a target='_blank' class='pages_href_selected' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        } else {
            html += "<a target='_blank' class='pages_href_normal' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        }
    }
    if (pageindex <= pagecount - 5) {
        html += "<span>…</span>";
    }
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
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#school_testss").offset().top }, 500);
}

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}

$(document).ready(function () {
    id = GetQueryString("id");
    GetDataCount();
    GetList();
});