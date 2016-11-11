/// <reference path="../Scripts/jquery-1.8.2.js" />



//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


var pageindex = 1;  //当前页数
var pagecount = 0; //总页数

var id;
var way;

//
//热门下载
//
function GetTest_Hot_Download() {
    $.post("../Elite_School/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp\">●</span>&nbsp;<a  class=\"rmxzaa\" href='../Download?cid=1&id=" + temp[i].id + "' target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'>" + text + "</a></li>";

            }
            $("#hot_download").html(html);
        }
    });
}

//
//相关推荐
//
function GetTest_Recommend() {
    $.post("../Elite_School/GetTest_Recommend", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < 11; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a class=\"rmxzaa rmxz2hv\" href='../Download?cid=1&id=" + temp[i].id + "' target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'>" + text + "</a></li>";
            }
            $("#recommend").html(html);
        }
    });
}

//
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#data_list_td").offset().top }, 500);
}

//
//获取试题数据
//
function GetList() {
    $.post("../Special/GetList", { id: id, way: way, pageindex: pageindex }, function (data) {
        if (data) {
            var html = "            <div class=\"lxclan mar_lf_0\">\
                <b class=\"bix\">" + title_name + "</b>\
            </div>";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    for (var i = 0; i < temp.length; i++) {
                        date = new Date(temp[i].pubdate);
                        var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                        var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                        html += "<div class=\"lxc_320\">\
                                <a class=\"wdk fl\" href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "' target='_blank' ></a>\
                                <div class=\"wenbenkui fl\">\
                                    <a class=\"b320 font_size16 overf_com font_wb\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "' target='_blank'  title='" + text + "'>" + text + "</a><br>\
                                    <span class=\"lxcsp320\">下载扣点：" + temp[i].neednum + "点 " + temp[i].uploadtime + " 类型：" + Produce_TypeName(temp[i].category) + "</span>\
                                </div>\
                                <div class=\"xiazai fr\" style='position:static;width:45px;height:45px;margin-right: 15px;'>\
                                    <a class=\"xztb2 fr\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "' target='_blank' ></a>\
                                </div>\
                            </div>";
                    }
                }
            }
            $("#data_list_td").html(html);
            Produce_A_Signs();
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
    $.post("../Special/GetDataCount", { id: id, way: way }, function (data) {
        if (data) {
            $("#all_data_count").html("该章节（" + data + "份）");

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
    var html = "<a  class=\"anniu1 syy1\" onclick=\"anchor(this),pre_page()\">上一页</a>";
    var signs_length;
    if (pageindex >= pagecount - 3) {
        signs_length = (pagecount - pageindex) + 1;
    } else {
        signs_length = 5;
    }
    if (pageindex >= 2) {
        html += "<span class=\"anniusp1\">...</span>";
    }
    for (var i = 0; i < signs_length; i++) {
        flag = (i + 1);
        if (i == 0) {
            html += "<a  onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ") class=\"an" + flag + " pages_href_selected\"><span class=\"ysp" + flag + "\">" + (pageindex + i) + "</span></a>";
        } else {
            html += "<a  onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ") class=\"an" + flag + " pages_href_normal\"><span class=\"ysp" + flag + "\">" + (pageindex + i) + "</span></a>";
        }

        //if (i == 0) {
        //    html += "<a class='pages_href_selected' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        //} else {
        //    html += "<a class='pages_href_normal' onclick=anchor(this),A_Signs_selected(" + (pageindex + i) + ")>" + (pageindex + i) + "</a>";
        //}
    }
    if (pageindex <= pagecount - 5) {
        html += "<span class=\"anniusp\">...</span>";
    }
    html += "<a class=\"anniu1 xiaan2 xyy1\" onclick=\"anchor(this),next_page()\">下一页</a>\
        <span class=\"anniusp2\">跳转到</span>\
        <input type=\"text\" class=\"tzsr\" id=\"page_size\" value=\"\" onkeyup = \"in_enter_key_fun(event)\">\
        <a class=\"an87\" id=\"data_go\" onclick=\"anchor(this),Go()\">G O</a>";
    $("#pages").html(html);
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
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}
var title_name;
$(document).ready(function () {
    StartReading("data_list_td");
    GetTest_Hot_Download();
    GetTest_Recommend();
    id = GetQueryString("id");
    way = GetQueryString("way");
    title_name = GetQueryString("name");
    $("#title_left").html(name);
    GetDataCount();
    GetList();
});


//
//下载
//
function DownLoad(id, cid) {
    $.post("../Download/GetInformation", { id: id, category: cid }, function (data) {
        if (data) {
            var models = eval(data);
            var m = models[0];
            $.post("../Download/DownLoad", {
                id: id,
                category: cid
            }, function (result) {
                switch (result) {
                    case "0":
                        var return_url = location.href;
                        location.href = '../Login?return_url=' + return_url;
                        break;
                    case "1":
                        //下载
                        location.href = "http://www.5ihzy.com:82" + m.filesrc;
                        break;
                    case "2":
                        message("与绑定IP不符, 不能下载");
                        break;
                    case "3":
                        message("该资源为精品资源,您的会员级别不够,不能下载");
                        break;
                    case "4":
                        message("您的账户余额不足,不能下载");
                        break;
                    case "5":
                        message("您的会员已过期且账户余额不足,不能下载");
                        break;
                    default:
                        break;
                }
            });
        }
    });
}

function message(text) {
    $("#message_content").html("系统提示: " + text);
    $("#message_download").click();
}

//
//解析类型名称
//
function Produce_TypeName(category) {
    var name = "";
    switch (category) {
        case "2":
            name = "课件";
            break;
        case "3":
            name = "教案";
            break;
        case "4":
            name = "学案";
            break;
        case "5":
            name = "素材";
            break;
        case "6":
            name = "同步";
            break;
        default:
            break;
    }
    return name;
}


//
//预览点击事件
//
function preview_show(url) {
    $("#download_preview").attr("src", url);
    $("#message_preview").click();
}