<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="trade_detail" %>
<%@ Register src="../controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc3" %>
<%@ Register src="../controls/login.ascx" tagname="login" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" type="text/css" href="../css/css.css">
<link rel="stylesheet" type="text/css" href="../css/nei.css">
<title><%=trade.title%>-<%=info %></title>
<script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../scripts/jquery/jquery.form.min.js" type="text/javascript"></script>
<script src="../scripts/MSClass.js" type="text/javascript"></script>
<script src="../scripts/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery.lazyload.min.js"></script>  
</head>
<body>
<div class="contents">
    <uc1:header ID="header1" runat="server" />
	<uc2:xsheader ID="xsheader1" runat="server" />
    <div class="clear01"></div>
    <div class="contentsLeft">
    	   <uc4:login ID="login1" runat="server" />
        <div class="clear01"></div>
        <div class="leftMenu">
        <div class="biaoti2">动态分类</div>
        <div class="leftMenuContent">
            	<ul>
              	    <li><a href="/info/list.aspx?sort=1">新闻资讯</a></li>
                    <li><a href="/info/list.aspx?sort=40">政策法规</a></li>
                    <li><a href="/info/list.aspx?sort=53">行业自律</a></li>
                    <li><a href="/info/list.aspx?sort=38">工作简报</a></li>
                    <li><a href="/community/list.aspx">会员名录</a></li>
                    <li><a href="/info/list.aspx?sort=50">产品展会</a></li>
                    <li><a href="/info/list.aspx?sort=262">供应信息</a></li>
                    <li><a href="/info/list.aspx?sort=263">需求信息</a></li>
                    <li><a href="/lishi.aspx">理事单位</a></li>
                    <li><a href="/info/list.aspx?sort=49">农超对接</a></li>
                    <li><a href="/community/reg.htm">注册会员</a></li>
                    <li><a href="/lianhui.aspx">联会机构</a></li>
                    <li><a href="/info/list.aspx?sort=36">经管动态</a></li>
                    <li><a href="/info/list.aspx?sort=43">通知公告</a></li>
                    <li><a href="/info/list.aspx?sort=47">农业科技</a></li>
                    <li><a href="/info/list.aspx?sort=44">技术规范</a></li>
                    <li><a href="/info/list.aspx?sort=239">品牌建设</a></li>
                    <li><a href="/info/list.aspx?sort=83">示范社库</a></li>
                    <li><a href="/info/list.aspx?sort=51">名优特产</a></li>
                    <li><a href="/info/list.aspx?sort=55">质量安全</a></li>
                    <li><a href="/info/list.aspx?sort=267">视频点播</a></li>
                    <li><a href="/info/list.aspx?sort=127">人才培训</a></li>
                    <li><a href="/info/list.aspx?sort=48">会员风采</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="contentsRight">
    <div class="nMainRig">
        	<div class="mainRighTitleMessageIco">当前位置：<a href="/">首页</a> > <%=info %> > <%=trade.title%> </div>
            <div class="gyxxxq">
            <ul>
                <li>
                <div class="gyxximgxqbg"><a target="_blank" href="#"><img style=" width:314px; height:314px;" src="<%=string.IsNullOrEmpty(trade.tpic) ? "../images/noimg.png" : ("../tradeimg/s/" + trade.tpic)%>"/></a></div>
                <div class="gyxxxqTxt"><span class="fGreen">品　　名：</span><%=trade.name %></div>
                <div class="gyxxxqTxt"><span class="fGreen">描　　述：</span><%=StringClass.CutString(string.IsNullOrEmpty(trade.intro) ? "暂无内容" : trade.intro, 18)%>...</div>
                <div class="gyxxxqTxt"><span class="fGreen">价　　格：</span><%=Others.Decimals(trade.price.ToString()).ToString("0.0")%>元/<%=trade.units %></div>
                <div class="gyxxxqTxt"><span class="fGreen">单位名称：</span><%=user.corpname %></div>
                <div class="gyxxxqTxt"><span class="fGreen">所 在 地：</span><%=province.sortarea %> <%=city.sortarea %> <%=county.sortarea %></div>
                <div class="gyxxxqTxt"><span class="fGreen">负 责 人：</span><%=user.hzsboss %></div>
                <div class="gyxxxqTxt"><span class="fGreen">联系方式：</span><%=user.tel %></div>
                <div class="gyxxxqTxt"><span class="fGreen">发布日期：</span><%=trade.addtime.ToString("yyyy-MM-dd")%></div>
                <div class="gyxxxqTxt"><span class="fGreen">有 效 期：</span><%=effetive_days %>天</div>
                </li>
                <div class="clear01"></div>
                <div class="xqBg flanmu">详细信息</div>
                <div class="xqneirong">
                　　<%=trade.content %>
                </div>
                    </ul>
                   <div class="clear02"></div>   
                  </div>
        </div>
  </div>
                <div class="clear02"></div>
     <uc3:footer ID="footer1" runat="server" /> 
  <div class="clear01"></div>	
    </div>
</body>
</html>
