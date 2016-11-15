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
                var text = temp[i].title.length > 10 ? temp[i].title.substr(0, 10) + "..." : temp[i].title;
                if (i == 0) {
                    html += "<li><img src=\"img/1tubiao.png\" class=\"rmxzdk\"><a target='_blank' class=\"rm1\"  onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + "> " + text + "</a></li>";
                } else if (i == 1) {
                    html += "<li><img src=\"img/2tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' class=\"rm2\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                } else if (i == 2) {
                    html += "<li><img src=\"img/3tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' class=\"rm3\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                } else {
                    html += "<li><img src=\"img/" + (i + 1) + "tbbiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
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
                    var text = temp[i].title.length > 10? temp[i].title.substr(0, 10) + "..." : temp[i].title;
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