<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager_pwd.aspx.cs" Inherits="sunadmin_manager_manager_pwd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>修改密码</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidformByAjax();      
    });
</script>
</head>

<body class="mainbody">
<!--导航栏-->
<div class="location">
 <a href="../manager/managerlist.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="../manager/managerlist.aspx"><span>管理员列表</span></a>
  <i class="arrow"></i>
  <span>修改密码</span>
</div>
<div class="line10"></div>
<!--/导航栏-->
<form method="post" action="<%=ac %>" id="form1">
<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑管理员信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>账户状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <span id="rblIsDel"><input id="rblIsDel_0" type="radio" name="isdel" value="0" checked="checked" /><label for="rblIsDel_0">启用</label><input id="rblIsDel_1" type="radio" name="isdel" value="1" /><label for="rblIsDel_0">禁用</label></span>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>用户名</dt>
    <dd><input name="name" type="text" value="<%=mo.name %>" id="name" class="input normal" datatype="*2-50" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>登录密码</dt>
    <dd><input type="password" name="apwd" type="text" value="<%=pwd %>" id="apwd" class="input normal" datatype="*6-18" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>确认密码</dt>
    <dd><input type="password" name="pwd_again" type="text" value="<%=pwd %>" id="pwd_again" class="input normal" recheck="apwd" datatype="*6-18" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>电子邮箱</dt>
    <dd><input name="email" type="text" value="<%=mo.email %>" id="email" class="input normal" datatype="e" sucmsg=" " /></dd>
  </dl>

</div>
<input type="hidden" id="adminid" name="adminid" value="<%=mo.adminid %>" />
<input type="hidden" id="utype" name="utype" value="1" />
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <input type="submit" name="btnSubmit" value="提交保存" id="btnSubmit" class="btn" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

<!--Loading...-->
<div id="loading" style="position:fixed !important;position:absolute;top:0;left:0;height:100%; width:100%; z-index:999; background:#000 url(../../images/loading/load.gif) no-repeat center center; opacity:0.3; filter:alpha(opacity=30);font-size:14px;line-height:20px;display:none;">
		<p id="loading-one" style="color:#666;position:absolute; top:50%; left:50%; margin:20px 0 0 -50px; padding:3px 10px;">页面载入中..</p>
	</div>
<!--End-->
</form>
</body>
</html>
