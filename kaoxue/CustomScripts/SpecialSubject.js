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
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 热门下载</span><a href='../Test_Center?level=3&type=1'><span class='directory_container_title_right'>More</span></a></div>";
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
    $.post("../Elite_School/GetTest_Recommend", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 相关推荐</span><a href='../Test_Center?level=3&type=1'><span class='directory_container_title_right'>More</span></a></div>";
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
                    html += "<a href='../Download?id=" + temp[i].id + "&cid=" + temp[i].category + "'><div class='data_list_td_container'><div class='data_list_td_container_left'><img src='../Images/%e5%a4%87%e8%af%be%e4%b8%ad%e5%bf%83/%e6%96%87%e6%a1%a3.png' /></div><div class='data_list_td_container_middle' style=' width:500px;'><div><span id='text_title'>" + text + "</span></div><div><span class='text_description'><span><span id='download_point'></span></span> <span id='text_date'>" + temp[i].uploadtime + "</span> <span><span id='text_type'></span></span></span></div></div><div class='data_list_td_container_right'><a  href='../Download?id=" + temp[i].id + "&cid=" + temp[i].category + "' class='download_button download_button1'>下载</a></div></div>";
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