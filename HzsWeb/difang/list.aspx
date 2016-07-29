<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="difang_dflist" %>
<%@ Register src="~/controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="~/controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="~/controls/login.ascx" tagname="login" tagprefix="uc3" %>
<%@ Register src="~/controls/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/nei.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../scripts/MSClass.js" type="text/javascript"></script>
<script src="../scripts/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery.lazyload.min.js"></script>

<title><%=inifo%>-泸县数字农经网-列表页</title>
</head>

<body>
<div class="contents">
	<uc1:header ID="header1" runat="server" />
    <uc2:xsheader ID="xsheader1" runat="server" />
    <div class="clear01"></div>
    <div class="contentsLeft">
    	<div class="admin">
        <uc3:login ID="login1" runat="server" />
        </div>
        <div class="clear01"></div>
        <div class="leftMenu">
        <div class="biaoti2">动态分类</div>
        <div class="leftMenuContent">
            	<ul>
              			<li style="width:100%; letter-spacing:2px;"><a href="list.aspx?sort=1&areaid=<%=zzdw.ZZDW_DM %>" >信息新闻</a></li>
                    <li style="width:100%; letter-spacing:2px;"><a href="list.aspx?sort=2&areaid=<%=zzdw.ZZDW_DM %>">图片新闻</a></li>
                    <li style="width:100%; letter-spacing:2px;"><a href="list.aspx?sort=3&areaid=<%=zzdw.ZZDW_DM %>">农优特产</a></li>
                    <li style="width:100%; letter-spacing:2px;"><a href="list.aspx?sort=4&areaid=<%=zzdw.ZZDW_DM %>">合作社风采</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="contentsRight">
    <div class="nMainRig">
    <div class="mainRighTitleMessageIco">当前位置：<a href="Default.aspx">首页</a> > <a><%=zzdw.ZZDW_JC%></a> ><%=inifo%></div>
    <form runat="server"> 
    <div class="nymainNews">
    <ul>
    <asp:Repeater ID="rptList" runat="server">
    <ItemTemplate>
    <li>
    <a href="detail.aspx?id=<%#Eval("id") %>" target="_blank"><%#StringClass.CutString(Eval("title").ToString(),72) %></a>
    <span class="mainDate"><%#StringClass.CutString(Eval("addtime").ToString(), 8)%></span>
                          </li></ItemTemplate></asp:Repeater>
                        </ul>
    <div style="width:100%; text-align:right; right:20px;">
    <webdiyer:AspNetPager ID="AspNetPagerAskAnswer" runat="server" 
            AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
             PrevPageText="上一页" 
            PageSize="15" onpagechanged="AspNetPagerAskAnswer_PageChanged">
                </webdiyer:AspNetPager> </div>
   <div class="clear03"></div>   
                  </div></form>
        </div>
        </div>
   <div class="clear02"></div>
   <uc4:footer ID="footer1" runat="server" />
  <div class="clear01"></div>	
</div>
</body>
</html>

