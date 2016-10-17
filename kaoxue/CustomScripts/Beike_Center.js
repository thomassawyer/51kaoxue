/// <reference path="../Scripts/jquery-1.8.2.js" />

var level; //学段
var level_num;
var subject; //学科
var version_first; //一级版本
var version_second;//二级版本
var version_third; //三级版本
var version_fourth; //四级版本
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
var category = ""; //类型名称
var click_title = "";  //当前被点击的节点名称
var para_type; //类型
var para_type_control = false;
//
//点击A标签时,改变A标签背景
//
function a_selected(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("condition_selected");
    });
    $(obj).addClass("condition_selected");
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
    GetSubject();
}

//
//获取学科
//
function GetSubject() {
    $.post("../Beike_Center/GetSubject", { level: level_num }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    if (i == 0) {
                        html += "<a class=condition_selected id=subject" + (i + 1) + " onclick=a_selected(this),subject_selected('" + temp[i].id + "')>" + temp[i].name + "</a>";
                    } else {
                        html += "<a id=subject" + (i + 1) + " onclick=a_selected(this),subject_selected('" + temp[i].id + "')>" + temp[i].name + "</a>";
                    }
                }
            }
            $("#subject").html(html);
            subject_selected(temp[0].id);
            //$("#subject1").click();
        }
    });
}

//
//点击学科A标签,为学科变量赋值
//
function subject_selected(subjectid) {
    subject = subjectid;
    GetVersion_First();
}

//
//获取一级版本
//
function GetVersion_First() {
    $.post("../Beike_Center/GetVersion_First", { subject: subject }, function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                if (i == 0) {
                    html += "<a class=condition_selected id=version_first" + (i + 1) + " onclick=a_selected(this),version_first_selected('" + temp[i].id + "')>" + temp[i].name + "</a>";
                } else {
                    html += "<a id=version_first" + (i + 1) + " onclick=a_selected(this),version_first_selected('" + temp[i].id + "')>" + temp[i].name + "</a>";
                }
            }
            $("#version_first").html(html);
            version_first_selected(temp[0].id);
            //$("#version_first1").click();
        }
    });
}

//
//点击一级版本A标签,为一级版本变量赋值
//
function version_first_selected(versionid) {
    version_first = versionid;
    GetVersion_Second();
}

//
//获取二级版本
//
function GetVersion_Second() {
    $.ajaxSetup({
        async: false
    });
    $.post("../Beike_Center/GetVersion_Second", { subject: subject, version_first: version_first }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    if (i == 0) {
                        html += "<a class=condition_selected id=version_second" + (i + 1) + " onclick=\"a_selected(this),version_second_selected('" + temp[i].id + "','" + temp[i].name + "')\">" + temp[i].name + "</a>";
                    } else {
                        html += "<a id=version_second" + (i + 1) + " onclick=\"a_selected(this),version_second_selected('" + temp[i].id + "','" + temp[i].name + "')\">" + temp[i].name + "</a>";
                    }
                }
            }
            $("#version_second").html(html);
            version_second_selected(temp[0].id, temp[0].name);
            //$("#version_second1").click();
        }
    });
}

//
//点击二级版本A标签,为二级版本变量赋值
//
function version_second_selected(versionid, title) {
    pageindex = 1;
    version_second = versionid;
    version_third = "";
    version_fourth = "";
    GetVersion_ThirdAndFourth();
    click_title = title;
    GetData();
    //GetList();
}

//
//获取三四级版本
//
function GetVersion_ThirdAndFourth() {
    Loading_start();
    $.ajaxSetup({
        async: false
    });
    setTimeout(function () {
        $.post("../Beike_Center/GetVersion_ThirdAndFourth", { subject: subject, version_second: version_second }, function (data) {
            if (data) {
                var temp;
                var flag;
                var title1 = "";
                var title2 = "";
                var html = "<div id='directory_title' class='middle_content_bottom_text_left_title'><span class='title_left'>| 章节单元</span></div><div id='directory_title1'>全部</div>";
                if (data != "]") {
                    temp = eval(data);
                    for (var i = 0; i < temp.length; i++) {
                        html += "<div class='tree_title'><a id=directory" + (i + 1) + "  onclick=\"anchor(this),tree_title_selected('" + temp[i].id + "','" + temp[i].name + "')\"><span>" + temp[i].name + "</span></a></div>";
                        $.post("../Beike_Center/GetVersion_ThirdAndFourth", { subject: subject, version_second: temp[i].id }, function (data1) {
                            if (data1) {
                                if (data1 != "]") {
                                    flag = eval(data1);
                                    html += "<div class='tree_content'><ul>";
                                    for (var j = 0; j < flag.length; j++) {
                                        html += "<li><a id=drectory" + (i + 1) + "" + (j + 1) + " onclick=\"anchor(this),tree_content_li_selected('" + flag[j].id + "','" + flag[j].name + "')\"><span class='tree_flag'>·</span>" + flag[j].name + "</a></li>";
                                        //
                                        $.post("../Beike_Center/GetVersion_ThirdAndFourth", { subject: subject, version_second: flag[j].id }, function (data2) {

                                            if (data2) {
                                                if (data2 != "]") {
                                                    var para_others = eval(data2);  //节
                                                    for (var l = 0; l < para_others.length; l++) {
                                                        html += "<li><a id=drectory" + (i + 1) + "" + (j + 1) + "" + (l + 1) + " onclick=\"anchor(this),tree_content_li_selected('" + para_others[l].id + "','" + para_others[l].name + "')\"><span class='tree_flag'>·</span>" + para_others[l].name + "</a></li>";
                                                    }
                                                }
                                            }

                                        });
                                        //
                                    }
                                    html += "</ul></div>";
                                }

                            }
                        });
                        if (i == 0) {
                            if (temp != undefined) {
                                if (temp[0].id != undefined)
                                    title1 = temp[0].id;
                            }
                            if (flag != undefined) {
                                if (flag[0].id != undefined)
                                    title2 = flag[0].id;
                            }
                        }
                    }
                }
                $("#directory").html(html);
            }
        });
        $.ajaxSetup({
            async: true
        });
        Loading_end();
    }, 1000);
}

