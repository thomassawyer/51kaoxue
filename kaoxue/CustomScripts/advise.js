/// <reference path="../Scripts/jquery-1.8.2.js" />

//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

//点击span时，改变span样式
function change_css_span(obj,css_class) {
    $(obj).parent().children().each(function () {
        $(this).removeClass(css_class);
    });
    $(obj).addClass(css_class);
}

$(document).ready(function () {

});