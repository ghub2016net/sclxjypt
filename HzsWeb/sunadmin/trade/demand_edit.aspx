<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demand_edit.aspx.cs" Inherits="sunadmin_trade_demand_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑需求信息</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../../js/tradejs.js"></script>
<script type="text/javascript" src="../js/hik/trade_edit.js?s=1"></script>
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
</script>
</head>
<body class="mainbody">

<!--导航栏-->
<div class="location">
  <a href="../trade/supply.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="../trade/supply.aspx"><span>需求列表</span></a>
  <i class="arrow"></i>
  <span>编辑需求信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">需求信息 页1</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">需求信息 页2</a></li>
      </ul>
    </div>
  </div>
</div>
<form name="form1" method="post" action="<%=ac %>" id="form1" enctype="multipart/form-data">
 <input type="hidden" name="id" value="<%=mo.id %>" />
<div class="tab-content">
  <dl>
    <dt>显示状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <span id="rblStatus"><input id="rblStatus_0" type="radio" name="isverify" value="10"/><label for="rblStatus_0">审核</label><input id="rblStatus_1" type="radio" name="isverify" value="20" /><label for="rblStatus_1">待审核</label><input id="rblStatus_2" type="radio" name="isverify" value="40" /><label for="rblStatus_2">不显示</label></span>
        <script type="text/javascript">
            var ck = "<%=mo.isverify.ToString() %>"; if (ck == 0) { $("[name='isverify']:eq(0)").attr("checked", "true"); } else { $("[name='isverify']").each(function () { if ($(this).val() == ck) $(this).attr("checked", "true") }) }
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
            var ckhot = "<%=mo.ishot %>"; if (ckhot == 0) $("input[name='ishot']:eq(0)").attr("checked", "true"); else { $('input[name="ishot"]').each(function () { if ($(this).val() == ckhot) $(this).attr("checked", "true") }) }
        </script>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>产品类型</dt>
    <dd>
        <div class="rule-single-select">
         <select name="ptype" id="ddlptype" datatype="*" sucmsg=" "></select>
         </div>
        <div class="rule-single-select">
         <select name="ptype2" id="ddlptype2" sucmsg=" "><option value="">==小类==</option></select>
         </div>
        
    </dd>
    <%if (mo.ptype > 0){ %>
    <script>
        $(function () {
            $("#ddlptype").val("<%=mo.ptype %>");
            //加载小类
            $("#ddlptype2").empty();
            var bigzhi = $("#ddlptype").val();
            $.each(arrtrade, function (a, b) {
                if (b.pid == bigzhi) {
                    $("#ddlptype2").append("<option value='" + b.tid + "'>" + b.tname + "</option>");
                }
            });
            $("#ddlptype2").prepend("<option value=\"\">==小类==</option>");
            <%if(mo.ptype2 > 0){ %>
            $("#ddlptype2").val("<%=mo.ptype2 %>");
            <%} %>
            $(".rule-single-select").ruleSingleSelect();
        });
    </script>
    <%} %>
  </dl>
  <dl>
    <dt>产品名称</dt>
    <dd><input name="name" type="text" id="txtname" class="input normal" datatype="*1-50" sucmsg=" " value="<%=mo.name %>" />
      <span class="Validform_checktip">*产品名称最多50个字符</span></dd>
  </dl>
  <dl>
    <dt>信息标题</dt>
    <dd>
      <input name="title" type="text" id="txtTitle" class="input normal" datatype="*2-100" sucmsg=" " value="<%=mo.title %>" />
      <span class="Validform_checktip">*标题最多100个字符</span>
    </dd>
  </dl>
  <dl>
    <dt>产品图片</dt>
    <dd>
      <input type="file"  id="file_nImg" class="input normal " runat="server" datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/" sucmsg=" " />&nbsp;<%=mo.tpic%>
      <input type="hidden" name="nimg" value="<%=mo.tpic %>" />
    </dd>
  </dl>
  <dl>
  <dt>产品价格</dt>
  <dd><input type="text" class="input small" name="price" datatype="/^\s*$/|/^(:?(:?\d+.\d+)|(:?\d+))$/|n1-7" sucmsg=" " maxlength="7" value="<%=mo.price %>" />元/<input type="text" class="input small" name="units" datatype="/^\s*$/|*1-5" sucmsg=" " value="<%=mo.units %>" />（称量单位） &nbsp;*例：20元/斤</dd>
  </dl>
  <dl>
    <dt>需求量范围</dt> 
    <%if (String.IsNullOrEmpty(mo.bigamount)) mo.bigamount = "0"; %>    
    <%if (String.IsNullOrEmpty(mo.smallamount)) mo.smallamount = "0"; %>
    <dd><input type="text" class="input small" name="smallamount" datatype="/^\s*$/|n1-10" sucmsg=" " value="<%=mo.smallamount %>" />至<input type="text" class="input small" name="bigamount" datatype="/^\s*$/|n1-10" sucmsg=" " value="<%=mo.bigamount %>" />/<input type="text" class="input small" name="amountunits" datatype="/^\s*$/|*1-5" sucmsg=" " value="<%=mo.amountunits %>" />（称量单位） &nbsp;*例：2000至5000/斤,不填默认0不限量</dd>
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
    <dt>发布地区</dt>
    <dd>
        <div class="rule-single-select">
         <select name="province" id="ddlProvince" datatype="*" sucmsg=" "></select>
         </div>
        <div class="rule-single-select">
         <select name="city" id="ddlcity" sucmsg=" "><option value="">==选择市==</option></select>
         </div>
        <div class="rule-single-select">
         <select name="county" id="ddlcounty" sucmsg=" "><option value="">==选择县==</option></select>
         </div>
    </dd>
    <%if (mo.province > 0){ %>
    <script>
        $(function () {
            $("#ddlProvince").val("<%=mo.province %>");
            //加载市
            $("#ddlcity").empty();
            var provincezhi = $("#ddlProvince").val();
            $.each(arrarea, function (i2, n2) {
                if (n2.pid == provincezhi) {
                    $("#ddlcity").append("<option value='" + n2.oid + "'>" + n2.oname + "</option>");
                }
            });
            $("#ddlcity").prepend("<option value=\"\">==选择市==</option>");
            <%if(mo.city > 0){ %>
            $("#ddlcity").val("<%=mo.city %>");
            <%} %>
            //加载县
            $("#ddlcounty").empty();
            var countyzhi = $("#ddlcity").val();
            $.each(arrarea, function (i1, n1) {
                if (n1.pid == countyzhi) {
                    $("#ddlcounty").prepend("<option value='" + n1.oid + "'>" + n1.oname + "</option>");
                }
            });
            $("#ddlcounty").prepend("<option value=\"\">==选择县==</option>");
            <%if(mo.county>0){ %>
            $("#ddlcounty").val("<%=mo.county %>");
            <%} %>
            $(".rule-single-select").ruleSingleSelect();
        });
    </script>
    <%} %>
  </dl>
  <dl>
    <dt>到期时间</dt>
    <dd>
    <%string lastdate = DateTime.Now.AddMonths(1).ToString("yyyy-MM"); if (mo.daytime>DateTime.Parse("2010-01")) { lastdate = mo.daytime.ToString("yyyy-MM"); }  %>
      <div class="input-date">
        <input name="daytime" type="text" id="txtdaytime" class="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" datatype="/^\d{4}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " value="<%=lastdate %>"  />
        <i>日期</i>
      </div>
      <span class="Validform_checktip">*需求信息到期时间 例：(2018-06)=(2018-06-01)</span>
    </dd>
  </dl>
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
<div><input type="hidden" name="uid" value="<%=mo.uid %>" /><input type="hidden" name="tradetype" value="<%=mo.tradetype %>" /></div>
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
