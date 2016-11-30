﻿/// <reference path="../Scripts/jquery-1.8.2.js" />

//
//最新专题
//

function New_Zhuanti() {
    $.post("../Home/GetNewZhunati",
        function (data) {
            if (data) {
                var temp = eval(data);
                var html = "";
                var date;
                html += "<div id=\"\" class=\"jpst_lianjie fl\">\
                <ul>";
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].updatetime);
                    var text = temp[i].name.length > 20 ? temp[i].name.substr(0, 20) : temp[i].name;
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate()); //构造特定的日期格式
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    if (i < 6) {
                        html += "<li>\
                        <div class=\"jpstli zxzhutiys\">\
                            <a target='_blank' class=\"fl btnjps size_com\">" + number + "</a><div class=\"fl jpstys\"><a target='_blank' title='" + temp[i].name.replace(" ", "-") + "'  href=\"../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "\"> " + text + "</a></div><div class=\"fr\" id=\"\">\
                                <a target='_blank'  class=\"zxzths\" href='../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "' class=\"zxzths\">[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
                    } else {
                        html += "<li>\
                        <div class=\"jpstli zxzhutiys\">\
                            <a target='_blank' class=\"fl btnjps size_com\">" + number + "</a><div class=\"fl jpstys\"><a target='_blank' title='" + temp[i].name.replace(" ", "-") + "'  href=\"../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "\"> " + temp[i].name + "</a></div><div class=\"fr\" id=\"\">\
                                <a target='_blank' class=\"zxzths\" href=\"\">[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
                    }
                    if ((i + 1) % 6 == 0 && i != 0 && (i + 1) < temp.length) {
                        html += "</ul>\
                            </div>\
                            <div id=\"\" class=\"jpst_lianjie fr\">\
                                <ul>";
                    }
                }
                html += "</ul>\
            </div>";
                $("#news_zhuangti").html(html);
            }
        });
}

//
//名校套题
//
function Taoti() {
    $.post("../Home/GetTaoTi", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;

            html += "<div id=\"\" class=\"ztklianjie fl\">\
                    <ul class=\"ztk_ul\">";

            for (var i = 1; i <= temp.length; i++) {
                date = new Date(temp[i - 1].pubdate);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = i + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                //html += "<li><a target='_blank' class=\"btn size_com fl\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i - 1].name.replace(" ", "-") + "' class=\"fff\" href='../Special?id=" + temp[i - 1].id + "&way=1&name=" + temp[i - 1].name + "'> " + temp[i - 1].name + "</a></li>";
                html += "<li>\
                        <div class=\"jpstli zxzhutiys\">\
                            <a target='_blank' class=\"btn size_com fl\">" + number + "</a><div class=\"ztk_ul_div_1 fl\"><a target='_blank' class=\"fff\" title='" + temp[i - 1].name.replace(" ", "-") + "' href=\"../Special?id=" + temp[i - 1].id + "&way=1&name=" + temp[i - 1].name + "\"> " + temp[i - 1].name + "</a></div><div class=\"fr\" id=\"\">\
                                <a target='_blank' class=\"fff\" href=\"\">["+ time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
                if (i % 6 == 0 && i != 0 && i < temp.length) {
                    html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"ztklianjie fl\">\
                                    <ul class=\"ztk_ul\">";
                }
            }
            html += " </ul>\
                </div>\
                <div class=\"fl mxttimg gedigaokao_img\" onclick=\"javascript:window.open('http://www.51kaoxue.com/Special?id=12799&way=1&name=%E6%B2%B3%E5%8D%97%E7%9C%81%E6%96%B0%E4%B9%A1%E5%B8%822015-2016%E5%AD%A6%E5%B9%B4%E9%AB%98%E4%BA%8C%E4%B8%8B%E5%AD%A6%E6%9C%9F%E6%9C%9F%E6%9C%AB%E8%80%83%E8%AF%95%E7%BB%BC%E5%90%88%E8%AF%95%E9%A2%98%EF%BC%88%E6%89%AB%E6%8F%8F%E7%89%88%E5%85%A8%E7%A7%916%E4%BB%BD%EF%BC%89');\">\
                </div>";
            //<img src=\"../../img/gedigaokao.jpg\" />\
            $("#taoti").html(html);
        }
    });
}

