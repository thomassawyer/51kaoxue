<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

    <div class="top_head">
        <div class="top_head_div">
            <div  class="fl_head">
                <ul>
                    <li>您好,欢迎来到51考学网</li>
                    <li class="li1">请<a >[登录]</a></li>
                    <li class="li2"><a >免费注册</a></li>
                </ul>
            </div>
            <div class="f2_head">
                <ul>
                    <li class="li1 lispan">今日上新：<span>999套</span></li>
                    <li class="li1 lispan">总数：<span>9999套</span></li>
                    <li class="li3">免费咨询热线：400-819-8115</li>
                </ul>
            </div>
        </div>
    </div><!--这是头部  登录部分-->

    <div class="navinput">
        <div class="navinput_div">
            <div  class="fl logo">
                <a href="../Home">
                    <img src="../../img/logo.png" class="logo1">
                </a>
                
            </div>
            <div id="ztc" class="fl">
                <img src="../../img/ztc.png" />
            </div>
            <div id="ztc_bottom" class="fl">
                <form action="#" method="get">
                    <input type="text" name="lname" class="fl" id="shousuo" placeholder="&nbsp&nbsp请输入搜索内容" /><a  id="tijiao" class="fl"></a><img src="../../img/sousuo.png" id="soussuo">
                </form>
            </div>
            <div class="fl xbs">
                <img src="../../img/boshimao.png"  class="fl" /><h3 class="fl h3gaokao"><a >高考试题</a></h3>
            </div>
            <div class="fl xbss">
                <img src="../../img/shutubiao1.png"  class="fl" /><h3 class="fl h3gaokao"><a >天天新闻</a></h3>
            </div>
        </div>
    </div><!--这是搜索框部分-->

    <div  class="daohanglan">
        <div  class="daohanglan_ul">
            <ul class="uuu">
                <li class="fl"><a href="../Home"><span>首页</span></a></li>
                <li class="fl pad bk1"><a href="../Beike_Center">备课中心</a><img src="../../img/tc-93.png"  class="bkimg2" /></li>
                <li class="fl pad bk1"><a href="../Test_Center">试题中心</a><img src="../../img/tc-93.png"  class="bkimg3" /></li>
                <li class="fl pad bk1"><a href="../Past_Exam">高考真题</a><img src="../../img/tc-93.png"  class="bkimg4" /></li>
                <li class="fl pad bk1"><a href="../Elite_School">百强名校</a><img src="../../img/tc-93.png"  class="bkimg5" /></li>
                <li class="fl pad bk1"><a href="../Gaokao_Beikao">高考备考</a><img src="../../img/tc-93.png"  class="bkimg6" /></li>
            </ul>

        </div>
    </div><!--导航栏-->