//
//点击章节一级标题A标签,为其变量赋值
//
function tree_title_selected(versionid, title) {
    pageindex = 1;
    version_fourth = "";
    version_third = versionid;
    click_title = title;
    GetData();
    //tree_content_li_selected("");
}

//
//点击章节二级标题A标签,为其变量赋值
//
function tree_content_li_selected(versionid, title) {
    pageindex = 1;
    version_fourth = versionid;
    click_title = title;
    GetData();
}

function GetData() {
    GetDataCount();
    GetDataCount_Direction();
    StartReading("data_list_td");
    GetList();
}

//
//数据列表锚点
//
function anchor(obj) {
    if ($(obj).offset().top > 1400)
        $("html,body").animate({ scrollTop: $("#data_list").offset().top }, 500)
}

//
//获取备课数据
//
function GetList() {
    $.post("../Beike_Center/GetList", { subject: subject, level: level_num, version_first: version_first, version_second: version_second, version_third: version_third, version_fourth: version_fourth, pageindex: pageindex, category: category }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    html += "<div class='data_list_td_container'><div class='data_list_td_container_left'><img src='../Images/%e5%a4%87%e8%af%be%e4%b8%ad%e5%bf%83/%e6%96%87%e6%a1%a3.png' /></div><div class='data_list_td_container_middle'><div><span id='text_title'>" + text + "</span></div><div><span class='text_description'><span>下载扣点：<span id='download_point'>" + temp[i].neednum + "</span>点</span> <span id='text_date'>" + temp[i].uploadtime + "</span> <span>类型：<span id='text_type'>" + Produce_TypeName(temp[i].category) + "</span></span></span></div></div><div class='data_list_td_container_right'><a onclick=DownLoad(\"" + temp[i].id + "\",\"" + temp[i].category + "\") class='download_button download_button1'>直接下载</a><a onclick='preview_show(\"../Download_Child?id=" + temp[i].id + "&cid=" + temp[i].category + "\")' class='download_button download_button1'>预览</a></div></div>";
                }
            }
            $("#data_list_td").html(html);
            Produce_A_Signs();
            if (para_type != undefined && para_type != null && para_type_control == true) {
                setTimeout(function () {
                    $("#type" + para_type).click();
                    para_type_control = false;
                }, 1000);
            }
        }
    });
}

//
//获取某小节数据条数
//
function GetDataCount() {

    $.post("../Beike_Center/GetDataCount", { subject: subject, level: level_num, version_first: version_first, version_second: version_second, version_third: version_third, version_fourth: version_fourth, pageindex: pageindex, category: category }, function (data) {
        if (data) {
            $("#all_data_count").html(click_title + "（" + data + "份）");
            if (Number(data) % 10 == 0) {
                pagecount = data / 10;
            } else {
                pagecount = Math.floor((data / 10)) + 1;
            }
        }

    });
}

//
//获取某版本数据条数
//
function GetDataCount_Direction() {
    $.post("../Beike_Center/GetDataCount_Direction", { subject: subject, level: level_num, version_first: version_first, version_second: version_second, version_third: version_third, version_fourth: version_fourth, pageindex: pageindex, category: category }, function (data) {
        if (data) {
            $("#all_data_count_directory").html("该科目（" + data + "份）");
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
    GetDataCount_Direction();
    StartReading("data_list_td");
    GetList();
}

//
//预览点击事件
//
function preview_show(url) {
    $("#download_preview").attr("src", url);
    $("#message_preview").click();
}
//
//数据读取动画
//
function StartReading(controlid) {
    var html = "<br/><br/><br/><br/><div class='loader1'><i></i><i></i></div>";
    $("#" + controlid).html(html);
}

function Loading_start() {
    $("#message_start").click();

}

function Loading_end() {
    $("#message_close").click();
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}



$(document).ready(function () {
    para_type_control = true;
    para_type = GetQueryString("type");
    var level = GetQueryString("level");
    if (level != "" && level != null && level != undefined) {
        $("#level_button" + level).click();
    }
    else {
        level_selected(3);
    }
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