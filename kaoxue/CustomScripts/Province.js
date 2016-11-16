/// <reference path="../Scripts/jquery-1.8.2.js" />


//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var area;
var text;
//
//本省名校试题
//
function test_mingxiao(level) {
    $.post("../Province/Test_Mingxiao", { area: area,level:level }, function (data) {
        if (data) {
            var html = "<div class=\"gkd_3 fl\">\
                        <div id=\"\" class=\"gdk3_2 ie8 ma20\">\
                            <ul>";
            if (data!="]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].testname;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li>\
                    //                <div id=\"\" class=\"fl gkdt_270\">\
                    //                    <a target='_blank' class=\"gkdtbtn bsdkbtn\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "' class=\"gdkys gkgdkys\">[试题试卷] " + text + "</a>\
                    //                </div>\
                    //                <div class=\" fl\">\
                    //                    <a target='_blank' href=\"\" class=\"gkdttime gkgdkys\">["+time+"]</a>\
                    //                </div>\
                    //            </li>";
                    html += "<li>\
                            <div class=\"fl gkdt_2701 overf_com color_ff\">\
                                <a target='_blank' class=\"zxzt_btn_808ffb dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"color_ff\" href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "'>[试题试卷]  " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"fr color_ff\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    if ((i + 1) % 6 == 0 && i != 0 && (i + 1) < temp.length) {
                        html += "</ul>\
                        </div>\
                    </div>\
                    <div class=\"gkd_3 fl gkdt_lianjiedk\" style='margin-left:61px;'>\
                        <div id=\"\" class=\"gdk3_2 ie8 ma20\">\
                            <ul>";
                    }
                }
                html += "</ul>\
                        </div>\
                    </div>";
            }
            $("#test_mingxiao").html(html);
        }
    });
}

//
//精品试题
//
function test_jingpin() {
    $.post("../Province/Test_Jingpin", { area: area }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].testname;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li>\
                    //        <div id=\"\" class=\"fl gkdt_270\">\
                    //            <a target='_blank'  class=\"gkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'  href='../Download?cid=1&id=" + temp[i].id + "' class=\"gdkys\">[试题试卷] " + text + "</a>\
                    //</div>\
                    //<div class=\" fl\">\
                    //            <a target='_blank' href=\"\" class=\"gkdttime\">["+time+"]</a>\
                    //        </div>\
                    //    </li>";
                    html += " <li>\
                            <div class=\"fl gkdt_2701 overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"gdkys\"  href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "'>[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#test_jingpin").html(html);
        }
    });
}

//
//精品备课
//
function beike_jingpin() {
    $.post("../Province/Beike_jingpin", { area: area }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li>\
                    //        <div id=\"\" class=\"fl gkdt_270\">\
                    //            <a target='_blank' class=\"gkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i].name.replace(" ", "-") + "' href='../Special/Beike?id=" + temp[i].id + "&way=2&name=" + temp[i].name + "' class=\"gdkys\">[试题试卷] " + text + "</a>\
                    //</div>\
                    //<div class=\" fl\">\
                    //            <a target='_blank' href=\"\" class=\"gkdttime\">["+ time + "]</a>\
                    //        </div>\
                    //    </li>";
                    html += " <li>\
                            <div class=\"fl gkdt_2701 overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"gdkys\"  href='../Special/Beike?id=" + temp[i].id + "&way=2&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#beike_jingpin").html(html);
        }
    });
}

//
//推荐套题
//
function taoti_tuijian() {
    $.post("../Province/Taoti_tuijian", { area: area }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li>\
                    //        <div id=\"\" class=\"fl gkdt_270\">\
                    //            <a target='_blank' class=\"gkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i].name.replace(" ", "-") + "' href='../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' class=\"gdkys\">[试题试卷] " + text + "</a>\
                    //</div>\
                    //<div class=\" fl\">\
                    //            <a target='_blank' href=\"\" class=\"gkdttime\">["+ time + "]</a>\
                    //        </div>\
                    //    </li>";
                    html += " <li>\
                            <div class=\"fl gkdt_2701 overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"gdkys\"  href='../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#taoti_tuijian").html(html);
        }
    });
}

