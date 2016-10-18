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
            var html = "<div class=\"xd5_div1 fl\"><img src=\"img/gongju.png\" class=\"xdtb5\"><a class=\"xd5a\"><b>年 份</b></a></div>";
            var temp;
            if (data != "]") {
                temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                   
                    if (i == 0) {
                        html += "<div class=\"xd5_hover xdh5 fl years_selected\" onclick=a_selected(this,\"years_selected\"),year_selected('" + temp[i].id + "','" + temp[i].name + "')>";
                        html += "<a id=year" + temp[i].id + ">" + temp[i].name + "</a>";
                        html += "</div>";
                    } else {
                        html += "<div class=\"xd5_hover xdh5 fl\" onclick=a_selected(this,\"years_selected\"),year_selected('" + temp[i].id + "','" + temp[i].name + "')>";
                        html += "<a id=year" + temp[i].id + ">" + temp[i].name + "</a>";
                        html += "</div>";
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
    //数据读取中
    $("#loading").html("数据读取中……");
    GetProvince();
}

//
//获取省份
//
function GetProvince() {
    $.post("../Past_Exam/GetProvince", { year: year }, function (data) {
        if (data) {
            var html = "<div class=\"xd5_div1 fl xd5k1 xd5_div1dk\"><img src=\"img/leixin.png\" class=\"xdtb5\" ><a  class=\"xd5a\"><b>地 区</b></a></div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div id=subject" + (i + 1) + " class=\"fl\" onclick=a_selected(this,\"dkhh5_selected\"),anchor_go('exam" + temp[i].id + "')>\
                                <a  class=\" xdh51 fl dkhh5\" style=\"margin-left:20px; margin-right:20px;\">" + temp[i].name + "</a>\
                                </div>";
                    //html += "<div id=subject" + (i + 1) + " class=\"xdh5 fl dkhh5\" onclick=a_selected(this,\"dkhh5_selected\"),anchor_go('exam" + temp[i].id + "')>\
                    //            <a  class=\"xdh55a\">" + temp[i].name + "</a>\
                    //            </div>";
                }
            }
            $("#province").html(html);
            //$("#subject1").click();
            
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
                    html += "<div class=\"gkzj101\"  id='exam" + temp[i].id + "'>\
                                <div class=\"gkzj21\">\
                                    <div class=\"lan44\">";
                    html += "<span class=\"zjshijian\"><b>" + year_text + "</b></span>";

                    html += "</div>\
                                <div class=\"bai630\">\
                                    <img src=\"img/wenjianltb.png\"  class=\"wenjianl\" />\
                                    <span class=\"qgjy\">\
                                        " + temp[i].name + "\
                                    </span>\
                                </div>\
                            </div>";
                    daohangid = temp[i].id;
                    html += "<div class=\"wdtb\">";
                    $.post("../Past_Exam/GetList", { daohangid: daohangid }, function (json) {
                        if (json) {

                            if (json != "]") {
                                var flag = eval(json);
                                for (var j = 0; j < flag.length; j++) {
                                    html += "<a  class=\"wrd1 fl\"><span class=\"wdsp\"><b class=\"wdb\">" + flag[j].subject + "</b></span><b class=\"wdjx\">";
                                    //if (j % 5 == 0 && j !=0)
                                    //    html += "<div class='list_content_text list_content_text_clear'><div class='list_content_text_top'>" + flag[j].subject + "</div><div class='list_content_text_bottom'>";
                                    //else
                                    //    html += "<div class='list_content_text'><div class='list_content_text_top'>" + flag[j].subject + "</div><div class='list_content_text_bottom'>";
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
                                    html += "</b></a>";
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
                $("#loading").html("");
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

