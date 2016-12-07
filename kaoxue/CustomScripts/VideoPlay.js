/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function GetUserInfo() {
    $.post("../Home/GetUserInfo", function (data) {
        if (data != "0") {
            var temp = eval(data);
            
        } 
    })
}

var videoname;
//
//获取视频信息
//
function GetInformation() {
    $.post("../VideoPlay/GetInformation",{id:id}, function (data) {
        if (data != "]") {
            var temp = eval(data);
            var m = temp[0];
            $("#title1").html(m.title);
            $("#title2").html(m.title);
            $("#title3").html(m.title);
            $("#teacher").html("课程主讲：" + m.teacherName);
            var date = new Date(m.updateTime);
            var time = date.getFullYear().toString() + "-" + ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
            $("#updateTime").html("课程日期：" + time);
            $("#videoTime").html("视频时长：" + m.videoTime);
            $("#classCount").html("视频课时：" + m.classCount);
            $("#viewingTimes").html("观看人数：" + m.viewingTimes);
            $("#introduce").html(m.introduce);
            chapterid = m.chapterId;
            videoname = m.title;
            Add_ViewCounts();
            add_record();
            Watching_Record();
            Video_List();
            Related_Videos();
        } 
    })
}

//
//增加该视频的观看次数
//
function Add_ViewCounts() {
    $.post("../VideoPlay/Add_ViewCounts", { id: id }, function (data) {
        
    })
}

//
//增加观看记录
//
function add_record() {
    $.post("../VideoPlay/Add_Record", { id: id ,videoname:videoname}, function (data) {

    })
}

//
//视频观看记录
//
function Watching_Record() {
    $.post("../VideoPlay/Watching_Record", function (data) {
        if (data != "0") {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<li class=\"mar_bott_7\">\
                                <span class=\"ic ic_video fl\"></span>\
                                <div class=\"li_content overf_com fl\">\
                                    <a href='../VideoPlay?id=" + temp[i].videoId + "' title=\"" + temp[i].videoName + "\">" + temp[i].videoName + "</a>\
                                </div>\
                            </li>";
            }
            $("#Watching_Record").html(html);
        }
    })
}

//
//视频排行榜
//
function Video_List() {
    $.post("../VideoPlay/Video_List", function (data) {
        if (data != "0") {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<li class=\"mar_bott_7\">\
                                <span class=\"ic ic_view_rec fl\"></span>\
                                <div class=\"li_content overf_com fl li_content_video_ranking\">\
                                    <a  href='../VideoPlay?id=" + temp[i].id + "' title=\"" + temp[i].title + "\">" + temp[i].title + "</a>\
                                </div>\
                        </li>";
            }
            $("#Video_List").html(html);
        }
    })
}

//
//相关推荐
//
function Related_Videos() {
    $.post("../VideoPlay/Related_Videos", { chapterid: chapterid }, function (data) {
        if (data != "0") {
            var temp = eval(data);
            var html = "<div class=\"item_row\">";
            for (var i = 0; i < temp.length; i++) {
                var url = temp[i].videoImageUrl == "" ? "../img/232-152.png" : temp[i].videoImageUrl;
                html += "<div class=\"item fl mar_lf_10\">\
                                    <div class=\"item_hover\"></div>\
                                    <img src=\""+url+"\" class=\"item_img\">\
                                    <div class=\"i_video_f\">已播放" + temp[i].viewingTimes + "次</div>\
                                    <div class=\"item_title\">\
                                        <div class=\"item_title_name\">\
                                            <p class=\"item_title_name_o\">" + temp[i].title + "</p>\
                                            <p class=\"item_title_name_s\">主讲老师：" + temp[i].teacherName + "</p>\
                                        </div>\
                                    </div>\
                                </div>";
                if (i % 3 == 0 && i != 0) {
                    html += "</div>\
                            <div class=\"mar_top_16 item_row\">";
                }
            }
            html += "</div>";
            $("#Related_Videos").html(html);
        }
    })
}
var id;
var chapterid;
$(document).ready(function () {
    id = GetQueryString("id");
    GetInformation();
});
