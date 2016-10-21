﻿/// <reference path="../Scripts/jquery-1.8.2.js" />

var first_id;
//
//获取一级古文分类
//
function Get_First_Category() {
    $.post("../Ancient/Get_First_Category", function (data) {
        if (data) {
            var html = "";
            var temp;
            temp = eval(data);
            for (var i = 0; i < temp.length; i++) {
                if (i == 0) {
                    html += "<a class=\"condition_selected\" onclick=\" a_selected(this),type_selected(" + temp[i].id + ")\">" + temp[i].title + "</a>";
                } else {
                    html += "<a onclick=\"a_selected(this),type_selected(" + temp[i].id + ") \">" + temp[i].title + "</a>";
                }

            }
            $("#categories").html(html);
            type_selected(temp[0].id);

        }
    });
}

//
//一级分类点击事件
//
function type_selected(id) {
    Reading_Lists();
    first_id = id;
    Relative_Recommend();
    Get_Second_Category(id);
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
//获取二级古文分类
//
function Get_Second_Category(first_ids) {
    $.ajaxSetup({
        async: false
    });
    $.post("../Ancient/Get_Second_Category", { first_id: first_ids }, function (data) {
        if (data) {
            if (data != "]") {
                var html = "<div class=\"wxfl210 dkwxmg\">";
                var temp;
                if (data != "]") {
                    temp = eval(data);
                    for (var i = 0; i < temp.length; i++) {
                        var title_css = "";
                        if (i == 0) {
                            title_css = "genduoa";
                        } else if (i == 1) {
                            title_css = "genduoa gdlv";
                        } else if (i == 2) {
                            title_css = "genduoa gdlan";
                        } else if (i == 3) {
                            title_css = "genduoa gdalv1";
                        } else if (i == 4) {
                            title_css = "genduoa gdlan1";
                        } else {
                            title_css = "genduoa gdlan";
                        }
                        html += "<div class=\"gda1\"><a  class=\"" + title_css + "\" style=\"padding:0px 20px;\">" + temp[i].title + "</a></div>";
                        //获取三级分类
                        $.post("../Ancient/Get_Third_Category", { second_id: temp[i].id }, function (data1) {
                            if (data1) {
                                if (data1 != "]") {
                                    var flag = eval(data1);
                                    html += "<div class=\"chuchi1\">";
                                    for (var j = 0; j < flag.length; j++) {

                                        var bg = "";
                                        if (i == 0) {
                                            bg = "bg_yellow";
                                        } else if (i == 1) {
                                            bg = "bg_green";
                                        } else if (i == 2) {
                                            bg = "bg_blue";
                                        } else if (i == 3) {
                                            bg = "bg_lightgreen";
                                        } else if (i == 4) {
                                            bg = "bg_cyan";
                                        } else {
                                            bg = "bg_blue";
                                        }
                                        html += "<div class=\"ccimg1 cc2k fl\">\
                                                    <a  href=\"../Ancient_List?title=" + flag[j].title + "&first_id=" + first_id + "&third_id=" + flag[j].id + "\" class=\"bg " + bg + "\">" + flag[j].title + "</a>\
                                                </div>";
                                        if ((j + 1) % 9 == 0 && i != 0) {
                                            if ((j + 1) % 9 == 0 && j != 0 && j < flag.length) {
                                                html += "</div><div class=\"chuchi2\">";
                                            }
                                        }
                                    }
                                    html += "</div>";
                                }
                            }
                        });
                        if (temp[i].id == undefined || temp[i].id == "" || temp[i].id == null) {
                            continue;
                        }
                        if (i == 0) {
                            html += "</div>\
                                        <div class=\"wxfl210 wx201 wxmg\">";
                        } else if (i == 1) {
                            html += "</div>\
                                        <div class=\"wxfl210 wx202 wxmg\">";
                        } else if (i == 2) {
                            html += "</div>\
                                        <div class=\"wxfl210 wx203 wxmg\">";
                        } else if (i == 3) {
                            html += "</div>\
                                <div class=\"wxfl210 wx204 wxmg\">";
                        } else {
                            if (i == temp.length - 1) {
                                html += "</div>";
                            } else {
                                if (temp[i].id == undefined || temp[i].id == "" || temp[i].id == null) {
                                    continue;
                                } else {
                                    html += "</div>\
                                        <div class=\"wxfl210 wx202 wxmg\">";
                                }

                            }
                        }
                    }
                }
                //学校试题ID, 填充代码
                $("#category_content_left").html(html);
                $.ajaxSetup({
                    async: true
                });
            }
        }
    });

}

//
//阅读排行榜
//
function Reading_Lists() {
    $.post("../Ancient/Reading_Lists", function (data) {
        if (data) {
            var html = "";
            var temp;
            temp = eval(data);
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title.length > 10 ? temp[i].title.substr(0, 10) + "..." : temp[i].title;
                if (i == 0) {
                    html += "<li><img src=\"img/1tubiao.png\" class=\"rmxzdk\"><a class=\"rm1\"  onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + "> " + text + "</a></li>";
                } else if (i == 1) {
                    html += "<li><img src=\"img/2tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a class=\"rm2\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                } else if (i == 2) {
                    html += "<li><img src=\"img/3tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a class=\"rm3\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                } else {
                    html += "<li><img src=\"img/" + (i + 1) + "tbbiao.png\" width=\"17px\" class=\"rmxzdk\"><a onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                }

            }
            $("#Reading_List").html(html);
        }
    });
}

//
//相关推荐
//
function Relative_Recommend() {
    $.post("../Ancient/Relative_Recommend", { first_id: first_id }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp;
                temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].title.length > 10 ? temp[i].title.substr(0, 10) + "..." : temp[i].title;
                    if (i == 0) {
                        html += "<li><img src=\"img/1tubiao.png\" class=\"rmxzdk\"><a class=\"rm1\"  onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + "> " + text + "</a></li>";
                    } else if (i == 1) {
                        html += "<li><img src=\"img/2tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a class=\"rm2\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + ">" + text + "</a></li>";
                    } else if (i == 2) {
                        html += "<li><img src=\"img/3tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a class=\"rm3\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + ">" + text + "</a></li>";
                    } else {
                        html += "<li><img src=\"img/" + (i + 1) + "tbbiao.png\" width=\"17px\" class=\"rmxzdk\"><a onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + ">" + text + "</a></li>";
                    }

                }
            }
            $("#relative_recommend").html(html);
        }
    });
}

//
//更新浏览次数
//
function update_viewcount(id) {
    $.post("../Ancient_Article/Update_Viewcount", { id: id }, function (data) {
        if (data == "1") {
            location.href = '../Ancient_Article?id=' + id;
        }
    });
}

$(document).ready(function () {
    Get_First_Category();
});