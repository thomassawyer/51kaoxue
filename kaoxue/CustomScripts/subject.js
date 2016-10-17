/// <reference path="../Scripts/jquery-1.8.2.js" />
/// <reference path="Common.js" />


//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var subjectname = "";

//
//精品备课
//
function beike_jingpin() {
    $.post("../Subject/Beike_jingpin", { subjectname: subjectname }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].pubdate);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 20 ? temp[i].name.substr(0, 20) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                            <div class=\"jpstli zxzhutiys\">\
                                <a class=\"fl btnjps btnjspt\">"+ number + "</a><div class=\"fl jpstys jpys\"><a href=\"\">[试题试卷] " + text + "</a></div><div class=\"fl\" id=\"\">\
                                    <a class=\"ayblue\" href=\"\">["+ time + "]</a>\
                                </div>\
                            </div>\
                        </li>";
            }
            $("#beike_jingpin").html(html);
        }
    });
}

//
//精品试题
//
function test_jingpin() {
    $.post("../Subject/Test_jingpin", { subjectname: subjectname }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) : temp[i].testname;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                            <div class=\"jpstli zxzhutiys\">\
                                <a class=\"fl btnjps btnjspt\">"+ number + "</a><div class=\"fl jpstys jpys\"><a href=\"\">[试题试卷] " + text + "</a></div><div class=\"fl\" id=\"\">\
                                    <a class=\"ayblue\" href=\"\">["+ time + "]</a>\
                                </div>\
                            </div>\
                        </li>";
            }
            $("#test_jingpin").html(html);
        }
    });
}

//
//最新专题推荐-高中
//
function zhuanti_new_recommend_senior() {
    $.post("../Subject/Zhuanti_New_Recommmend", { subjectname: subjectname, level: 3 }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].updatetime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                if (time == "NaN-NaN")
                    time = "";
                var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += " <li>\
                            <div class=\"fl gkdt_270\">\
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;\
                                <a class=\"gdkys\">[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fl\">\
                                <a class=\"gkdttime\">[" + time + "]</a>\
                            </div>\
                        </li>";
            }
            $("#zhuanti_new_recommend_senior").html(html);
        }
    });
}

//
//最新专题推荐-初中
//
function zhuanti_new_recommend_junior() {
    $.post("../Subject/Zhuanti_New_Recommmend", { subjectname: subjectname, level: 2 }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].updatetime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    if (time == "NaN-NaN")
                        time = "";
                    var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += " <li>\
                            <div class=\"fl gkdt_270\">\
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;\
                                <a class=\"gdkys\">[试题试卷] " + text + "</a>\
                            </div>\
                            <div class=\" fl\">\
                                <a class=\"gkdttime\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#zhuanti_new_recommend_junior").html(html);
        }
    });
}

//
//最新试题-高中
//
function test_new_senior(level) {
    $.post("../Subject/Test_new", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].testname.length > 13 ? temp[i].testname.substr(0, 13) : temp[i].testname;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                            <div class=\"fl gkdt_270\">\
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;\
                                <a class=\"gdkys\">[试题试卷] "+ text + "</a>\
                            </div>\
                            <div class=\" fl\">\
                                <a class=\"gkdttime\">["+ time + "]</a>\
                            </div>\
                        </li>";
            }
            $("#test_new_senior").html(html);
        }
    });
}

//
//最新试题-初中
//
function test_new_junior(level) {
    $.post("../Subject/Test_new", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].testname.length > 13 ? temp[i].testname.substr(0, 13) : temp[i].testname;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                            <div class=\"fl gkdt_270\">\
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;\
                                <a class=\"gdkys\">[试题试卷] "+ text + "</a>\
                            </div>\
                            <div class=\" fl\">\
                                <a class=\"gkdttime\">["+ time + "]</a>\
                            </div>\
                        </li>";
            }
            $("#test_new_junior").html(html);
        }
    });
}

