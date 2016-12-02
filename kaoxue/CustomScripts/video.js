/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

//点击span时，改变span样式
function change_css_span(obj, css_class) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css_class);
    });
    $(obj).addClass(css_class);
}

//
//课堂讲学
//
function Classroom_Teaching(subjectId) {
    $.post("../Video/Classroom_Teaching",{subjectId:subjectId}, function (data) {
        if (data != "]") {
            var temp = eval(data);
            var html = "";
            var date;

            html += "<ul class=\"mar_lf_30 ma20 overf_hid\">";

            for (var i = 0; i < temp.length; i++) {
                var url = temp[i].videoImageUrl == "" ? "../img/232-152.png" : temp[i].videoImageUrl;
                html += "<li class=\"fl mar_rg_17\">\
                                <div class=\"item\" onclick=\"javascript:window.open('../VideoPlay')\">\
                                    <div class=\"item_hover\"></div>\
                                    <div class=\"item_title\">\
                                        <img src=\"" + url + "\" class=\"item_title_img\">\
                                        <div class=\"video_f\">已播放" + temp[i].viewingTimes + "次</div>\
                                    </div>\
                                    <div class=\"item_name\">\
                                        <p class=\"item_o_title\">" + temp[i].ChapterName + "</p>\
                                        <p class=\"item_s_title\">"+ temp[i].title + "</p>\
                                    </div>\
                                </div>\
                            </li>";
                if (i % 3 == 0 && i != 0) {
                    html += "</ul>\
                            <ul class=\"mar_lf_30 ma20 overf_hid\">";
                }
            }
            html += "</ul>";
            $("#Classroom_Teaching").html(html);
        } else {
            $("#Classroom_Teaching").html("<img src=\"../img/no_data_bg2.png\" style='margin-left:226px;margin-top:175px;'>");
        }
    });
}

//
//心理解压
//
function Psychological_decompression() {
    $.post("../Video/Psychological_decompression",  function (data) {
        if (data != "]") {
            var temp = eval(data);
            var html = "";
            var date;

            html += "<ul class=\"mar_lf_30 ma20 overf_hid\">";

            for (var i = 0; i < temp.length; i++) {
                var url = temp[i].videoImageUrl == "" ? "../img/354-181.png" : temp[i].videoImageUrl;
                html += "<li class=\"fl mar_rg_17 slide\">\
                                <div class=\"p_item\">\
                                    <div class=\"p_item_hover\"></div>\
                                    <div class=\"p_item_name\">\
                                        <p class=\"p_item_o_title\">" + temp[i].ChapterName + "</p>\
                                        <p class=\"p_item_s_title\">" + temp[i].title + "</p>\
                                    </div>\
                                    <div class=\"p_item_title\">\
                                        <img src=\"" + url + "\" class=\"p_item_title_img\">\
                                        <div class=\"p_video_f\">已播放" + temp[i].viewingTimes + "次</div>\
                                    </div>\
                                </div>\
                            </li>";
            }
            $("#Psychological_decompression").html(html);
        } else {
            $("#Psychological_decompression").html("<img src=\"../img/no_data_bg2.png\" style='margin-left:188px;'>");
        }
    });
}

