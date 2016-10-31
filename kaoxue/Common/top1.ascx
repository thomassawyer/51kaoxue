<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<style>
    a {
        cursor:pointer;
    }
</style>
<script src="../CustomScripts/top.js"></script>

    <div class="top_head">
        <div class="top_head_div">
            <div class="fl_head">
                <ul>
                    <li>您好,欢迎来到51考学网</li>
                    <li class="li1" id="logininfo">请<a href="../Login">[登录]</a></li>
                </ul>
            </div>
            <div class="f2_head">
                <ul>
                    <li class="li1 lispan" style="padding-left:8px;">试题资源：<span id="shiticount"></span></li>
                    <li class="li1 lispan" style="padding-left:30px;" >总数：<span id="beikecount"></span></li>
                    <li class="li3">免费咨询热线：400-819-8115</li>
                </ul>
            </div>
        </div>
    </div><!--这是头部  登录部分-->

    <div class="navinput">
        <div class="navinput_div">
            <div class="fl logo">
                <a href="../Home"><img src="../../img/logo.png" class="logo1"/></a>
            </div>
            <div id="ztc" class="fl">
                <a href="../ThroughTrain"><img src="../../img/ztc.png" /></a>
            </div>
            <div id="ztc_bottom" class="fl">
                <form action="#" method="get">
                    <input type="text" name="lname" class="fl" id="shousuo" style="padding-left:20px; width:430px;" placeholder="请输入搜索内容" /><a id="tijiao" class="fl"  onclick="javascript: location.href = '../Search?keywords=' + $('#shousuo').val()"></a><img src="../../img/sousuo.png" id="soussuo" style="cursor:pointer;"  onclick="javascript: location.href = '../Search?keywords=' + $('#shousuo').val()"/>
                </form>
            </div>
            <div class="fl xbs">
                <img src="../../img/boshimao.png" alt="" class="fl" /><h3 class="fl h3gaokao"><a href="../Test_Center">高考试题</a></h3>
            </div>
            <div class="fl xbss">
                <img src="../../img/shutubiao1.png" alt="" class="fl" /><h3 class="fl h3gaokao"><a href="../News">天天新闻</a></h3>
            </div>
        </div>
    </div><!--这是搜索框部分-->

    <div class="daohanglan">
        <div class="daohanglan_ul">
            <ul class="dhul">
                <li class="fl bk fb1" id="pad"><a href="../Subject?subjectname=语文">语文</a><img src="../../img/tc-93.png" class="maozi1" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=数学">数学</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=英语">英语</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=物理">物理</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=化学">化学</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=生物">生物</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=历史">历史</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=政治">政治</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Subject?subjectname=地理">地理</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk1" id="bk"><a href="../Beike_Center">备课中心</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk1"><a href="../Test_Center">试题中心</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Grade?level=2">初中</a><img src="../../img/tc-93.png" alt="" /></li>
                <li class="fl pad bk"><a href="../Grade?level=3">高中</a><img src="../../img/tc-93.png" alt="" /></li>
            </ul>
        </div>
    </div><!--导航栏-->
