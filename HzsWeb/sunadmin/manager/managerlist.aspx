<%@ Page Language="C#" AutoEventWireup="true" CodeFile="managerlist.aspx.cs" Inherits="sunadmin_manager_managerlist" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理员列表</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.pagination.js"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript" src="../../scripts/common.js"></script>
<script type="text/javascript" src="../js/hik/adminuserlist.js"></script>
</head>

<body class="mainbody">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>管理员列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <form runat="server">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="manager_pwd.aspx?action=Add"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack('btnDelete');" id="btnDelete" class="del" href="javascript:;"><i></i><span>禁用</span></a></li>
      </ul>
    </div>
    </form>
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
    <th >用户名</th>
    <th>邮箱</th>
    <th width="18%">添加时间</th>
    <th width="10%">状态</th>
    <th width="10%">操作</th>
  </tr>
<%if(molist.Count==0){%><tr><td align="center" colspan="6">暂无记录</td></tr><%}else{for(int i=0;i<molist.Count;i++){%>
  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_<%=molist[i].adminid %>" type="checkbox" name="rptList_chkId" value="<%=molist[i].adminid %>" /></span>
    </td>
    <td align="center"><a href="javascript:;"><%=molist[i].name %></a></td>
    <td align="center"><%=molist[i].email %></td>
    <td align="center"><%=molist[i].addtime.ToString("yyyy-MM-dd hh:mm") %></td>
    <td align="center"><%=molist[i].isdel==0 ? "正常":"禁用"%></td>
    <td align="center">
    <%if (molist[i].adminid.ToString() == DataCache.GetCache(HzsKey.CACHE_HTUID).ToString())
      { %><a href="manager_pwd.aspx?action=Edit&id=2">修改</a>
      <%} %>
    </td>   
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
</body>
</html>

