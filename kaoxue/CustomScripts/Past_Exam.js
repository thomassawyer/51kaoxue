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
function a_selected(obj, css) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css);
    });
    $(obj).addClass(css);
}

//
//获取年份
//
function GetYear() {
    $.post("../Past_Exam/GetYears", function (data) {
        if (data) {
            var html = "<div class=\"xd5_div1 fl\"><img src=\"img/gongju.png\" class=\"xdtb5\"><a target='_blank' target='_blank' class=\"xd5a\"><b>年 份</b></a></div>";
            var temp;
            if (data != "]") {
                temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    if (i == 0) {
                        html += "<div class=\"xd5_hover xdh5 fl years_selected\" onclick=a_selected(this,\"years_selected\"),year_selected('" + temp[i].id + "','" + temp[i].name + "')>";
                        html += "<a target='_blank' target='_blank' id=year" + temp[i].id + ">" + temp[i].name + "</a>";
                        html += "</div>";
                    } else {
                        html += "<div class=\"xd5_hover xdh5 fl\" onclick=a_selected(this,\"years_selected\"),year_selected('" + temp[i].id + "','" + temp[i].name + "')>";
                        html += "<a target='_blank' target='_blank' id=year" + temp[i].id + ">" + temp[i].name + "</a>";
                        html += "</div>";
                    }
                }
            }
            $("#years_columns").html(html);
            if (year_para != "" && year_para != null && year_para != undefined) {
                year_text = GetQueryString("year_text");
                $("#year" + year_para).click();
                year_para = "";
            } else {
                year_selected(temp[0].id, temp[0].name);
            }
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
    //数据读取中
    $("#loading").html("<div class=\"waiting_bg_1_2\"></div>");
    $("#list").html("");
    GetProvince();
}

//
//获取省份
//
function GetProvince() {
    $.post("../Past_Exam/GetProvince", { year: year }, function (data) {
        if (data) {
            var html = "<div class=\"xd5_div1 fl xd5k1 xd5_div1dk\"><img src=\"img/leixin.png\" class=\"xdtb5\" ><a target='_blank' target='_blank'  class=\"xd5a\"><b>地 区</b></a></div><div class=\"xd522 fl\">";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    var num = temp[i].name.indexOf("：");
                    var text = temp[i].name;
                    if (num != -1) {
                        text = text.substring(0,num);
                    }
                    html += "<div id=subject" + (i + 1) + " class=\"fl\" onclick=a_selected(this,\"dkhh5_selected\"),anchor_go('exam" + temp[i].id + "')>\
                                <a target='_blank' target='_blank' class=\" xdh51 fl dkhh5\" style=\"margin-left:20px; margin-right:20px;\">" + text + "</a>\
                                </div>";
                }
            }

            html += "</div>";

            $("#province").html(html);
            
            Loading_start();
            $.ajaxSetup({
                async: false
            });
            setTimeout(GetList, 10);
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
                    var num = temp[i].name.indexOf("：");
                    var text = temp[i].name;
                    var sub_title = "";

                    if (num != -1) {
                        sub_title = text.substring(num+1);
                        text = text.substring(0, num); 
                    }

                    html += "<div class=\"gkzj101\"  id='exam" + temp[i].id + "'>\
                                <div class=\"gkzj21\">";
                       
                    if (sub_title.length != 0) {
                        html += "<img src=\"img/wenjianltb.png\"  class=\"wenjianl fl\" />\
                                <div class=\"bai630 fl\">\
                                    <span class=\"qgjy fl\" style='line-height: 44px;'>\
                                        " + text + "\
                                    </span>\
                                    <span class=\"qgjy_1 fl\" style='line-height: 44px;padding-left: 18px;'>\
                                        " + "(" + sub_title + ")" + "\
                                    </span>\
                            </div>";
                            
                    } else {
                        html += "<img src=\"img/wenjianltb.png\"  class=\"wenjianl fl\" />\
                                <div class=\"bai630 fl\">\
                                    <span class=\"qgjy\" style='line-height: 44px;'>\
                                        " + text + "\
                                    </span>\
                            </div>";

                    }
                    

                    html += "<div class=\"box_sizing_box fl year_title_b\">" + year_text + "</div></div>";

                    daohangid = temp[i].id;
                    html += "<div class=\"wdtb\">";
                    $.post("../Past_Exam/GetList", { daohangid: daohangid }, function (json) {
                        if (json) {

                            if (json != "]") {
                                var flag = eval(json);
                                for (var j = 0; j < flag.length; j++) {
                                    if (j % 3 == 0) {
                                        html += "<div class=\"fl mar_top_16\"><div class=\"fl sub_title_a\">" + flag[j].subject + "</div><div class=\"fl box_sizing_box sub_type_all\">";
                                    } else {
                                        html += "<div class=\"fl mar_top_16 mar_lf_130\"><div class=\"fl sub_title_a\">" + flag[j].subject + "</div><div class=\"fl box_sizing_box sub_type_all\">";
                                    }

                                    $.post("../Past_Exam/GetList1", { daohangid: daohangid, subjectid: flag[j].subjectid }, function (list) {
                                        if (list) {
                                            if (list != "]") {
                                                var flag2 = eval(list);
                                                for (var k = 0; k < flag2.length; k++) {
                                                    html += "<a target='_blank' class=\"sub_type_per\" onclick=\"javascript:window.open('../Download?cid=1&id=" + flag2[k].testid + "');\" target='_blank'>" + GetTypeName(flag2[k].type) + "</a>";
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
                }
                $("#list").html(html);
                $.ajaxSetup({
                    async: true
                });
                $("#loading").html("");
            }

        }
    });
}

function GetTypeName(para) {
    var type = para;
    if (type == "1") type = "Word";
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
    $("#" + controlid).html("<div class=\"waiting_bg_1_2\"></div>");
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

    $("#Past_Exam_img").css({ 'display': 'block', 'right': '42px' });
    $("#nav_rec_2").html("高考真题");
});

