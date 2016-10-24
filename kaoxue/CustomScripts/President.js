/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var level; //学段
var level_num;
var subject; //学科
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
var category = ""; //类型名称
var testcategory = ""; //试题类型
var grade = ""; // 年级
var district = ""; //地区
var para_subjectid;// 参数-学科
var para_type; //类型
var para_testcategory; // 试题类型
var para_testcategory_control = false;
var para_control = false; // 带参加载,控制变量
var para_type_control = false;
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
    subject = ""; //学科
    category = ""; //类型名称
    testcategory = ""; //试题类型
    grade = ""; // 年级
    district = ""; //地区

    GetSubject();
    GetDataCount();
    StartReading("data_list_td");
    GetList();
    if (para_subjectid != undefined && para_subjectid != null && para_control == true) {
        setTimeout(function () {
            $("#subject" + para_subjectid).click();
            para_control = false;
        }, 1000);
    }
    if (para_type != undefined && para_type != null && para_type_control == true) {
        setTimeout(function () {
            $("#type" + para_type).click();
            para_type_control = false;
        }, 1000);
    }




}

//
//获取学科
//
function GetSubject() {
    $.post("../Test_Center/GetSubject", { level: level_num }, function (data) {
        if (data) {
            var html = "<div class=\"xd5_hover  fl xdh33_selected\" onclick=' a_selected(this, \"xdh33_selected\"), subject_selected(0)'>\
                        <a>全部</a>\
                    </div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div id=subject" + temp[i].id + " class=\"xd5_hover fl\" onclick=' a_selected(this, \"xdh33_selected\"), subject_selected(" + temp[i].id + ")'>\
                        <a>"+ temp[i].name + "</a>\
                    </div>";
                }
            }
            $("#subject").html(html);
        }
    });
}

//
//点击学科A标签,为学科变量赋值
//
function subject_selected(subjectid) {
    pageindex = 1;
    subject = subjectid;

    GetDataCount();
    StartReading("data_list_td");
    GetList();
}

//
//热门下载
//
function GetTest_Hot_Download() {
    $.post("../Elite_School/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp\">●</span>&nbsp;<a  class=\"rmxzaa\">" + text + "</a></li>";
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
            var html = "";
            for (var i = 0; i < 11; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
            }
            $("#recommend").html(html);
        }
    });
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
//点击地区A标签,为地区变量赋值
//
function district_selected(num) {
    pageindex = 1;
    district = num;

    GetDataCount();
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

//
//获取试题数据
//
//
//获取学校数据
//
function GetList() {
    $.post("../President/GetList", { level: level_num, district: district, pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                html += "<div class=\"lxclan\">\
                <img src=\"img/renwu.png\" alt=\"\" class=\"rwimg\" />\
                <b class=\"bix dkbix\">校长列表</b>\
            </div>";
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].intime);
                    var time = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    html += "<div class=\"xz360\" style=\"width:100%;overflow:auto;\">\
                <div class=\"fl\"><img src=\""+ temp[i].headimgsrc + "\" class=\"lsimg\" style=\"min-width:200px;\" /></div>\
                <div class=\"fl neirong620\">\
                    <b class=\"fz25\">" + temp[i].headname + "</b>\
                    <span id=\"\" class=\"lssp\">\
                       " + temp[i].memo + "\
                    </span>\
                    <span class=\"lsmssp\">\
                        "+ temp[i].content + "\
                    </span>\
                    <span class=\"gxsjsp\">更新时间：<span>" + time + "</span>   |   类型：" + produce_type(temp[i].level) + "   |   学校校长：代用名   |   地区："+temp[i].areaname+"</span>\
                    <a href=\"\" class=\"xzhsan\"><img src=\"img/xqhsan.png\" alt=\"\" /></a>\
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
    $.post("../Elite_School/GetDataCount", { subject: subject, level: level_num, testcategory: testcategory, grade: grade, district: district, pageindex: pageindex, category: category }, function (data) {
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
function produce_type(text) {
    var str = "";
    switch (text) {
        case 1:
            str = "小学";
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

$(document).ready(function () {
    para_control = true;
    para_type_control = true;
    para_testcategory_control = true;
    para_subjectid = GetQueryString("subjectid");
    para_type = GetQueryString("type");
    para_testcategory = GetQueryString("testcategory");
    var para_level = GetQueryString("level");
    if (para_level != undefined && para_level != null) {
        $("#level" + para_level).click();
    } else {
        level_selected(3);
    }
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetArea();
    eliteschool_recommend();
    test_recommend();
});

function message(text) {
    $("#message_content").html("系统提示: " + text);
    $("#message_download").click();
}

//
//预览点击事件
//
function preview_show(url) {
    $("#download_preview").attr("src", url);
    $("#message_preview").click();
}