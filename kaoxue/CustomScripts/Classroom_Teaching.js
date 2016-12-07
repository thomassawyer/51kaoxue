/// <reference path="../Scripts/jquery-1.8.2.js" />

//
//点击A标签时,改变A标签背景
//
function a_selected(obj, css) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css);
    });
    $(obj).addClass(css);
}

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var subjectid; //科目编号
var gradeid;//年级编号
var category; //视频类型
var chaper; //章节编号


//
//获取所有视频分类
//

function GetVideoType() {
    $.post("../Classroom_Teaching/GetVideoType", function (data) {
        if (data) {
            var html = "<div class=\"xd5_div1 fl\"><img src=\"img/duanluo.png\" class=\"xdtb5\"><a target='_blank' class=\"xd5a\"><b>视 频</b></a></div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div class=\"xd5_hover fl\" id=\"videotype_button" + temp[i].id + "\" onclick=\"a_selected(this, 'xd5_hover_selected'), videotype_selected(" + temp[i].id + ")\">\
                                <a target='_blank'>" + temp[i].videoType + "</a>\
                            </div>";
                }
            }
            $("#GetVideoType").html(html);
            if (category != "" && category != null && category != undefined) {
                $("#videotype_button" + category).trigger("click");
            } else {
                $("#videotype_button0").trigger("click");
            }
            
        }
    });
}

//
//视频分类点击事件
//
function videotype_selected(num) {
    category = num;
    GetGrade();
}

//
//获取所有年级
//
function GetGrade() {
    $.post("../Classroom_Teaching/GetGrade", function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div class=\"xd5_hover xdh33 fl\" id='grade_button" + i + "' onclick=\"a_selected(this, 'xdh33_selected'), grade_selected(" + temp[i].id + ")\">\
                                <a target=\"_blank\">" + temp[i].name + "</a>\
                            </div>";
                }
            }
            $("#GetGrade").html(html);
            $('#grade_button0').trigger("click");
        }
    });
}

//
//年级点击事件
//
function grade_selected(num) {
    gradeid = num;
    produce_level();
    GetSubject();
}
var level;

function produce_level() {
    if (gradeid > 9) {
        level = 3;
    } else if (gradeid > 6) {
        level = 2;
    } else {
        level = 1;
    }
}

//
//获取科目
//
function GetSubject() {
    $.post("../Classroom_Teaching/GetSubject", { level: level }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div class=\"stzx115 fl  stzx85\" id='subject_button" + i + "'  onclick=\"a_selected(this, 'stzx115_selected'), subject_selected(" + temp[i].id + ")\">\
                                <a target=\"_blank\">"+ temp[i].name + "</a>\
                            </div>";
                }
            }
            $("#GetSubject").html(html);
            $('#subject_button0').trigger("click");
        }
    });
}

function subject_selected(num) {
    subjectid = num;
    GetParentChaper();
    GetList();
}

//
//获取章节
//
function GetParentChaper() {
    $("#GetParentChaper").html("<div class=\"waiting_bg\"></div>");
    $.ajaxSetup({
        async: false
    });
    $.post("../Classroom_Teaching/GetParentChaper", { subjectid: subjectid, gradeid: gradeid, videoid: category }, function (data) {
        if (data) {
            var html = "<div class=\"lianxice33\"><a target=\"_blank\">章节单元</a></div>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div class=\"lx136 zjie fl\" style=\"height:auto;\">\
                <ul>\
                    <li><a id=\"directory1\"><b class=\"ce33b\">" + temp[i].chapterName + "</b></a></li>";
                    //获取子级章节
                    $.post("../Classroom_Teaching/GetChildChaper", { fid: temp[i].id }, function (data1) {
                        if (data1) {
                            var flag;
                            if (data1 != "]") {
                                flag = eval(data1);
                                for (var j = 0; j < flag.length; j++) {
                                    html += "<li><a id=\"drectory11\" onclick=\"anchor(this),tree_content_li_selected('" + flag[j].id + "')\">" + flag[j].chapterName + "</a></li>";
                                }
                            }
                        }
                    });
                    html += "</ul>\
                            </div>";
                }
                $.ajaxSetup({
                    async: true
                });
            } else {
                html += "<img src=\"../img/210.png\" />";
            }
            $("#GetParentChaper").html(html);
        }
    });
}

function tree_content_li_selected(id) {
    pageindex = 1;
    chaper = id;
    GetList();
}

//
//获取某小节数据条数
//
function GetDataCount() {
    $.ajaxSetup({
        async: false
    });
    $.post("../Classroom_Teaching/GetDataCount", { subjectid: subjectid, gradeid: gradeid, category: category, chaper: chaper }, function (data) {
        if (data) {
            $("#all_data_count").html("视频（"+data+"个）");
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
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#GetList").offset().top }, 100)
}
var pageindex = 1;

//
//获取视频数据
//
function GetList() {
    GetDataCount();
    $.post("../Classroom_Teaching/GetList", { subjectid: subjectid, gradeid: gradeid, category: category, chaper: chaper, pageindex: pageindex }, function (data) {
        if (data) {
            $("#pages").removeClass("display_none");
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    var url = temp[i].videoImageUrl == "" ? "../img/232-152.png" : temp[i].videoImageUrl;
                    date = new Date(temp[i].updateTime);
                    var time =  date.getYear().toString() + "-" + ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    html += "<div class=\"item fl mar_rg_22\"  onclick=\"javascript:window.open('../VideoPlay?id=" + temp[i].id + "')\">\
                        <div class=\"item_hover\"></div>\
                        <img src=\"" + url + "\" class=\"item_img\">\
                        <div class=\"item_title\">\
                            <div class=\"item_title_name\">\
                                <p class=\"item_title_name_o\">" + temp[i].title + "</p>\
                                <p class=\"item_title_name_s\">主讲老师：" + temp[i].teacherName + "</p>\
                            </div>\
                            <div class=\"item_title_time\">\
                                <span class=\"item_title_time_o fl\">"+time+"</span>\
                                <span class=\"item_title_time_s fr\">已播放" + temp[i].viewingTimes + "次</span>\
                            </div>\
                        </div>\
                    </div>";
                }
            }
            else {
                $("#pages").addClass("display_none");
                html += "<div class=\"no_data_bg\"></div>";
            }
            $("#GetList").html(html);
        }
    });
}
var data_count;
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

$(document).ready(function () {
    category = GetQueryString("category");
    GetVideoType();
});