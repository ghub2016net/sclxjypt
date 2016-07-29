<%@ Page Language="C#" AutoEventWireup="true" CodeFile="huser_edit.aspx.cs" Inherits="sunadmin_huser_huser_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑合作社会员信息</title>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../js/areajs.js"></script>
<script type="text/javascript" src="../js/hik/huseredit.js?x=1"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>
<body class="mainbody">

<!--导航栏-->
<div class="location">
  <a href="../huser/huserlist.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="../huser/huserlist.aspx"><span>新闻列表</span></a>
  <i class="arrow"></i>
  <span>编辑合作社会员信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->
<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">详细信息</a></li>
      </ul>
    </div>
  </div>
</div>
<form name="form1" method="post" action="<%=ac %>" id="form1" enctype="multipart/form-data" onsubmit="return tj();">
<div class="tab-content">
  <dl>
    <dt>显示状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <span id="rblStatus"><input id="rblStatus_0" type="radio" name="isverify" value="10"/><label for="rblStatus_0">审核</label><input id="rblStatus_1" type="radio" name="isverify" value="20" /><label for="rblStatus_1">待审核</label><input id="rblStatus_2" type="radio" name="isverify" value="40" /><label for="rblStatus_2">审核失败</label></span>
        <script>
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
        <script>
            var ckhot = "<%=mo.ishot %>"; if (ckhot == 0) $("input[name='ishot']:eq(0)").attr("checked", "true"); else { $('input[name="ishot"]').each(function () { if ($(this).val() == ckhot) $(this).attr("checked", "true") }) }
        </script>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>登陆名称</dt>
    <dd>
      <input name="hname" type="text" id="txthname" class="input normal"<%if(String.IsNullOrEmpty(mo.hname)){ %> ajaxurl="/AjaxHzsUser/IsYzName.ashx"<%}else{ %> readonly="readonly" <%} %> datatype="s4-20"  sucmsg=" " value="<%=mo.hname %>" />
      <span class="Validform_checktip">*登陆名称最少4个字符，最多20个字符（英文字符、数字、下划线，中文亦可）</span>
    </dd>
  </dl>
  <dl>
    <dt>登录密码</dt>
    <dd><input type="password" name="hpwd" type="text" value="" id="hpwd" class="input normal" datatype="*6-20" sucmsg=" " />
    <span class="Validform_checktip">*密码长度6~20字符</span></dd>
  </dl>
  <dl id="pwdagain" runat="server">
    <dt>确认密码</dt>
    <dd><input type="password" name="pwd_again" type="text" value="" id="pwd_again" class="input normal" recheck="hpwd" datatype="*6-20" sucmsg=" " />
    <span class="Validform_checktip">*密码长度6~20字符</span></dd>
  </dl>
  <dl>
    <dt>合作社头像</dt>
    <dd>
      <input type="file" id="file_nImg" runat="server" class="input normal " datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/" sucmsg=" " />&nbsp;<%=mo.corppic %>
      <input type="hidden" name="corppic" value="<%=mo.corppic %>" />
    </dd>
  </dl>
  <dl>
    <dt>合作社名称</dt>
    <dd><input name="corpname" type="text" value="<%=mo.corpname %>" id="txtcorpname" class="input normal" datatype="*3-50" sucmsg=" " />
    <span class="Validform_checktip">*合作社名称长度3~50字符</span></dd>
  </dl>
  <dl>
    <dt>电子邮箱</dt>
    <dd><input name="email" type="text" value="<%=mo.email %>" id="email" class="input normal" datatype="/^\s*$/|e" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>联系方式</dt>
    <dd>
      <input name="tel" id="txttel" value="<%=mo.tel %>" class="input normal" datatype="/^((\(\d{2,5}\))|(\d{2,5}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/ | m" sucmsg=" "/>
      <span class="Validform_checktip">手机或者固话，固定电话：010-66666666-666（分机可不写）</span>
    </dd>
  </dl>
  <dl>
    <dt>创立时间</dt>
    <dd>
      <div class="input-date">
        <input name="cropregtime" type="text" id="txtcropregtime" value="<%=mo.cropregtime %>" class="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" datatype="/^\s*$|^\d{4}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip">合作社创立时间</span>
    </dd>
  </dl>
</div>