//
//通过试题类型获取试题
//
function gettest_bucategory(category,controlid,iswhite) {
    $.post("../Province/GetTest_ByCategory", { area: area, category: category }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].testname;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    if (iswhite == 0) {
                        html += "<li>\
                            <div class=\"fl gkdt_2701 overf_com color07c277\">\
                                <a target='_blank' class=\"zxzt_btn_fff dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"color07c277\" href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "'>[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"color07c277  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    } else if(iswhite==1) {
                        html += "<li>\
                            <div class=\"fl gkdt_2701 overf_com color_ff\">\
                                <a target='_blank' class=\"zxzt_btn_07c277 dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"color_ff\" href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "'>[试题试卷]  " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"fr color_ff\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    } else if (iswhite == 2) {
                        html += "<li>\
                            <div class=\"fl gkdt_2701 overf_com color_ff\">\
                                <a target='_blank' class=\"zxzt_btn_8cc407 dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"color_ff\" href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "'>[试题试卷]  " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"fr color_ff\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    } else if (iswhite == 3) {
                  html += "<li>\
                            <div class=\"fl gkdt_2701 overf_com gkdttime_8cc407\">\
                                <a target='_blank' class=\"gkdtbtn_8cc407 dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"gkdttime_8cc407\" href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "'>[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime_8cc407  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    }
                    
                }
            }
            $("#"+controlid).html(html);
        }
    });
}

function changeArea() {
    $("#middle_content_top_left_top_smalllogo").html("当前省份:"+text);
    $("#taoti_recommend_text").html("推荐套题（"+text+"）");
    $("#recommend_taoti_a").attr("href","../Elite_School?area="+area);  //本省名校试题-more
}

//
//获取新闻
//
function News(type, controlid) {
    $.post("../Home/GetNews3", { type: type }, function (data) {
        if (data) {
            if (data) {
                var temp = eval(data);
                var html = "<ul class=\"ul1 fl mar_rg_45\">";
                var date;
                for (var i = 1; i <= temp.length; i++) {
                    date = new Date(temp[i - 1].pubdate);
                    var text = temp[i - 1].title;
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var number_str = (i) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li><div class=\"fl ul1div\"><a target='_blank' class=\"abt abtdk\">" + number + "</a>&nbsp;<a target='_blank'  title='" + temp[i-1].title.replace(" ", "-") + "' href='../News_Detail?id=" + temp[i - 1].id + "' class=\"ul1a\">" + text + "</a></div><div class=\"fl\"><a target='_blank' class=\"ul1a\">[" + time + "]</a></div></li>";
                    html += "<li  class=\"font_size16\">\
                            <div class=\"fl gkdt_240 overf_com color07c7bc\">\
                                <a target='_blank' class=\"zxzt_btn_07c7bc dot_data_com fl\">" + number + "</a>&nbsp;\
                                <a target='_blank' class=\"color07c7bc line_hg_25\" href='../News_Detail?id="+temp[i-1].id+"' title='" + temp[i - 1].title.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"color07c7bc  fr line_hg_25\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    if (i % 6 == 0 && i != 0 && i < temp.length) {
                        if (i / 6 >= 3) {
                            html += "</ul>\
                                <ul class=\"ul1 fl\">";
                        } else {
                            html += "</ul>\
                                <ul class=\"ul1 fl mar_rg_45\">";
                        }

                    }
                }
                html += "</ul>";
                $(controlid).html(html);
            }
        }
    });
}
//
//获取轮播图
//
function Banner() {
    $.post("../Province/GetBanner", { type: 31 }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var html1 = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<li><a target='_blank' href='"+temp[i].link+"'><img src='" + "http://source.51kaoxue.com" + temp[i].pic + "' alt='" + (i + 1) + "' title='" + (i + 1) + "' id='wows1_" + (i + 1) + "' style='width:715px; height:442px;'></a></li>";
                html1 += "<a target='_blank' href='#' title='" + (i + 1) + "'><span></span></a>";
            }
            $("#banner_images").html(html);
            $("#banner_buttons").html(html1);
            jQuery.getScript("../engine1/wowslider.js", function () {
                jQuery.getScript("../engine1/script.js", function () {

                });
            });

        }
    });
}

