/// <reference path="../Scripts/jquery-1.8.2.js" />

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
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 高考动态</span><a href='../News?type=1&typename=高考动态'><span class='directory_container_title_right'>More</span></a></div>";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title.length > 18 ? temp[i].title.substr(0, 18) + "..." : temp[i].title;
                if (i <= 2) {
                    html += "<a href='../News_Detail?id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left_red'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                } else {
                    html += "<a href='../News_Detail?id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                }

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
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 教材教法</span><a href='../News?type=6&typename=教材教法'><span class='directory_container_title_right'>More</span></a></div>";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title.length > 18 ? temp[i].title.substr(0, 18) + "..." : temp[i].title;
                if (i <= 2) {
                    html += "<a href='../News_Detail?id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left_red'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                } else {
                    html += "<a href='../News_Detail?id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                }
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
                    $("#data_date").html("上传时间:  " + temp[i].pubdate + "<br/><br/><br/>");
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