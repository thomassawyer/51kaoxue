/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


function showorhidediv_province(controlid) {
    $("#middle_content_top_left_bottom").find('.nav_background_container').each(function () {
        $(this).slideUp();
        $(this).width(750);
    });
    $("#middle_content_top_left_bottom").find('.sign_reduce').each(function () {
        $(this).removeClass("sign_reduce").addClass("sign_add");
    });
    $("#" + controlid).prev().find(".sign_add").removeClass("sign_add").addClass("sign_reduce");
    $("#" + controlid).slideDown(function () {
        $("#" + controlid).animate({ width: "274px" });
    });
}

function News(type, controlid) {
    $.post("../Home/GetNews3", { type: type }, function (data) {
        if (data) {
            if (data) {
                var temp = eval(data);
                var html = "<ul class=\"ul1 fl mar_rg_45\">";
                var date;
                for (var i = 1; i <= temp.length; i++) {
                    date = new Date(temp[i - 1].pubdate);
                    var text = temp[i - 1].title;
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var number_str = (i) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                //    html += "<li><div style='width: 240px;' class=\"fl ul1div\"><a target='_blank' class=\"abt\">" + number + "</a>&nbsp;<a target='_blank' class=\"ul1a\" href='../News_Detail?id=" + temp[i - 1].id + "' title='" + temp[i - 1].title.replace(" ", "-") + "'>" + text + "</a></div><div class=\"fl\"><a target='_blank' class=\"ul1a\">[" + time + "]</a></div></li>";
                //    if (i % 6 == 0 && i != 0 && i < temp.length) {
                //        html += "</ul>\
                //<ul class=\"ul1 fl\">";
                    //    }
                    html += "<li class=\"font_size16\">\
                            <div class=\"fl overf_com color_ff\">\
                                <a target='_blank' class=\"btn dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl gkdt_240 overf_com color_ff\">\
                                <a target='_blank' class=\"color_ff line_hg_25\" href='../News_Detail?id=" + temp[i - 1].id + "&myTitle=" + text + "' title='" + temp[i - 1].title.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"color_ff  fr line_hg_25\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    if (i % 6 == 0 && i != 0 && i < temp.length) {
                        if (i / 6 >= 3) {
                            html += "</ul>\
                                <ul class=\"ul1 fl\">";
                        } else {
                            html += "</ul>\
                                <ul class=\"ul1 fl mar_rg_45\">";
                        }

                    }
                }
                html += "</ul>";
                $(controlid).html(html);
            }
        }
    });
}

var level;
//
//专题推荐
//
function zhuanti_tuijian() {
    $.post("../Grade/Zhunati_tuijian", { level: '=' + GetQueryString("level") }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].updatetime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    if (isNaN((date.getMonth() + 1))) {
                        time = "";
                    }
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += "<li>\
                            <div class=\"fl overf_com color_ff\">\
                                <a target='_blank' class=\"zxzt_btn_808ffb dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap color_ff\">\
                                <a target='_blank' class=\"color_ff\" href='../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"fr color_ff\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    //html += "<li><div class=\"zxtlianjiediv fl\"><a target='_blank' class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a target='_blank' href='../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a></div><div class=\"fl zuixinzt\"><a target='_blank' href=\"\">[" + time + "]</a></div></li>";
                }
            }
            $("#zhuanti_tuijian").html(html);
        }
    });
}

//
//精品备课
//

function beike_jingpin() {
    $.post("../Grade/Beike_jingpin", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += "<li>\
                            <div class=\"fl overf_com color_ff\">\
                                <a target='_blank' class=\"zxzt_btn_808ffb dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap color_ff\">\
                                <a target='_blank' class=\"color_ff\" href='Special/Beike?id=" + temp[i].id + "&way=2&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"fr color_ff\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    //html += "<li><div class=\"zxtlianjiediv fl\"><a target='_blank' class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a target='_blank' href='Special/Beike?id=" + temp[i].id + "&way=2&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a></div><div class=\"fl zuixinzt\"><a target='_blank' href=\"\">[" + time + "]</a></div></li>";
                }
            }
            $("#beike_jingpin").html(html);
        }
    });
}

