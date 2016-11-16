/// <reference path="../Scripts/jquery-1.8.2.js" />


var filepath;

var id = "";
var cid = "";
var control = false;
//url参数集合
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = decodeURI(window.location.search).substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//
//热门下载
//
function GetTest_Hot_Download() {
    $.post("../Elite_School/GetTest_Hot_Download", function (data) {
        if (data) {
            var temp = eval(data);
            var html = "";
            for (var i = 0; i < temp.length; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp\">●</span>&nbsp;<a target='_blank'  title='" + temp[i].testname + "' href='../Download?cid=1&id=" + temp[i].id + "' target='_blank' class=\"rmxzaa\">" + text + "</a></li>";
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
            var html = "";
            for (var i = 0; i < 11; i++) {
                var text = temp[i].testname.length > 10 ? temp[i].testname.substr(0, 10) + "..." : temp[i].testname;
                html += "<li class=\"rmxzli\"><span class=\"rmxzsp rmxz2hv\">●</span>&nbsp;<a target='_blank' title='" + temp[i].testname + "'  href='../Download?cid=1&id=" + temp[i].id + "' target='_blank' class=\"rmxzaa rmxz2hv\">" + text + "</a></li>";
            }
            $("#recommend").html(html);
        }
    });
}


//文件预览

function Preview() {
    $.post('http://admin.51kaoxue.com/Office.ashx', { temp: filepath }, function (data) {
        if (data != 'no') {
            var root = "http://admin.51kaoxue.com/Upload/template.aspx?url=";
            var url = root + data;
            document.getElementById('preview').src = url;
            $("#preview").attr("src", 'http://admin.51kaoxue.com/Upload/template.aspx?url=' + data);
        }
    });
}

//点击收藏
function AddFavorite() {

    var ctrl = (navigator.userAgent.toLowerCase()).indexOf('mac') != -1 ? 'Command/Cmd' : 'CTRL';

    if (document.all) {

        window.external.addFavorite(window.location.href, document.title)

    } else if (window.sidebar) {

        window.sidebar.addPanel(document.title, window.location.href, "")

    } else {　　　　//添加收藏的快捷键 

        alert('添加失败\n您可以尝试通过快捷键' + ctrl + ' + D 加入到收藏夹~')
    }
}

function GetInformation() {
     id = GetQueryString("id");
     cid = GetQueryString("cid");
     $.post("../Download/GetInformation", { id: id, category: cid }, function (data) {
        if (data) {
            var models = eval(data);
            var m = models[0];
            var typename = Produce_TypeName(cid);
            var text = m.name.length > 35 ? m.name.substr(0, 35)+"..." : m.name;
            //标题
            $("#info_title").html(text);
            //类型
            $("#datatype").html(typename);
            //学科
            $("#subjectname").html(m.subname);
            //地区
            if (m.areaname!="" && m.areaname != null && m.areaname != undefined)
            $("#district").html(m.areaname);
            ////具体类型
            //$("#testcategory").html("同步检测");
            //文件格式
            $("#filetype").html(m.extension);
            //下载扣点
            $("#neednum").html(m.neednum + "点");
            var date = new Date(m.uploadtime);
            var datestr = date.getFullYear() + "/" + Number(date.getMonth()+1) + "/" + date.getDate();
            //上传时间
            $("#uploadtime").html(datestr);
            filepath = m.filesrc;
            $("#download").show();
            Preview();
        }
    });
}

//
//解析类型名称
//
function Produce_TypeName(category) {
    var name = "";
    switch (category) {
        case "1":
            name = "试题";
            break;
        case "2":
            name = "课件";
            break;
        case "3":
            name = "教案";
            break;
        case "4":
            name = "学案";
            break;
        case "6":
            name = "同步";
            break;
        case "5":
            name = "素材";
            break;
        case "7":
            name = "论文";
            break;
        case "8":
            name = "套题";
            break;
        case "9":
            name = "备课";
            break;
        default:
            break;
    }
    return name;
}

function DownLoad() {
    if (control)
        return;
    control = true;
    $("#download_resource").attr("disabled", "true");// disabled
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
                location.href = "http://source.51kaoxue.com" + filepath;
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

function message(text) {
    $("#message_content").html("系统提示: " + text);
    $("#message_start").click();
}

function Loading_start() {
    $("#message_start1").click();

}

function Loading_end() {
    $("#message_close1").click();
}
    
$(document).ready(function () {
    GetTest_Hot_Download();
    GetTest_Recommend();
    GetInformation();
});