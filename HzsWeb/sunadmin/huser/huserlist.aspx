<%@ Page Language="C#" AutoEventWireup="true" CodeFile="huserlist.aspx.cs" Inherits="sunadmin_huser_huserlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>合作社会员管理</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript" src="../../js/areajs.js"></script>
<script type="text/javascript" src="../js/hik/huser.js"></script>

</head>
<body class="mainbody">
<form method="post" action="#" id="form1">

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>合作社会员管理</span>
  <i class="arrow"></i>
  <span>合作社会员列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="huser_edit.aspx?action=Add"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack('btnShow','执行站内审核通过，是否继续？');" id="btnShow" class="save" href="javascript:;"><i></i><span>审核</span></a></li>
        <li><a onclick="return ExePostBack('btnDelete');" id="btnDelete" class="del" href="javascript:;"><i></i><span>删除</span></a></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <select name="ddlGroupId" onchange="javascript:;" id="ddlhzsjb">
	        <option value="">=合作社级别=</option>
	        <%foreach (HzsModel.HZSModels.HzsUserType htype in typelist.HzsUserType)
                  {%>
                    <option value="<%=htype.id %>" ><%= htype.tname%></option>
                <%} %>
        </select>
        </div>
      </div>

      <div class="menu-list">
        <div class="rule-single-select">
          <select name="ddlGroupId" onchange="javascript:;" id="ddlsfsjb">
	        <option value="">=经营模式=</option>
	        <%foreach (HzsModel.HZSModels.HzsUserJyms jtype in jymslist.HzsUserJyms)
                  {%>
                    <option value="<%=jtype.id %>" ><%= jtype.jname %></option>
                <%} %>
        </select>
        </div>
      </div>
    </div>
    <div class="r-list">
      <input name="txtKeywords" type="text" id="txtKeywords" class="keyword" />
      <input id="lbtnSearch" value="查询" class="btn-search" />
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="12%">用户名</th>
    <th align="left" width="20%">合作社名称</th>
    <th align="left" width="10%">合作社等级</th>
    <th align="left" width="12%">城市</th>
    <th align="left" width="18%">经营模式</th>
    <th align="left" width="12%">注册时间</th>
    <th width="8%">操作</th>
  </tr>
<%if(molist.Count==0){%><tr><td align="center" colspan="8">暂无记录</td></tr><%}else{for(int i=0;i<molist.Count;i++){%>
  <tr>
    <td align="center">
       <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_<%=molist[i].uid %>" type="checkbox" name="rptList_chkId" value="<%=molist[i].uid %>" /></span>
    </td>
    <td align="left"><%=molist[i].hname %></td>
    <td align="left"><%=molist[i].corpname %></td>
    <td align="left"><%=GetHzsType(molist[i].htype)%></td>
    <td align="left"><script>$.each(arrarea, function (i, n) { if (n.oid == <%=molist[i].province %>) { document.write(n.oname); } });</script>
    <%if (molist[i].city != 0){ %><script>$.each(arrarea, function (i, n) { if (n.oid == <%=molist[i].city %>) { document.write(" "+n.oname); } });</script><%} %>
    <%if (molist[i].county != 0) { %><script>$.each(arrarea, function (i, n) { if (n.oid == <%=molist[i].county %>) { document.write(" "+n.oname); } });</script><%} %>
    </td>
    <td align="left"><%=GetScope(molist[i].scope) %></td>
    <td align="left"><%=molist[i].addtime %></td>
    <td align="center"><a href="huser_edit.aspx?action=Edit&id=<%=molist[i].uid %>">修改</a></td>
  </tr>
<%}}%>
</table>

<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><input value="<%=pageSize %>" class="pagenum" readonly="readonly" /><span>条/页</span>
  </div>
  <div id="PageContent" class="default right" runat="server"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
