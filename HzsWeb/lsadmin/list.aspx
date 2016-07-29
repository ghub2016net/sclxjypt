<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="lsadmin_list" %>
<%@ Register src="../controls/lishi/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register src="../controls/login.ascx" tagname="login" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>-理事会员列表</title>
    <link rel="stylesheet" type="text/css" href="../css/css.css" />
    <link rel="stylesheet" type="text/css" href="../css/nei.css" /> 
</head>
<body>    
   <div class="contents">
	<uc1:header ID="header1" runat="server" />
    <div class="clear01"></div>
    <div class="contentsLeft">
    	<uc4:login ID="login1" runat="server" />
        <div class="clear01"></div>
        <div class="leftMenu">
        <div class="biaoti2">动态分类</div>
        <div class="leftMenuContent">
        <ul>
            <li><a href="/lsadmin/list.aspx?sort=275">人物风彩</a></li>
            <li><a href="/lsadmin/list.aspx?sort=276">项目指南</a></li>
            <li><a href="/lsadmin/list.aspx?sort=277">示范社指南</a></li>
            <li><a href="/lsadmin/list.aspx?sort=278">营销指南</a></li>
            <li><a href="/lsadmin/list.aspx?sort=279">经验交流</a></li>
            <li><a href="/lsadmin/list.aspx?sort=280">联会通报</a></li>
            <li><a href="/lsadmin/list.aspx?sort=287">理事图片</a></li>
            <li><a href="/lsadmin/list.aspx?sort=288">献策建议</a></li>
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
  <uc2:footer ID="footer1" runat="server" />
  <div class="clear01"></div>	
</div>
</body>
</html>