//
//试题解析
//
function Test_Questions_Analysis(subjectId) {
    $.post("../Video/Test_Questions_Analysis", { subjectId: subjectId }, function (data) {
        if (data != "]") {
            var temp = eval(data);
            var html = "";
            var date;

            html += "<ul class=\"mar_lf_30 mar_top_27 overf_hid\">";

            for (var i = 0; i < temp.length; i++) {
                var url = temp[i].videoImageUrl == "" ? "../img/232-177.png" : temp[i].videoImageUrl;
                html += "<li class=\"fl mar_rg_17\">\
                                <div class=\"t_item\">\
                                    <div class=\"t_item_hover\"></div>\
                                    <div class=\"t_item_title\">\
                                        <div class=\"t_video_f\">已播放" + temp[i].viewingTimes + "次</div>\
                                        <img src=\""+ url + "\" class=\"item_title_img\">\
                                    </div>\
                                    <div class=\"t_item_name\">\
                                        <p class=\"t_item_o_title\">" + temp[i].ChapterName + "</p>\
                                        <p class=\"t_item_s_title\">" + temp[i].title + "</p>\
                                    </div>\
                                </div>\
                            </li>";
                if (i % 3 == 0 && i != 0) {
                    html += "</ul>\
                            <ul class=\"mar_lf_30 mar_top_27 overf_hid\">";
                }
            }
            html += "</ul>";
            $("#Test_Questions_Analysis").html(html);
        } else {
            $("#Test_Questions_Analysis").html("<img src=\"../img/no_data_bg2.png\"  style='margin-left:226px;margin-top:175px;'>");
        }
    });
}

//
//高考研讨会
//
function Seminar(subjectId) {
    $.post("../Video/Seminar", { subjectId: subjectId }, function (data) {
        if (data != "]") {
            var temp = eval(data);
            var html = "";
            var date;

            html += "<ul class=\"mar_lf_30 ma20 overf_hid\">";

            for (var i = 0; i < temp.length; i++) {
                var url = temp[i].videoImageUrl == "" ? "../img/232-152.png" : temp[i].videoImageUrl;
                html += "<li class=\"fl mar_rg_17\">\
                        <div class=\"item\">\
                            <div class=\"item_hover u_item_hover\"></div>\
                            <div class=\"item_title\">\
                                <img src=\"../img/u_item_title_img.png\" class=\"item_title_img\">\
                                <div class=\"video_f\">已播放" + temp[i].viewingTimes + "次</div>\
                            </div>\
                            <div class=\"item_name\">\
                                <p class=\"item_o_title\">" + temp[i].title + "</p>\
                                <p class=\"item_s_title u_item_s_title\">研讨会邀请函</p>\
                            </div>\
                        </div>\
                    </li>";
                if (i % 3 == 0 && i != 0) {
                    html += "</ul>\
                            <ul class=\"mar_lf_30 ma20 overf_hid\">";
                }
            }
            html += "</ul>";
            $("#Seminar").html(html);
        } else {
            $("#Seminar").html("<img src=\"../img/no_data_bg2.png\"  style='margin-left:226px;margin-top:175px;'>");
        }
    });
}

//
//高考备战
//
function Exam_Prepare() {
    $.post("../Video/Exam_Prepare", function (data) {
        if (data != "]") {
            var temp = eval(data);
            var html = "";
            var date;

            html += "<ul class=\"mar_lf_30 ma20 overf_hid\">";

            for (var i = 0; i < temp.length; i++) {
                var url = temp[i].videoImageUrl == "" ? "../img/354-181.png" : temp[i].videoImageUrl;
                html += "<li class=\"fl mar_rg_17 slide\">\
                                <div class=\"p_item\">\
                                    <div class=\"p_item_hover e_item_hover\"></div>\
                                    <div class=\"p_item_name\">\
                                        <p class=\"p_item_o_title e_item_o_title\">" + temp[i].ChapterName + "</p>\
                                        <p class=\"p_item_s_title\">" + temp[i].title + "</p>\
                                    </div>\
                                    <div class=\"p_item_title\">\
                                        <img src=\"../img/e_item_title_img.png\" class=\"p_item_title_img\">\
                                        <div class=\"p_video_f\">已播放" + temp[i].viewingTimes + "次</div>\
                                    </div>\
                                </div>\
                            </li>";
            }
            $("#Exam_Prepare").html(html);
        } else {
            $("#Exam_Prepare").html("<img src=\"../img/no_data_bg2.png\" style='margin-left:188px;'>");
        }
    });
}
$(document).ready(function () {
    Classroom_Teaching(19);
    Psychological_decompression();
    Test_Questions_Analysis(19);
    Seminar(19);
    Exam_Prepare();
});