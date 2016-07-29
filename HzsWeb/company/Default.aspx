<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="company_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="../controls/company/foot.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../controls/company/header.ascx" tagname="header" tagprefix="uc1" %>
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/hzs.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../scripts/MSClass.js" type="text/javascript"></script>
<style type="text/css">
    body
    { background: url(images/bg_01.jpg) repeat-x top #f2f2f2;}</style>
<title><%=hzuModel.corpname %>泸县数字农经网</title>
</head>

<body>
    <form id="form1">
<div class="hcontents">
    <uc1:header ID="header1" runat="server" />
	<div class="clear02"></div>
    <div style="width:750px; float:left">
    <div class="hL">
    	<div class="himg"><img src="images/himg2.jpg" /></div>
        <div class="clear01"></div>
        <div class="hmainNewsL">
        <div class="hmoreL"><img src="images/hnews.jpg" /></div>
        <div class="hmoreR"><a href="comlist.aspx?uid=<%=hzuModel.uid %>">更多&gt;&gt;</a></div>
        <div class="hmainLNews">
            <ul>
                <asp:Repeater ID="rptXwzx" runat="server">
                <ItemTemplate>
                <li><a href="cominfo.aspx?id=<%#Eval("id") %>&uid=<%=hzuModel.uid %>>" title="<%#Eval("title") %>"><%#StringClass.CutString(Eval("content").ToString(),36)%></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul> 
          </div>
        </div>
    </div>
    <div class="hL2">
    	<div><img src="images/about.jpg" /></div>
        <div class="hL2Neirong">
        	<div class="hTxt" style=" height:169px;">　<a href="/company/view.aspx?uid=<%=hzuModel.uid %>&typeid=1"><span class="mingchenFont"><%=hzuModel.corpname%></span>
             <%=String.IsNullOrEmpty(hzsintro.intro)?"":StringClass.CutString(hzsintro.intro, 300)%>
              </a><br />
                　　</div>
    <div class="hClear03"></div>
    <div class="clear02"></div>
    <div class="hGongyingImgbg">
        <div class="hmoreImgR"><a href="../trade/list.aspx?uid=<%=hzuModel.uid %>&trade_type=10" target="_blank">更多&gt;&gt;</a></div>
        <div class="clear01"></div>
		<div class="hGongyingCenter">
            <table border="0" class="hMainTable">
        <tr>              
              <th class="width170">品　种</th>
              <th class="width110">价　格</th>
              <th class="width80">日　期</th>
            </tr>
                <asp:Repeater ID="rptZxgy" runat="server">
               <ItemTemplate>
        <tr>
              <td><a href="../trade/detail.aspx?id=<%#Eval("id") %>&uid=<%=hzuModel.uid %>" target="_blank"><%#StringClass.CutString(Eval("title").ToString(),20) %></a></td>
              <td><%#Eval("price")%>/<%#Eval("units")%></td>
              <td><%#StringClass.CutString(Eval("daytime").ToString(),8) %></td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
          </table>
          </div>            
		</div>
        <div class="clear01"></div>
        </div>
    </div>
    </div>
    <div class="hR">
    	<div class="hmainNews4">
        <div class="hbiaoti2">联系我们</div>
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
            <a target="_blank"  style="text-align:center; margin:auto" href="prodectdetail.aspx?&uid=<%=hzuModel.uid %>&id=<%#Eval("id") %>"><img src="<%#string.IsNullOrEmpty(Eval("pic").ToString())?"../images/noimg.png":("../corpimg/s/"+Eval("pic"))%>" style="width:87px;"/></a>
            </div>
            <div class="himgScrollTxt"><%# StringClass.CutString(Eval("title").ToString(),14) %></div>
            </li></ItemTemplate> 
            </asp:Repeater>
            </ul>
        </div>
        </div>
        <script type="text/javascript">new Marquee("roll",0,1,220,270,50,0,0,0);</script>      
    </div>
    <div class="clear02"></div>

 <uc4:footer ID="footer1" runat="server" />
</div>
    </form>
</body>
</html>

