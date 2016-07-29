<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cooperation.aspx.cs" Inherits="user_trade_cooperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>合作社合作信息列表</title>    
    <link rel="stylesheet" type="text/css" href="../../Style/common.css" />
    <link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../js/areajs.js"></script>
    <script type="text/javascript" src="../../js/tradejs.js"></script>
    <script>
        function getddl() {
            var ddl = document.getElementById("ddlProperty").value;
            location.href = "?rid="+ddl;
        }
        function getType(p, p2) {
            var getzhi;
            if (p2 > 0) {
                $.each(arrtrade, function (i, n) {
                    if (n.tid == p) {
                        getzhi = n.tname + "--";
                    }
                    if (n.tid == p2) {
                        getzhi += n.tname;
                    }
                });
            } else {
                $.each(arrtrade, function (i, n) {
                    if (n.tid == p) {
                        getzhi = n.tname;
                    }
                });
            }
            document.write(getzhi);
        }
        function del(zhi) {
            $.ajax({
                type: "post", 
                url: "/AjaxViewTrade/Del.ashx?id="+zhi,
                dataType: "json",
                success: function(data) {
                    if(data.status=="y")
                        location.reload(); 
                    else
                        alert(data.info);
                }
            });
        }
    </script>
</head>
<body>   
<div class="mainRighTitle mainRighTitleMessageIco">供求信息管理 > 合作信息列表 <span style=" text-align:right; float:right; padding-right:20px;"><select class="selectList10" id="ddlProperty" onchange="getddl()"><option value="10">审核通过</option><option value="20">待审核</option><option value="40">审核未通过</option></select></span></div>
<%if (!String.IsNullOrEmpty(rid))
  { %><script>document.getElementById("ddlProperty").value=<%=rid %></script><%} %>
<div class="clear02"></div>
<table border="0" class="mainTable02">
<tr class="bgColorGray">
    <th class="width15p">城市</th>
    <th class="width10p">合作信息标题</th>
    <th class="width15p">产品类别</th>
    <th class="width10p">点击量</th>
    <th class="width10p">发布日期</th>
    <th class="width20p">操作</th>
</tr>
<%if (molist.Count == 0)
    { %>
    <tr><td align="center" colspan="6">暂无记录</td></tr>
  <%}else{ for (int i = 0; i < molist.Count; i++){ %>
  <%if (i % 2 != 0)
    { %>
     <tr class="bgColorGray">
  <%}
    else
    { %> <tr ><%} %>
 
    <td><script>$.each(arrarea, function (i, n) { if (n.oid == <%=molist[i].province %>) { document.write(n.oname); } });</script></td>
    <td><span title="<%=molist[i].title %>"><%=StringClass.CutString(molist[i].title,40) %></span></td>
    <td><script>getType(<%=molist[i].ptype %>,<%=molist[i].ptype2 %>);</script> </td>
    <td align="center"><%=molist[i].click %></td>
    <td align="center"><%=molist[i].addtime.ToString("yyyy-MM-dd hh:mm") %></td>
    <td><a class="mainIco mainEdit" href="cooperation_edit.aspx?action=Edit&id=<%=molist[i].id %>">编辑</a><a class="mainIco mainIcoSearch" target="_blank" href="/trade/detail.aspx?id=<%=molist[i].id %>">查看</a><a class=" mainIco mainDelete" href="javascript:del(<%=molist[i].id %>);">删除</a></td>
  </tr>
  <% } }%>

</table>
<div class="clear02"></div>
        <div class="page marginRigh10" id="PageContent" runat="server"></div>

</body>
</html>