//
//精品套题
//
function taoti_jingpin() {
    $.post("../Grade/Taoti_jingpin", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += "<li>\
                            <div class=\"fl overf_com color_ff\">\
                                <a target='_blank' class=\"zxzt_btn_808ffb dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap color_ff\">\
                                <a target='_blank' class=\"color_ff\" href='Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"fr color_ff\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    //html += "<li><div class=\"zxtlianjiediv fl\"><a target='_blank' class=\"zxzt_btn\"><span>" + number + "</span></a>&nbsp;<a target='_blank' href='Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a></div><div class=\"fl zuixinzt\"><a target='_blank' href=\"\">[" + time + "]</a></div></li>";
                }
            }
            $("#taoti_jingpin").html(html);
        }
    });
}

//
//名校套题
//

function taoti_mingxiao() {
    $.post("../Grade/Taoti_mingxiao", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].pubdate);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                //    html += "<li>\
				//				<div id=\"\" class=\"fl gkdt_270\">\
				//					<a target='_blank' class=\"gkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' href='Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "' class=\"gdkys\"> " + text + "</a>\
				//				</div>\
				//				<div class=\" fl\">\
				//					<a target='_blank' href=\"\" class=\"gkdttime\">["+ time + "]</a>\
                //    </div>\
                    //</li>";
                    html += " <li>\
                            <div class=\"fl overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap gkdttime\">\
                                <a target='_blank' class=\"gdkys\"  href='Special?id=" + temp[i].id + "&way=1&name=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#taoti_mingxiao").html(html);
        }
    });
}

//
//高考备战
//
function gaokao_beikao() {
    $.post("../Grade/Gaokao_beizhan", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                //    html+="<li>\
				//				<div id=\"\" class=\"fl gkdt_270\">\
				//					<a target='_blank' class=\"gkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "' title='" + temp[i].name.replace(" ", "-") + "' class=\"gdkys\"> " + text + "</a>\
				//				</div>\
				//				<div class=\" fl\">\
				//					<a target='_blank' href=\"\" class=\"gkdttime\">["+time+"]</a>\
                //    </div>\
                    //</li>";
                    html += " <li>\
                            <div class=\"fl overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap gkdttime\">\
                                <a target='_blank' class=\"gdkys\"  href='../Download?cid=" + temp[i].category + "&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#beizhangaokao").html(html);
        }
    });
}

//
//中考模拟
//
function moni_zhongkao() {
    $.post("../Grade/Moni_zhongkao", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                //    html += "<li>\
				//				<div id=\"\" class=\"fl gkdt_270\">\
				//					<a target='_blank' class=\"gkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' href='../Download?cid=1&id=" + temp[i].id + "' title='" + temp[i].testname.replace(" ", "-") + "' class=\"gdkys\"> " + text + "</a>\
				//				</div>\
				//				<div class=\" fl\">\
				//					<a target='_blank' href=\"\" class=\"gkdttime\">["+ time + "]</a>\
                //    </div>\
                    //</li>";
                    html += " <li>\
                            <div class=\"fl  overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap gkdttime\">\
                                <a target='_blank' class=\"gdkys\"  href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#monikao").html(html);
        }
    });
}

//
//高考模拟
//
function moni_gaokao() {
    $.post("../Grade/Moni_gaokao", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].testname;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    html += " <li>\
                            <div class=\"fl overf_com gkdttime\">\
                                <a target='_blank' class=\"gkdtbtn dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap gkdttime\">\
                                <a target='_blank' class=\"gdkys\"  href='../SpecialSubject?id=" + temp[i].id + "&name=" + temp[i].testname + "' title='" + temp[i].testname.replace(" ", "-") + "'> " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#monikao").html(html);
        }
    });
}

