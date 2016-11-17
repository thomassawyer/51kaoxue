﻿/// <reference path="../Scripts/jquery-1.8.2.js" />

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
var data_count = 0;
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
                    html += "<li><img src=\"img/1tubiao.png\" class=\"rmxzdk\"><a target='_blank' target='_blank' class=\"rm1\"  onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + "> " + text + "</a></li>";
                } else if (i == 1) {
                    html += "<li><img src=\"img/2tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' target='_blank' class=\"rm2\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                } else if (i == 2) {
                    html += "<li><img src=\"img/3tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' target='_blank' class=\"rm3\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
                } else {
                    html += "<li><img src=\"img/" + (i + 1) + "tbbiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' target='_blank' onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title + ">" + text + "</a></li>";
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
                        html += "<li><img src=\"img/1tubiao.png\" class=\"rmxzdk\"><a target='_blank' class=\"rm1\"  onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + "> " + text + "</a></li>";
                    } else if (i == 1) {
                        html += "<li><img src=\"img/2tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' class=\"rm2\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + ">" + text + "</a></li>";
                    } else if (i == 2) {
                        html += "<li><img src=\"img/3tubiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' class=\"rm3\" onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + ">" + text + "</a></li>";
                    } else {
                        html += "<li><img src=\"img/" + (i + 1) + "tbbiao.png\" width=\"17px\" class=\"rmxzdk\"><a target='_blank' onclick='update_viewcount(" + temp[i].id + ")' title=" + temp[i].title.replace(" ", "-") + ">" + text + "</a></li>";
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
//获取国学数据
//
function GetList() {
    $.post("../Ancient_List/GetList", { pageindex: pageindex, category: third_id }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    html += "<div class=\"fenlei11\" onclick='update_viewcount(" + temp[i].id + ")'>\
                                <img src=\"img/shushuxian.png\"  class=\"shushu\">\
                                <a target='_blank'  target='_blank' class=\"fla\" >" + temp[i].title + "</a>\
                            </div>";
                }
            }
            $("#lists").html(html);
            $("#page_title").html(category_title);
            //Produce_A_Signs();
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
//接收键盘消息处理函数
//
function in_enter_key_fun(evt) {
    if (evt.keyCode) {
        if (evt.keyCode == 13) {
            Go();
        }
    }
}
//
//分页页码
//
function Produce_A_Signs() {
    //var html = "<a target='_blank'  class=\"anniu1 syy1\" onclick=\"anchor(this),pre_page()\">上一页</a>";
    //var signs_length;
    //if (pageindex >= pagecount - 3) {
    //    signs_length = (pagecount - pageindex) + 1;
    //} else {
    //    signs_length = 5;
    //}
    //if (pageindex >= 2) {
    //    html += "<span class=\"anniusp1\">...</span>";
    //}
    //for (var i = 0; i < signs_length; i++) {
    //    flag = (i + 1);
    //    if (i == 0) {
    //        html += "<a target='_blank'  target='_blank' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ") class=\"an" + flag + " pages_href_selected\"><span class=\"ysp" + flag + "\">" + (pageindex + i) + "</span></a>";
    //    } else {
    //        html += "<a target='_blank'  target='_blank' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ") class=\"an" + flag + " pages_href_normal\"><span class=\"ysp" + flag + "\">" + (pageindex + i) + "</span></a>";
    //    }

    //    //if (i == 0) {
    //    //    html += "<a target='_blank' class='pages_href_selected' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
    //    //} else {
    //    //    html += "<a target='_blank' class='pages_href_normal' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
    //    //}
    //}
    //if (pageindex <= pagecount - 5) {
    //    html += "<span class=\"anniusp\">...</span>";
    //}
    //html += "<a target='_blank' class=\"anniu1 xiaan2 xyy1\" onclick=\"anchor(this),next_page()\">下一页</a>\
    //    <span class=\"anniusp2\">跳转到</span>\
    //    <input type=\"number\" class=\"tzsr\" id=\"page_size\" value=\"\" min='1' max='" + pagecount + "'"+"onkeyup = \"in_enter_key_fun(event)\">\
    //    <a target='_blank' class=\"an87\" id=\"data_go\" onclick=\"anchor(this),Go()\">G O</a>";
    $("#pages").paging(data_count, {
        format: '[< nncnnn >]',
        perpage: 10,
        onSelect: function (page) {
            // add code which gets executed when user selects a 
            StartReading("lists");
            pageindex = page;
            GetList();
        },
        onFormat: function (type) {
            switch (type) {
                case 'block': // n and c
                    if (!this.active)
                        return '<span class="disabled">' + this.value + '</span>';
                    else if (this.value != this.page)
                        return '<em><a href="#' + this.value + '">' + this.value + '</a></em>';
                    return '<a  href="#" class="pager_selected">' + this.value + '</a>';
                case 'next': // >
                    return '<a href="#">下一页</a>';
                case 'prev': // <
                    return '<a href="#">上一页</a>';
                case 'first': // [
                    return '<a href="#">首页</a>';
                case 'last': // ]
                    return '<a href="#">末页</a>';
            }
        }
    });
    //$("#pages").html(html);
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

            data_count = Number(data);
            if (Number(data) % 10 == 0) {
                pagecount = data / 10;
            } else {
                pagecount = Math.floor((data / 10)) + 1;
            }

            Produce_A_Signs();
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
        $("html,body").animate({ scrollTop: $("#page_title").offset().top }, 500)
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
    $("#" + controlid).html("<div class=\"waiting_bg_1\"></div>");
}


$(document).ready(function () {
    StartReading("lists");
    third_id = GetQueryString("third_id");
    first_id = GetQueryString("first_id");
    category_title = GetQueryString("title");
    Reading_Lists();
    Relative_Recommend();
    GetDataCount();
  //  GetList();
});