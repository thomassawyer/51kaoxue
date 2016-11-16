/// <reference path="../Scripts/jquery-1.8.2.js" />


//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var username="";
var password = "";
var return_url;
function remove_div() {
    var width = ($("body").width() -1200) / 2;
    var height = ($("body").height() -768) / 2;
    $("#container").css("left",width);
}

function getpara() {
    username = $("#username").val();
    password = $("#password").val();
}

function validate() {
    getpara();
    if (username == "" || username == undefined || username == null) {
        //alert("请输入用户名");
        var tip = $("#username").easytip();
        tip.show("用户名不能为空!");
        return false;
    }
    if (password == "" || password == undefined || password == null) {
        //alert("请输入密码");
        var tip = $("#password").easytip();
        tip.show("用户密码不能为空!");
        return false;
    }
    return true;
}

function keyPro(event) {
    if (event.keyCode == 13) {
        if($("#password").val() != '') {
            Login();
        } else {
            $("#password").focus();
        }
            
     }
}

function keyPro_1(event) {
    if (event.keyCode == 13) {
            Login();
    }
}

function Login() {
    var result = validate();
    if (!result)
        return;
    //验证用户名是否存在
    $.post("../Login/UserNameIsExists", {
        username:username
    }, function (data) {
        if (data == "0") {
            var tip = $("#username").easytip();
            tip.show("用户名不存在!");
            //alert("用户名不存在");
        } else if(data=="1") {
            $.post("../Login/ValidateUsernameAndPassword", {
                username: username,
                password:password
            }, function (json) {
                if (json == "1") {
                    if (location.href.indexOf('return_url') != -1) {
                        return_url = location.href.substring(location.href.indexOf('return_url') + 11);
                    }
                    if (return_url == "" || return_url == undefined || return_url == null) {
                        location.href = "../Home";
                    } else {
                        location.href = return_url;
                    }
                } else {
                    //alert("密码错误");
                    var tip = $("#password").easytip();
                    tip.show("密码错误!");
                }
            });
        }
    });
}

function message(text) {
    $("#message_content").html("系统提示: "+text);
    $("#message_start").click();
}

//function keylogin() {
//    if (event.keyCode == 13) {
//        Login();
//    } //回车键的键值为13
        
//}

/** 
 * 判断浏览器; 
 * @return 
 */
function getOs() {
    var OsObject = "";
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        return "MSIE";
    }
    if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {
        return "Firefox";
    }
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        return "Safari";
    }
    if (isCamino = navigator.userAgent.indexOf("Camino") > 0) {
        return "Camino";
    }
    if (isMozilla = navigator.userAgent.indexOf("Gecko/") > 0) {
        return "Gecko";
    }
}

//回车键登陆，支持火狐和IE浏览器;  
function loginEnterCheck() {
    //获取当前浏览器;  
    var browser = getOs();
    if (browser == "Firefox") {
        //判断IE还是火狐浏览器;  
        $("html").die().live("keydown", function (event) {
            if (event.keyCode == 13) {
                //调用登陆方法;  
                Login();
            }
        });
    } else
    {
        if (event.keyCode == 13) {
            Login();
        }
    }
}



$(document).ready(function () {
    $("#reg-form").easyform();

    remove_div();

    $("#password").blur(function () {
        if ($("#password").val() == '') {
            var tip = $("#password").easytip();
            tip.show("用户密码不能为空!");
        }
    });
    $("#username").blur(function () {
        if ($("#username").val() == '') {
            var tip = $("#username").easytip();
            tip.show("用户名不能为空!");
        } 
    });
});