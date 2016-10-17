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
    $.post("../Gaokao_Beikao/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 热门下载</span><a href='../Test_Center?type=1&level=3'><span class='directory_container_title_right'>More</span></a></div>";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 18 ? temp[i].testname.substr(0, 18) + "..." : temp[i].testname;
                if (i <= 2) {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left_red'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                } else {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                }

            }
            $("#hot_download").html(html);
        }
    });
}

//
//相关推荐
//
function GetTest_Recommend() {
    $.post("../Gaokao_Beikao/GetTest_Recommend", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 相关推荐</span><a href='../Test_Center?type=1&level=3'><span class='directory_container_title_right'>More</span></a></div>";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 18 ? temp[i].testname.substr(0, 18) + "..." : temp[i].testname;
                if (i <= 2) {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left_red'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                } else {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                }
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
        $("html,body").animate({ scrollTop: $("#data_list").offset().top }, 500);
}

//
//获取试题数据
//
function GetList() {
    $.post("../Search/GetList", {pageindex: pageindex, keywords:keywords }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    html += "<a href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "'><div class='data_list_td_container'><div class='data_list_td_container_left'><img src='../Images/%e5%a4%87%e8%af%be%e4%b8%ad%e5%bf%83/%e6%96%87%e6%a1%a3.png' /></div><div class='data_list_td_container_middle' style=' width:500px;'><div><span id='text_title'>" + text + "</span></div><div><span class='text_description'><span><span id='download_point'></span></span> <span id='text_date'>" + temp[i].uploadtime + "</span> <span><span id='text_type'></span></span></span></div></div><div class='data_list_td_container_right'><a  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "' class='download_button download_button1'>下载</a></div></div>";
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