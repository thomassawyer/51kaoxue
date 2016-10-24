/// <reference path="../Scripts/jquery-1.8.2.js" />

var level; //学段
var level_num;
var district = ""; //地区




//
//点击学段A标签时,为学段变量赋值
//
function level_selected(num) {
    switch (num) {
        case 1:
            level = " between 1 and 6";
            level_num = 1;
            break;
        case 2:
            level = " between 7 and 9";
            level_num = 2;
            break;
        case 3:
            level = " between 10 and 12";
            level_num = 3;
            break;
        default:
            break;
    }
    pageindex = 1;
    district = ""; //地区
    GetDataCount();
    StartReading("data_list");
    GetList();
}
//
//获取地区
//
function GetArea() {
    $.post("../Test_Center/GetArea", function (data) {
        if (data) {
            var html = "<div class=\"xd5_hover fl district_selected\" onclick='a_selected(this, \"district_selected\"), district_selected(0)'>\
                        <a>全部</a>\
                    </div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {

                    html += "<div id=area" + (i + 1) + " class=\"xd5_hover fl \" onclick='a_selected(this, \"district_selected\"), district_selected(" + temp[i].id + ")'>\
                        <a>" + temp[i].areaname + "</a>\
                    </div>";
                }
            }
            $("#district").html(html);
            //$("#subject1").click();
        }
    });
}

//
//点击地区A标签,为地区变量赋值
//
function district_selected(num) {
    pageindex = 1;
    district = num;

    GetDataCount();
    StartReading("data_list");
    GetList();
}

//
//点击学科A标签,为学科变量赋值
//
function subject_selected(subjectid) {
    pageindex = 1;
    subject = subjectid;

    GetDataCount();
    StartReading("data_list");
    GetList();
}

//
//名校推荐
//

function eliteschool_recommend() {
    $.post("../President/EliteSchool_Recommend", function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].name.length > 10 ? temp[i].name.substr(0, 10) + "..." : temp[i].name;
                    //html += "<a href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'><div class=\"elite_school_recommends_container\"><div class=\"elite_school_recommends_container_top\"><span class=\"sign_red\">·</span><div class=\"school_name\">" + text + "</div></div><div class=\"elite_school_recommends_container_bottom\">共计" + temp[i].testnum + "套题</div></div></a>";
                    html += "<li><a href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>●" + text + "<br />共计" + temp[i].testnum + "套题</a></li>";
                }
            }
            $("#elite_school_recommends").html(html);
        }
    });
}


//
//试题推荐
//

function test_recommend() {
    $.post("../President/Test_Recommend", function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                    //html += "<div class=\"elite_school_recommends_container_top\">\
                    //                    <span class=\"sign_red\">·</span>\
                    //                    <div class=\"school_name\"><a href=\"../Download?cid=1&id="+ temp[i].id + "\" target=\"_blank\">" + text + "</a></div>\
                    //                </div>";
                    html += "<li><a href=\"../Download?cid=1&id=" + temp[i].id + "\" target=\"_blank\">●" + text + "</a></li>";
                }
            }
            $("#test_recommend").html(html);
        }
    });
}

//
//点击A标签时,改变A标签背景
//
function a_selected(obj, css) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css);
    });
    $(obj).addClass(css);
}

//
//获取学校数据
//
function GetList() {
    $.post("../School/GetList", { level: level_num, district: district, pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                html += "<div class=\"lxclan\">\
                <img src=\"img/renwu.png\" alt=\"\" class=\"rwimg\" />\
                <b class=\"bix dkbix\">学校列表</b>\
            </div>";
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].intime);
                    var time = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    html += "<div class=\"xz360\" style=\"width:100%;\">\
                <div class=\"fl\"><img src=\"http://source.51kaoxue.com/"+ temp[i].imgsrc + "\" class=\"lsimg\" style=\"width:270px;height:200px;\" /></div>\
                <div class=\"fl neirong620\">\
                    <b class=\"fz25\">" + temp[i].name + "</b>\
                    <div id=\"\" class=\"lssp\" style='display:block;height:51px;overflow-y:auto;overflow-x:hidden;'>\
                       " + temp[i].content + "\
                    </div>\
                    <span class=\"gxsjsp\">更新时间：<span>" + time + "</span>   |   类型：" + produce_type(temp[i].level) + "   |   学校校长：" + temp[i].headname + "   |   地区：" + temp[i].areaname + "</span>\
                    <a href=\"../SchoolDetail?id=" + temp[i].id + "&areaid="+temp[i].areaid+"\" class=\"xzhsan\"><img src=\"img/xqhsan.png\" alt=\"\" /></a>\
                </div>\
            </div>\
                    ";
                }
            }
            $("#data_list").html(html);
            Produce_A_Signs();
        }
    });
}
var pagecount = 0;
var pageindex = 0;

function produce_type(text) {
    var str = "";
    switch (text) {
        case 1:
            str= "小学";
            break;
        case 2:
            str = "初中";
            break;
        case 3:
            str = "高中";
            break;
        default:
            str = "";
            break;
    }
    return str;
}
//
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../School/GetDataCount", { level: level_num, district: district, pageindex: pageindex }, function (data) {
        if (data) {

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
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
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
        $("html,body").animate({ scrollTop: $("#data_list").offset().top }, 500);
}


$(document).ready(function () {
    level_selected(3);
    GetArea();
    eliteschool_recommend();
    test_recommend();
});