//
//试题推荐
//
function Test() {
    $.post("../Home/GetTest", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) : temp[i].testname;
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                        <div class=\"jpstli zxzhutiys\">\
                            <a target='_blank' class=\"fl btnjps btnjspt size_com\">" + number + "</a><div class=\"fl jpstys jpys\"><a target='_blank' title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "'> " + temp[i].testname + "</a></div><div class=\"fr\" id=\"\">\
                                <a target='_blank' class=\"ayblue\" href=\"\">["+ time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
            }
            $("#test").html(html);
        }
    });
}

//
//名校试题
//
function School_Test() {
    $.post("../Home/GetSchool_Test", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<div class=\"ztklianjie fl stkz\">\
                        <ul class=\"ztk_ul\">";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var text = temp[i].testname.length > 22 ? temp[i].testname.substr(0, 22) : temp[i].testname;
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                //html += "<li><a target='_blank' class=\"btn\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "' class=\"fff\"> " + text + "</a></li>";
                html += "<li>\
                        <div class=\"jpstli zxzhutiys\">\
                            <a target='_blank' class=\"btn size_com fl\">" + number + "</a><div class=\"ztk_ul_div_1 fl\"><a target='_blank' class=\"fff\" title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "'\"> " + temp[i].testname + "</a></div><div class=\"fr\" id=\"\">\
                                <a target='_blank' class=\"fff\" href=\"\">["+ time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
                if ((i + 1) % 6 == 0 && i != 0 && (i + 1) < temp.length) {
                    html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"ztklianjie fl stkz\">\
                                    <ul class=\"ztk_ul\">";
                }
            }
            html += "</ul>\
                    </div>\
                    <div class=\"fl mxttimg gedigaokao_img  gedigaokao_img_1\" onclick=\"javascript:window.open('http://www.51kaoxue.com/Download?cid=1&id=359019');\">\
                    </div>\
                </div>";
            //<img src=\"../../img/gedigaokao.jpg\" />
            $("#shiti_school").html(html);
        }
    });
}

//
//金品备课
//
function Beike() {
    $.post("../Home/GetBeiKe", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].pubdate);
                var text = temp[i].name.length > 15 ? temp[i].name.substr(0, 15) : temp[i].name;
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                        <div class=\"jpstli zxzhutiys\">\
                            <a target='_blank' class=\"fl btnjps btnjspt size_com\">" + number + "</a><div class=\"fl jpstys jpys\"><a target='_blank' title='" + temp[i].name.replace(" ", "-") + "' href=\"../Special/Beike?id=" + temp[i].id + "&way=2&name=" + temp[i].name + "\"> " + temp[i].name + "</a></div><div class=\"fr\" id=\"\">\
                                <a target='_blank' class=\"ayblue\" href=\"\">["+ time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
            }
            $("#beike").html(html);
        }
    });
}

//
//最新套题
//
function Taoti_JuniorMiddleSchool() {
    $.post("../Home/GetTaoti_SeniorMiddleSchool", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].pubdate);
                var text = temp[i].name.length > 15 ? temp[i].name.substr(0, 15) : temp[i].name;
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                        <div class=\"zxtlianjiediv fl\">\
                            <a target='_blank' class=\"zxzt_btn fl size_com\"><span>" + number + "</span></a><div class=\"fl zxzt_index\"><a target='_blank' title='" + temp[i].name.replace(" ", "-") + "' href=\"../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "\"> " + temp[i].name + "</a></div><div class=\"fr zuixinzt\" id=\"\">\
                                <a target='_blank' href=\"\">[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
            }
            $("#Taoti_JuniorMiddleSchool").html(html);
        }
    });
}

