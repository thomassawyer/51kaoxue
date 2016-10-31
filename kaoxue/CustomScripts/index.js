/// <reference path="../Scripts/jquery-1.8.2.js" />

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
                            <a class=\"fl btnjps\">" + number + "</a><div class=\"fl jpstys\" style='width:390px;'><a title='" + temp[i].name.replace(" ", "-") + "'  href=\"../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "\">[试题试卷] " + text + "</a></div><div class=\"fl\" id=\"\">\
                                <a  class=\"ayblue1\" href='../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "' style='color:#f5bc2b;'>[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
                    } else {
                        html += "<li>\
                        <div class=\"jpstli zxzhutiys pps\">\
                            <a class=\"fl btnjps\">" + number + "</a><div class=\"fl jpstys\" style='width:390px;'><a title='" + temp[i].name.replace(" ", "-") + "' href=\"../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "\">[试题试卷] " + text + "</a></div><div class=\"fl\" id=\"\">\
                                <a class=\"ayblue1\" href=\"\" style='color:#f5bc2b;'>[" + time + "]</a>\
                            </div>\
                        </div>\
                    </li>";
                    }
                    if ((i + 1) % 6 == 0 && i != 0 && (i + 1) < temp.length) {
                        html += "</ul>\
                            </div>\
                            <div id=\"\" class=\"jpst_lianjie fl mgjpst\">\
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
                html += "<li><a class=\"btn\">" + number + "</a>&nbsp;<a title='" + temp[i - 1].name.replace(" ", "-") + "' class=\"fff\" href='../Special?id=" + temp[i - 1].id + "&way=1&name=" + temp[i - 1].name + "'> " + temp[i - 1].name + "</a></li>";
                if (i % 6 == 0 && i != 0 && i < temp.length) {
                    html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"ztklianjie fl\">\
                                    <ul class=\"ztk_ul\">";
                }
            }
            html += " </ul>\
                </div>\
                <div class=\"fl mxttimg\">\
                    <img src=\"../../img/gedigaokao.jpg\" />\
                </div>";
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
                            <a class=\"fl btnjps btnjspt\">" + number + "</a><div class=\"fl jpstys jpys\"><a title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "'>[试题试卷] " + temp[i].testname + "</a></div><div class=\"fl\" id=\"\">\
                                <a class=\"ayblue\" href=\"\">["+ time + "]</a>\
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
                html += "<li><a class=\"btn\">" + number + "</a>&nbsp;<a title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "' class=\"fff\"> " + text + "</a></li>";
                if ((i + 1) % 6 == 0 && i != 0 && (i + 1) < temp.length) {
                    html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"ztklianjie fl stkz\">\
                                    <ul class=\"ztk_ul\">";
                }
            }
            html += "</ul>\
                    </div>\
                    <div class=\"fl mxttimg\">\
                        <img src=\"../../img/gedigaokao.jpg\" />\
                    </div>\
                </div>";
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
                            <a class=\"fl btnjps btnjspt\">" + number + "</a><div class=\"fl jpstys jpys\"><a title='" + temp[i].name.replace(" ", "-") + "' href=\"../Special/Beike?id=" + temp[i].id + "&way=2&name=" + temp[i].name + "\">[试题试卷] " + temp[i].name + "</a></div><div class=\"fl\" id=\"\">\
                                <a class=\"ayblue\" href=\"\">["+ time + "]</a>\
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
    $.post("../Home/GetTaoti_JuniorMiddleSchool", function (data) {
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
                html += "<li><div class=\"zxtlianjiediv fl\"><a class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a  title='" + temp[i].name.replace(" ", "-") + "' href='../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "'>" + text + "</a></div><div class=\"fl zuixinzt\"><a href=\"\">[" + time + "]</a></div></li>";
            }
            $("#Taoti_JuniorMiddleSchool").html(html);
        }
    });
}

