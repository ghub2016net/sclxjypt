<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="difang_infodetail" %>
<%@ Register src="~/controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="~/controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="~/controls/footer.ascx" tagname="footer" tagprefix="uc4" %>
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
<title>泸县数字农经网-详细页</title>
</head>

<body>
<form runat="server">
<div class="contents">
	<uc1:header ID="header1" runat="server" />
    <uc2:xsheader ID="xsheader1" runat="server" />
    <div class="clear01"></div>
    <div class="ncontents">
    <div class="detailed">
            <div><img src="../images/ntop.jpg" /></div>
            <div class="ncontentsBorder">
                <div class="newsTitle"><%=iinfo.title %></div>
                <div class="newsTitle2">
                	<span>
                    <span>发布日期：</span>
                    <span><%=iinfo.addtime %> </span>&nbsp;&nbsp;
                    <span>作者：<%=iinfo.source %></span>
                    <span></span>
                    </span>
                </div>
                <div class="newsDetail">
                <%if (string.IsNullOrEmpty(iinfo.pic) || iinfo.pic == "图片名称") { }
                      else
                      {%>
                    <center><img width="100%" src="../newsimg/s/<%=iinfo.pic %>" /></center>
                    <%} %>
                <%=iinfo.content %>　　
                </div>
      </div>
    </div>
    </div>
    <div><img src="../images/nbottom.jpg" /></div>
                <div class="clear01"></div>
  <uc4:footer ID="footer1" runat="server" />
  <div class="clear01"></div>	
</div>
</form>
</body>
</html>
