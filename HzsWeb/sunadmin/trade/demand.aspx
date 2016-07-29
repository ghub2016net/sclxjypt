<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demand.aspx.cs" Inherits="sunadmin_trade_demand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>合作社需求信息列表</title>
<link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../js/areajs.js"></script>
<script type="text/javascript" src="../../js/tradejs.js"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript" src="../js/hik/demand.js"></script>
</head>

<body class="mainbody">
<form method="post" action="#" id="form1">

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>需求信息管理</span>
  <i class="arrow"></i>
  <span>需求列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="demand_edit.aspx"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack('btnShow','审核通过后将在前台显示，是否继续？');" id="btnShow" class="save" href="javascript:;"><i></i><span>审核</span></a></li>
        <li><a onclick="return ExePostBack('btnHide','审核后将在前台隐藏！！，是否继续？');" id="btnHide" class="save" href="javascript:;"><i></i><span>不显示</span></a></li>
        <li><a onclick="return ExePostBack('btnDelete');" id="btnDelete" class="del" href="javascript:;"><i></i><span>删除</span></a></li>
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
      <input name="txtKeywords" type="text" id="txtKeywords" class="keyword" value="<%=keywords %>" />
      <input id="lbtnSearch" value="查询" class="btn-search" />
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="12%">城市</th>
    <th align="left" width="24%">需求信息标题</th>
    <th align="left" width="15%">产品类别</th>
    <th width="8%">点击率</th>
    <th width="15%">添加时间</th>
    <th align="left" width="8%">属性</th>
    <th align="left" width="10%">操作</th>
  </tr>
  <%if (molist.Count == 0)
    { %>
    <tr><td align="center" colspan="8">暂无记录</td></tr>
  <%}else{ for (int i = 0; i < molist.Count; i++){ %>
  <tr>
    <td align="center">
       <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_<%=molist[i].id %>" type="checkbox" name="rptList_chkId" value="<%=molist[i].id %>" /></span>
    </td>
    <td><script>$.each(arrarea, function (i, n) { if (n.oid == <%=molist[i].province %>) { document.write(n.oname); } });</script></td>
    <td><span title="<%=molist[i].title %>"><%=StringClass.CutString(molist[i].title,40) %></span></td>
    <td><script>getType(<%=molist[i].ptype %>,<%=molist[i].ptype2 %>);</script> </td>
    <td align="center"><%=molist[i].click %></td>
    <td align="center"><%=molist[i].addtime.ToString("yyyy-MM-dd hh:mm") %></td>
    <td>
      <div class="btn-tools">
        <a title="热门推荐" class="hot <%if (molist[i].ishot > 0){ %>selected<%}%>" ></a>
        <%if (String.IsNullOrEmpty(molist[i].tpic)){ %>
        <a title="图片" class="pic"></a>
        <%} else {%>
        <a title="点击显示图片" class="pic selected" href="javascript:checkimg('<%="/tradeimg/s/" + molist[i].tpic%>');"></a>
        <%} %>
      </div>
    </td>
    <td align="left"><a href="demand_edit.aspx?action=Edit&id=<%=molist[i].id %>">修改</a>&nbsp; <a target="_blank" href="../../show/xuqiu.aspx?id=<%=molist[i].id %>">查看</a></td>
  </tr>
  <% } }%>
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
