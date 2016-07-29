<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info_edit.aspx.cs" Inherits="sunadmin_info_info_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑内容信息</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //初始化编辑器
        var editor = KindEditor.create('.editor', {
            width: '98%',
            height: '350px',
            resizeType: 1,
            uploadJson: '/Ajaxupload_json/UpLoadImg.ashx',
            fileManagerJson: '/Ajaxfile_manager_json/UpLoadFile.ashx',
            allowFileManager: true,
            afterBlur: function () { editor.sync(); }
        });
    });
    function checkNewsType(obj) {
        var NewsTypeDialog = $.dialog({
            id: 'DialogNewsType',
            title: "新闻类型",
            height: 300,
            content: "url:../../common/newstype.aspx",
            max: false,
            min: false,
            lock: true
        });
        NewsTypeDialog.data = obj;
    }
</script>
</head>
<body class="mainbody">

<!--导航栏-->
<div class="location">
  <a href="../info/local.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="../info/local.aspx"><span>新闻列表</span></a>
  <i class="arrow"></i>
  <span>编辑新闻信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">详细描述</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">SEO选项</a></li>
      </ul>
    </div>
  </div>
</div>
<form name="form1" method="post" action="<%=ac %>" id="form1" enctype="multipart/form-data">
 <div id="showInfoList"><ul><input type="hidden" name="ntypeid" value="<%=mo.ntypeid%>" /></ul></div>
 <input type="hidden" name="id" value="<%=mo.id %>" />
<div class="tab-content">
  <dl>
    <dt>所属类别</dt>
    <dd id="sslb">
      <input type="text" id="txtntype" class="input" datatype="*2-20" sucmsg=" " readonly="readonly" value="<%=mo.tname %>" /> <a class="search" href="javascript:;" onclick="checkNewsType();"><i></i><span>查询类型</span></a>
    </dd>
  </dl>
  <dl>
    <dt>显示状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <span id="rblStatus"><input id="rblStatus_0" type="radio" name="isverify" value="10"/><label for="rblStatus_0">审核</label><input id="rblStatus_1" type="radio" name="isverify" value="20" /><label for="rblStatus_1">待审核</label><input id="rblStatus_2" type="radio" name="isverify" value="40" /><label for="rblStatus_2">不显示</label></span>
        <script type="text/javascript">
        var ck="<%=mo.isverify.ToString() %>";if(ck==0){$("[name='isverify']:eq(0)").attr("checked","true");}else{$("[name='isverify']").each(function(){if($(this).val()==ck)$(this).attr("checked","true")})}
        </script>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>推荐类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <span id="cblHot"><input id="rdoHot_0" type="radio" name="ishot" value="0" checked="checked" /><label for="rdoHot_0">不推荐</label><input id="rdoHot_1" type="radio" name="ishot" value="10" /><label for="rdoHot_1">推荐</label></span>
        <script type="text/javascript">
        var ckhot="<%=mo.ishot %>";if(ckhot==0)$("input[name='ishot']:eq(0)").attr("checked","true");else{$('input[name="ishot"]').each(function(){if($(this).val()==ckhot)$(this).attr("checked","true")})}
        </script>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>内容标题</dt>
    <dd>
      <input name="title" type="text" id="txtTitle" class="input normal" datatype="*2-100" sucmsg=" " value="<%=mo.title %>" />
      <span class="Validform_checktip">*标题最多100个字符</span>
    </dd>
  </dl>
  
  <dl>
    <dt>封面图片</dt>
    <dd>
      <input type="file"  id="file_nImg" class="input normal " runat="server" datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/" sucmsg=" " />&nbsp;<%=mo.nimg %>
      <input type="hidden" name="nimg" value="<%=mo.nimg %>" />
    </dd>
  </dl>
  
  <dl>
    <dt>浏览次数</dt>
    <dd>
      <input name="click" type="text" id="txtClick" class="input small" datatype="n" sucmsg=" " value="<%=mo.click %>" />
      <span class="Validform_checktip">点击浏览该信息自动+1</span>
    </dd>
  </dl>
  <dl>
    <dt>发布时间</dt>
    <dd>
      <div class="input-date">
        <input name="addtime" type="text" id="txtAddTime" class="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " value="" />
        <i>日期</i>
      </div>
      <span class="Validform_checktip">不选择默认当前发布时间</span>
    </dd>
  </dl>
</div>

<div class="tab-content" style="display:none">
  <dl>
    <dt>内容摘要</dt>
    <dd>
      <textarea name="intro" rows="2" cols="20" id="txtIntro" class="input" datatype="*0-255" sucmsg=" "><%=mo.intro %></textarea>
      <span class="Validform_checktip">不填写则自动截取内容前255字符</span>
    </dd>
  </dl>
  <dl>
    <dt>内容描述</dt>
    <dd>
      <textarea name="content" id="txtContent" class="editor" style="visibility:hidden;"><%=mo.content %></textarea>
    </dd>
  </dl>
</div>

<div class="tab-content" style="display:none">
  <dl>
    <dt>SEO标题</dt>
    <dd>
      <input name="seotitle" type="text" maxlength="255" id="txtSeoTitle" class="input normal" datatype="*0-100" sucmsg=" " value="<%=mo.seotitle %>" />
      <span class="Validform_checktip">255个字符以内</span>
    </dd>
  </dl>
  <dl>
    <dt>SEO关健字</dt>
    <dd>
      <textarea name="seokeyword" rows="2" cols="20" id="txtSeoKeywords" class="input" datatype="*0-255" sucmsg=" " value="<%=mo.seokeyword %>"></textarea>
      <span class="Validform_checktip">以“,”逗号区分开，255个字符以内</span>
    </dd>
  </dl>
  <dl>
    <dt>SEO描述</dt>
    <dd>
      <textarea name="seointro" rows="2" cols="20" id="txtSeoDescription" class="input" datatype="*0-255" sucmsg=" " value="<%=mo.seointro %>"></textarea>
      <span class="Validform_checktip">255个字符以内</span>
    </dd>
  </dl>
</div>

<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <input type="submit" name="btnSubmit" value="提交保存" id="btnSubmit" class="btn" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
<!--Loading...-->
<div id="loading" style="position:fixed !important;position:absolute;top:0;left:0;height:100%; width:100%; z-index:999; background:#000 url(../../images/loading/load.gif) no-repeat center center; opacity:0.3; filter:alpha(opacity=30);font-size:14px;line-height:20px;display:none;">
		<p id="loading-one" style="color:#666;position:absolute; top:50%; left:50%; margin:20px 0 0 -50px; padding:3px 10px;">页面载入中..</p>
	</div>
<!--End-->
</body>
</html>
