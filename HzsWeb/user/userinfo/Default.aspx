<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="user_userinfo_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>合作社会员详情信息</title>
        <link rel="stylesheet" type="text/css" href="../../Style/common.css" />
    <script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../js/areajs.js"></script>
<script type="text/javascript" src="../js/huseredit.js"></script>
<script type="text/javascript" src="../js/yz.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>
<body>
    <form id="form1" action="/AjaxViewHzsUserLogin/Update.ashx" enctype="multipart/form-data" onsubmit="return tj();">
          <div class="mainRighTitle mainRighTitleMessageIco">会员信息管理 > 合作社会员详情信息</div>

          <div class="clear02"></div>
          <table border="0" class="searchTable borderNone">
          <tr>
              <td class="textAlignR">登录名称：</td>
              <td>      <input name="hname" type="text" id="txthname" class="textInput02 floatLef" <%if(String.IsNullOrEmpty(mo.hname)){ %> ajaxurl="/AjaxHzsUser/IsYzName.ashx"<%}else{ %> readonly="readonly" <%} %> datatype="s4-20"  sucmsg=" " value="<%=mo.hname %>" />
      <span class="Validform_checktip">*登陆名称最少4个字符，最多20个字符（英文字符、数字、下划线，中文亦可）</span>
</td>
            </tr>
        <tr>
              <td class="width20p textAlignR">登录密码：</td>
              <td class="width80p"><input type="password" name="hpwd" type="text" value="" id="hpwd" class="textInput02 floatLef" datatype="*6-20" sucmsg=" " />
    <span class="Validform_checktip">*密码长度6~20字符</span></td>
            </tr>
        <tr>
              <td class="textAlignR">确认密码：</td>
              <td><input type="password" name="pwd_again" type="text" value="" id="pwd_again" class="textInput02 floatLef" recheck="hpwd" datatype="*6-20" sucmsg=" " />
    <span class="Validform_checktip">*密码长度6~20字符</span></td>
            </tr>
        <tr>
              <td class="textAlignR">合作社头像：</td>
              <td><input type="file" id="file_nImg" runat="server" class="textInput02" datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/" sucmsg=" " />&nbsp;<%=mo.corppic %>
      <input type="hidden" name="corppic" value="<%=mo.corppic %>" /></td>
            </tr>
        <tr>
              <td class="textAlignR">合作社名称：</td>
              <td><input name="corpname" type="text" value="<%=mo.corpname %>" id="txtcorpname" class="textInput02" datatype="*3-50" sucmsg=" " />
    <span class="Validform_checktip">*合作社名称长度3~50字符</span></td>
            </tr>
            <tr>
              <td class="width20p textAlignR">电子邮箱：</td>
              <td class="width80p"><input name="email" type="text" value="<%=mo.email %>" id="email" class="textInput02" datatype="/^\s*$/|e" sucmsg=" " /></td>
            </tr>
       <tr>
              <td class="textAlignR">联系方式：</td>
              <td><input name="tel" id="txttel" value="<%=mo.tel %>" class="textInput02" datatype="/^((\(\d{2,5}\))|(\d{2,5}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/ | m" sucmsg=" "/>
      <span class="Validform_checktip">手机或者固话，固定电话：010-66666666-666（分机可不写）</span></td>
            </tr>
            <tr>
              <td class="textAlignR">创立时间：</td>
              <td><input name="cropregtime" type="text" id="txtcropregtime" value="<%=mo.cropregtime %>" class="textInput02" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" datatype="/^\s*$|^\d{4}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
              <span class="Validform_checktip">合作社创立时间</span></td>
            </tr>
            <tr>
              <td class="textAlignR">会员类型：</td>
              <td>
              <%foreach (HzsModel.HZSModels.HzsUserType utype in typelist.HzsUserType){ %>
    <input id="rdoHtype_<%=utype.id %>" type="radio" name="htype" datatype="*" sucmsg=" " value="<%=utype.id %>"/><label for="rdoHtype_<%=utype.id %>"><%=utype.tname%></label>
    <%} %>
              </td>
            </tr>
                <script>var utype = "<%=mo.htype.ToString() %>"; if (utype != 0) { $("[name='htype']").each(function () { if ($(this).val() == utype) $(this).attr("checked", "true"); }); } </script>
        <tr>
              <td class="textAlignR">示范社等级：</td>
              <td class="paddingTB10">
              <%foreach (HzsModel.HZSModels.HzsUserSfsjb sfstype in sfslist.HzsUserSfsjb){%>
    <input id="rdoSfsjb_<%=sfstype.id %>" type="radio" name="sfsjb" datatype="*" sucmsg=" " value="<%=sfstype.id %>"/><label for="rdoSfsjb_<%=sfstype.id %>"><%=sfstype.gname%></label>
    <%}%>
              </td>
            </tr>
                <script>var sfstype = "<%=mo.sfsjb.ToString() %>"; if (sfstype != 0) { $("[name='sfsjb']").each(function () { if ($(this).val() == sfstype) $(this).attr("checked", "true"); }); } </script> 
        <tr>
              <td class="textAlignR">示范社到期时间：</td>
              <td class="paddingTB10">
                      <input name="hzslevellasttime" type="text" id="txthzslevellasttime" class="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " value="<%=mo.hzslevellasttime %>" />
            </td>
            </tr>
        <tr>
            <td class="textAlignR">经营模式：</td>
            <td class="paddingTB10">
