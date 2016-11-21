/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var type=""; //类型编号
var typename = ""; //类型名称
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
var data_count = 0;
//
//高考动态
//
function GetTest_Hot_Download() {
    $.post("../Home/GetNews2", { type: 1 }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title;
                //html += "<li><a target='_blank' href='../News_Detail?id=" + temp[i].id + "'>" + text + "</a></li>";
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp_07c277\">●</span>&nbsp;<a target='_blank'  title='" + temp[i].title + "' href='../News_Detail?id=" + temp[i].id + "' target='_blank' class=\"rmxzaa_07c277\">" + text + "</a></li>";
            }
            $("#hot_download").html(html);
        }
    });
}

//
//教学方法
//
function GetTest_Recommend() {
    $.post("../Home/GetNews2", { type: 6 }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].title;
                //html += "<li><a target='_blank' href='../News_Detail?id=" + temp[i].id + "'>" + text + "</a></li>";
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp\">●</span>&nbsp;<a target='_blank'  title='" + temp[i].title + "' href='../News_Detail?id=" + temp[i].id + "' target='_blank' class=\"rmxzaa\">" + text + "</a></li>";
            }
            $("#recommend").html(html);
        }
    });
}

//
//获取新闻数据
//
function GetList() {
    $.post("../News/GetList", {pageindex: pageindex, type: type }, function (data) {
        if (data) {
            //onclick=\"javascript:window.open('../Download?cid=1&id=" + flag2[k].testid + "');\" target='_blank'
            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].title.length > 40 ? temp[i].title.substr(0, 40) : temp[i].title;

                    //var num = temp[i].content.indexOf("</table>"); 
                    //if (num != -1) {
                    //    var str = temp[i].content.substr(num+14, 80);
                    //} else {
                    //    var str = temp[i].content.substr(0, 80);
                    //}
                    
                    //var str_1 = str.replace(/<p>/g, "");
                    //var str_2 = str_1.replace(/<\/p>/g, "<br>");
                    html += "<div class=\"xwliebiao\" onclick=\"javascript:window.open('../News_Detail?id=" + temp[i].id + "');\">\
                            <div class=\"fl xwsc mar_lf_11\">\
                                <img src=\"img/xwtpshucai.png\" />\
                            </div>\
                        <div class=\"fl cswx\">";
                    html += "<b class=\"xwlbzt\">" + text + "</b>\
                    <div class=\"xwwby\">" + temp[i].content + "</div>";
                    html+="<img src=\"img/wenhao.png\" class=\"xwimg\" />\
                    <span class=\"xwgxsj color555\">\
                        更新时间:	 <span class=\"color555\">" + temp[i].pubdate + "</span>\
                    </span>\
                    <a target='_blank' class=\"xqhsankz\"><img src=\"img/xqhsan.png\" /></a>";
                    
                    html += "</div>\
                        </div>";
                    //if (i < (temp.length - 1)) {
                    //    html += "</div>\
                    //            </div>\
                    //            <div class=\"xwliebiao dkmgxz\">\
                    //                <div class=\"fl xwsc mar_lf_11\">\
                    //                    <img src=\"img/xwtpshucai.png\" />\
                    //                </div>\
                    //                <div class=\"fl cswx\">";
                    //}
                    
                }

            }
            $("#data_list_td").html(html);
            //Produce_A_Signs();
        }
    });
}

//
//上一页
//
function pre_page() {
    if (pageindex >= 2) {
        StartReading("data_list_td");
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
        StartReading("data_list_td");
        pageindex++;
        GetList();
    }
}

//
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../News/GetDataCount", { pageindex: pageindex, type: type }, function (data) {
        if (data) {
            $("#all_data_count").html("该章节（" + data + "份）");
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
    var pager = $("#pages").paging(data_count, {
        format: '[< nncnnn >]',
        perpage: 10,
        //onSelect: function (page) {
        //    // add code which gets executed when user selects a 
        //    //anchor(this);
        //    StartReading("data_list_td");
        //    pageindex = page;
        //    GetList();
        //},
        // Set up onclick handler
        onClick: function (ev) {

            ev.preventDefault();

            anchor(this);
            StartReading("data_list_td");

            var page = $(this).data('page');
            pageindex = page;
            GetList();

            // Call asynchronously, could be ajax, or whatever
            window.setTimeout(function () {
                pager.setPage(page);
            }, 1000);

        },
        onFormat: function (type) {
            switch (type) {
                case 'block': // n and c
                    if (!this.active)
                        return '<a disabled=\"disabled\" class=\"disabled\" href="#' + this.value + '">' + this.value + '</a>';
                    else if (this.value != this.page)
                        return '<a href="#' + this.value + '">' + this.value + '</a>';
                    return '<a  href="#" class="pager_selected">' + this.value + '</a>';
                case 'next': // >
                    if (this.active) {
                        return '<a href="#">下一页</a>';
                    }
                    return '<a href="#" disabled=\"disabled\" class=\"disabled\" >下一页</a>';

                case 'prev': // <
                    if (this.active) {
                        return '<a href="#" onclick=\"anchor(this);\">上一页</a>';
                    }
                    return '<a href="#" disabled=\"disabled\" class=\"disabled\">上一页</a>';
                case 'first': // [
                    if (this.active) {

                        return '<a href="#">首页</a>';
                    }
                    return '<a href="#" disabled=\"disabled\" class=\"disabled\">首页</a>';
                case 'last': // ]
                    if (this.active) {

                        return '<a href="#">末页</a>';
                    }
                    return '<a href="#" disabled=\"disabled\" class=\"disabled\">末页</a>';
            }
        }
    });
    //$("#pages").html(html);
}
//
//解析类型名称
//
function Produce_TypeName(category) {
    var name = "";
    switch (category) {
        case "1":
            name = "试题";
            break;
        case "2":
            name = "课件";
            break;
        case "3":
            name = "教案";
            break;
        case "4":
            name = "学案";
            break;
        case "6":
            name = "同步";
            break;
        case "5":
            name = "素材";
            break;
        case "7":
            name = "论文";
            break;
        case "8":
            name = "套题";
            break;
        case "9":
            name = "备课";
            break;
        default:
            break;
    }
    return name;
}

//
//页码被点击时
//
function A_Signs_selected(num) {
    pageindex = num;
    StartReading("data_list_td");
    GetList();
}

//
//Go按钮被点击时
//
function Go() {
    pageindex = Number($("#page_size").val());
    StartReading("data_list_td");
    GetList();
}

//
//类型选项被点击时
//
function type_selected(num) {
    pageindex = 1;
    category = num;
    GetDataCount();
    StartReading("data_list_td");
    GetList();
}

//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html("<div class=\"waiting_bg_1\"></div>");
}

//
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#anchor_id").offset().top }, 100);
}

$(document).ready(function () {
    typename = GetQueryString("typename");
    type = GetQueryString("type");
    if (typename != "" && typename != undefined && typename != null) {
        $("#title_left").html(typename);
    }
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetDataCount();
   GetList();
});