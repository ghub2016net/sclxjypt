<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="user_company_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../../Style/common.css" />
    <link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
    <title>合作社会员管理平台</title>
    </head>

    <body>
          <div class="mainRighTitle mainRighTitleMessageIco">合作社管理 > 新闻中心</div>
          <div class="clear02"></div>
          <table border="0" class="mainTable02">
        <tr class="bgColorGray">
              <th class="width20p">标题</th>
              <th class="width10p">点击量</th>
              <th class="width10p">发布日期</th>
              <th class="width20p">操作</th>
            </tr>
    <%if (molist.Count == 0)
    { %>
    <tr><td align="center" colspan="4">暂无记录</td></tr>
  <%}else{ for (int i = 0; i < molist.Count; i++){ %>
  <%if (i % 2 != 0)
    { %>
     <tr class="bgColorGray">
  <%}
    else
    { %> <tr ><%} %>
 
    <td><%=molist[i].title %></td>
    <td><%=molist[i].click %></td>
    <td align="center"><%=molist[i].addtime.ToString("yyyy-MM-dd hh:mm") %></td>
    <td><a class="mainIco mainEdit" href="info_edit.aspx?action=Edit&rid=<%=molist[i].typeid %>&id=<%=molist[i].id %>">编辑</a><a class="mainIco mainIcoSearch" target="_blank" href="/company/newdetail.aspx?uid=<%=molist[i].uid %>&id=<%=molist[i].id %>">查看</a><a class=" mainIco mainDelete" href="/AjaxViewCompany/Del.ashx?id=<%=molist[i].id %>">删除</a></td>
  </tr>
  <% } }%>
      </table>
      <div class="clear02"></div>
                  <div class="page marginRigh10">    <div class="page marginRigh10" id="PageContent" runat="server"></div>
</div>
</body>
</html>

