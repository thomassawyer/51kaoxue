/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var level; //学段
var level_num;
var pageindex = 1;  //当前页数
var pagecount = 0; //总页数
var grade = ""; // 年级
var district; //地区
var district_control=false;

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

    
    pageindex = 1;
    grade = ""; // 年级
    district = ""; //地区
    district = GetQueryString("area");
    GetGrade();
    GetDataCount();
    StartReading("data_list_td");
    GetList();
}



//
//获取年级
//
function GetGrade() {
    $.post("../Elite_School/GetGrade", { level: level_num }, function (data) {
        if (data) {
            var html = "<a class='condition_selected' onclick='a_selected(this),grade_selected(0)'>全部</a>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {

                    html += "<a id=subject" + (i + 1) + " onclick=a_selected(this),grade_selected('" + temp[i].id + "')>" + temp[i].name + "</a>";

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
    $.post("../Elite_School/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 热门下载</span><a href='../Test_Center?type=1&level=3'><span class='directory_container_title_right'>More</span></a></div>";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 18 ? temp[i].testname.substr(0, 18) + "..." : temp[i].testname;
                if (i <= 2) {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left_red'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                } else {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                }

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
            var html = "<div class='directory_container_title'><span class='directory_container_title_left'>| 相关推荐</span><a href='../Test_Center?type=1&level=3'><span class='directory_container_title_right'>More</span></a></div>";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 18 ? temp[i].testname.substr(0, 18) + "..." : temp[i].testname;
                if (i <= 2) {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left_red'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                } else {
                    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='directory_container_text'><span class='directory_container_text_left'>·</span><span class='directory_container_text_right'>" + text + "</span></div></a>";
                }
            }
            $("#recommend").html(html);
        }
    });
}

//
//获取地区
//
function GetArea() {
    $.post("../Elite_School/GetArea", function (data) {
        if (data) {
            var html = "<a class='condition_selected' onclick='a_selected(this),district_selected(0)'>全部</a>";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {

                    html += "<a id=area" + temp[i].id + " onclick=a_selected(this),district_selected('" + temp[i].id + "')>" + temp[i].areaname + "</a>";

                }
            }
            $("#district").html(html);
            //$("#subject1").click();
            if (district != "" && district != null && district != undefined && district_control == false) {
                $("#area" + district).click();
                district_control = true;
            }
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
function GetList() {
    $.post("../Elite_School/GetList", { level: level_num, grade: grade, district: district, pageindex: pageindex }, function (data) {
        if (data) {

            var html = "";
            if (data != "]") {
                var temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name.length > 40 ? temp[i].name.substr(0, 40) : temp[i].name;
                    html += "<a href='../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "'><div class='data_list_td_container'><div class='data_list_td_container_left'><img src='../Images/%e5%a4%87%e8%af%be%e4%b8%ad%e5%bf%83/%e6%96%87%e6%a1%a3.png' /></div><div class='data_list_td_container_middle' style=' width:500px;'><div><span id='text_title'>" + text + "</span></div><div><span class='text_description'><span><span id='download_point'></span></span> <span id='text_date'>" + temp[i].pubdate + "</span> <span><span id='text_type'></span></span></span></div></div><div class='data_list_td_container_right'><a  href='../Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "'  class='download_button download_button1'>下载</a></div></div></a>";
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
    $.post("../Elite_School/GetDataCount", { level: level_num, grade: grade, district: district, pageindex: pageindex}, function (data) {
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

$(document).ready(function () {
    
    level_selected(3);
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetArea();
});