//
//最新试题
//
function Test_JuniorMiddleSchool() {
    $.post("../Home/GetTest_SeniorMiddleSchool", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) : temp[i].testname;
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                        <div class=\"zxtlianjiediv fl\">\
                            <a target='_blank' class=\"zxzt_btn fl size_com\"><span>" + number + "</span></a><div class=\"fl zxzt_index\"><a target='_blank' title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "'\"> " + temp[i].testname + "</a></div><div class=\"fr zuixinzt\" id=\"\">\
                                <a target='_blank' href=\"\">[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
            }
            $("#Test_JuniorMiddleSchool").html(html);
        }
    });
}

//
//最新历年中考试卷
//
function Mid_examination() {
    $.post("../Home/GetMid_examination", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) : temp[i].testname;
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                        <div class=\"zxtlianjiediv fl\">\
                            <a target='_blank' class=\"zxzt_btn fl size_com\"><span>" + number + "</span></a><div class=\"fl zxzt_index\"><a target='_blank' title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "'\"> " + temp[i].testname + "</a></div><div class=\"fr zuixinzt\" id=\"\">\
                                <a target='_blank' href=\"\">[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
            }
            $("#Mid_examination").html(html);
        }
    });
}

//
//获取新闻
//
function News(type, controlid) {
    $.post("../Home/GetNews1", { type: type }, function (data) {
        if (data) {
            if (data) {
                var temp = eval(data);
                var html = "";
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var text = temp[i].title.length > 15 ? temp[i].title.substr(0, 15) : temp[i].title;
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += "<li>\
                            <div  class=\"fl gkdt_270\">\
                                <a target='_blank' class=\"fl gkdtbtn size_com\">" + number + "</a>&nbsp;</div>\
                            <div class=\"gdkys flow_nowrap fl\"><a target='_blank'  title='" + temp[i].title.replace(" ", "-") + "'  class=\"gdkys\" href='../News_Detail?id=" + temp[i].id + "&myTitle=" + text + "'>[新闻] " + text + "</a>\
                    </div>\
                    <div class=\" fr\">\
                                <a target='_blank'  class=\"gkdttime fr\">["+ time + "]</a>\
                            </div>\
                        </li>";
                }
                $(controlid).html(html);
            }
        }
    });
}

//
//获取轮播图
//
function Banner() {
    $.post("../Home/GetBanner", { type: 1 }, function (data) {
        if (data && data != "]") {
            var temp = eval(data);
            var html = "";
            var html1 = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<a target='_blank' href='" + temp[i].link + "'><img src='" + "http://source.51kaoxue.com" + temp[i].pic + "' style=\"height: 489px; width: 717px; \"></a>";
            }
            $("#wowslider-container1_new").html(html);
            //$("#banner_buttons").html(html1);
            jQuery.getScript("../engine1/vmc.slider.full.js", function () {
                jQuery.getScript("../engine1/script.js", function () {
                    if (navigator.userAgent.indexOf("MSIE") > 0) {
                        //修复ie7问题
                        setTimeout(function () {
                            //$(".vui-prev").click();
                            $(".vui-next").click();
                        }, 100);
                    }
                });
            });

        }
    });
}

