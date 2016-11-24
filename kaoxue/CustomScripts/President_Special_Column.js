/// <reference path="../Scripts/jquery-1.8.2.js" />



//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
var id=0;
//
//获取校长信息
//
function GetPresidentInfo() {
    $.post("../President_Special_Column/GetPresidentInfo", { id: id }, function (data) {
        if (data) {
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    //校长头像
                    $("#president_headimg").attr("src", "http://source.51kaoxue.com/" + temp[i].headimgsrc);
                    //校长简介
                    $("#president_introduce").html(temp[i].memo);
                    $("#presidentName").html(temp[i].headname);
                    $("#schooleName").html(temp[i].name);
                }
                
            }
        }
    });
}


//
//校长专栏
//
function President_Special_Columns() {
    $.post("../President_Special_Column/President_Special_Columns", function (data) {
        if (data) {
            if (data != "]") {
                var temp = eval(data);
                var html = "";
                for (var i = 0; i < temp.length; i++) {
                    //html += "<div class=\"middle_content_bottom_left_cotent_column\" onclick=\"GetNewsDetail("+temp[i].id+")\">\
                    //            "+temp[i].title+"\
                    //        </div>";
                    var text = temp[i].title;
                    html += "<li class=\"overf_com\" style=\"width:180px;\"><a target='_blank' onclick=\"GetNewsDetail(" + temp[i].id + ")\">● " + text + "</a></li>";
                }
                $("#president_special_columns").html(html);
                GetNewsDetail(temp[0].id);
            }
        }
    });
}


//
//获取新闻详细内容
//
function GetNewsDetail(id) {
    $("#news_title").html("");
    StartReading("news_content");
    $.post("../President_Special_Column/GetNewsDetail",{id:id}, function (data) {
        if (data) {
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    //新闻标题
                    $("#news_title").html(temp[i].title);
                    //新闻内容
                    $("#news_content").html(temp[i].content);
                    $("#news_time").html(temp[i].pubdate);
                }
            }
        }
    });
}

$(document).ready(function (data) {
    id = GetQueryString("id");
    GetPresidentInfo();
    President_Special_Columns();
});

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html("<div class=\"waiting_bg_1\"></div>");
}