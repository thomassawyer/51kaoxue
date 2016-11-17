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
function a_selected(obj, css) {
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
    subject = ""; //学科
    category = ""; //类型名称
    testcategory = ""; //试题类型
    grade = ""; // 年级
    district = ""; //地区

    GetSubject();
    GetDataCount();
   // StartReading("data_list_td");
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
            var html = "<div class=\"xd5_hover  fl xdh33_selected\" onclick=' a_selected(this, \"xdh33_selected\"), subject_selected(0)'>\
                        <a target='_blank'>全部</a>\
                    </div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div id=subject" + temp[i].id + " class=\"xd5_hover fl\" onclick=' a_selected(this, \"xdh33_selected\"), subject_selected(" + temp[i].id + ")'>\
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
//热门下载
//
function GetTest_Hot_Download() {
    $.post("../Elite_School/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp\">●</span>&nbsp;<a target='_blank'  class=\"rmxzaa\">" + text + "</a></li>";
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
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
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
            var html = "<div class=\"xd5_hover fl district_selected\" onclick='a_selected(this, \"district_selected\"), district_selected(0)'>\
                        <a target='_blank'>全部</a>\
                    </div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {

                    html += "<div id=area" + (i + 1) + " class=\"xd5_hover fl \" onclick='a_selected(this, \"district_selected\"), district_selected(" + temp[i].id + ")'>\
                        <a target='_blank'>" + temp[i].areaname + "</a>\
                    </div>";
                }
            }
            $("#district").html(html);
            //$("#subject1").click();
        }
    });
}
//
//名校推荐
//

function eliteschool_recommend() {
    $.post("../President/EliteSchool_Recommend", function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].name.length > 10 ? temp[i].name.substr(0, 10) + "..." : temp[i].name;
                    //html += "<a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'><div class=\"elite_school_recommends_container\"><div class=\"elite_school_recommends_container_top\"><span class=\"sign_red\">·</span><div class=\"school_name\">" + text + "</div></div><div class=\"elite_school_recommends_container_bottom\">共计" + temp[i].testnum + "套题</div></div></a>";
                    html += "<li><a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'>●" + text + "<br />共计" + temp[i].testnum + "套题</a></li>";
                }
            }
            $("#elite_school_recommends").html(html);
        }
    });
}


//
//试题推荐
//

function test_recommend() {
    $.post("../President/Test_Recommend", function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                    //html += "<div class=\"elite_school_recommends_container_top\">\
                    //                    <span class=\"sign_red\">·</span>\
                    //                    <div class=\"school_name\"><a target='_blank' href=\"../Download?cid=1&id="+ temp[i].id + "\" target=\"_blank\">" + text + "</a></div>\
                    //                </div>";
                    //html += "<li><a target='_blank' href=\"../Download?cid=1&id=" + temp[i].id + "\" target=\"_blank\">●" + text + "</a></li>";
		    html += "<li class=\"rmxzli\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' title='" + temp[i].testname + "'  href=\"../Download?cid=1&id=" + temp[i].id + "\" target='_blank' class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
                }
            }
            $("#test_recommend").html(html);
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
        $("html,body").animate({ scrollTop: $("#data_list").offset().top }, 500);
}

//
//获取试题数据
//
//
//获取学校数据
//
function GetList() {
    $.post("../President/GetList", { level: level_num, district: district, pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            html += "<div class=\"lxclan mar_lf_0\">\
                <img src=\"img/renwu.png\" alt=\"\" class=\"rwimg\" />\
                <a target='_blank' target='_blank' class=\"bix dkbix\">校长列表</a>\
            </div>";
            if (data != "]") {
                var temp = eval(data);
                var date;
                $("#pages").removeClass("display_none");
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].intime);
                    var time = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    html += "<div class=\"xz360\" style=\"width:100%;\">\
                <div class=\"fl\">\
                    <a target='_blank' class=\"img_a_p\" target ='_blank' href=\"../President_Special_Column?id=" + temp[i].headid + "\"><img src=\"http://source.51kaoxue.com/" + temp[i].headimgsrc + "\" class=\"lsimg\" style=\"width:270px;height:200px;\" /></a></div>\
                <div class=\"fl neirong620\">\
                     <a target='_blank' target ='_blank' href=\"../President_Special_Column?id=" + temp[i].headid + "\" class=\"fz25\">" + temp[i].name + "&nbsp校长&nbsp" + temp[i].headname + "</a>\
                    <div id=\"\" class=\"lssp\">\
                       " + temp[i].memo + "\
                    </div>\
                    <span class=\"gxsjsp\">更新时间：<span>" + time + "</span>   |   类型：" + produce_type(temp[i].level) + "   |   学校：" + temp[i].name + "   |   地区：" + temp[i].areaname + "</span>\
                    <a target='_blank'  target ='_blank' href=\"../President_Special_Column?id="+ temp[i].headid + "\" class=\"xzhsan\"><img src=\"img/xqhsan.png\" alt=\"\" /></a>\
                </div>\
            </div>\
                    ";
                }
                $("#data_list").html(html);
                //Produce_A_Signs()
            } else {
                $("#pages").addClass("display_none");
                $("#data_list").html(html + "<div class=\"no_data_bg\"></div>");
            }
        }
    });
}

//
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
    $.post("../President/GetDataCount", { level: level_num, district: district, pageindex: pageindex }, function (data) {
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
function produce_type(text) {
    var str = "";
    switch (text) {
        case 1:
            str = "小学";
            break;
        case 2:
            str = "初中";
            break;
        case 3:
            str = "高中";
            break;
        default:
            str = "";
            break;
    }
    return str;
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
            StartReading("data_list");
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
    var para_level = GetQueryString("level");
    if (para_level != undefined && para_level != null) {
        $("#level" + para_level).click();
    } else {
        level_selected(3);
    }
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetArea();
    eliteschool_recommend();
    test_recommend();
});

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