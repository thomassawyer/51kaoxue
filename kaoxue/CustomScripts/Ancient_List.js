/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

var category = ""; //类型名称
var third_id = "";
var first_id = "";
var category_title = "";
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
    $.post("../Ancient/Relative_Recommend", { first_id: first_id }, function (data) {
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
//获取国学数据
//
function GetList() {
    $.post("../Ancient_List/GetList", { pageindex: pageindex, category: third_id }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    html += "<a onclick='update_viewcount("+temp[i].id+")' style='cursor:pointer;'><div class=\"data_list_td_container\">\
                            <div class=\"data_list_td_container_left\">\
                                <img src=\"../Images/%e5%a4%87%e8%af%be%e4%b8%ad%e5%bf%83/%e6%96%87%e6%a1%a3.png\">\
                            </div>\
                            <div class=\"data_list_td_container_middle\" style=\"width:500px\">\
                                <div>\
                                    <span id=\"text_title\">"+temp[i].title+"</span>\
                                </div>\
                            </div>\
                        </div></a>";
                }
            }
            $("#lists").html(html);
            $("#page_title").html(category_title);
            Produce_A_Signs();
        }
    });
}

//
//更新浏览次数
//
function update_viewcount(id) {
    $.post("../Ancient_Article/Update_Viewcount", { id: id }, function (data) {
        if (data == "1") {
            location.href = '../Ancient_Article?id='+id;
        }
    });
}

//
//分页页码
//
function Produce_A_Signs() {
    var html = "";
    var signs_length;
    if (pageindex >= pagecount - 3) {
        signs_length = (pagecount - pageindex) + 1;
    } else {
        signs_length = 5;
    }
    if (pageindex >= 2) {
        html += "<span>…</span>";
    }
    for (var i = 0; i < signs_length; i++) {
        if (i == 0) {
            html += "<a class='pages_href_selected' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        } else {
            html += "<a class='pages_href_normal' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        }
    }
    if (pageindex <= pagecount - 5) {
        html += "<span>…</span>";
    }
    $("#pages").html(html);
}

//
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../Ancient_List/GetDataCount", { pageindex: pageindex, category: third_id }, function (data) {
        if (data) {

            if (Number(data) % 10 == 0) {
                pagecount = data / 10;
            } else {
                pagecount = Math.floor((data / 10)) + 1;
            }
            $.ajaxSetup({
                async: true
            });
        }
    });
}

//
//页码被点击时
//
function A_Signs_selected(num) {
    pageindex = num;
    StartReading("lists");
    GetList();
}

//
//Go按钮被点击时
//
function Go() {
    pageindex = Number($("#page_size").val());
    StartReading("lists");
    GetList();
}

//
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#lists").offset().top }, 500)
}

//
//上一页
//
function pre_page() {
    if (pageindex >= 2) {
        StartReading("lists");
        pageindex--;
        GetList();
    } else {
        alert('已到达第一页');
    }
}
//
//下一页
//
function next_page() {
    if (pageindex <= (pagecount - 1)) {
        StartReading("lists");
        pageindex++;
        GetList();
    }
}

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}


$(document).ready(function () {
    StartReading("lists");
    third_id = GetQueryString("third_id");
    first_id = GetQueryString("first_id");
    category_title = GetQueryString("title");
    Reading_Lists();
    Relative_Recommend();
    GetDataCount();
    GetList();
});