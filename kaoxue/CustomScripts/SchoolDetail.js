/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
var id;
var areaid;
//
//获取学校信息
//
function GetSchoolInfo() {
    $.post("../SchoolDetail/GetSchoolInfo", { id: id }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    //学校信息
                    //学校名称
                    $("#school_name").html(temp[i].name);
                    //学校照片
                    $("#imgurl").attr("src", "http://source.51kaoxue.com/" + temp[i].imgsrc);
                    //星级
                    $("#school_star").html("");
                    for (var j = 0; j < temp[i].star; j++) {
                        $("#school_star").html($("#school_star").html() + "<img src='../Images/%e5%ad%a6%e6%a0%a1/%e5%a4%9a%e8%be%b9%e5%bd%a2%205.png' />");
                    }

                    //介绍
                    $("#content").html(temp[i].content);
                }
            }
        }
    });
}


//
//获取学校试题
//
function GetSchoolTest() {
    $.post("../SchoolDetail/GetSchoolTest", { id: id }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);
                for (var i = 0; i < temp.length; i++) {
                    var date = new Date(temp[i].uploadtime);
                    var text = temp[i].testname.length > 50 ? temp[i].testname.substr(0, 50) : temp[i].testname;
                    date = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    ////学校试题
                    //if (i == 0) {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container'><span class='school_tests_container_left_red'>" + (i + 1) + "</span><span class='school_tests_container_middle'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //} else if (i == 1) {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container'><span class='school_tests_container_left_orange'>" + (i + 1) + "</span><span class='school_tests_container_middle'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //} else if (i == 2) {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container'><span class='school_tests_container_left_yellow'>" + (i + 1) + "</span><span class='school_tests_container_middle'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //} else {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container'><span class='school_tests_container_left_gray'>" + (i + 1) + "</span><span class='school_tests_container_middle'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //}
                    html += "  <li class=\"jianju\"><a href='../Download?cid=1&id=" + temp[i].id + "' class=\"stcfh fl\">" + (i + 1) + "</a><a href=\"\" class=\"fl wdwenben\">" + text + "</a><a href=\"\" class=\"fl rqbenxiao\">" + date + "</a></li>";

                }
            }
            //学校试题ID, 填充代码
            $("#school_tests").html(html);
        }
    });
}

//
//校长专栏
//
function President_Special_Column() {
    $.post("../SchoolDetail/President_Special_Column", function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].title.length > 10 ? temp[i].title.substr(0, 10) : temp[i].title;
                    //校长专栏
                    //html += "<a href='../News_Detail?id="+temp[i].id+"'><div class='president_special_columns_container'><span class='sign_red'>·</span><span>" + text + "</span></div><a>";
                    html += " <li><a href='../News_Detail?id=" + temp[i].id + "'>●" + text + "...</a></li>";
                }
            }
            //校长专栏ID, 填充代码
            $("#president_special_columns").html(html);
        }
    });
}


//
//本省试题
//
function Province_Test() {
    $.post("../SchoolDetail/Province_Test", { areaid: areaid }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    var date = new Date(temp[i].uploadtime);
                    var text = temp[i].testname.length > 15 ? temp[i].testname.substr(0, 15) + "..." : temp[i].testname;
                    date = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    //本省试题
                    //if (i == 0) {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container1'><span class='school_tests_container_left_red'>" + (i + 1) + "</span><span class='school_tests_container_middle1'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //} else if (i == 1) {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container1'><span class='school_tests_container_left_orange'>" + (i + 1) + "</span><span class='school_tests_container_middle1'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //} else if (i == 2) {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container1'><span class='school_tests_container_left_yellow'>" + (i + 1) + "</span><span class='school_tests_container_middle1'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //} else {
                    //    html += "<a href='../Download?cid=1&id=" + temp[i].id + "'><div class='school_tests_container1'><span class='school_tests_container_left_gray'>" + (i + 1) + "</span><span class='school_tests_container_middle1'>" + text + "</span><span class='school_tests_container_right'>" + date + "</span></div></a>";
                    //}

                    //if ((i+1) % 2 != 0) {
                    //    html += "<div class='school_tests_container1_seprate'></div>";
                    //}
                    if ((i + 1) % 2 != 0) {
                        html += " <div class=\"fl hgh\"><a href='../Download?cid=1&id=" + temp[i].id + "' class=\"bxst2f fl\">" + (i + 1) + "</a><a href=\"\" class=\"wenben2 fl\">" + text + "2016...</a><a href=\"\" class=\"fl rqbenxiao ys7\">" + date + "</a></div>";
                    } else {
                        html += " <div class=\"fl hgh\" style=\"margin-left:120px;\"><a href='../Download?cid=1&id=" + temp[i].id + "' class=\"bxst2f fl\">" + (i + 1) + "</a><a href=\"\" class=\"wenben2 fl\">" + text + "2016...</a><a href=\"\" class=\"fl rqbenxiao ys7\">" + date + "</a></div>";
                    }

                }
            }
            //本省试题ID, 填充代码
            $("#province_tests").html(html);
            $("#the_school_test_more").attr("href", "../The_School_Test?id=" + id + "&areaid=" + areaid);
        }
    });
}


//
//校长介绍
//
function President_Introduce() {
    $.post("../SchoolDetail/President_Introduce", { id: id }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    //校长介绍
                    //照片
                    $("#president_head_img").html("<img src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" width=\"215\" height=\"130\" />");
                    //姓名
                    $("#president_name").html("校长:" + temp[i].name);
                    //简介
                    $("#president_description").html(temp[i].memo);

                    $("#president_more").attr("href", "../President_Special_Column?id=" + temp[i].id);
                }
            }
        }
    });
}


//
//相关名校
//
function Correlation_Elite_School() {
    $.post("../SchoolDetail/Correlation_Elite_School", { areaid: areaid }, function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    var text = temp[i].name.length > 9 ? temp[i].name.substr(0, 9) : temp[i].name;
                    //相关名校
                    //html += "<a href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'><div class=\"correlation_elite_schools_container\"><div><div class=\"school_img\"><img src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" width=\"131\" height=\"81\" /></div><div class=\"school_text\">" + text + " </div></div></div></a>";
                    if ((i + 1) != 1) {
                        html += "        <div class=\"fl\" style='margin-left:11px;'>\
           <img src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" width=\"139px\" height=\"110px\" />\
            <a href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "' class=\"xxmingzi\"> " + text + "</a>\
        </div>";
                    } else
                    {
                        html += "        <div class=\"fl\" >\
           <img src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" width=\"139px\" height=\"110px\" />\
            <a href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "' class=\"xxmingzi\"> " + text + "</a>\
        </div>";
                    }

                }
            }
            //相关名校ID, 填充代码
            $("#correlation_elite_schools").html(html);
        }
    });
}

$(document).ready(function () {
    id = GetQueryString("id");
    areaid = GetQueryString("areaid");
    GetSchoolInfo();
    GetSchoolTest();
    President_Special_Column();
    Province_Test();
    President_Introduce();
    Correlation_Elite_School();
});