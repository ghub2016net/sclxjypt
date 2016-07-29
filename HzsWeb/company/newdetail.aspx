<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newdetail.aspx.cs" Inherits="company_newdetail" %>
<%@ Register src="../controls/company/foot.ascx" tagname="foot" tagprefix="uc1" %>
<%@ Register src="../controls/company/header.ascx" tagname="header" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/hzs.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/nei.css">
<style>
body{
	background:url(images/bg_01.jpg) repeat-x top #f2f2f2; 
	}
</style>
<title><%=mo.title%>-泸县数字农经网</title>
</head>

<body>
    <form id="form1" runat="server">
<div class="hcontents">
	<uc2:header ID="header1" runat="server" />
    <div class="clear01"></div>
    <div class="ncontents">
    <div class="detailed">
            <div><img src="../images/ntop.jpg" /></div>
            <div class="ncontentsBorder">
                <div class="newsTitle"><%=mo.title%></div>
                <div class="newsTitle2">
                	<span>
                    <span>发布日期：</span>
                    <span><%= mo.addtime %> </span>&nbsp;&nbsp;新闻信息
                    
                    </span>
                </div>
                <div class="newsDetail">
                    <%if (!string.IsNullOrEmpty(mo.pic))
                      { %>
                      <center><img src="../corpimg/s/<%=mo.pic %>" /></center>
                    <%} %>
                　　<% = string.IsNullOrEmpty(mo.content)?"<div style='width:100%;text-align:center;'>暂无内容</div>":mo.content %>
                </div>
      </div>
    </div>
    </div>
    <div><img src="../images/nbottom.jpg" /></div>
    <div class="clear01"></div>
    <div class="clearHB"></div>
    
</div>
<uc1:foot ID="foot1" runat="server" />
    </form>
</body>

</html>
