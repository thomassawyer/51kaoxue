/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var level; //学段
var level_num;
var subject; //学科
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
var category = ""; //类型名称
var testcategory = ""; //试题类型
var grade = ""; // 年级
var district = ""; //地区
var para_subjectid;// 参数-学科
var para_type; //类型
var para_testcategory; // 试题类型
var para_testcategory_control = false;
var para_control = false; // 带参加载,控制变量
var para_type_control = false;
var data_count = 0;
//
//点击A标签时,改变A标签背景
//
function a_selected(obj,css) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css);
    });
    $(obj).addClass(css);
}

//
//点击学段A标签时,为学段变量赋值
//
function level_selected(num) {
    switch (num) {
        case 1:
            level = " between 1 and 6";
            level_num = 1;
            break;
        case 2:
            level = " between 7 and 9";
            level_num = 2;
            break;
        case 3:
            level = " between 10 and 12";
            level_num = 3;
            break;
        default:
            break;
    }
    pageindex = 1;
    subject=""; //学科
    category = ""; //类型名称
    testcategory = ""; //试题类型
    grade = ""; // 年级
    if (district == null)
        district = ""; //地区
    
    GetSubject();
    GetTestCategory();
    GetGrade();
    GetDataCount();
    StartReading("data_list_td");
    GetList();
    if (para_subjectid != undefined && para_subjectid != null && para_control == true) {
        setTimeout(function () {
            $("#subject" + para_subjectid).click();
            para_control = false;
        }, 1000);
    }
    if (para_type != undefined && para_type != null && para_type_control == true) {
        setTimeout(function () {
            $("#type" + para_type).click();
            para_type_control = false;
        }, 1000);
    }


        
    
}

//
//获取学科
//
function GetSubject() {
    $.post("../Test_Center/GetSubject", { level: level_num }, function (data) {
        if (data) {
            var html = "<div class=\"xd5_hover xdh33 fl xdh33_selected\" onclick=' a_selected(this, \"xdh33_selected\"), subject_selected(0)'>\
                        <a target='_blank'>全部</a>\
                    </div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div id=subject" + temp[i].id + " class=\"xd5_hover xdh33 fl\" onclick=' a_selected(this, \"xdh33_selected\"), subject_selected(" + temp[i].id + ")'>\
                        <a target='_blank'>"+ temp[i].name + "</a>\
                    </div>";
                }
            }
            $("#subject").html(html);
        }
    });
}

//
//点击学科A标签,为学科变量赋值
//
function subject_selected(subjectid) {
    pageindex = 1;
    subject = subjectid;
    
    GetDataCount();
    StartReading("data_list_td");
    GetList();
}

//
//获取试题类型
//
function GetTestCategory() {
    $.post("../Test_Center/GetTestCategory", { level: level_num }, function (data) {
        if (data) {
            var html = "<div class=\"stzx115 fl stzx115_selected\" onclick='a_selected(this, \"stzx115_selected\"), testcategory_selected(0) '><a target='_blank'>全部</a></div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div id=testcategory" + temp[i].id + " class=\"stzx115 fl\" onclick='a_selected(this, \"stzx115_selected\"), testcategory_selected(" + temp[i].id + ") '><a target='_blank'>" + temp[i].name + "</a></div>";
                }
            }
            $("#testcategory").html(html);

            if (para_testcategory != undefined && para_testcategory != null && para_testcategory_control == true) {
                setTimeout(function () {
                    $("#testcategory" + para_testcategory).click();
                    para_testcategory_control = false;
                }, 1000);
            }
            //$("#subject1").click();
        }
    });
}

//
//点击试题类型A标签,为试题类型变量赋值
//
function testcategory_selected(num) {
    pageindex = 1;
    testcategory = num;
    
    GetDataCount();
    StartReading("data_list_td");
    GetList();
}

//
//获取年级
//
function GetGrade() {
    $.post("../Test_Center/GetGrade", { level: level_num }, function (data) {
        if (data) {
            var html = "<div class=\"xd5_div1 fl xd5k1\"><img src=\"img/gongju.png\" class=\"xdtb5\"><a target='_blank' class=\"xd5a\"><b>年 级</b></a></div><div class=\"xd5_hover xdh5 fl xdh5_selected\" onclick='a_selected(this, \"xdh5_selected\"), grade_selected(0)'>\
                    <a target='_blank'>全部</a>\
                </div>";
            var temp;
            if (data != "]") {
                temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    html += "<div id=subject" + (i + 1) + " class=\"xd5_hover xdh5 fl\" onclick='a_selected(this, \"xdh5_selected\"), grade_selected(" + temp[i].id  +")'>\
                    <a target='_blank'>" + temp[i].name + "</a>\
                </div>";
                    
                }
            }
            $("#grade").html(html);
            //$("#subject1").click();
        }
    });
}
//
//点击年级A标签,为年级变量赋值
//
function grade_selected(num) {
    pageindex = 1;
    grade = num;
    GetDataCount();
    StartReading("data_list_td");
    GetList();
}

