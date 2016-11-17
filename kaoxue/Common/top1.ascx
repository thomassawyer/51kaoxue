<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<style>
    a {
        cursor:pointer;
    }
</style>
<script src="../CustomScripts/top.js"></script>

    <div class="top_head">
        <div class="top_head_div font_size12">
            <div class="fl_head">
                <ul>
                    <li>您好,欢迎来到51考学网</li>
                    <li class="li1" id="logininfo" style="padding-left:20px;">请<a target='_blank' href="../Login">[登录]</a></li>
                </ul>
            </div>
            <div class="f2_head">
                <ul>
                    <li class="li1 lispan" style="padding-left:8px;">今日上新：<span id="UpCountByDay"></span></li>
                    <li class="li1 lispan" style="padding-left:20px;" >网校数：<span id="MemberCount"></span></li>
                    <li class="li1 lispan" style="padding-left:20px;">试题资源：<span id="shiticount"></span></li>
                    <li class="li1 lispan" style="padding-left:20px;" >总数：<span id="beikecount"></span></li>
                    <li class="li3 fr">免费咨询热线：400-819-8115</li>
                </ul>
            </div>
        </div>
    </div><!--这是头部  登录部分-->

    <div class="navinput">
        <div class="navinput_div">
            <div class="fl logo">
                <a target='_blank' href="../Home"><img src="../../img/logo.png" class="logo1"/></a>
            </div>
            <div id="ztc" class="fl">
                <a target='_blank' href="../ThroughTrain"><img src="../../img/ztc.png" /></a>
            </div>
            <div id="ztc_bottom" class="fl">
                <form action="#" method="get">
                    <input type="text" name="keywords" class="fl" id="shousuo" style="padding-left:20px; width:430px;" placeholder="请输入搜索内容" onkeyup="shousuo_keyfun(event)"/><a target='_blank' id="tijiao" target='_blank' class="fl"  onclick="javascript: location.href = '../Search?keywords=' + $('#shousuo').val()"></a><img src="../../img/sousuo.png" id="soussuo" style="cursor:pointer;"  onclick="javascript: location.href = '../Search?keywords=' + $('#shousuo').val()"/>
                </form>
            </div>
            <div class="fl xbs">
                <img src="../../img/boshimao.png" alt="" class="fl" /><h3 class="fl h3gaokao"><a target='_blank' href="../Test_Center">高考试题</a></h3>
            </div>
            <div class="fl xbss">
                <img src="../../img/shutubiao1.png" alt="" class="fl" /><h3 class="fl h3gaokao"><a target='_blank' href="../News">天天新闻</a></h3>
            </div>
        </div>
    </div><!--这是搜索框部分-->

    <div class="daohanglan">
        <div class="daohanglan_ul">
            <ul class="dhul">
                <li class="fl bk fb1" id="pad"><a target='_blank'  href="../Subject?subjectname=语文">语文</a><img src="../../img/tc-93.png" class="maozi1" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=数学">数学</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=英语">英语</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=物理">物理</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=化学">化学</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=生物">生物</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=历史">历史</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=政治">政治</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Subject?subjectname=地理">地理</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk1" id="bk"><a target='_blank'  href="../Beike_Center">备课中心</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk1"><a target='_blank'  href="../Test_Center">试题中心</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Grade?level=3">高中</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a target='_blank'  href="../Grade?level=2">初中</a><img src="../../img/tc-93.png" alt="" /></li>  
            </ul>
        </div>
    </div><!--导航栏-->
