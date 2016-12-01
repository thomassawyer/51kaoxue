/// <reference path="../Scripts/jquery-1.8.2.js" />



//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var data_count = 0;
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
                var text = temp[i].testname;
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp\">●</span>&nbsp;<a target='_blank'  class=\"rmxzaa\" href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'>" + text + "</a></li>";

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
                var text = temp[i].testname;
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' class=\"rmxzaa rmxz2hv\" href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' title='" + temp[i].testname.replace(" ", "-") + "'>" + text + "</a></li>";
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
        $("html,body").animate({ scrollTop: $("#anchor_id").offset().top }, 100);
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
                $("#pages").removeClass("display_none");
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
                                <a target='_blank' class=\"wdk fl\" href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' ></a>\
                                <div class=\"wenbenkui fl\">\
                                    <a target='_blank' class=\"b320 font_size16 overf_com font_wb\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank'  title='" + text + "'>" + text + "</a><br>\
                                    <span class=\"lxcsp320\">下载扣点：" + temp[i].neednum + "点 " + "&nbsp;&nbsp;时间：" + temp[i].uploadtime + "</span>\
                                </div>\
                                <div class=\"xiazai fr\" style='position:static;width:45px;height:45px;margin-right: 30px;'>\
                                    <a target='_blank' class=\"xztb2 fr\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' ></a>\
                                </div>\
                            </div>";
                    }
                }
            }
            else {
                $("#pages").addClass("display_none");
                html += "<div class=\"no_data_bg\"></div>";
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
    $.post("../Special/GetDataCount", { id: id, way: way }, function (data) {
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
    $("#" + controlid).html("<div class=\"waiting_bg_1\"></div>");
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