<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demand_edit.aspx.cs" Inherits="user_trade_demand_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
    <title>编辑需求信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../../Style/common.css" />
    <script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../../js/areajs.js"></script>
    <script type="text/javascript" src="../../js/tradejs.js"></script>
    <script type="text/javascript" src="../js/yz.js"></script>
    <script type="text/javascript" src="../js/trade_edit.js"></script>
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
    <body>
          <div class="mainRighTitle mainRighTitleMessageIco"><a href="demand.aspx">需求信息管理</a> > 添加需求信息</div>
          <div class="clear02"></div>
          <form name="form1" method="post" action="<%=ac %>" id="form1" enctype="multipart/form-data">
           <div><input type="hidden" name="id" value="<%=mo.id %>" /><input type="hidden" name="isverify" value="<%=mo.isverify==0? 10 : mo.isverify %>" />
           <input type="hidden" name="ishot" value="0" /><input type="hidden" name="nimg" value="<%=mo.tpic %>" />
           <input type="hidden" name="uid" value="<%=mo.uid %>" /><input type="hidden" name="tradetype" value="<%=mo.tradetype %>" />
           </div>
          <table border="0" id="edittable" class="searchTable borderNone">
          <tr>
              <td class="textAlignR">产品名称：</td>
              <td><input name="name" type="text" id="txtname" class="textInput02" datatype="*1-50" sucmsg=" " value="<%=mo.name %>" />
              <span class="Validform_checktip">*产品名称最多50个字符</span>
              </td>
            </tr>
            <tr>
              <td class="textAlignR">需求信息标题：</td>
              <td>
              <input name="title" type="text" id="txtTitle" class="textInput02" datatype="*2-100" sucmsg=" " value="<%=mo.title %>" />
              <span class="Validform_checktip">*标题最多100个字符</span>
              </td>
            </tr>
            <tr>
              <td class="width20p textAlignR">产品类型：</td>
              
              <td><select name="ptype" class="selectList10" id="ddlptype" datatype="*" sucmsg=" "></select>
              &nbsp; <select name="ptype2" class="selectList10" id="ddlptype2" sucmsg=" "><option value="">==小类==</option></select>
              </td>
            </tr>
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
        });
    </script>
    <%} %>
        <tr>
              <td class="textAlignR">产品图片：</td>
              <td><input type="file"  id="file_nImg" class="textInput02 floatLef" runat="server" datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/" sucmsg=" " />
              &nbsp;<%=mo.tpic%>
              </td>
            </tr>
        <tr>
              <td class="textAlignR">产品价格：</td>
              <td><input type="text" name="price" class="textInput10" datatype="/^\s*$/|/^(:?(:?\d+.\d+)|(:?\d+))$/|n1-7" sucmsg=" " maxlength="7" value="<%=mo.price %>" />元/<input type="text" class="textInput10" name="units" datatype="/^\s*$/|*1-5" sucmsg=" " value="<%=mo.units %>" />（称量单位） &nbsp;*例：20元/斤
              </td>
            </tr>
        <tr>
              <td class="textAlignR">需求量范围：</td>
              <td>
              <%if (String.IsNullOrEmpty(mo.bigamount)) mo.bigamount = "0"; %>    
    <%if (String.IsNullOrEmpty(mo.smallamount)) mo.smallamount = "0"; %>
    <input type="text" class="textInput10" name="smallamount" datatype="/^\s*$/|n1-10" sucmsg=" " value="<%=mo.smallamount %>" />至<input type="text" class="textInput10" name="bigamount" datatype="/^\s*$/|n1-10" sucmsg=" " value="<%=mo.bigamount %>" />/<input type="text" class="textInput10" name="amountunits" datatype="/^\s*$/|*1-5" sucmsg=" " value="<%=mo.amountunits %>" />（称量单位） &nbsp;*例：2000至5000/斤,不填默认0不限量
              </td>
            </tr>
            <tr>
              <td class="width20p textAlignR">发布地区：</td>
              <td class="width80p">
              <select name="province" class="selectList10" id="ddlProvince" datatype="*" sucmsg=" "></select>
              <select name="city" class="selectList10" id="ddlcity" sucmsg=" "><option value="">==选择市==</option></select>
              <select name="county" class="selectList10" id="ddlcounty" sucmsg=" "><option value="">==选择县==</option></select>
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
            $(".rule-single-select").ruleSingleSelect();
        });
    </script>
    <%} %>
       <tr>
              <td class="textAlignR">到期时间：</td>
              <%string lastdate = DateTime.Now.AddMonths(1).ToString("yyyy-MM"); if (mo.daytime>DateTime.Parse("2010-01")) { lastdate = mo.daytime.ToString("yyyy-MM"); }  %>
              <td><input name="daytime" type="text" id="txtdaytime" class="textInput02" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" datatype="/^\d{4}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " value="<%=lastdate %>"  /></td>
            </tr>
            <tr>
              <td class="textAlignR">内容摘要：</td>
              <td><textarea name="intro" rows="2" cols="20" id="txtIntro" class="textarea02" datatype="*0-255" sucmsg=" "><%=mo.intro %></textarea>
      <span class="Validform_checktip">不填写则自动截取内容前255字符</span></td>
            </tr>
            <tr>
              <td class="textAlignR">内容描述：</td>
              <td> <textarea name="content" id="txtContent" class="editor" style="visibility:hidden;"><%=mo.content %></textarea></td>
            </tr>

        <tr>
              <td></td>
              <td>
              <input type="submit" name="btnSubmit" value="提交" id="btnSubmit" class="botton" />
              <input name="btnReturn" type="button" value="返回" class="botton marginLef10" onclick="javascript: history.back(-1);" />
            </tr>
      </table>
          </form>
          <div class="clear02"></div>
</body>
</html>
