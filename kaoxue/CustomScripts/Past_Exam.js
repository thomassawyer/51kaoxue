/// <reference path="../Scripts/jquery-1.8.2.js" />


var level; //学段
var level_num;
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
var year = ""; // 年级
var daohangid = "";
var year_text;
var year_para = GetQueryString("year");
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
//获取年份
//
function GetYear() {
    $.post("../Past_Exam/GetYears", function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    if (i == 0) {
                        html += "<a class=condition_selected id=year" + temp[i].id + " onclick=a_selected(this),year_selected('" + temp[i].id + "','" + temp[i].name + "')>" + temp[i].name + "</a>";
                    } else {
                        html += "<a id=year" + temp[i].id + " onclick=a_selected(this),year_selected('" + temp[i].id + "','" + temp[i].name + "')>" + temp[i].name + "</a>";
                    }
                }
            }
            $("#years").html(html);
            if (year_para != "" && year_para != null && year_para != undefined) {
                year_text = GetQueryString("year_text");
                $("#year" + year_para).click();
                year_para = "";
            } else {
                year_selected(temp[0].id, temp[0].name);
            }
            
            //$("#subject1").click();
        }
    });
}

function Loading_start() {
    $("#message_start").click();

}


function Loading_end() {
    $("#message_close").click();
}


//
//点击年级A标签,为年级变量赋值
//
function year_selected(num, text) {
    year = num;
    year_text = text;
    GetProvince();
}

//
//获取省份
//
function GetProvince() {
    $.post("../Past_Exam/GetProvince", { year: year }, function (data) {
        if (data) {
            var html = "<a class='condition_selected' onclick='a_selected(this),district_selected(0)'>全部</a>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {

                    html += "<a id=subject" + (i + 1) + " onclick=a_selected(this),anchor_go('exam" + temp[i].id + "')>" + temp[i].name + "</a>";

                }
            }
            $("#province").html(html);
            //$("#subject1").click();
            Loading_start();
            $.ajaxSetup({
                async: false
            });
            setTimeout(GetList, 1000);
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
//数据列表锚点
//
function anchor_go(obj) {
    $("html,body").animate({ scrollTop: $("#" + obj).offset().top }, 500);
}

//
//获取试题数据
//
var daohangid;
function GetList() {

    $("#list").html("");
    $.post("../Past_Exam/GetProvince", { year: year }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    //html = "";
                    html += "<div class='list_content_container' id='exam" + temp[i].id + "'><div class='list_title'><span class='list_title_left'>" + temp[i].name + "</span><span class='list_title_right'>" + year_text + "年</span></div><div class='list_content'>";
                    daohangid = temp[i].id;
                    $.post("../Past_Exam/GetList", { daohangid: daohangid }, function (json) {
                        if (json) {

                            if (json != "]") {
                                var flag = eval(json);
                                for (var j = 0; j < flag.length; j++) {
                                    if (j % 5 == 0 && j !=0)
                                        html += "<div class='list_content_text list_content_text_clear'><div class='list_content_text_top'>" + flag[j].subject + "</div><div class='list_content_text_bottom'>";
                                    else
                                        html += "<div class='list_content_text'><div class='list_content_text_top'>" + flag[j].subject + "</div><div class='list_content_text_bottom'>";
                                    $.post("../Past_Exam/GetList1", { daohangid: daohangid, subjectid: flag[j].subjectid }, function (list) {
                                        if (list) {

                                            if (list != "]") {
                                                var flag2 = eval(list);
                                                for (var k = 0; k < flag2.length; k++) {
                                                    html += "<span>" + GetTypeName(flag2[k].type) + "</span>";
                                                }
                                            }
                                        }
                                    });
                                    html += "</div></div>";
                                }
                            }
                        }
                    });
                    html += "</div></div>";
                    //$("#list").html($("#list").html() + html);
                }
                $("#list").html(html);
                $.ajaxSetup({
                    async: true
                });
                Loading_end();
            }

        }
    });
}

function GetTypeName(para) {
    var type = para;
    if (type == "1") type = "WORD";
    if (type == "2") type = "解析";
    if (type == "3") type = "答案";
    if (type == "4") type = "作文";
    if (type == "5") type = "听力";
    return type;
}

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

$(document).ready(function () {
    year_para = GetQueryString("year");
    GetYear();
});

