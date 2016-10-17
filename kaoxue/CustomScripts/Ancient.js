/// <reference path="../Scripts/jquery-1.8.2.js" />

var first_id;
//
//获取一级古文分类
//
function Get_First_Category() {
    $.post("../Ancient/Get_First_Category", function (data) {
        if (data) {
            var html = "";
            var temp;
            temp = eval(data);
            for (var i = 0; i < temp.length; i++) {
                if (i == 0) {
                    html += "<a class=\"condition_selected\" onclick=\" a_selected(this),type_selected(" + temp[i].id + ")\">" + temp[i].title + "</a>";
                } else {
                    html += "<a onclick=\"a_selected(this),type_selected(" + temp[i].id + ") \">" + temp[i].title + "</a>";
                }
                
            }
            $("#categories").html(html);
            type_selected(temp[0].id);
           
        }
    });
}

//
//一级分类点击事件
//
function type_selected(id) {
    Reading_Lists();
    first_id = id;
    Relative_Recommend();
    Get_Second_Category(id);
}

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
//获取二级古文分类
//
function Get_Second_Category(first_ids) {
    $.ajaxSetup({
        async: false
    });
    $.post("../Ancient/Get_Second_Category", { first_id: first_ids }, function (data) {
        if (data) {
            if (data != "]") {
                var html = "";
                var temp;
                if (data != "]") {
                    temp = eval(data);
                    for (var i = 0; i < temp.length; i++) {
                        html += "<div class=\"category_content_left_container\">\
                        <div class=\"book\">\
                            <div class=\"book_title\">";

                        html += "<span>" + temp[i].title + "</span>";
                        html += "</div>\
                        </div>\
                        <div class=\"book_categories\">\
                            <div class=\"book_categories_container\">";
                        //获取三级分类
                        $.post("../Ancient/Get_Third_Category", { second_id: temp[i].id }, function (data1) {
                            if (data1) {
                                if (data1 != "]") {
                                    var flag = eval(data1);
                                    for (var j = 0; j < flag.length; j++) {
                                        html += "<a href=\"../Ancient_List?title="+flag[j].title+"&first_id="+first_id+"&third_id="+flag[j].id+"\">"+flag[j].title+"</a><span class=\"book_seprate\">|</span>";
                                    }
                                }
                            }
                        });
                        html += "</div>\
                        </div>\
                    </div>";
                    }
                }
                //学校试题ID, 填充代码
                $("#category_content_left").html(html);
                $.ajaxSetup({
                    async: true
                });
            }
        }
    });
    
}

//
//阅读排行榜
//
function Reading_Lists() {
    $.post("../Ancient/Reading_Lists", function (data) {
        if (data) {
            var html = "";
            var temp;
            temp = eval(data);
            for (var i = 0; i < temp.length; i++) {
                if (i == 0) {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign1\">"+(i+1)+"</span>\
                                <div class=\"text_content\">"+temp[i].title+"</div>\
                            </div></a>";
                } else if(i==1) {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign2\">" + (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
                } else if (i == 2) {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign3\">" + (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
                } else {
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"text_container\">\
                                <span class=\"sign_normal\">" + (i + 1) + "</span>\
                                <div class=\"text_content\">"+ temp[i].title + "</div>\
                            </div></a>";
                }

            }
            $("#Reading_List").html(html);
        }
    });
}

//
//相关推荐
//
function Relative_Recommend() {
    $.post("../Ancient/Relative_Recommend",{first_id:first_id}, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp;
                temp = eval(data);
                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    date = date.getFullYear() + "-" + Number(date.getMonth() + 1) + "-" + date.getDate();
                    html += "<a onclick='update_viewcount(" + temp[i].id + ")' style='cursor:pointer;'><div class=\"relative_recommend_container\">\
                                <div class=\"relative_recommend_container_top\">\
                                    <span class=\"relative_recommend_container_top_left\">\
                                        ·\
                                    </span>\
                                    <span class=\"relative_recommend_container_top_right\">\
                                        "+ temp[i].title + "\
                                    </span>\
                                </div>\
                                <div class=\"relative_recommend_container_bottom\">\
                                    <span class=\"relative_recommend_container_bottom_left\">\
                                        浏览：" + temp[i].viewcounts + "\
                                    </span>\
                                    <span class=\"relative_recommend_container_bottom_right\">\
                                        "+ date + "\
                                    </span>\
                                </div>\
                            </div></a>";

                }
            }
            $("#relative_recommend").html(html);
        }
    });
}

//
//更新浏览次数
//
function update_viewcount(id) {
    $.post("../Ancient_Article/Update_Viewcount", { id: id }, function (data) {
        if (data == "1") {
            location.href = '../Ancient_Article?id=' + id;
        }
    });
}

$(document).ready(function () {
    Get_First_Category();
});