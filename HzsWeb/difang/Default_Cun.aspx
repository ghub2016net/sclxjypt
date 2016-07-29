<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Cun.aspx.cs" Inherits="Default_Cun" %>
<%@ Register src="~/controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%--<%@ Register src="~/controls/cunheader.ascx" tagname="cunheader" tagprefix="uc2" %>--%>
<%@ Register src="~/controls/login.ascx" tagname="login" tagprefix="uc3" %>
<%@ Register src="~/controls/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../scripts/jquery/jquery.form.js" type="text/javascript"></script>
<script src="../scripts/MSClass.js" type="text/javascript"></script>
<script src="../scripts/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery.lazyload.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
<title>-地方频道-泸县数字农经网</title>
<script type="text/javascript">
$(function(){
    $("#KinSlideshow").KinSlideshow({
			moveStyle:"down",
			intervalTime:8,
			mouseEvent:"mouseover",
			isHasTitleBar:true,	
			titleBar:{titleBar_height:30,titleBar_bgColor:"#3a3a3a",titleBar_alpha:0.5},
			titleFont:{TitleFont_size:14,TitleFont_color:"#ffffff"}
	});
	
})
</script>
</head>

<body>
<form runat="server">
<div class="contents">
	<uc1:header ID="header1" runat="server" />
    <%--<uc2:cunheader ID="xsheader1" runat="server" />--%>
    <div class="xz">
  		<div class="xzBtn"><img src="../images/dfpd.jpg" title="地方频道" /></div>
   	    <div class="countiesBtn" id="hotArea">
          <ul id="ulid">
              <% foreach (HzsModel.Models.DM_ZZDW c in arealist)
                 { %>
                    <li><a href="../difang/Default_Cun.aspx?aid=<%=c.ZZDW_DM %>" target="_blank"><%=c.ZZDW_JC %></a></li>
              <%} %>
          </ul>
		</div>
    </div>
<script type="text/javascript"> new Marquee(["hotArea", "ulid"], 2, 2, 900, 30, 20, 0, 0);</script>
    <div class="clear5px"></div>
    <div class="weizhi">当前位置：首页 &gt; 泸县市 &gt; <%=info.ZZDW_JC%></div>
    <div class="clear5px"></div>
    <div class="contentsRight">
        <div class="xsmainNewsL">
        <div class="flanmu3 moreL2">信息新闻</div>
        <div class="moreR"><a href="list.aspx?sort=1&areaid=<%=info.ZZDW_DM%>">更多&gt;</a></div>
        <div class="xsmainLNews">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                <li><a href="detail.aspx?id=<%#Eval("id")%>"><%#StringClass.CutString(Eval("title").ToString(),34)%></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
    </div>
    <div class="contentsLeft">
    	<div class="banner" id="KinSlideshow" style="visibility:hidden">
            <asp:Repeater ID="rptBimg" runat="server">
            <ItemTemplate><a href="detail.aspx?id=<%#Eval("id")%>" target="_blank" ><img src="../newsimg/s/<%#Eval("pic")%>"alt="<%#StringClass.CutString(Eval("title").ToString(),36) %>" width="369" height="232"></a></ItemTemplate>
       
            </asp:Repeater>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    	</div>
        <div class="mainNews2xs rig">
        <div class="biaotiHezuoshe">农民合作社推荐</div>
        <div class="biaotiMore"><a href="list.aspx?sort=4&areaid=<%=info.ZZDW_DM%>">更多&gt;&gt;</a></div>
        <div class="mainLNews2">
            <ul>
                <asp:Repeater ID="rptNmhzstj" runat="server">
                <ItemTemplate>
                <li><a href="detail.aspx?id=<%#Eval("id")%>"><%#StringClass.CutString(Eval("title").ToString(),22)%></a> <span class="mainDate"><%#StringClass.CutString(Eval("addtime").ToString(),8)%></span></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
    </div>
    <div class="clear01"></div>
    <div class="snqyImgbg">
        <div class="flanmu3 moreL4">名优特产</div>
        <div class="moreImgR02"><a href="list.aspx?sort=3&areaid=<%=info.ZZDW_DM %>">更多&gt;&gt;</a></div>
		<div class="snqyimgScrollCenter">
            <ul>
                <asp:Repeater ID="rptMytc" runat="server">
                <ItemTemplate>
                <li>
                <div class="imgNewsbg"><a href="detail.aspx?id=<%#Eval("id") %>" title="<%#Eval("title")%>" target="_blank"><img src="../newsimg/s/<%#Eval("pic") %>" width="97" height="97"></a></div>
                <div class="imgScrolltxt"><a href="detail.aspx.aspx?id=<%#Eval("id")%>"title="<%#Eval("title")%>" target="_blank"><%#StringClass.CutString(Eval("title").ToString(),16)%></a></div>
                </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
            </div>         
		</div>
        <div class="clear01"></div>
    <uc4:footer ID="footer1" runat="server" />
    <div class="clear01"></div>
</div>
</form>
</body>
</html>