//
//热门下载
//
function GetTest_Hot_Download() {
    $.post("../Test_Center/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname;
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp\">●</span>&nbsp;<a target='_blank'  title='" + temp[i].testname + "' href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' class=\"rmxzaa\">" + text + "</a></li>";
            }
            $("#hot_download").html(html);
        }
    });
}

//
//相关推荐
//
function GetTest_Recommend() {
    $.post("../Test_Center/GetTest_Recommend", function (data) {
        if (data) {
            var temp = eval(data);
            var html ="";
            for (var i = 0; i < 11; i++) {
                var text = temp[i].testname;
                html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' title='" + temp[i].testname + "'  href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
            }
            $("#recommend").html(html);
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
            if (district.length != 0) {
                html = "<div class=\"xd5_hover xdh33 fl\" onclick='a_selected(this, \"district_selected\"), district_selected(0)'>\
                        <a target='_blank' target='_blank'>全部</a>\
                    </div>";
            } else {
                html = "<div class=\"xd5_hover xdh33 fl district_selected\" onclick='a_selected(this, \"district_selected\"), district_selected(0)'>\
                        <a target='_blank' target='_blank'>全部</a>\
                    </div>";
            }
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {

                    if (district == temp[i].id) {
                        html += "<div id=area" + (i + 1) + " class=\"xd5_hover xdh33 fl district_selected\" onclick='a_selected(this, \"district_selected\"), district_selected(" + temp[i].id + ")'>\
                        <a target='_blank'>" + temp[i].areaname + "</a>\
                    </div>";
                    } else {
                        html += "<div id=area" + (i + 1) + " class=\"xd5_hover xdh33 fl \" onclick='a_selected(this, \"district_selected\"), district_selected(" + temp[i].id + ")'>\
                        <a target='_blank'>" + temp[i].areaname + "</a>\
                    </div>";
                    }

                }
            }
            $("#district").html(html);
            //$("#subject1").click();
        }
    });
}

//
//点击地区A标签,为地区变量赋值
//
function district_selected(num) {
    pageindex = 1;
    district = num;
    
    GetDataCount();
    StartReading("data_list_td");
    GetList();
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
    $.post("../Test_Center/GetList", { subject: subject, level: level_num, testcategory: testcategory, grade: grade, district: district, pageindex: pageindex, category: category }, function (data) {
        if (data) {
            var html ="";
            if (data != "]") {
                $("#pages").removeClass("display_none");
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    html += "<div class=\"lxc_320\">\
                                <a target='_blank' class=\"wdk fl\" href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' ></a>\
                                <div class=\"wenbenkui fl\">\
                                    <a target='_blank' class=\"b320 font_size16 overf_com font_wb\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank'  title='" + text + "'>" + text + "</a><br>\
                                    <span class=\"lxcsp320\">下载扣点：" + temp[i].neednum + "点 " + temp[i].uploadtime + " 类型：" + Produce_TypeName(temp[i].category) + "</span>\
                                </div>\
                                <div class=\"xiazai fr\" style='position:static;width:45px;height:45px;margin-right: 30px;'>\
                                    <a target='_blank' class=\"xztb2 fr\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' target='_blank' ></a>\
                                </div>\
                            </div>";
                    //html += "<div class='data_list_td_container'><div class='data_list_td_container_left'><img src='../Images/%e5%a4%87%e8%af%be%e4%b8%ad%e5%bf%83/%e6%96%87%e6%a1%a3.png' /></div><div class='data_list_td_container_middle' style='width:500px'><div><span id='text_title'>" + text + "</span></div><div><span class='text_description'><span>下载扣点：<span id='download_point'>" + temp[i].neednum + "</span>点</span> <span id='text_date'>" + temp[i].uploadtime + "</span> <span>类型：<span id='text_type'>" + Produce_TypeName(temp[i].category) + "</span></span></span></div></div><div class='data_list_td_container_right'><a target='_blank' onclick=DownLoad(\"" + temp[i].id + "\",\"" + temp[i].category + "\") class='download_button download_button1'>直接下载</a><a target='_blank' onclick='preview_show(\"../Download_Child?id=" + temp[i].id + "&cid=" + temp[i].category + "\")' class='download_button download_button1'>预览</a></div></div>";
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
        async:false
    });
    $.post("../Test_Center/GetDataCount", { subject: subject, level: level_num, testcategory: testcategory, grade: grade, district: district, pageindex: pageindex, category: category }, function (data) {
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

$(document).ready(function () {
    para_control = true;
    para_type_control = true;
    para_testcategory_control = true;
    para_subjectid = GetQueryString("subjectid");
    para_type = GetQueryString("type");
    para_testcategory = GetQueryString("testcategory");
    district = GetQueryString("district");
    var para_level = GetQueryString("level");
    if (para_level != undefined && para_level != null) {
        $("#level" + para_level).click();
    } else {
        level_selected(3);
    }
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetArea();

    //$("#Test_Center_img").css({ 'display': 'block', 'right': '42px' });
    //$("#nav_rec_2").html("&nbsp;&gt;&nbsp;试题中心");
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
//预览点击事件
//
function preview_show(url) {
    $("#download_preview").attr("src", url);
    $("#message_preview").click();
}