//
//精品课件
//
function Kejian_jingping() {
    $.post("../Grade/Kejian_jingping", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i+1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li>\
                    //        <div class=\"jpstli zxzhutiys\">\
                    //            <a target='_blank' class=\"fl btnjps btnjspt\">" + number + "</a><div class=\"fl jpstys jpys\"><a target='_blank' href='../Download?cid=2&id=" + temp[i].id + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a></div><div class=\"fl\">\
                    //                <a target='_blank' class=\"ayblue\">["+time+"]</a>\
                    //            </div>\
                    //        </div>\
                    //    </li>";
                    html += "<li>\
                            <div class=\"jpstli zxzhutiys\">\
                                <a target='_blank' class=\"fl btnjps btnjspt dot_data_com\">" + number + "</a><div class=\"fl jpstys jpys overf_com gkdttime\"><a target='_blank' href='../Download?cid=2&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a></div><div class=\"fr\" id=\"\">\
                                    <a target='_blank' class=\"ayblue\" >["+ time + "]</a>\
                                </div>\
                            </div>\
                        </li>";
                }
            }
            $("#kejian_jingpin").html(html);
        }
    });
}

//
//精品教案
//
function jiaoan_jingpin() {
    $.post("../Grade/Jiaoan_jingpin", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;

                    //html += "<li>\
                    //        <div class=\"fl gkdt_270\">\
                    //            <a target='_blank' class=\"gkdtbtn dkgkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' class=\"gdkys kylv\" href='../Download?cid=3&id=" + temp[i].id + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a>\
                    //</div>\
                    //<div class=\" fl\">\
                    //            <a target='_blank' class=\"gkdttime dkgkdttime\">["+time+"]</a>\
                    //        </div>\
                    //    </li>";
                    html += "<li>\
                            <div class=\"fl overf_com color07c277\">\
                                <a target='_blank' class=\"zxzt_btn_fff dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap overf_com color07c277\">\
                                <a target='_blank' class=\"color07c277\" href='../Download?cid=3&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"color07c277  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#jiaoan_jingpin").html(html);
        }
    });
}

//
//精品学案
//
function xuean_jingpin() {
    $.post("../Grade/Xuean_jingpin", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    //html += "<li>\
                    //        <div class=\"jpstli zxzhutiys\">\
                    //            <a target='_blank' class=\"fl btnjps btnjspt\">" + number + "</a><div class=\"fl jpstys jpys\"><a target='_blank' href='../Download?cid=4&id=" + temp[i].id + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a></div><div class=\"fl\">\
                    //                <a target='_blank' class=\"ayblue\">["+ time + "]</a>\
                    //            </div>\
                    //        </div>\
                    //    </li>";
                    html += "<li>\
                            <div class=\"jpstli zxzhutiys\">\
                                <a target='_blank' class=\"fl btnjps btnjspt dot_data_com\">" + number + "</a><div class=\"fl jpstys jpys overf_com gkdttime\"><a target='_blank' href='../Download?cid=4&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a></div><div class=\"fr\" id=\"\">\
                                    <a target='_blank' class=\"ayblue\" >["+ time + "]</a>\
                                </div>\
                            </div>\
                        </li>";
                }
            }
            $("#xuean_jingpin").html(html);
        }
    });
}

//
//精品练习
//
function lianxi_jingpin() {
    $.post("../Grade/Lianxi_jingpin", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;

                    //html += "<li>\
                    //        <div class=\"fl gkdt_270\">\
                    //            <a target='_blank' class=\"gkdtbtn dkgkdtbtn\">" + number + "</a>&nbsp;<a target='_blank' class=\"gdkys kylv\" href='../Download?cid=6&id=" + temp[i].id + "' title='" + temp[i].name.replace(" ", "-") + "'> " + text + "</a>\
                    //</div>\
                    //<div class=\" fl\">\
                    //            <a target='_blank' class=\"gkdttime dkgkdttime\">["+ time + "]</a>\
                    //        </div>\
                    //    </li>";
                    html += "<li>\
                            <div class=\"fl  overf_com color07c277\">\
                                <a target='_blank' class=\"zxzt_btn_fff dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap overf_com color07c277\">\
                                <a target='_blank' class=\"color07c277\" href='../Download?cid=6&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"color07c277  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#lianxi_jingpin").html(html);
        }
    });
}

//
//精品素材
//
function sucai_jingpin() {
    $.post("../Grade/Sucai_jingpin", { level: level }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    var text = temp[i].name;
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;

                    html += "<li>\
                            <div class=\"fl overf_com color07c277\">\
                                <a target='_blank' class=\"zxzt_btn_fff dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap overf_com color07c277\">\
                                <a target='_blank' class=\"color07c277\" href='../Download?cid=5&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].name.replace(" ", "-") + "'>" + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"color07c277  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                }
            }
            $("#sucai_jingpin").html(html);
        }
    });
}

