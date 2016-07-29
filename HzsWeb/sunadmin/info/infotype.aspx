<%@ Page Language="C#" AutoEventWireup="true" CodeFile="infotype.aspx.cs" Inherits="sunadmin_info_infotype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>新闻类型</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript" src="../../scripts/common.js"></script>
<script type="text/javascript" src="../js/hik/infotype.js"></script>

</head>

<body class="mainbody">
<form name="form1" method="post" id="form1">

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>新闻类型列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="infotype_edit.aspx?action=Add"><i></i><span>新增</span></a></li>
        <li><a id="btnSave" class="save" href="javascript:__doPostBack('btnSave','')"><i></i><span>保存(未做，保存排序)</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack('btnDelete','本操作会删除本类别及下属子类别，是否继续？');" id="btnDelete" class="del" href="javascript:;"><i></i><span>删除</span></a></li>
      </ul>
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
    <th width="6%">选择</th>
    <th align="left" width="6%">编号</th>
    <th align="left">类别名称</th>
    <th align="left" width="12%">排序</th>
    <th width="12%">操作</th>
  </tr>
<%if (molist.Count == 0)
    { %>
    <tr><td align="center" colspan="5">暂无记录</td></tr>
  <%}
    else
    {
        for (int i = 0; i < molist.Count; i++)
        {
         %>
  <tr>
    <td align="center">
       <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_<%=molist[i].ntypeid %>" type="checkbox" name="rptList_chkId" value="<%=molist[i].ntypeid %>" /></span>
    </td>
    <td><%=(page-1)*pageSize+i+1%></td>
    <td>
      <% if (ico == 0)
         { %>
      <span class="folder-open"></span>
      <%}
         else if (ico == 10)
         { %>
      <span class="folder-line"></span><span class="folder-open"></span>
      <%} %>

      <a href="infotype_edit.aspx?action=Edit&id=<%=molist[i].ntypeid %>"><%=molist[i].name %></a> <% if (molist[i].ispublic == 1)
                                                                                                  { %>&nbsp;&nbsp;--<a href="?npid=<%=molist[i].ntypeid %>">查询子类</a><%} %>
    </td>
    
    <td><input name="array" type="text" value="<%=molist[i].array%>" id="array_<%=molist[i].array%>" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center">
      <a href="infotype_edit.aspx?action=Add&id=<%=molist[i].ntypeid %>">添加子类</a>
      <a href="infotype_edit.aspx?action=Edit&id=<%=molist[i].ntypeid %>">修改</a>
    </td>
  </tr>
    <%    }
    }%>
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