//
//距离高考还有多少天
//
function gaokao() {

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
                    if (temp[i - 1].areaname.length == 2) {
                        html += "<li><a target='_blank' href=\"../Province?area=" + temp[i - 1].id + "&text=" + temp[i - 1].areaname + "\" class=\"hover1\"><img src=\"../../img/hover-10.png\" alt=\"\" class=\"hover10\" />" + temp[i - 1].areaname + "</a></li>";
                    } else {
                        html += "<li><a target='_blank' href=\"../Province?area=" + temp[i - 1].id + "&text=" + temp[i - 1].areaname + "\" class=\"hover1\"><img src=\"../../img/hover10_1.png\" alt=\"\" class=\"hover10 hover10_1\" />" + temp[i - 1].areaname + "</a></li>";
                    }
                  
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

//
//获取学科
//
function GetSubject(num, controlid, hover, imgsrc, hover2) {
    $.post("../Beike_Center/GetSubject", { level: num }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);
                html += "<div id=\"\" class=\"fl cebianlan_ul1\">\
                    <ul>";
                for (var i = 1; i <= temp.length; i++) {
                    html += "<li><a target='_blank' style='cursor:pointer;' onclick= subjecturl(" + num + "," + temp[i - 1].id + ") class=\"hover" + hover2 + "\"><img src=\"../../img/" + imgsrc + "\" alt=\"\" class=\"hover" + hover + "\" />" + temp[i - 1].name + "</a></li>";
                    if (i <= 6) {
                        if (i % 3 == 0 && i != 0 && i < temp.length) {
                            html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"fl cebianlan_ul1\">\
                                    <ul>";
                        }
                    } else {
                        if (i % 2 == 0 && i != 0 && i < temp.length) {
                            html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"fl cebianlan_ul1\">\
                                    <ul>";
                        }
                    }


                }
                html += "</ul>\
                        </div>";
            }

            $("#" + controlid).html(html);
            //$("#subject1").click();
        }
    });
}

//
//名校合作
//
function GetSchool() {
    $.post("../Home/GetSchool", function (data) {
        if (data) {
            var html = ""; //名校合作
            var html2 = ""; //名校展示
            var temp;
            if (data != "]") {
                temp = eval(data);

                html += "<b><h3 class=\"mingxiaoziyuan_h3\">名校合作 UNIVERCITIES COOPERATION</h3></b>\
                <div  class=\"ztk_div_div \">\
                    <div class=\"xian1 fl\"></div>\
                    <div class=\"quanquan fl\">\
                        <div class=\"qq1 fl qdankong\" style='background:url(\"../img/tbkb001.png\") repeat scroll 0 0;'><a target='_blank'  class=\"fff\">备课中心</a></div>\
                        <div class=\"qq1 fl qqq1\" style='background:url(\"../img/tbkb002.png\") repeat scroll 0 0;'><a target='_blank'  class=\"fff\">每日专题</a></div>\
                        <div class=\"qq1 fl qqq1\" style='background: url(\"../img/tbkb003.png\") repeat scroll 0 0;'><a target='_blank'  class=\"fff\">历年考题</a></div>\
                        <div class=\"qq1 fl qqq1\" style='background: url(\"../img/tbkb004.png\") repeat scroll 0 0;'><a target='_blank'  class=\"fff\">名校测题</a></div>\
                    </div>\
                    <div class=\"xian2 fl\" style=\"position:relative;\"><a target='_blank' href='../school' class=\"genduo lantb_set\"><img src=\"../../img/lantb.png\" alt=\"\"></a></div>\
                </div>";

                html += "<div  class=\"mxhz6 fl\">\
                    <ul class=\"mxhz6_ul\">";

                for (var i = 0; i < 15; i++) {
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += "<li><a target='_blank' class=\"fl size_com mxhz6_btn\">" + number + "</a>&nbsp;<a target='_blank' title='" + temp[i].name.replace(" ", "-") + "' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "'>" + temp[i].name + "</a></li>";
                    if ((i + 1) % 3 == 0 && i != 0 && (i + 1) < 15) {
                        if (i <= 15) {
                            html += "</ul>\
                                    </div>\
                                    <div  class=\"mxhz6 fl mxhz_left\"  >\
                                        <ul class=\"mxhz6ul\">";
                        } else {
                            html += "</ul>\
                                    </div>\
                                    <div  class=\"mxhz6 fl mxhz_left mxhz_dk\">\
                                        <ul class=\"mxhz6ul\" >";
                        }
                    }
                }
                for (var i = 0; i < 5; i++) {
                    if (i == 0) {
                        html2 += "<div  class=\"mxzy_8 fl\">\
                        <div>\
                            <img src=\"" + "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" class=\"school_img\"  onclick=\"javascript:window.open('../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "');\"/>\
                        </div>\
                        <a target='_blank'   href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "'>" + temp[i].name + "</a>\
                    </div>";
                    } else {
                        html2 += "<div  class=\"mxzy_8 fl mxzykz6\">\
                        <div>\
                            <img src=\"" + "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" class=\"school_img\" onclick=\"javascript:window.open('../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "');\"/>\
                        </div>\
                        <a target='_blank'   href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "'>" + temp[i].name + "</a>\
                    </div>";
                    }

                }

            }
            $("#elite_school").html(html);
            $("#elite_school_show").html(html2);
        }
    });
}
//
//名师推荐
//
function GetTeachers() {
    $.post("../Home/GetTeachers", function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);
                var url = "http://source.51kaoxue.com/";

                for (var i = 0; i < temp.length; i++) {
                    if (i == 0) {
                        html += "<div class=\"ls4_img fl \">\
                        <div class=\"lszp fl\"><img src=\"" + url + temp[i].headimgsrc + "\" alt=\"\" style='width:131px;height:167px;' /></div>\
                        <div  class=\"lszp fl padding_top35\">\
                            <h3><b>" + temp[i].headname + "</b></h3>\
                            <p class=\"dkms\">" + temp[i].name + "</p>\
                            <a target='_blank' class=\"mstjbtn mar_top30\"  href='../President_Special_Column?id=" + temp[i].headid + "&myTitle=" + temp[i].headname + "_" + temp[i].name + "校长" + "'>详情</a>\
                        </div>\
                    </div>";
                    } else {
                        html += "<div class=\"ls4_img fl lstp_mg \">\
                        <div class=\"lszp fl\"><img src=\"" + url + temp[i].headimgsrc + "\" alt=\"\" style='width:131px;height:167px;' /></div>\
                        <div  class=\"lszp fl padding_top35\">\
                            <h3><b>" + temp[i].headname + "</b></h3>\
                            <p class=\"dkms\">" + temp[i].name + "</p>\
                            <a target='_blank' class=\"mstjbtn mar_top30\" href='../President_Special_Column?id=" + temp[i].headid + "&myTitle=" + temp[i].headname + "_" + temp[i].name + "校长" + "'>详情</a>\
                        </div>\
                    </div>";
                    }

                }
            }
            $("#teachers").html(html);
            //$("#subject1").click();
        }
    });
}