//
//最新试题
//
function Test_JuniorMiddleSchool() {
    $.post("../Home/GetTest_JuniorMiddleSchool", function (data) {
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
                html += "<li><div class=\"zxtlianjiediv fl\"><a class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a  title='" + temp[i].testname.replace(" ", "-") + "' href=\"../Download?id=" + temp[i].id + "&cid=1\">" + text + "</a></div><div class=\"fl zuixinzt\"><a href=\"\">[" + time + "]</a></div></li>";
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
                html += "<li><div class=\"zxtlianjiediv fl\"><a class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a  title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "'>" + text + "</a></div><div class=\"fl zuixinzt\"><a href=\"\">[" + time + "]</a></div></li>";
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
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;<a  title='" + temp[i].title.replace(" ", "-") + "'  class=\"gdkys\" href='../News_Detail?id=" + temp[i].id + "'>[新闻] " + text + "</a>\
                    </div>\
                    <div class=\" fl\">\
                                <a  class=\"gkdttime\">["+ time + "]</a>\
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
        if (data) {
            var temp = eval(data);
            var html = "";
            var html1 = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<li><a href='"+temp[i].link+"'><img src='" + "http://source.51kaoxue.com" + temp[i].pic + "' alt='" + (i + 1) + "' title='" + (i + 1) + "' id='wows1_" + (i + 1) + "' style='width:714px; height:489px;'></a></li>";
                html1 += "<a href='#' title='" + (i + 1) + "'><span></span></a>";
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
                    html += "<li><a href=\"../Province?area=" + temp[i - 1].id + "&text=" + temp[i - 1].areaname + "\" class=\"hover1\"><img src=\"../../img/hover-10.png\" alt=\"\" class=\"hover10\" />" + temp[i - 1].areaname + "</a></li>";
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
                    html += "<li><a style='cursor:pointer;' onclick= subjecturl(" + num + "," + temp[i - 1].id + ") class=\"hover" + hover2 + "\"><img src=\"../../img/" + imgsrc + "\" alt=\"\" class=\"hover" + hover + "\" />" + temp[i - 1].name + "</a></li>";
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

                html += "<b><h3>名校合作 UNIVERCITIES COOPERATION</h3></b>\
                <div  class=\"ztk_div_div \">\
                    <div class=\"xian1 fl\"></div>\
                    <div class=\"quanquan fl\">\
                        <div class=\"qq1 fl qdankong\" style='background: rgba(0, 0, 0, 0) url(\"../img/tbkb001.png\") repeat scroll 0 0;'><a  class=\"fff\">备课中心</a></div>\
                        <div class=\"qq1 fl qqq1\" style='background: rgba(0, 0, 0, 0) url(\"../img/tbkb002.png\") repeat scroll 0 0;'><a  class=\"fff\">每日专题</a></div>\
                        <div class=\"qq1 fl qqq1\" style='background: rgba(0, 0, 0, 0) url(\"../img/tbkb003.png\") repeat scroll 0 0;'><a  class=\"fff\">历年考题</a></div>\
                        <div class=\"qq1 fl qqq1\" style='background: rgba(0, 0, 0, 0) url(\"../img/tbkb004.png\") repeat scroll 0 0;'><a  class=\"fff\">名校测题</a></div>\
                    </div>\
                    <div class=\"xian2 fl\"><a href='../school' class=\"genduo\"><img src=\"../../img/lantb.png\" alt=\"\"></a></div>\
                </div>";

                html += "<div  class=\"mxhz6 fl\">\
                    <ul class=\"mxhz6_ul\">";

                for (var i = 0; i < temp.length; i++) {
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += "<li><a>" + number + "</a>&nbsp;<a title='" + temp[i].name.replace(" ", "-") + "' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>" + temp[i].name + "</a></li>";
                    if ((i + 1) % 3 == 0 && i != 0 && (i + 1) < temp.length) {
                        if (i <= 15) {
                            html += "</ul>\
                                    </div>\
                                    <div  class=\"mxhz6 fl mxhz_left\"  >\
                                        <ul class=\"mxhz6ul\" style='padding-left:55px;'>";
                        } else {
                            html += "</ul>\
                                    </div>\
                                    <div  class=\"mxhz6 fl mxhz_left mxhz_dk\">\
                                        <ul class=\"mxhz6ul\" >";
                        }
                    }
                }
                for (var i = 0; i < 8; i++) {
                    if (i == 0) {
                        html2 += "<div  class=\"mxzy_8 fl\">\
                        <div class=\"mxzy_border\">\
                            <img src=\""+ "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" />\
                        </div>\
                        <a   href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>" + temp[i].name + "</a>\
                    </div>";
                    } else {
                        html2 += "<div  class=\"mxzy_8 fl mxzykz6\">\
                        <div class=\"mxzy_border\">\
                            <img src=\""+ "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" />\
                        </div>\
                        <a   href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>" + temp[i].name + "</a>\
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
                        <div  class=\"lszp fl\">\
                            <h3><b>" + temp[i].headname + "</b></h3>\
                            <p class=\"dkms\">" + temp[i].name + "</p>\
                            <a class=\"mstjbtn\"  href='../President_Special_Column?id=" + temp[i].headid + "'>详情</a>\
                        </div>\
                    </div>";
                    } else {
                        html += "<div class=\"ls4_img fl lstp_mg \">\
                        <div class=\"lszp fl\"><img src=\"" + url + temp[i].headimgsrc + "\" alt=\"\" style='width:131px;height:167px;' /></div>\
                        <div  class=\"lszp fl\">\
                            <h3><b>" + temp[i].headname + "</b></h3>\
                            <p class=\"dkms\">" + temp[i].name + "</p>\
                            <a class=\"mstjbtn\" href='../President_Special_Column?id=" + temp[i].headid + "'>详情</a>\
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
                $(this).html( CHour + "时" + CMinute + "分" + CSecond + "秒");          //输出没有天数的数据
            } else {
                $(this).html("倒计时：" + days + "天");          //输出有天数的数据
            }
        }
    });
    setTimeout("lxfEndtime()", 1000);
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
    News(5, "#keyanlunwen");
    News(3, "#xuexifangfa");
    News(4, "#jingyanjiaoliu");
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