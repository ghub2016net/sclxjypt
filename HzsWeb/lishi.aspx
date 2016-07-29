<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lishi.aspx.cs" Inherits="lishi" %>
<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<link rel="stylesheet" type="text/css" href="styles/css.css"/>
    <link rel="stylesheet" type="text/css" href="styles/nei.css"/>--%>
    <link rel="stylesheet" type="text/css" href="css/css.css">
<link rel="stylesheet" type="text/css" href="css/nei.css">
   
    <title></title>
    <script src="scripts/MSClass.js" type="text/javascript"></script>
    <style>
 .cdborder{
	float:left;
	border:1px solid #ccc;
	padding-bottom:10px;
}
.blja{
	float:left;
	width:956px;
	margin:10px 0px 0px 10px;
	display:inline;
}
.fjta{
	float:left;
	border:1px solid #b0cb8b;
	padding:0px 2px 2px 0px;
}
.ftali01{
	float:left;
	width:130px;
	border:1px solid #b0cb8b; 
	text-align:center; 
	line-height:40px;
	margin:2px 2px 0px 2px;
	display:inline;
	background-color:#f0fedc;
}
.ftali02{
	float:left;
	width:130px;
	border:1px solid #b0cb8b; 
	text-align:center; 
	line-height:40px;
	margin:2px 2px 0px 2px;
	display:inline;
	background-color:#fff;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="contents">
	<uc1:header ID="header1" runat="server" />
	<uc2:xsheader ID="xsheader1" runat="server" />   
    <div class="clear01"></div>
        <div class="mainRighTitleMessageIco">
        	当前位置：<a href="../Default.aspx">首页</a> > <a href="lishi.aspx">理事会员</a>
        	</div>   
        	             
        	<div class="newsTitle">合作社理事单位成员</div>
                <div class="newsTitle2">
                </div>
                <div class="newsDetail">
                    
                　　<div class="border">
<div class="blja">
   <div class="fjta">
		<ul>
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
            <li class="ftali01"><a href="../company/default.aspx?uid=<%#Eval("uid")%>" target="_blank"><%#Eval("corpname")%></a></li><%--../community/com_detail.aspx?id=<%#Eval("id")%>--%>
            </ItemTemplate>
            </asp:Repeater>
	       
	       
        </ul>
     </div>   
 </div>
</div>
                　　
                　　
                </div>
 <li style="text-align:right;font-size: 14px;"><img src="images/gb.gif" width="14" height="15"><a href="javascript:window.close();">[关闭本页]</a>&nbsp;&nbsp;</li>  
                <div class="clear01"></div>
                <uc3:footer ID="nfooter1" runat="server" />    
  <div class="clear01"></div>	
</div>
    </form>
</body>
</html>