function subjecturl(level, subjectid) {
    location.href = "../Test_Center?level=" + level + "&subjectid=" + subjectid;
}

function Today() {
    $("#today").html(new Date().toLocaleDateString());
}

function lxfEndtime() {
    $(".lxftime").each(function () {
        var lxfday = $(this).attr("lxfday"); //用来判断是否显示天数的变量
        var endtime = new Date($(this).attr("endtime")).getTime(); //取结束日期(毫秒值)
        var nowtime = new Date().getTime();        //今天的日期(毫秒值)
        var youtime = endtime - nowtime; //还有多久(毫秒值)
        var seconds = youtime / 1000;
        var minutes = Math.floor(seconds / 60);
        var hours = Math.floor(minutes / 60);
        var days = Math.floor(hours / 24);
        var CDay = days;
        var CHour = hours % 24;
        var CMinute = minutes % 60;
        var CSecond = Math.floor(seconds % 60); //"%"是取余运算，可以理解为60进一后取余数，然后只要余数。
        if (endtime <= nowtime) {
            $(this).html("进行中"); //如果结束日期小于当前日期就提示过期啦
            $(this).attr("style", "font-size:24px");
        } else {
            if ($(this).attr("lxfday") == "no") {
                $(this).html(CHour + "时" + CMinute + "分" + CSecond + "秒");          //输出没有天数的数据
            } else {
                $(this).html("<b class=\"font_wnormal pa_sec_1\">倒计时</b><b class=\"enlarge_day\">" + days + "</b><b class=\"font_wnormal pa_sec_2\">天</b>");          //输出有天数的数据
            }
        }
    });
    //setTimeout("lxfEndtime()", 1000);
};

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
                    html += "<option value='" + temp[i].id + "'>" + temp[i].name + "</option>";
                }
            }
            $("#years").html(html);
            //$("#subject1").click();
        }
    });
}

