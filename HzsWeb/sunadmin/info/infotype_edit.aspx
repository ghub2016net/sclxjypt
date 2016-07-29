<%@ Page Language="C#" AutoEventWireup="true" CodeFile="infotype_edit.aspx.cs" Inherits="sunadmin_info_infotype_edit" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑新闻类型</title>
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
    function checkNewsType(obj) {
        var NewsTypeDialog = $.dialog({
            id: 'DialogNewsType',
            title: "新闻类型",
            height: 300,
            content: "url:../../common/newstype.aspx?t=info",
            max: false,
            min: false,
            lock: true
        });
        //NewsTypeDialog.data = obj;
    }
</script>
</head>

<body class="mainbody">
<form method="post" action="<%=ac %>" id="form1">
<!--导航栏-->
<div class="location">
  <a href="infotype.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="infotype.aspx"><span>导航列表</span></a>
  <i class="arrow"></i>
  <span>编辑新闻类型</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">后台新闻类型</a></li>
      </ul>
    </div>
  </div>
</div>
 <div id="showInfoList"><ul><input type="hidden" name="pid" value="<%=mo.pid.ToString().Length>0 ? mo.pid : 0 %>" /></ul></div>
 <input type="hidden" name="ntypeid" value="<%=mo.ntypeid.ToString().Length>0 ? mo.ntypeid : 0 %>" />
  <%if (mo.id.ToString().Length > 0)
    { %>
  <input type="hidden" name="id" value="<%=mo.id%>" />
  <%} %>
  
<div class="tab-content">
  <dl>
    <dt>上级新闻类型</dt>
    <dd id="sslb">
        <%string pname = "根目录"; if (!string.IsNullOrEmpty(mo.pname)) pname = mo.pname;  %>
       <input type="text" id="txtntype" class="input" datatype="*2-20" sucmsg=" " readonly="readonly" value="<%=pname %>" /> <a class="search" href="javascript:;" onclick="checkNewsType();"><i></i><span>查询类型</span></a>
    </dd>
  </dl>
  <%if (istrue <= 0 && mo.ispublic == 1)
    { %>
  <dl>
    <dt>子类开关</dt>
    <dd>
      <div class="rule-multi-radio multi-radio"><div class="boxwrap"><a href="javascript:;" class="selected">禁用</a><a href="javascript:;">启用</a></div>
        <span id="rblIspublic" style="display: none;"><input id="rblIspublic_0" type="radio" name="ispublic" value="0" checked="checked"><label for="rblIspublic_0">禁用</label><input id="rblIspublic_1" type="radio" name="ispublic" value="1"><label for="rblIspublic_1">启用</label></span>
      </div>
    </dd>
  </dl>
  <%} %>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <input name="txtSortId" type="text" id="txtSortId" class="input small" datatype="n" sucmsg=" " value="<%= mo.array.ToString().Length>0 ? mo.array : 0 %>" />
      <span class="Validform_checktip">*数字,默认0为自动排序</span>
    </dd>
  </dl>
  <dl>
    <dt>类型名称</dt>
    <dd><input name="name" type="text" id="txtname" class="input normal" datatype="*1-50" sucmsg=" " value="<%=mo.name %>"> <span class="Validform_checktip">*类别标题，50字符内</span></dd>
  </dl>
  <dl>
    <dt>备注说明</dt>
    <dd>
      <textarea name="intro" rows="2" cols="20" id="txtintro" class="input"><%=mo.intro %>
</textarea>
      <span class="Validform_checktip">非必填，可为空</span>
    </dd>
  </dl>
</div>
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

