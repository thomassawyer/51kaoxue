/// <reference path="../Scripts/jquery-1.8.2.js" />

var level; //学段
var level_num;
var district = ""; //地区
var data_count = 0;



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
    district = ""; //地区
    GetDataCount();
    //StartReading("data_list");
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
//点击地区A标签,为地区变量赋值
//
function district_selected(num) {
    pageindex = 1;
    district = num;

    GetDataCount();
    StartReading("data_list");
    GetList();
}

//
//点击学科A标签,为学科变量赋值
//
function subject_selected(subjectid) {
    pageindex = 1;
    subject = subjectid;

    GetDataCount();
    StartReading("data_list");
    GetList();
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
                    if (i == 0) {
                        html += "<li style=\"padding-top:20px;\"><a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + text + "'>●" + text + "<br /><span style=\"color:#bfbfbf;padding-left:10px;\">共计" + temp[i].testnum + "套题</span></a></li>";
                    } else {
                        html += "<li><a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + text + "'>●" + text + "<br /><span style=\"color:#bfbfbf;padding-left:10px;\">共计" + temp[i].testnum + "套题</span></a></li>";
                    }
                   
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
                    var text = temp[i].testname;
                    //html += "<div class=\"elite_school_recommends_container_top\">\
                    //                    <span class=\"sign_red\">·</span>\
                    //                    <div class=\"school_name\"><a target='_blank' href=\"../Download?cid=1&id="+ temp[i].id + "\" target=\"_blank\">" + text + "</a></div>\
                    //                </div>";
                    //html += "<li><a target='_blank' href=\"../Download?cid=1&id=" + temp[i].id + "\" target=\"_blank\">●" + text + "</a></li>";
                    html += "<li class=\"rmxzli overf_com\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' title='" + temp[i].testname + "'  href=\"../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "\" target='_blank' class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
                }
            }
            $("#test_recommend").html(html);
        }
    });
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
//获取学校数据
//
function GetList() {
    $.post("../School/GetList", { level: level_num, district: district, pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            html += "<div class=\"lxclan mar_lf_0\">\
                <img src=\"img/mxtubiao.png\" alt=\"\" class=\"rwimg\" />\
                <a target='_blank' target='_blank' class=\"bix dkbix\">名校列表</a>\
            </div>";
            if (data != "]") {
                var temp = eval(data);
                var date;
                $("#pages").removeClass("display_none");
                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].name;
                    date = new Date(temp[i].intime);
                    var time = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    html += "<div class=\"xz360\" style=\"width:100%;\">\
                <div class=\"fl\">\
                    <a target='_blank' class=\"img_a_p\" target ='_blank' href=\"../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + text + "\"><img src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" class=\"lsimg\" style=\"width:270px;height:200px;\" /></a></div>\
                <div class=\"fl neirong620\">\
                    <a target='_blank' target ='_blank' href=\"../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + text + "\" class=\"fz25\">" + temp[i].name + "</a>\
                    <div id=\"\" class=\"lssp\">\
                       " + temp[i].content + "\
                    </div>\
                    <span class=\"gxsjsp\">更新时间：<span>" + time + "</span>   |   类型：" + produce_type(temp[i].level) + "   |   校长：";
                    if (temp[i].headname == "") {
                        html += "<span  class=\"\" >暂无数据</span>";
                    } else {
                        html += "<a target='_blank' class=\"p_more_hover\" target ='_blank' href=\"../President_Special_Column?id=" + temp[i].headid + "&myTitle=" + temp[i].headname + "_" + temp[i].name + "校长" + "\">" + temp[i].headname + "</a>";
                    }
                    html += "   |   地区：" + temp[i].areaname + "</span>\
                    <a target='_blank' target ='_blank' href=\"../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + text + "\" class=\"xzhsan\"><img src=\"img/xqhsan.png\" alt=\"\" /></a>\
                </div>\
            </div>\
                    ";
                }
                $("#data_list").html(html);
                //Produce_A_Signs();
            } else {
                $("#pages").addClass("display_none");
                $("#data_list").html(html + "<div class=\"no_data_bg\"></div>");
            }
        }
    });
}
var pagecount = 0;
var pageindex = 0;

function produce_type(text) {
    var str = "";
    switch (text) {
        case 1:
            str= "小学";
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
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../School/GetDataCount", { level: level_num, district: district, pageindex: pageindex }, function (data) {
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
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html("<div class=\"waiting_bg_1\"></div>");
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
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#anchor_id").offset().top }, 100);
}


$(document).ready(function () {
    level_selected(3);
    GetArea();
    eliteschool_recommend();
    test_recommend();
    GetList();
    $("#School_img").css({ 'display': 'block', 'right': '21px' });
    $("#nav_rec_2").html("&nbsp;&gt;&nbsp;学校");
});