//
//通过试题类型获取试题
//
function gettestbycategory(category, controlid,flag) {
    $.post("../Grade/GetTestByCategory", { level: level, category: category }, function (data) {
        if (data) {
            var html = "";
            if (data != "]") {
                var temp = eval(data);

                var date;
                for (var i = 0; i < temp.length; i++) {
                    date = new Date(temp[i].uploadtime);
                    var time = ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1).toString() : date.getMonth() + 1) + "-" + (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate());
                    
                    var number_str = (i + 1) + "";
                    var number = number_str.length < 2 ? "0" + number_str : number_str;
                    if (flag == 1) {
                        var text = temp[i].testname;
                        html += "<li>\
                            <div class=\"jpstli zxzhutiys\">\
                                <a target='_blank' class=\"fl btnjps zxzt_btn_8cc407 dot_data_com\">" + number + "</a><div class=\"fl jpstys jpys overf_com gkdttime\"><a target='_blank' href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].testname.replace(" ", "-") + "'> " + text + "</a></div><div class=\"fr\" id=\"\">\
                                    <a target='_blank' class=\"ayblue\" >["+ time + "]</a>\
                                </div>\
                            </div>\
                        </li>";
                    } else {
                        var text = temp[i].testname;
                        html += "<li>\
                            <div class=\"fl overf_com gkdttime_8cc407\">\
                                <a target='_blank' class=\"gkdtbtn_8cc407 dot_data_com fl\">" + number + "</a>&nbsp;\
                            </div>\
                            <div class=\"fl flow_nowrap overf_com gkdttime_8cc407\">\
                                <a target='_blank' class=\"gkdttime_8cc407\" href='../Download?cid=1&id=" + temp[i].id + "&myTitle=" + text + "' title='" + temp[i].testname.replace(" ", "-") + "'> " + text + "</a>\
                            </div>\
                            <div class=\" fr\">\
                                <a target='_blank' class=\"gkdttime_8cc407  fr\">[" + time + "]</a>\
                            </div>\
                        </li>";
                    }
                }
            }
            $("#" + controlid).html(html);
        }
    });
}

//
//获取轮播图
//
function Banner() {
    $.post("../Province/GetBanner", { type: 9 }, function (data) {
        if (data && data != "]") {
            var temp = eval(data);
            var html = "";
            var html1 = "";
            for (var i = 0; i < temp.length; i++) {
                html += "<a target='_blank'  href='" + temp[i].link + "'><img src='" + "http://source.51kaoxue.com" + temp[i].pic + "' style='width:715px; height:442px;'></a>";
              
            }
            $("#wowslider-container1_new_1").html(html);
            jQuery.getScript("../engine1/vmc.slider.full.js", function () {
                jQuery.getScript("../engine1/script.js", function () {
                    if (navigator.userAgent.indexOf("MSIE") > 0) {
                        //修复ie7问题
                        setTimeout(function () {
                            //$(".vui-prev").click();
                            $(".vui-next").click();
                        }, 100);
                    }
                });
            });

        }
    });
}


//
//获取年份
//
function GetYear() {
    $.post("../Past_Exam/GetYears", function (data) {
        if (data) {
            var html = "";
            var temp;
            if (data != "]") {
                temp = eval(data);

                for (var i = 0; i < temp.length; i++) {
                    html += "<div class='nav_background_container_child'><span onclick=\"javascript:location.href='../Past_Exam?year=" + temp[i].id + "&year_text=" + temp[i].name + "'\">" + temp[i].name + "</span><a target='_blank'></a></div>";
                }
            }
            $("#history_test_senior").html(html);
            //$("#subject1").click();
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
            var temp;
            if (data != "]") {
                temp = eval(data);
                html += "<div id=\"\" class=\"fl cebianlan_ul1\">\
                    <ul>";

                for (var i = 1; i <= temp.length; i++) {
                    html += "<li><a target='_blank' href=\"../Province?area=" + temp[i - 1].id + "&text=" + temp[i - 1].areaname + "\" class=\"hover1\"><img src=\"../../img/hover-10.png\" alt=\"\" class=\"hover10\" />" + temp[i - 1].areaname + "</a></li>";
                    if (i % 8 == 0 && i != 0) {
                        html += "</ul>\
                                </div>\
                                <div id=\"\" class=\"fl cebianlan_ul1\">\
                                    <ul>";
                    }
                }
            }
            html += "</ul>\
                        </div>\
                    </div>";
            $("#province_more").html(html);
            //$("#subject1").click();
        }
    });
}

