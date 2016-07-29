<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lsadmin_Default" %>

<%@ Register src="../controls/lishi/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../css/css.css">
<title>理事会员专享-泸县数字农经网</title>
<script src="../scripts/MSClass.js" type="text/javascript"></script>

</head>

<body>
    <form id="form1" runat="server">
<div class="contents">
    <uc1:header ID="header1" runat="server" />
    <div class="xz">
  		<div class="lishi">所在位置： 理事专享信息</div>
    </div>
    <div class="clear01"></div>
    <div class="contentsRight">
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">示范社指南</div>
        <div class="moreR"><a href="list.aspx?sort=277" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
            <ul>
                  <asp:Repeater ID="rptSfszn" runat="server">
                <ItemTemplate>
                   <li><a href="detail.aspx?id=<%#Eval("id")%>" title="<%#Eval("title") %>" target="_blank" ><%# StringClass.CutString(Eval("title").ToString(), 42)%></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">项目指南</div>
        <div class="moreR"><a href="list.aspx?sort=276" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
            <ul>
                <asp:Repeater ID="rptXmzn" runat="server">
                <ItemTemplate>
                <li><a href="detail.aspx?id=<%#Eval("id") %>" target="_blank"><%#StringClass.CutString(Eval("title").ToString(), 34)%></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">献策建议</div>
        <div class="moreR"><a href="list.aspx?sort=288" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
            <ul>
                <asp:Repeater ID="rptxcjy" runat="server">
                <ItemTemplate>
                <li><a href="detail.aspx?id=<%#Eval("id") %>" target="_blank"><%#StringClass.CutString(Eval("title").ToString(), 34)%></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
    </div>
    <div class="contentsLeft">
    <div class="mainNews3">
        <div class="biaoti">人物风采</div>
        <div class="biaotiMore"><a href="list.aspx?sort=275" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul>
                <asp:Repeater ID="rptRwfc" runat="server">
                <ItemTemplate>
                <li><a href="../info/infodetail.aspx?id=<%#Eval("id")%>" title="<%#Eval("title") %>" target="_blank" ><%# StringClass.CutString(Eval("title").ToString(), 42)%></a><span class="mainDate"><%# string.Format("{0:d}",Eval("crdate")) %></span></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
        <div class="mainNews3 rig">
        <div class="biaoti">营销指南</div>
        <div class="biaotiMore"><a href="list.aspx?sort=278" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul>
                <asp:Repeater ID="rptYxzn" runat="server">
                <ItemTemplate>
                <li><a href="../info/infodetail.aspx?id=<%#Eval("id")%>" title="<%#Eval("title") %>" target="_blank" ><%# StringClass.CutString(Eval("title").ToString(), 42)%></a><span class="mainDate"><%# string.Format("{0:d}",Eval("crdate")) %></span></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="newsImgbg" style="height:208px;">
        <div class="flanmu2 moreL3">理事图片</div>
        <div class="moreImgR"><a href="list.aspx?sort=287" target="_blank">更多&gt;&gt;</a></div>
		<div class="imgScrollCenter" style="margin-top:11px;" id="hottitle6">
            <ul id="ulid6">
            <%if (lishitupian.Count > 0){ foreach (HzsModel.Models.NewsInfo wxpt in lishitupian){
                  string imgzhi = string.IsNullOrEmpty(wxpt.nimg) ? "../images/noimg.png" : ("../newsimg/s/" + wxpt.nimg);
                  %>
                <li class="imgScroll">
                <div class="imgNewsbg"><a href="/info/infodetail.aspx?id=<%=wxpt.id %>" title="<%=wxpt.title %>" target="_blank"><img data-original="newsimg/s/<%=wxpt.nimg %>"  width="97" height="97" border="0" hspace="1"></a></div>
                <div class="imgScrollTxt"><a href="/info/infodetail.aspx?id=<%=wxpt.id %>" title="<%=wxpt.title %>" target="_blank"><%=StringClass.CutString(wxpt.title, 16)%></a></div>
                </li> 
            <%} } %> 
            </ul>
            </div>            
		</div><script>new Marquee(["hottitle6", "ulid6"], 2, 6, 740, 160, 100, 0, 0);</script>        
        <div class="clear01"></div> 
        <div class="mainNews3">
        <div class="biaoti">经验交流</div>
        <div class="biaotiMore"><a href="list.aspx?sort=279" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul>
                <asp:Repeater ID="rptJyjl" runat="server">
                <ItemTemplate>
                <li><a href="../info/infodetail.aspx?id=<%#Eval("id")%>" title="<%#Eval("title") %>" target="_blank" ><%# StringClass.CutString(Eval("title").ToString(), 42)%></a> </a><span class="mainDate"><%#string.Format("{0:d}",Eval("crdate"))%></span></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
        <div class="mainNews3 rig">
        <div class="biaoti">联会通报</div>
        <div class="biaotiMore"><a href="list.aspx?sort=280" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul>
                <asp:Repeater ID="rptLhtb" runat="server">
                <ItemTemplate>
                <li><a href="../info/infodetail.aspx?id=<%#Eval("id")%>" title="<%#Eval("title") %>" target="_blank" ><%# StringClass.CutString(Eval("title").ToString(), 42)%></a> </a><span class="mainDate"><%#string.Format("{0:d}",Eval("crdate"))%></span></li>
                </ItemTemplate>
                </asp:Repeater>
             </ul> 
          </div>
        </div>    
    </div>
  <div class="clear01"></div>
  <uc2:footer ID="footer1" runat="server" />
    <div class="clear01"></div>
</div>
    </form>
</body>
</html>
