/// <reference path="../Scripts/jquery-1.8.2.js" />

//
//获取下载记录数据
//
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

function GetList() {
    $.post("../Member_Center/GetList", { pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                if (data == "0") {
                    location.href = "../Login?return_url=../Member_Center/Download_Record?controlid=lsxzjl";
                }
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].dltime);
                    date = date.getFullYear() + "-" + Number(date.getMonth() + 1) + "-" + date.getDate();
                    html += "<tr>\
                                <td>"+temp[i].filename+"</td>\
                                <td>"+date+"</td>\
                            </tr>";
                }
            }
            $("#data_table_td").html(html);
            Produce_A_Signs();
        }
    });
}

//
//上一页
//
function pre_page() {
    if (pageindex >= 2) {
        StartReading("data_table_td");
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
        StartReading("data_table_td");
        pageindex++;
        GetList();
    }
}

//
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#data_list").offset().top }, 500);
}

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}
//
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../Member_Center/GetDataCount", {  pageindex: pageindex }, function (data) {
        if (data) {

            if (Number(data) % 10 == 0) {
                pagecount = data / 10;
            } else {
                pagecount = Math.floor((data / 10)) + 1;
            }

            $("#resource_count").html(data);
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
//页码被点击时
//
function A_Signs_selected(num) {
    pageindex = num;
    StartReading("data_table_td");
    GetList();
}

//
//Go按钮被点击时
//
function Go() {
    pageindex = Number($("#page_size").val());
    StartReading("data_table_td");
    GetList();
}

//
//退出登录
//
function ClearSession() {
    $.post("../Member_Center/ClearSession", function (data) {
        if (data == "1") {
            location.href = "../Login?return_url=../Member_Center/Download_Record?controlid=lsxzjl";
        }
    });
}

$(document).ready(function () {
    GetDataCount();
    GetList();
});