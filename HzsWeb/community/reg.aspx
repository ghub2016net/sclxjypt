<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="community_reg" %>
<%@ Register src="../controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../css/css.css">
<link href="../Style/reg.css" rel="stylesheet" type="text/css" />
<title>注册-泸县数字农经网</title>
<script type="text/javascript" src="../scripts/jquery-1.7.1.min.js"></script>
<script src="../scripts/MSClass.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../js/areajs.js"></script>
<script type="text/javascript" src="../user/js/huseredit.js"></script>
<script type="text/javascript" src="../js/yz.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
    function tj() {
        var jyms = "";
        $("#cbxHzsJyms :checkbox").each(function () {
            if ($(this).attr("checked"))
                jyms += $(this).val() + "|";
        });
        $("#txtscope").val(jyms);
    }
</script>
</head>

<body>
<form method="post" action="/AjaxViewHzsUserLogin/Reg.ashx" id="form1" enctype="multipart/form-data" onsubmit="return tj();">
<div class="contents">
	<uc1:header ID="header1" runat="server" />
	<uc2:xsheader ID="xsheader1" runat="server" />   
    <div class="clear5px"></div>
    <div class="clear5px"></div>
    <div style=" width:760px; margin:auto">
    <div class="fzhuce">基本信息<span class="marginLef10Red">(注:打*号为必填项)</span></div>
    <div class="clear5px"></div>
        <table class="searchTable">
          <tr>
            <td class="textAlignR width20p"><span class="marginLef10Red">*</span>登录名称：</td>
            <td class="width80p"><input name="hname" type="text" id="txthname" class="textInput02" datatype="s4-20"  ajaxurl="/AjaxHzsUser/IsYzName.ashx" sucmsg=" " value="" />
      <span class="Validform_checktip" style="height:20px">*最少4字符，最多20字符（英文字符、数字、下划线，中文亦可）</span></td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>用户密码：</td>
            <td><input type="password" name="hpwd" type="text" value="" id="hpwd" class="textInput02" datatype="*6-20" sucmsg=" " /><span class="Validform_checktip marginLef10">(注:请输入密码,数字或字母均可,长度在6-12个字符)</span></td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>确认密码：</td>
            <td><input type="password" name="pwd_again" type="text" value="" id="pwd_again" class="textInput02" recheck="hpwd" datatype="*6-20" sucmsg=" " /><span class="Validform_checktip marginLef10">(注:请再输一遍确认,长度在6-12个字符)</span></td>
          </tr>
          <tr>
            <td class="textAlignR">合作社名称：</td>
            <td><input name="corpname" type="text" value="" id="txtcorpname" class="textInput02" datatype="*3-50" sucmsg=" " /><span class="Validform_checktip marginLef10">(注:长度3~50字符)</span></td>
          </tr>
          <tr>
            <td class="textAlignR">电子邮箱：</td>
            <td><input name="email" type="text" value="" id="email" class="textInput02" datatype="/^\s*$/|e" sucmsg=" " /><span class="Validform_checktip marginLef10">(注:作为用户联系方式,可找回密码,如:xx@xx.com)</span></td>
          </tr>
        </table>
	</div>
    <div class="clear01"></div>
    <div style=" width:760px; margin:auto">
    <div class="fzhuce">详细信息<span class="marginLef10Red">(注:打*号为必填项)</span></div>
    <div class="clear5px"></div>
        <table class="searchTable">
          <tr>
            <td class="textAlignR width20p"><span class="marginLef10Red">*</span>联系方式：</td>
            <td class="width80p"><input name="tel" id="txttel" value="" class="textInput02" datatype="/^((\(\d{2,5}\))|(\d{2,5}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/ | m" sucmsg=" "/>
            <span class="Validform_checktip marginLef10">手机或者固话，固定电话：010-66666666-666（分机可不写）</span>
            </td>
          </tr>
          <tr>
            <td class="textAlignR">创立时间：</td>
            <td><input name="cropregtime" type="text" id="txtcropregtime" value="" class="textInput02" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" datatype="/^\s*$|^\d{4}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " /></td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>会员类型：</td>
            <td>
                <%foreach (HzsModel.HZSModels.HzsUserType utype in typelist.HzsUserType){ %>
    <input id="rdoHtype_<%=utype.id %>" type="radio" name="htype" datatype="*" sucmsg=" " value="<%=utype.id %>"/><label for="rdoHtype_<%=utype.id %>"><%=utype.tname%></label>
    <%} %>
                </td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>示范社等级：</td>
            <td>
            <%foreach (HzsModel.HZSModels.HzsUserSfsjb sfstype in sfslist.HzsUserSfsjb){%>
    <input id="rdoSfsjb_<%=sfstype.id %>" type="radio" name="sfsjb" datatype="*" sucmsg=" " value="<%=sfstype.id %>"/><label for="rdoSfsjb_<%=sfstype.id %>"><%=sfstype.gname%></label>
    <%}%>
            </td>
          </tr>
          <tr>
            <td class="textAlignR">示范社到期时间：</td>
            <td><input name="hzslevellasttime" type="text" id="txthzslevellasttime" class="textInput02" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " value="" /></td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>经验模式：</td>
            <td><span id="cbxHzsJyms"><%foreach (HzsModel.HZSModels.HzsUserJyms jtype in jymslist.HzsUserJyms){%>
        <input id="cbxJyms_<%=jtype.id %>" type="checkbox" name="ckscope" value="<%=jtype.id %>"  datatype="*" sucmsg=" " /><label for="cbxJyms_<%=jtype.id %>"><%=jtype.jname%></label>
     <%}%> </span>     <span class="Validform_checktip marginLef10">*最多选择两项,超过则只录入选择的前两项</span>
              </td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>合作社类型：</td>
            <td>
            <select name="hzsbigclass" id="ddlhzsbigclass" class="selectList floatLef marginBottom10" datatype="*" sucmsg=" "></select>
              &nbsp;          <select name="hzssmallclass" class="selectList floatLef marginBottom10" id="ddlhzssmallclass" sucmsg=" "><option value="">==小类==</option></select>
            </td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>所在地区：</td>
            <td><select name="province" id="ddlProvince" class="selectList floatLef marginBottom10" datatype="*" sucmsg=" "></select>
        &nbsp; <select name="city" id="ddlcity" class="selectList floatLef marginBottom10" sucmsg=" "><option value="">==选择市==</option></select>
        &nbsp;<select name="county" id="ddlcounty" class="selectList floatLef marginBottom10" sucmsg=" "><option value="">==选择县==</option></select>
        </td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>详细地址：</td>
            <td><input name="address" type="text" value="" id="txtaddress" class="textInput02" datatype="*3-60" sucmsg=" " />
        <span class="Validform_checktip marginLef10">*详细地址最多60个字符</span></td>
          </tr>
          <tr>
            <td class="textAlignR"><span class="marginLef10Red">*</span>邮政编码：</td>
            <td>
            <input name="zipcode" type="text" value="" id="txtzipcode" class="textInput02" sucmsg=" " />
        <span class="Validform_checktip marginLef10">*详细地址最多60个字符</span>
            </td>
          </tr>
          <tr>
        <td class="textAlignR">联系人：</td>
        <td><input name="linkman" type="text" value="" id="txtlinkman" class="textInput02" sucmsg=" " />
        </td>
    </tr>
    <tr>
        <td class="textAlignR">营业执照：</td>
        <td><input name="licence" type="text" value="" id="txtlicence" class="textInput02" sucmsg=" " />
        </td>
    </tr>
    <tr>
        <td class="textAlignR">负责人：</td>
        <td><input name="hzsboss" type="text" value="" id="txthzsboss" class="textInput02" datatype="*2-8" sucmsg=" " />
        </td>
    </tr>
    <tr>
        <td class="textAlignR">产品简介：</td>
        <td> <input name="hzsintro" type="text" value="" id="txthzsintro" class="textInput02" datatype="/^\s*$/|*2-100" sucmsg=" " />        </td>
    </tr>
        <tr>
        <td class="textAlignR">联系QQ：</td>
        <td><input name="qq" type="text" value="" id="txtqq" class="textInput02" datatype="/^\s*$/|n" />
        </td>
    </tr>
          <tr>
            <td class="textAlignR"></td>
            <td>
            <input type="submit" name="btnSubmit" id="btnSubmit" value="" class="sbotton" />
            <span class="marginLef10"><input name="btnReturn" type="button" value="" class="qxbotton" onclick="javascript: history.back(-1);" /></td></span>
            </td>
          </tr>
        </table>
	</div>
    <div class="clear02"></div>
    <uc3:footer ID="nfooter1" runat="server" />    
    <div class="clear01"></div>
</div>
<div><input type="hidden" name="scope" id="txtscope" /></div>
</form>
<style>
.sbotton{width:102px; height:31px;background: url(../images/tj.jpg) left center repeat-x; cursor:pointer;}
.qxbotton{width:102px; height:31px;background: url(../images/qx.jpg) left center repeat-x; cursor:pointer;}
</style>
</body>
</html>