//
//名校合作
//
function GetSchool() {
    $.post("../Home/GetSchool", function (data) {
        if (data) {
            var html2 = ""; //名校展示
            var temp;
            if (data != "]") {
                temp = eval(data);
                for (var i = 0; i < 5; i++) {
                    if (i == 0) {
                        html2 += "<div class=\"hs1 fl\">\
                        <div class=\"hsimg1\">\
                            <img src=\""+ "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" alt=\"\" class=\"img190\" />\
                        </div>\
                        <div class=\"wzhs\">\
                            <a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>" + temp[i].name + "</a>\
                        </div>\
                    </div>";

                    } else {
                        html2 += "<div class=\"hs1 fl mxzykz6\">\
                        <div class=\"hsimg1\">\
                            <img src=\""+ "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" alt=\"\" class=\"img190\" />\
                        </div>\
                        <div class=\"wzhs\">\
                            <a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>" + temp[i].name + "</a>\
                        </div>\
                    </div>";
                    }
                }

            }
            $("#elite_school_show").html(html2);
        }
    });
}

//
//获取地区
//
function GetArea() {
    $.post("../Test_Center/GetArea", function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);
                html += "<div id=\"\" class=\"fl cebianlan_ul1\">\
                    <ul>";

                for (var i = 1; i <= temp.length; i++) {
                    html += "<li><a target='_blank' href=\"../Province?area=" + temp[i - 1].id + "&text=" + temp[i - 1].areaname + "\" class=\"hover1\"><img src=\"../../img/hover-10.png\" alt=\"\" class=\"hover10\" />" + temp[i - 1].areaname + "</a></li>";
                    if (i % 8 == 0 && i != 0) {
                        html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"fl cebianlan_ul1\">\
                                    <ul>";
                    }
                }
            }
            html += "</ul>\
                        </div>\
                    </div>";
            $("#province_more").html(html);
            //$("#subject1").click();
        }
    });
}

$(document).ready(function () {
    area = GetQueryString("area");
    text = GetQueryString("text");
    test_mingxiao(" between 10 and 12");
    test_jingpin();
    beike_jingpin();
    taoti_tuijian();
    //高中
    //月考阶段试题
    gettest_bucategory(9, "s_test_yuekao",1);
    //期中期末试题
    gettest_bucategory(10, "s_test_qimo",1);
    //地区联考试题
    gettest_bucategory(15, "s_test_district",1);
    //学业会考试题
    gettest_bucategory(11, "s_test_huikao",0);
    //模拟预测试题
    gettest_bucategory(16, "s_test_moni",0);
    //历年高考真题
    gettest_bucategory(18, "s_test_gaokao",0);

    //初中
    //月考阶段试题
    gettest_bucategory(5, "j_test_yuekao",2);
    //期中期末试题
    gettest_bucategory(6, "j_test_qimo",2);
    //地区联考试题
    gettest_bucategory(8, "j_test_district",2);
    //学业会考试题
    gettest_bucategory(7, "j_test_huikao",3);
    //模拟预测试题
    gettest_bucategory(22, "j_test_moni",3);
    //历年高考真题
    gettest_bucategory(24, "j_test_zhongkao",3);

    changeArea();
    News(1, "#gaokaodongtai");
    Banner();
    GetSchool();
    GetArea();
});


//点击span时，改变span样式
function change_css_span(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("title_middle_nav_span_select");
    });
    $(obj).addClass("title_middle_nav_span_select");
}

//点击li时，改变li样式
function change_css_li(obj) {  //obj ——被选中的span标签
    $(obj).parent().children().each(function () {  //  获取被选中的span标签的所有兄弟标签
        $(this).removeClass("news_span_selected");
        $(this).addClass("news_span_normal");
    });
    $(obj).removeClass("news_span_normal");
    $(obj).addClass("news_span_selected");
}