//
//最新备考
//
function beikao_new(wheel) {
    $.post("../Subject/Beikao_new", { subjectname: subjectname, wheel: wheel }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                            <div class=\"fl gkdt_270\">\
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;\
                                <a class=\"gdkys\">[试题试卷]  " + text + "</a>\
                            </div>\
                            <div class=\" fl\">\
                                <a class=\"gkdttime\">[" + time + "]</a>\
                            </div>\
                        </li>";
            }
            $("#beikao_new").html(html);
        }
    });
}

//
//中考模拟
//
function moni_junior() {
    $.post("../Subject/Moni_junior", { subjectname: subjectname }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li>\
                            <div class=\"fl gkdt_270\">\
                                <a class=\"gkdtbtn\">" + number + "</a>&nbsp;\
                                <a class=\"gdkys\">[试题试卷]  " + text + "</a>\
                            </div>\
                            <div class=\" fl\">\
                                <a class=\"gkdttime\">[" + time + "]</a>\
                            </div>\
                        </li>";
            }
            $("#moni_junior").html(html);
        }
    });
}
//
//名校试题-高中
//
function test_mingxiao_senior(level) {
    $.post("../Subject/Test_mingxiao", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<ul style='width:50%; float:left;'>";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) : temp[i].testname;
                if (i == 0) {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_3'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><li><span class='li_left li_left_3'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
                if (i == 4) {
                    html += "</ul>";
                    html += "<ul style='width:50%; float:left;'>";
                }
            }
            html += "</ul>";
            $("#test_mingxiao_senior").html(html);
        }
    });
}

//
//名校试题-初中
//
function test_mingxiao_junior(level) {
    $.post("../Subject/Test_mingxiao", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<ul style='width:50%; float:left;'>";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) : temp[i].testname;
                if (i == 0) {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_3'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><li><span class='li_left li_left_3'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
                if (i == 4) {
                    html += "</ul>";
                    html += "<ul style='width:50%; float:left;'>";
                }
            }
            html += "</ul>";
            $("#test_mingxiao_junior").html(html);
        }
    });
}


//
//课件-高中
//
function kejian_senior(level) {
    $.post("../Subject/Kejian", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<ul style='width:50%; float:left;'>";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 15 ? temp[i].name.substr(0, 15) : temp[i].name;
                if (i == 0) {
                    html += "<a href='../Download?cid=2&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_3'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=2&id=" + temp[i].id + "'><li><span class='li_left li_left_3'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
                if (i == 4) {
                    html += "</ul>";
                    html += "<ul style='width:50%; float:left;'>";
                }
            }
            html += "</ul>";
            $("#kejian_senior").html(html);
        }
    });
}

//
//课件-初中
//
function kejian_junior(level) {
    $.post("../Subject/Kejian", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<ul style='width:50%; float:left;'>";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 15 ? temp[i].name.substr(0, 15) : temp[i].name;
                if (i == 0) {
                    html += "<a href='../Download?cid=2&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_3'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=2&id=" + temp[i].id + "'><li><span class='li_left li_left_3'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
                if (i == 4) {
                    html += "</ul>";
                    html += "<ul style='width:50%; float:left;'>";
                }
            }
            html += "</ul>";
            $("#kejian_junior").html(html);
        }
    });
}

//
//同步练习-高中
//
function tongbu_senior(level) {
    $.post("../Subject/Study_skills", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li><div class=\"zxtlianjiediv fl\"><a class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a >" + text + "</a></div><div class=\"fl zuixinzt\"><a >[" + time + "]</a></div></li>";
            }
            $("#tongbu_senior").html(html);
        }
    });
}

//
//同步练习-初中
//
function tongbu_junior(level) {
    $.post("../Subject/Study_skills", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 23 ? temp[i].name.substr(0, 23) : temp[i].name;
                if (i == 0) {
                    html += "<a href='../Download?cid=6&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_4'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=6&id=" + temp[i].id + "'><li><span class='li_left li_left_4'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
            }
            $("#tongbu_junior").html(html);
        }
    });
}