<span id="cbxHzsJyms"><%foreach (HzsModel.HZSModels.HzsUserJyms jtype in jymslist.HzsUserJyms){%>
        <input id="cbxJyms_<%=jtype.id %>" type="checkbox" name="ckscope" value="<%=jtype.id %>"  datatype="*" sucmsg=" " /><label for="cbxJyms_<%=jtype.id %>"><%=jtype.jname%></label>
     <%}%> </span>     <span class="Validform_checktip">*最多选择两项,超过则只录入选择的前两项</span>
        </td>
        </tr>
        <%if (!String.IsNullOrEmpty(mo.scope)){ %><script>
                                                      var arrscope = "<%=mo.scope.Trim().Substring(0,mo.scope.Length-1) %>".split("|");
                                                      var jtype = arrscope; for (var s = 0; s < arrscope.length; s++) { $("[name='ckscope']").each(function () { if ($(this).val() == arrscope[s]) $(this).attr("checked", "true"); }); }
      </script><%} %>   
      <tr>
              <td class="width20p textAlignR">合作社类型：</td>
              
              <td><select name="hzsbigclass" id="ddlhzsbigclass" class="selectList10" datatype="*" sucmsg=" "></select>
              &nbsp;          <select name="hzssmallclass" class="selectList10" id="ddlhzssmallclass" sucmsg=" "><option value="">==小类==</option></select>

              </td>
            </tr>
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
        });
    </script>
    <%} %>
    <tr>
        <td class="width20p textAlignR">所在地区：</td>
              
        <td><select name="province" id="ddlProvince" class="selectList10" datatype="*" sucmsg=" "></select>
        &nbsp; <select name="city" id="ddlcity" class="selectList10" sucmsg=" "><option value="">==选择市==</option></select>
        &nbsp;<select name="county" id="ddlcounty" class="selectList10" sucmsg=" "><option value="">==选择县==</option></select>
        </td>
    </tr>
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
        });
    </script>
    <%} %>
    <tr>
        <td class="textAlignR">详细地址：</td>
        <td><input name="address" type="text" value="<%=mo.address %>" id="txtaddress" class="textInput02" datatype="*3-60" sucmsg=" " />
        <span class="Validform_checktip">*详细地址最多60个字符</span>
        </td>
    </tr>
    <tr>
        <td class="textAlignR">邮政编码：</td>
        <td><input name="zipcode" type="text" value="<%=mo.zipcode %>" id="txtzipcode" class="textInput02" sucmsg=" " />
        <span class="Validform_checktip">*详细地址最多60个字符</span>
        </td>
    </tr>
    <tr>
        <td class="textAlignR">联系人：</td>
        <td><input name="linkman" type="text" value="<%=mo.linkman %>" id="txtlinkman" class="textInput02" sucmsg=" " />
        </td>
    </tr>
    <tr>
        <td class="textAlignR">营业执照：</td>
        <td><input name="licence" type="text" value="<%=mo.licence %>" id="txtlicence" class="textInput02" sucmsg=" " />
        </td>
    </tr>
    <tr>
        <td class="textAlignR">负责人：</td>
        <td><input name="hzsboss" type="text" value="<%=mo.hzsboss %>" id="txthzsboss" class="textInput02" datatype="*2-8" sucmsg=" " />
        </td>
    </tr>
    <tr>
        <td class="textAlignR">产品简介：</td>
        <td> <input name="hzsintro" type="text" value="<%=mo.hzsintro %>" id="txthzsintro" class="textInput02" datatype="/^\s*$/|*2-100" sucmsg=" " />        </td>
    </tr>
        <tr>
        <td class="textAlignR">联系QQ：</td>
        <td><input name="qq" type="text" value="<%=mo.qq %>" id="txtqq" class="textInput02" datatype="/^\s*$/|n" />
        </td>
    </tr>
        <tr>
              <td></td>
              <td><input type="submit" name="btnSubmit" value="提交" id="btnSubmit" class="botton" />
              <input name="btnReturn" type="button" value="返回" class="botton marginLef10" onclick="javascript: history.back(-1);" /></td>
            </tr>
      </table>
      <div><input type="hidden" name="uid" value="<%=mo.uid %>"  /><input type="hidden" name="scope" id="txtscope" /></div>
          <div class="clear02"></div>
    </form>
</body>
</html>
