/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

var keyword = "";
var category_title = "";
var id = "";
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
                if (i == 0) {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign1\">"+ (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
                } else if (i == 1) {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign2\">" + (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
                } else if (i == 2) {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign3\">" + (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
                } else {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign_normal\">" + (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
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
    $.post("../Ancient/Relative_Recommend_By_Keywords", { keyword: keyword }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp;
                temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    date = date.getFullYear() + "-" + Number(date.getMonth() + 1) + "-" + date.getDate();
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"relative_recommend_container\">\
                                <div class=\"relative_recommend_container_top\">\
                                    <span class=\"relative_recommend_container_top_left\">\
                                        ·\
                                    </span>\
                                    <span class=\"relative_recommend_container_top_right\">\
                                        "+ temp[i].title + "\
                                    </span>\
                                </div>\
                                <div class=\"relative_recommend_container_bottom\">\
                                    <span class=\"relative_recommend_container_bottom_left\">\
                                        浏览：" + temp[i].viewcounts + "\
                                    </span>\
                                    <span class=\"relative_recommend_container_bottom_right\">\
                                        "+ date + "\
                                    </span>\
                                </div>\
                            </div></a>";

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

//
//获取数据
//
function getInformation() {
    $.post("../Ancient_Article/GetInformation", { id: id }, function (data) {
        if (data) {
            var temp = eval(data);
            var m = temp[0];
            $("#page_title").html(m.title);
            $("#lists").html(m.content);
            keyword = m.keyword;
            Reading_Lists();
            Relative_Recommend();
        }
    });
}

$(document).ready(function () {
    id = GetQueryString("id");
    getInformation();
});