//
//名校合作
//
function GetSchool() {
    $.post("../Home/GetSchool", function (data) {
        if (data) {
            var html2 = ""; //名校展示
            var temp;
            if (data != "]") {
                temp = eval(data);
                for (var i = 0; i < 5; i++) {
                    if (i == 0) {
                        html2 += "<div class=\"hs1 fl\">\
                        <div class=\"hsimg1_new\">\
                            <img src=\"" + "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" alt=\"\" class=\"img190\"   onclick=\"javascript:window.open('../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "');\"/>\
                        </div>\
                        <div class=\"wzhs\">\
                            <a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + temp[i].name + "</a>\
                        </div>\
                    </div>";
                    } else {
                        html2 += "<div class=\"hs1 fl mxzykz6\">\
                        <div class=\"hsimg1_new\">\
                            <img src=\"" + "http://source.51kaoxue.com/" + temp[i].imgsrc + "\" alt=\"\" class=\"img190\"  onclick=\"javascript:window.open('../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "');\"/>\
                        </div>\
                        <div class=\"wzhs\">\
                            <a target='_blank' href='../SchoolDetail?id=" + temp[i].id + "&areaid=" + temp[i].areaid + "&myTitle=" + temp[i].name + "' title='" + temp[i].name.replace(" ", "-") + "'>" + temp[i].name + "</a>\
                        </div>\
                    </div>";
                    }

                }

            }
            $("#elite_school_show").html(html2);
        }
    });
}

$(document).ready(function () {
    level = GetQueryString("level");
    switch (level) {
        case '1':
            level = "between 1 and 6";
            break;
        case '2':
            level = "between 7 and 9";
            $("#moni_title").html("中考模拟");
            moni_zhongkao();
            //月考
            gettestbycategory(5, "yuekao_jieduan",2);
            //期中
            gettestbycategory(6, "qizhong_qimo",1);
            //摸底
            gettestbycategory(22, "modi_ceshi",1);
            //地区联考
            gettestbycategory(8, "diquliankao",2);
            //竞赛试题
            gettestbycategory(23, "jingsai_test",2);
            break;
        case '3':
            level = "between 10 and 12";
            $("#moni_title").html("高考模拟");
            moni_gaokao();
            //月考
            gettestbycategory(9, "yuekao_jieduan",2);
            //期中
            gettestbycategory(10, "qizhong_qimo",1);
            //摸底
            gettestbycategory(16, "modi_ceshi",1);
            //地区联考
            gettestbycategory(15, "diquliankao",2);
            //竞赛试题
            gettestbycategory(17, "jingsai_test",2);
            break;
        default:
            break;
    }
    zhuanti_tuijian();
    beike_jingpin();
    taoti_jingpin();
    taoti_mingxiao();
    gaokao_beikao();
    Kejian_jingping();
    jiaoan_jingpin();
    xuean_jingpin();
    lianxi_jingpin();
    sucai_jingpin();

    News(1, "#gaokaodongtai");
    Banner();
    GetYear();
    GetArea();
    GetSchool();
});

//点击li时，改变li样式
function change_css_li(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("news_selected_1");
        $(this).addClass("news_normal_1");
    });
    $(obj).removeClass("news_normal_1");
    $(obj).addClass("news_selected_1");
}

//点击span时，改变span样式
function change_css_span(obj) {
    $(obj).parent().children().each(function () {
        $(this).removeClass("title_middle_nav_span_select");
    });
    $(obj).addClass("title_middle_nav_span_select");
}

function provinceurl(area, text) {
    location.href = "../province?area=" + area + "&text=" + text;
}