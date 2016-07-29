<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="lsadmin_detail" %>
<%@ Register src="../controls/lishi/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="stylesheet" type="text/css" href="../css/css.css">
<link rel="stylesheet" type="text/css" href="../css/nei.css">
<title></title>
<script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../scripts/jquery/jquery.form.min.js" type="text/javascript"></script>
<script src="../scripts/MSClass.js" type="text/javascript"></script>
<script src="../scripts/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery.lazyload.min.js"></script>  
</head>
<body>
    <form id="form1" runat="server">
    <div class="contents">
	<uc1:header ID="header1" runat="server" />
    <div class="clear01"></div>
    <div class="ncontents">
    <div class="detailed">
            <div><img src="../images/ntop.jpg" /></div>
            <div class="ncontentsBorder">
                <div class="newsTitle"><%=iinfo.title %></div>
                <div class="newsTitle2">
                	<span>
                    <span>发布日期：</span>
                    <span><%=iinfo.addtime.ToString() %> </span>&nbsp;&nbsp;
                    <span>点击率：</span>
                    <span><%=iinfo.click %></span>
                    </span>
                </div>
                <div class="newsDetail">
                <%=iinfo.content %>
                </div>
      </div>
    </div>
    </div>
    <div><img src="../images/nbottom.jpg" /></div>
                <div class="clear01"></div>
       <uc2:footer ID="nfooter1" runat="server" /> 
  <div class="clear01"></div>	
</div>
    </form>
</body>
</html>
