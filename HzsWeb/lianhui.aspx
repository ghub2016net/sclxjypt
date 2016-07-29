<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lianhui.aspx.cs" Inherits="lianhui" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="css/css.css">
<link rel="stylesheet" type="text/css" href="css/lianhui.css">
<script src="scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="scripts/MSClass.js" type="text/javascript"></script>
<script src="scripts/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<title>联会机构-泸县数字农经网</title>
<script type="text/javascript">
    $(function () {
        $("#KinSlideshow").KinSlideshow({
            moveStyle: "down",
            intervalTime: 8,
            mouseEvent: "mouseover",
            isHasTitleBar: true,
            titleBar: { titleBar_height: 30, titleBar_bgColor: "#3a3a3a", titleBar_alpha: 0.5 },
            titleFont: { TitleFont_size: 14, TitleFont_color: "#ffffff" }
        });
    });
    </script>
</head>

<body>
<div class="contents">
	<%= UcExecutor.Render("~/controls/header.ascx", null)%>
    <div class="clear5px"></div>
    <div class="clear5px"></div>
    <div class="contentsRight">
        <div class="lhmainNewsL">
        <div class="flanmu3 moreL2">联会新闻</div>
        <div class="moreR"><a href="/info/list.aspx?sort=254" target="_blank">更多&gt;&gt;</a></div>
        <div class="lhmainLNews">
            <ul>
                <asp:Repeater ID="rptlhxw" runat="server">
                <ItemTemplate>
                <li><a href="/info/detail.aspx?id=<%#Eval("id") %>" target="_blank"><%#Eval("title") %></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
    </div>
    <div class="contentsLeft">
    <div class="banner" id="KinSlideshow" style="visibility:hidden;">
    <asp:Repeater ID="rptBimg" runat="server">
               <ItemTemplate>
               <a href="/info/detail.aspx?id=<%#Eval("id") %>" target="_blank"><img src="<%#string.IsNullOrEmpty(Eval("nimg").ToString())?"../images/noimg.png":("newsimg/s/"+Eval("nimg")) %>" alt="<%#StringClass.CutString(Eval("title").ToString(),14) %>" width="369" height="232"></a>
               </ItemTemplate>
               </asp:Repeater>
               <asp:Literal ID="Literal1" Text="<img src='../images/noimg.png' style='width:369px;height:232px'/>" runat="server"></asp:Literal>
    </div>
        <div class="mainNews2 rig">
        <div class="biaoti">机构介绍</div>
        <div class="biaotiMore02"><a href="/info/list.aspx?sort=283" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews2">
            <table border="0" class="lhmainTable">
            <asp:Repeater ID="rptjgjs" runat="server">
            <ItemTemplate>
            <tr>
                <td><a href="/info/detail.aspx?id=<%#Eval("id") %>" target="_blank"><%#Eval("title") %></a></td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
          </table> 
          </div>
        </div>
    </div>
    <div class="clear01"></div>
    <div class="snqyImgbg">
        <div class="flanmu3 moreL4">机构证书</div>
        <div class="moreImgR02"><a href="/info/list.aspx?sort=285" target="_blank">更多&gt;&gt;</a></div>
		<div class="snqyimgScrollCenter" id="hottitle7" style="margin-left:15px;">
            <ul id="ulid7">
            <%if (jigouzhengshu.Count > 0)
                          {
                              foreach (HzsModel.Models.NewsInfo wxpt in jigouzhengshu)
                              {
                  string imgzhi = string.IsNullOrEmpty(wxpt.nimg) ? "../images/noimg.png" : ("../newsimg/s/" + wxpt.nimg);
                  %>
                <li class="imgScroll">
                <div class="imgNewsbg"><a href="/info/infodetail.aspx?id=<%=wxpt.id %>" title="<%=wxpt.title %>" target="_blank"><img data-original="newsimg/s/<%=wxpt.nimg %>"  width="97" height="97" border="0" hspace="1"></a></div>
                <div class="imgScrollTxt"><a href="/info/infodetail.aspx?id=<%=wxpt.id %>" title="<%=wxpt.title %>" target="_blank"><%=StringClass.CutString(wxpt.title, 16)%></a></div>
                </li> 
            <%} } %> 
            
            </ul>
            </div>            
		</div><script>new Marquee(["hottitle7", "ulid7"], 2, 6, 940, 170, 100, 0, 0);</script>
        <div class="clear01"></div>
    <%=UcExecutor.Render("~/controls/footer.ascx", null)%>
    <div class="clear01"></div>
</div>
</body>
</html>