<div class="tab-content" style="display:none">
  <dl>
    <dt>会员类型</dt>
    <dd>
    <div class="rule-multi-radio">
    <span id="rdoHzstype">
    <%foreach (HzsModel.HZSModels.HzsUserType utype in typelist.HzsUserType){ %>
    <input id="rdoHtype_<%=utype.id %>" type="radio" name="htype" datatype="*" sucmsg=" " value="<%=utype.id %>"/><label for="rdoHtype_<%=utype.id %>"><%=utype.tname%></label>
    <%} %>
    </span>
    </div>
    <script>var utype = "<%=mo.htype.ToString() %>";if (utype != 0) { $("[name='htype']").each(function () { if ($(this).val() == utype) $(this).attr("checked", "true"); }); } </script>
    </dd>
  </dl>
  <dl>
    <dt>示范社等级</dt>
    <dd>
    <div class="rule-multi-radio">
    <span id="rdoHzsSfsjb">
    <%foreach (HzsModel.HZSModels.HzsUserSfsjb sfstype in sfslist.HzsUserSfsjb){%>
    <input id="rdoSfsjb_<%=sfstype.id %>" type="radio" name="sfsjb" datatype="*" sucmsg=" " value="<%=sfstype.id %>"/><label for="rdoSfsjb_<%=sfstype.id %>"><%=sfstype.gname%></label>
    <%}%>
    </span>
    </div>
    <script>var sfstype = "<%=mo.sfsjb.ToString() %>"; if (sfstype != 0) { $("[name='sfsjb']").each(function () { if ($(this).val() == sfstype) $(this).attr("checked", "true"); }); } </script>    </dd>
  </dl>
  <dl>
    <dt>示范社到期时间</dt>
    <dd><div class="input-date">
        <input name="hzslevellasttime" type="text" id="txthzslevellasttime" class="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " value="<%=mo.hzslevellasttime %>" />
        <i>日期</i>
      </div></dd>
  </dl>
  <dl>
    <dt>经营模式</dt>
    <dd>
    <div class="rule-multi-checkbox">
        <span id="cbxHzsJyms"><%foreach (HzsModel.HZSModels.HzsUserJyms jtype in jymslist.HzsUserJyms){%>
        <input id="cbxJyms_<%=jtype.id %>" type="checkbox" name="ckscope" value="<%=jtype.id %>"  datatype="*" sucmsg=" " /><label for="cbxJyms_<%=jtype.id %>"><%=jtype.jname%></label>
     <%}%>
          </span>
      </div>
      <span class="Validform_checktip">*最多选择两项,超过则只录入选择的前两项</span>
      <%if (!String.IsNullOrEmpty(mo.scope)){ %><script>
          var arrscope = "<%=mo.scope.Trim().Substring(0,mo.scope.Length-1) %>".split("|");
          var jtype = arrscope; for(var s=0;s<arrscope.length;s++){$("[name='ckscope']").each(function () { if ($(this).val() == arrscope[s]) $(this).attr("checked", "true"); });}
      </script><%} %>    
    </dd>
  </dl>
  <dl>
    <dt>合作社类型</dt>
    <dd>
        <div class="rule-single-select">
         <select name="hzsbigclass" id="ddlhzsbigclass" datatype="*" sucmsg=" "></select>
         </div>
        <div class="rule-single-select">
         <select name="hzssmallclass" id="ddlhzssmallclass" sucmsg=" "><option value="">==小类==</option></select>
         </div>
        
    </dd>
    <%if (mo.hzsbigclass > 0)
      { %>
    <script>
        $(function () {
            $("#ddlhzsbigclass").val("<%=mo.hzsbigclass %>");
            //加载小类
            $("#ddlhzssmallclass").empty();
            var provincezhi = $("#ddlhzsbigclass").val();
            $.each(arrarea, function (a, b) {
                if (b.pid == provincezhi) {
                    $("#ddlhzssmallclass").append("<option value='" + b.oid + "'>" + b.oname + "</option>");
                }
            });
            $("#ddlhzssmallclass").prepend("<option value=\"\">==小类==</option>");
            <%if(mo.hzssmallclass > 0){ %>
            $("#ddlhzssmallclass").val("<%=mo.hzssmallclass %>");
            <%} %>
            $(".rule-single-select").ruleSingleSelect();
        });
    </script>
    <%} %>
  </dl>
  <dl>
    <dt>所在地区</dt>
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
    <dt>详细地址</dt>
    <dd><input name="address" type="text" value="<%=mo.address %>" id="txtaddress" class="input normal" datatype="*3-60" sucmsg=" " />
  </dl>
  <dl>
    <dt>邮政编码</dt>
    <dd><input name="zipcode" type="text" value="<%=mo.zipcode %>" id="txtzipcode" class="input normal" sucmsg=" " />
  </dl>
  <dl>
    <dt>联系人</dt>
    <dd><input name="linkman" type="text" value="<%=mo.linkman %>" id="txtlinkman" class="input normal" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>营业执照</dt>
    <dd><input name="licence" type="text" value="<%=mo.licence %>" id="txtlicence" class="input normal" sucmsg=" " />
    <span class="Validform_checktip">身份证或者营业执照号码</span></dd>
  </dl>
  <dl>
    <dt>负责人</dt>
    <dd><input name="hzsboss" type="text" value="<%=mo.hzsboss %>" id="txthzsboss" class="input normal" datatype="*2-8" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>产品简介</dt>
    <dd><input name="hzsintro" type="text" value="<%=mo.hzsintro %>" id="txthzsintro" class="input normal" datatype="/^\s*$/|*2-100" sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt>联系QQ</dt>
    <dd><input name="qq" type="text" value="<%=mo.qq %>" id="txtqq" class="input normal" datatype="/^\s*$/|n" /></dd>
  </dl>
</div>
<div><input type="hidden" name="uid" value="<%=mo.uid %>"  /><input type="hidden" name="scope" id="txtscope" /></div>

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
