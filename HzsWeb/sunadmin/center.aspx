<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center.aspx.cs" Inherits="sunadmin_center" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>管理首页</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/scripts/layout.js"></script>
</head>

<body class="mainbody">
<form name="form1" method="post" action="center.aspx" id="form1">
<div>
</div>

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>管理中心</span>
</div>
<!--/导航栏-->

<!--内容-->
<div class="line10"></div>
<%if (loglist.Rows.Count > 0)
  { %>
<div class="nlist-1">
  <ul>
    <% if (loglist.Rows.Count > 1)
       { %>
    <li>本次登录IP：<%=loglist.Rows[0]["loginip"] %></li>
    <li>上次登录IP：<%=loglist.Rows[1]["loginip"]%></li>
    <li>上次登录时间：<%=loglist.Rows[1]["logintime"]%></li>
    <%}
       else
       { %>
       <li>本次登录IP：<%=loglist.Rows[0]["loginip"]%></li>
       <li>本次登录时间：<%=loglist.Rows[0]["logintime"]%></li>
    <%} %>
  </ul>
</div>
<div class="line10"></div>
<%} %>
<div class="nlist-2">
  <h3><i></i>站点信息</h3>
  <ul>
    <li>站点名称：<%=siteConfig.sitename%></li>
    <li>公司名称：<%=siteConfig.companyname %></li>
    <li>网站域名：<%=siteConfig.website %></li>
    <li>安装目录：<%=siteConfig.webpath%></li>
    <li>网站管理目录：<%=siteConfig.webadminpath %></li>
    <li>附件上传目录：<%=uploadpath %>
    <li>服务器名称：<%=Server.MachineName %></li>
    <li>服务器IP：<%=Request.ServerVariables["LOCAL_ADDR"]%></li>
    <li>NET框架版本：<%=Environment.Version.ToString() %></li>
    <li>操作系统：<%=Environment.OSVersion.ToString() %></li>
    <li>IIS环境：<%=Request.ServerVariables["SERVER_SOFTWARE"]%></li>
    <li>服务器端口：<%=Request.ServerVariables["SERVER_PORT"]%></li>
    <li>目录物理路径：<%=siteConfig.systempath%></li>
    <li>系统版本：V<%=Utils.GetVersion()%></li>
    
  </ul>
</div>
<div class="line20"></div>

<div class="nlist-3">
  <ul>
    <li><a onclick="parent.linkMenuTree(true, 'channel_trade_list');" class="icon-setting" href="javascript:;"></a><span>供应信息</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'channel_trade_demand');" class="icon-channel" href="javascript:;"></a><span>需求信息</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'channel_huser_list');" class="icon-templet" href="javascript:;"></a><span>合作社会员</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'app_builder_html');" class="icon-mark" href="javascript:;"></a><span>生成静态</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'plugin_link');" class="icon-plugin" href="javascript:;"></a><span>插件配置</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'user_list');" class="icon-user" href="javascript:;"></a><span>会员管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_list');" class="icon-manaer" href="javascript:;"></a><span>管理员</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_log');" class="icon-log" href="javascript:;"></a><span>系统日志</span></li>
  </ul>
</div>

<div class="nlist-4">

  <h3><i class="msg"></i>官方消息</h3>
  <ul>
    <li>软件公司： <a target="_blank" href="http://www.chinasunsoft.net">青岛太阳软件有限公司</a></li>
<li>技术支持电话： <a href="javascript:">0532-85877479/85884428</a></li>

  </ul>
</div>

<!--/内容-->
</form>
</body>
</html>