//
//年份下拉框-右侧查找按钮点击事件
//
function search_years() {
    location.href = '../Past_Exam?year=' + $("#years").val() + "&year_text=" + $("#years option:selected").text();
}

//
//备课资源数量
//
function getbeikecount() {
    $.post("../Home/GetBeikeCount", function (data) {
        $("#beikecount").html(data);
    });
}


//
//试题资源数量
//
function GetShitiCount() {
    $.post("../Home/GetShitiCount", function (data) {
        $("#shiticount").html(data);
    });
}

//
//教师资源数量
//
function GetTearcherCount() {
    $.post("../Home/GetTearcherCount", function (data) {
        $("#teacherscount").html(data);
    });
}

//
//初始化项
//
$(document).ready(function () {
    GetArea();
    New_Zhuanti();
    Taoti();
    Test();
    Beike();
    Taoti_JuniorMiddleSchool();
    Test_JuniorMiddleSchool();
    Mid_examination();
    News(1, "#gaokaodongtai");
    News(2, "#jiaoxueyanjiu");
    News(3, "#keyanlunwen");
    News(4, "#xuexifangfa");
    News(5, "#jingyanjiaoliu");
    News(6, "#jiaocaijiaofa");
    Banner();
    GetSubject(2, "junior_subject", 101, 'ty-10-kb.png', 11);
    GetSubject(3, "senior_subject", 121, 'ty-10-kb-2.png', 111);
    School_Test();
    GetSchool();
    GetTeachers();
    Today();
    lxfEndtime();
    GetYear();
});



//
//
//
//旋转木马
//
//
//
//当前显示的ul下标
var horse_current_index = 1;
//最大ul数量
var horse_max_num = 3;
//旋转木马-左
function wooden_horse_left() {
    if (horse_current_index > 1) {
        var controlid = "#images_" + horse_current_index;
        $(controlid).slideUp();
        horse_current_index--;
        controlid = "#images_" + horse_current_index;
        $(controlid).slideDown();
    }
}


//旋转木马-右
function wooden_horse_right() {
    if (horse_current_index < horse_max_num) {
        var controlid = "#images_" + horse_current_index;
        $(controlid).slideUp();
        horse_current_index++;
        controlid = "#images_" + horse_current_index;
        $(controlid).slideDown();
    }
}

function showorhidediv_province(controlid) {
    $("#middle_content_top_left_bottom").find('.nav_background_container').each(function () {
        $(this).slideUp();
        $(this).width(750);
    });
    $("#middle_content_top_left_bottom").find('.sign_reduce').each(function () {
        $(this).removeClass("sign_reduce").addClass("sign_add");
    });
    $("#" + controlid).prev().find(".sign_add").removeClass("sign_add").addClass("sign_reduce");
    $("#" + controlid).slideDown(function () {
        $("#" + controlid).animate({ width: "274px" });
    });
}

function provinceurl(area, text) {
    location.href = "../province?area=" + area + "&text=" + text;
}

//点击li时，改变li样式
function change_css_li(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("selected");
        $(this).addClass("normal");
    });
    $(obj).removeClass("normal");
    $(obj).addClass("selected");
}

//点击a时，改变a样式
function change_css_a(obj,css) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css);
    });
    $(obj).addClass(css);
}
//点击span时，改变span样式
function change_css_span(obj, num) {
    $(obj).parent().children().each(function () {
        $(this).addClass("title_middle_nav_span_normal_" + num);
    });
    $(obj).removeClass("title_middle_nav_span_normal_" + num);
}