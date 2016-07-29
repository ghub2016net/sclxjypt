<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defalut.aspx.cs" Inherits="user_Defalut" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../Style/common.css" />
    <link href="../Style/leftMenu.css" rel="stylesheet" type="text/css" />
    <script src="../JScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../JScript/leftMenu.js" type="text/javascript"></script>
    <script src="js/time.js" type="text/javascript"></script>
    <title>合作社会员管理平台</title>
    </head>
    <body>
<!-- nav start -->
<div class="nav">
      <div class="navCon">
    <div class="navConLef">您好<span class="fontColorBlue fontWeight marginLef5"><%=uname%></span>,欢迎进入合作社会员管理平台</div>
    <a class="floatRigh marginLef5" href="/AjaxViewHzsUserLogin/ViewHzsUserLoginOutUrl.ashx">[退出]　</a><a class="floatRigh" href="#">[设置]</a> </div>
    </div>
<!-- nav eng --> 
<!-- header start -->
<div class="header">
      <div class="headerCon">
    <div class="headerLogo"><a href="#"><img src="../Style/images/logo.jpg" /></a></div>
    <div class="headerDate"><script>clockon();</script></div>
  </div>
    </div>
<!-- header end -->
<div class="clear"></div>
<!-- main start -->
<div class="mainContent clearfix">
      <div class="main clearfix"> 
    <!-- mainLef start -->
    <div class="mainLef">
          <div class="leftMenuContent">
        <ul>
         <li> <a class="firstMenu">供求信息管理</a>
            <ul class="secondMenu">
                  <li id="html_supply"><a href="trade/supply.aspx" target="usermainframe">供应信息列表</a></li>
                  <li id="html_addsupply"><a href="trade/supply_edit.aspx" target="usermainframe">添加供应信息</a></li>
                  <li id="html_demand"><a href="trade/demand.aspx" target="usermainframe">求购信息列表</a></li>
                  <li id="html_adddemand"><a href="trade/demand_edit.aspx" target="usermainframe">添加求购信息</a></li>
                  <li id="html_cooperation"><a href="trade/cooperation.aspx" target="usermainframe">合作信息列表</a></li>
                  <li id="html_addcooperation"><a href="trade/cooperation_edit.aspx" target="usermainframe">添加合作信息</a></li>
                </ul>
          </li>
              <li><a class="firstMenu">独立合作社管理</a>
            <ul class="secondMenu">
                  <li id="html_intro"><a href="company/intro.aspx" target="usermainframe">合作社简介</a></li>
                  <li id="html_news"><a href="company/info.aspx?rid=2" target="usermainframe">新闻中心</a></li>
                  <li id="Li1"><a href="company/info_edit.aspx?action=Add&rid=2" target="usermainframe">编辑新闻中心</a></li>
                  <li id="html_glory"><a href="company/glory.aspx" target="usermainframe">荣誉资质</a></li>
                  <li id="Li3"><a href="company/glory_edit.aspx" target="usermainframe">编辑荣誉资质</a></li>
                  <li id="html_product"><a href="company/product.aspx?rid=3" target="usermainframe">产品信息</a></li>
                  <li id="Li2"><a href="company/product_eidt.aspx?action=Add&rid=3" target="usermainframe">编辑产品信息</a></li>
                  <li id="html_about"><a href="company/about.aspx?rid=4" target="usermainframe">联系我们</a></li>
                </ul>
          </li>
              <li><a class="firstMenu">会员信息管理</a>
            <ul class="secondMenu">
                  <li id="html_intro"><a href="userinfo/Default.aspx" target="usermainframe">个人信息</a></li>
                </ul>
          </li>
          <%if (utype >= 2)
            { %>
          <li><a class="firstMenu">理事会员</a>
            <ul class="secondMenu">
                  <li id="html_lishi"><a href="/lsadmin/" target="_blank">理事专享页面</a></li>
                </ul>
          </li>
          <%} %>
          <!--<li><a class="firstMenu">商城类信息</a>
            <ul class="secondMenu">
                  <li><a>商城类信息1</a></li>
                  <li><a>商城类信息2</a></li>
                  <li><a>商城类信息3</a></li>
                  <li><a>商城类信息4</a></li>
                </ul>
          </li>-->
            </ul>
      </div>
        </div>
    <!-- mainLef end --> 
    <!-- mainRigh start -->
    <div class="mainRigh">
    <iframe id="usermainframe" name="usermainframe" frameborder="0" src="center.aspx"></iframe>
    
    </div>
    </div>
    </div>
<!-- footer start -->
<%--<div class="mainContent">
      <div class="footer">
      
    <p>版权所有:泸县数字农经网 主管单位：泸县农业局</p>
    <p><a href="http://www.chinasunsoft.net" target="_blank">技术支持:青岛太阳软件有限公司</a>  </p>
  </div>
    </div>--%>
<!-- footer end -->
</body>
</html>