//
//教案-高中
//
function jiaoan_senior(level) {
    $.post("../Subject/Jiaoan", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li><div class=\"zxtlianjiediv fl\"><a class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a >" + text + "</a></div><div class=\"fl zuixinzt\"><a >[" + time + "]</a></div></li>";
            }
            $("#jiaoan_senior").html(html);
        }
    });
}

//
//教案-初中
//
function jiaoan_junior(level) {
    $.post("../Subject/Jiaoan", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 23 ? temp[i].name.substr(0, 23) : temp[i].name;
                if (i == 0) {
                    html += "<a href='../Download?cid=3&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_4'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=3&id=" + temp[i].id + "'><li><span class='li_left li_left_4'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
            }
            $("#jiaoan_junior").html(html);
        }
    });
}

//
//学案-高中
//
function xuean_senior(level) {
    $.post("../Subject/Xuean", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 13 ? temp[i].name.substr(0, 13) : temp[i].name;
                var number_str = (i + 1) + "";
                var number = number_str.length < 2 ? "0" + number_str : number_str;
                html += "<li><div class=\"zxtlianjiediv fl\"><a class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a >" + text + "</a></div><div class=\"fl zuixinzt\"><a >[" + time + "]</a></div></li>";
            }
            $("#xuean_senior").html(html);
        }
    });
}


//
//学案-初中
//
function xuean_junior(level) {
    $.post("../Subject/Xuean", { subjectname: subjectname, level: level }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var date;
            for (var i = 0; i < temp.length; i++) {
                date = new Date(temp[i].uploadtime);
                var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                var text = temp[i].name.length > 23 ? temp[i].name.substr(0, 23) : temp[i].name;
                if (i == 0) {
                    html += "<a href='../Download?cid=4&id=" + temp[i].id + "'><li><span style='color:red' class='li_left li_left_4'>" + text + "</span><span style='color:red' class='li_right'>" + time + "</span></li></a>";
                } else {
                    html += "<a href='../Download?cid=4&id=" + temp[i].id + "'><li><span class='li_left li_left_4'>" + text + "</span><span class='li_right'>" + time + "</span></li></a>";
                }
            }
            $("#xuean_junior").html(html);
        }
    });
}

//
//轮播图
//
function banner() {
    $.post("../Subject/GetBanner", { subjectname: subjectname }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            var html1 = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<li><img src='" + "http://www.5ihzy.com:82/" + temp[i].pic + "' alt='" + (i + 1) + "' title='" + (i + 1) + "' id='wows1_" + (i + 1) + "'></li>";
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

$(document).ready(function () {
    subjectname = GetQueryString("subjectname");
    beike_jingpin();
    test_jingpin();
    zhuanti_new_recommend_senior();
    zhuanti_new_recommend_junior();
    //最新试题-高中
    test_new_senior(" between 10 and 12");
    //最新试题-初中
    test_new_junior(" between 7 and 9");
    beikao_new("");
    moni_junior();
    //名校试题-高中
    test_mingxiao_senior(" between 10 and 12");
    //名校试题-初中
    test_mingxiao_junior(" between 7 and 9");
    //课件-高中
    kejian_senior(" between 10 and 12");
    //课件-初中
    kejian_junior(" between 7 and 9");
    //同步练习-高中
    tongbu_senior(" between 10 and 12");
    //同步练习-初中
    tongbu_junior(" between 7 and 9");
    //教案-高中
    jiaoan_senior(" between 10 and 12");
    //教案-初中
    jiaoan_junior(" between 7 and 9");
    //学案-高中
    xuean_senior(" between 10 and 12");
    //学案-初中
    xuean_junior(" between 7 and 9");
    banner();
    GetArea();
});

//点击span时，改变span样式
function change_css_span(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("title_middle_nav_span_select");
    });
    $(obj).addClass("title_middle_nav_span_select");
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
