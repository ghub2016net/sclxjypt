﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="company_news" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="../controls/company/foot.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../controls/company/header.ascx" tagname="header" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/hzs.css" rel="stylesheet" type="text/css" />
    <link href="../css/nei.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../scripts/MSClass.js" type="text/javascript"></script>

<style>
body{
	background:url(images/bg_01.jpg) repeat-x top #f2f2f2; 
	}
</style>
<title>新闻中心-泸县数字农经网</title>
</head>

<body>
<div class="hcontents">
    <uc1:header ID="header1" runat="server" />
	<div class="clear01"></div>
    <div class="hR2">
    	<div class="hmainNews4">
        <div class="hbiaoti2">联系我们</div>
        <div class="hmoreR">&nbsp;</div>
        <div class="hmainLNews4">
                  地址：<%=hzuModel.address %><br />
                  电话：<%=hzuModel.tel %><br />
                  传真：<%=hzuModel.fax %><br />
                  邮编：<%=hzuModel.zipcode %><br />
                  E-mail：<%=hzuModel.email %><br />
          </div>
        </div>
        <div class="clear01"></div>
        <div class="hmainNews5">
        <div class="hbiaoti2">产品展示</div>
        <div class="hmoreR"><a href="products.aspx?uid=<%=hzuModel.uid %>">更多&gt;&gt;</a></div>
        <div class="himgScrollCenter" id="roll">
            <ul>
            <asp:Repeater ID="rptCpzs" runat="server">
               <ItemTemplate>
            <li class="himgScroll">
            <div class="himgNewsbg">
            <a target="_blank"  style="text-align:center; margin:auto" href="comlist.aspx?&uid=<%=hzuModel.uid %>"><img src="<%#string.IsNullOrEmpty(Eval("pic").ToString())?"../images/noimg.png":("../corpimg/s/"+Eval("pic"))%>" style="width:87px;"/></a>
            </div>
            <div class="himgScrollTxt"><%# StringClass.CutString(Eval("title").ToString(),14) %></div>
            </li></ItemTemplate> 
            </asp:Repeater>
            </ul>
        </div>
        </div>       
         <script type="text/javascript">new Marquee("roll", 0, 1, 220, 270, 50, 0, 0, 0);</script>      
    </div>

        <div class="nMainRig">
        	<div class="nRighTitleMessageIco">当前位置：首页 > 新闻中心</div>
                <div class="hzsymainNews">
                    <ul>
                    <asp:Repeater ID="rptXinwen" runat="server">
                     <ItemTemplate>
                          <li><a href="newdetail.aspx?uid=<%#Eval("uid") %>&id=<%#Eval("id") %>" title="<%#Eval("title") %>"><%#StringClass.CutString(Eval("title").ToString(), 36)%></a>
                          <span class="mainDate"><%#Convert.ToDateTime(Eval("addtime")).ToString("yyyy-MM-dd") %></span>
                          </li>
                            </ItemTemplate>
                             </asp:Repeater>
                           <div class="clear02"></div>
                  
                        </ul>
                  </div>
                  <div><img src="../images/nbottom02.jpg" /></div>
        </div>
    <div class="clearHB"></div>    

 <uc4:footer ID="footer1" runat="server" />
</div>
</body>
</html>