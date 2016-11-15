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
                        $("#school_star").html($("#school_star").html() + "<img src='../img/stars_red.png' />");
                    }

                    //介绍
                    $("#content").html(temp[i].content);
                    $("#pro_test_more").attr("href", "../Test_Center?district=" + temp[i].areaid);
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
                    html += "  <li class=\"jianju\"><a class=\"stcfh fl\">" + (i + 1) + "</a><a title='" + temp[i].testname.replace(" ", "-") + "'  href='../Download?cid=1&id=" + temp[i].id + "' class=\"fl wdwenben overf_com\">" + text + "</a><a href=\"\" class=\"fr rqbenxiao\">" + date + "</a></li>";

                }
                //学校试题ID, 填充代码
                $("#school_tests").html(html);
            } else {

                $("#school_tests").html("<div class=\"no_data_text\"></div>");
            }

        } else {
            
            $("#school_tests").html("<div class=\"no_data_text\"></div>");
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
                    html += " <li><a title='" + temp[i].title.replace(" ", "-") + "' href='../News_Detail?id=" + temp[i].id + "'>●" + text + "...</a></li>";
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
                    var text = temp[i].testname;
                    date = date.getFullYear() + "/" + Number(date.getMonth() + 1) + "/" + date.getDate();
                    //本省试题
                    if ((i + 1) % 2 != 0) {
                        html += " <div class=\"fl hgh\"><a href='../Download?cid=1&id=" + temp[i].id + "' class=\"bxst2f fl\">" + (i + 1) + "</a><a title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "' class=\"wenben2 fl overf_com\">" + text + "2016...</a><a href=\"\" class=\"fr rqbenxiao ys7\">" + date + "</a></div>";
                    } else {
                        html += " <div class=\"fl hgh mar_lf_120\"><a href='../Download?cid=1&id=" + temp[i].id + "' class=\"bxst2f fl\">" + (i + 1) + "</a><a title='" + temp[i].testname.replace(" ", "-") + "' href='../Download?cid=1&id=" + temp[i].id + "' class=\"wenben2 fl overf_com\">" + text + "2016...</a><a href=\"\" class=\"fr rqbenxiao ys7\">" + date + "</a></div>";
                    }

                }
                //本省试题ID, 填充代码
                $("#province_tests").html(html);
                $("#the_school_test_more").attr("href", "../The_School_Test?id=" + id + "&areaid=" + areaid);
            }
            else {

                $("#school_tests").html("<div class=\"no_data_text\"></div>");
            }
        }
        else {

            $("#school_tests").html("<div class=\"no_data_text\"></div>");
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
                    $("#president_head_img").html("<img src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" class=\"president_head_img_1\"/>");
                    //姓名
                    $("#president_name").html("校长:" + temp[i].name);
                    //简介
                    $("#president_description").html(temp[i].memo);

                    $("#president_more").removeClass("display_none");
                    $("#president_more_1").removeClass("display_none");

                    $("#president_more").attr("href", "../President_Special_Column?id=" + temp[i].id);

                    $("#president_more_1").attr("href", "../President_Special_Column?id=" + temp[i].id);
                    
                }
            } else {
                //照片
                $("#president_head_img").html("<img src=\"../img/p_1.png\" class=\"president_head_img_1\"/>");
                $("#president_more").addClass("display_none");
                $("#president_more_1").addClass("display_none");
                //简介
                $("#president_description").attr("style","height:82px");
            }
        } else {
            //照片
            $("#president_head_img").html("<img src=\"../img/p_1.png\" class=\"president_head_img_1\"/>");
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
           <a target=\"_blank\" href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'><img class=\"img_a_p\" src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" width=\"139px\" height=\"110px\" /></a>\
            <a target=\"_blank\" title='" + temp[i].name.replace(" ", "-") + "' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "' class=\"xxmingzi\"> " + text + "</a>\
        </div>";
                    } else
                    {
                        html += "        <div class=\"fl\" >\
           <a target=\"_blank\" href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "'><img class=\"img_a_p\" src=\"http://source.51kaoxue.com/" + temp[i].imgsrc + "\" width=\"139px\" height=\"110px\" /></a>\
            <a  target=\"_blank\" title='" + temp[i].name.replace(" ", "-") + "' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "' class=\"xxmingzi\"> " + text + "</a>\
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