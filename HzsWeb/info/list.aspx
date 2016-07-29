<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="info_list" %>
<%@ Register src="../controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc3" %>
<%@ Register src="../controls/login.ascx" tagname="login" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%=isinfo.name %></title>
<link rel="stylesheet" type="text/css" href="../css/css.css">
<link rel="stylesheet" type="text/css" href="../css/nei.css">
<script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../scripts/jquery/jquery.form.min.js" type="text/javascript"></script>
<script src="../scripts/MSClass.js" type="text/javascript"></script>
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
            <li><a href="list.aspx?sort=1">新闻资讯</a></li>
            <li><a href="list.aspx?sort=40">政策法规</a></li>
            <li><a href="list.aspx?sort=53">行业自律</a></li>
            <li><a href="list.aspx?sort=38">工作简报</a></li>
            <li><a href="#">会员名录</a></li>
            <li><a href="list.aspx?sort=50">产品展会</a></li>
            <li><a href="list.aspx?sort=262">供应信息</a></li>
            <li><a href="list.aspx?sort=263">需求信息</a></li>
            <li><a href="#">理事单位</a></li>
            <li><a href="list.aspx?sort=49">农超对接</a></li>
            <li><a href="#">注册会员</a></li>
            <li><a href="#">联会机构</a></li>
            <li><a href="list.aspx?sort=36">经管动态</a></li>
            <li><a href="list.aspx?sort=43">通知公告</a></li>
            <li><a href="list.aspx?sort=47">农业科技</a></li>
            <li><a href="list.aspx?sort=44">技术规范</a></li>
            <li><a href="list.aspx?sort=239">品牌建设</a></li>
            <li><a href="list.aspx?sort=83">示范社库</a></li>
            <li><a href="list.aspx?sort=51">名优特产</a></li>
            <li><a href="list.aspx?sort=55">质量安全</a></li>
            <li><a href="list.aspx?sort=267">视频点播</a></li>
            <li><a href="list.aspx?sort=127">人才培训</a></li>
            <li><a href="list.aspx?sort=48">会员风采</a></li>
        </ul>
            </div>
        </div>
    </div>
    <div class="contentsRight">
    <div class="nMainRig">
        	<div class="mainRighTitleMessageIco">当前位置：<a href="../Default.aspx">首页</a> > <a href="list.aspx?sort=<%=isinfo.ntypeid %>"><%=isinfo.name %></a></div>
                <form id="Form1" runat="server">
        	<div class="nymainNews">
        	<ul>
                <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                <li>
                <a href="detail.aspx?id=<%#Eval("id") %>" target="_blank"><%#StringClass.CutString(Eval("title").ToString(),72) %></a>
                <span class="mainDate"><%#StringClass.CutString(Eval("addtime").ToString(), 8)%></span>
                </li>
                </ItemTemplate>
                
                </asp:Repeater>
               
                </ul>
		         <div class="clear01"></div>
		         <div  style="width:100%; text-align:right; right:20px;">
                <webdiyer:AspNetPager ID="AspNetPagerAskAnswer" runat="server" 
             FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
             PrevPageText="上一页" 
            PageSize="15" onpagechanged="AspNetPagerAskAnswer_PageChanged">
                </webdiyer:AspNetPager> </div>
                </div>
                </form>
        </div>
  </div>
                <div class="clear02"></div>
                
       <uc3:footer ID="footer1" runat="server" /> 
  <div class="clear01"></div>	
</div>
</body>
</html>
