<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="sunadmin_info_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>新闻内容管理</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript" src="../js/hik/info.js?t=1"></script>
</head>

<body class="mainbody">
<form name="form1" method="post" action="#" id="form1">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>内容管理</span>
  <i class="arrow"></i>
  <span>内容列表</span>
</div>
<!--/导航栏-->
<!--频道省市联级返回参数-->
<div id="showInfoList"><ul></ul></div>
<!--/频道省市联级返回参数-->
<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="info_edit.aspx"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack('btnShow','审核通过后将在前台显示，是否继续？');" id="btnShow" class="save" href="javascript:;"><i></i><span>审核</span></a></li>
        <li><a onclick="return ExePostBack('btnHide','审核后将在前台隐藏！！，是否继续？');" id="btnHide" class="save" href="javascript:;"><i></i><span>不显示</span></a></li>
        <li><a onclick="return ExePostBack('btnDelete');" id="btnDelete" class="del" href="javascript:;"><i></i><span>删除</span></a></li>
        <li id="sslb">&nbsp;<input type="text" id="txtntype" class="input" readonly="readonly" /></li>
        <li><a class="search" href="javascript:;" onclick="checkNewsType('1');"><i></i><span>查询类型</span></a></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <select id="ddlProperty">
            <option value="0">审核属性</option>
            <option value="10">审核</option>
            <option value="20">待审核</option>
            <option value="40">不显示</option>
        </select>
        </div>
          <script type="text/javascript">
            <%if (!String.IsNullOrEmpty(ntypename)){ %>
                $("#txtntype").val("<%=ntypename %>");
            <%} %>
            <%if (!String.IsNullOrEmpty(rid)){ %>
                $("#ddlProperty").val(<%=rid %>);
            <%} %>
        </script>
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
    <th width="6%">选择</th>
    <th align="left">标题</th>
    <th align="left" width="12%">所属类别</th>
    <th align="left" width="16%">发布时间</th>
    <th align="left" width="100">编辑人</th>
    <th align="left" width="75">属性</th>
    <th width="8%">操作</th>
  </tr>
  <%if (molist.Count == 0)
    { %>
    <tr><td align="center" colspan="7">暂无记录</td></tr>
  <%}
    else
    {
        for (int i = 0; i < molist.Count; i++)
        {
         %>
  <tr>
    <td align="center">
       <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_<%=molist[i].id %>" type="checkbox" name="rptList_chkId" value="<%=molist[i].id %>" /></span>
    </td>
    <td><a href="info_edit.aspx?action=Edit&id=<%=molist[i].id %>"><%=molist[i].title%></a></td>
    <td><%=molist[i].tname %></td>
    <td><%=molist[i].addtime %></td>
    <td><%=molist[i].editor %></td>
    <td>
      <div class="btn-tools">
        <a title="热门推荐" class="hot <%if (molist[i].ishot > 0){ %>selected<%}%>" ></a>
        <%if (String.IsNullOrEmpty(molist[i].nimg))
          { %>
        <a title="图片" class="pic"></a>
        <%}
          else
          {%>
        <a title="点击显示图片" class="pic selected" href="javascript:checkimg('<%="/newsimg/s/" + molist[i].nimg%>');"></a>
        <%} %>
      </div>
    </td>
    <td align="center"><a href="info_edit.aspx?action=Edit&id=<%=molist[i].id %>">修改</a></td>
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



