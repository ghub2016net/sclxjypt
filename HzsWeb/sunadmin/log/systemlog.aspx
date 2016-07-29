<%@ Page Language="C#" AutoEventWireup="true" CodeFile="systemlog.aspx.cs" Inherits="sunadmin_log_systemlog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>系统日志管理</title>
<link type="text/css" rel="stylesheet" href="../../skin/default/style.css" />
<link type="text/css" rel="stylesheet" href="../../skin/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript" src="../../scripts/common.js"></script>
<script type="text/javascript" src="../js/hik/syslog.js?tt=1"></script>
</head>

<body class="mainbody">
<form method="post" action="#" id="form1">

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <span>系统日志</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>

        <li><a onclick="return ExePostBack('btnDelete');" id="btnDelete" class="del" href="javascript:;"><i></i><span>删除</span></a></li>
        
      </ul>
      
    </div>
    
    <div class="r-list">
        <input name="txtKeywords" type="text" id="txtKeywords" class="keyword" />
      <input id="lbtnSearch" value="查询" class="btn-search" />
    </div>
    
    <div class="r-list">
        <div class="rule-single-select">
          <select id="ddlProperty">
            <option value="0">日志类型属性</option>
            <option value="1">管理员</option>
            <option value="2">合作社</option>
            <option value="3">其他</option>
        </select>
        <script type="text/javascript">
            <%if (!String.IsNullOrEmpty(rid)){ %>
                $("#ddlProperty").val(<%=rid %>);
            <%} %>
        </script>
        </div>
     </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th align="center" width="8%">选择</th>
    <th align="center">内容</th>
    <th align="left" width="16%">登录IP地址</th>
    <th width="16%" align="left">日志类型</th>
    <th width="18%" align="center">登录时间</th>
    
  </tr>
<%if (SysLog_list.Count == 0)
    { %>
    <tr><td align="center" colspan="6">暂无记录</td></tr>
  <%}
    else
    {
        for (int i = 0; i < SysLog_list.Count; i++)
        {
         %>
  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_<%=SysLog_list[i].id %>" type="checkbox" name="rptList_chkId" value="<%=SysLog_list[i].id %>" /></span>
    </td>
    <td align="center"><a href="javascript:;"><%=SysLog_list[i].logValue
%></a></td>
    <td align="left"><%=SysLog_list[i].ip %></td>
    <td align="left"><%=SysLog_list[i].logType %></td>
    <td align="center"><%=SysLog_list[i].addtime.ToString("yyyy-MM-dd hh:mm") %></td>
   
   
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
