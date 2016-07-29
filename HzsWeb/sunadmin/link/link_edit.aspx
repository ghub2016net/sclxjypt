<%@ Page Language="C#" AutoEventWireup="true" CodeFile="link_edit.aspx.cs" Inherits="sunadmin_link_link_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>链接</title>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>

</head>
<body class="mainbody">
    <form id="form1" method="post" action="<%=ac %>" enctype="multipart/form-data">
    <div class="tab-content">
        <dl>
            <dt>链接名称</dt>
            <dd>
                <input name="linkName" type="text" value="<%=mo.linkName %>" id="linkName" class="input normal"
                    datatype="*3-50" sucmsg=" " />
                <%--<span class="Validform_checktip">*合作社名称长度3~50字符</span></dd>--%>
        </dl>
        <dl>
            <dt>链接地址</dt>
            <dd>
                <input type="text" name="linkUrl" type="text" value="<%=mo.linkUrl %>" id="linkUrl"
                    class="input normal" datatype="*6-20" sucmsg=" " />
                <%--<span class="Validform_checktip">*密码长度6~20字符</span></dd>--%>
        </dl>
      <dl>
    <dt>链接类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <span id="cblHot"><input id="rdoHot_0" type="radio" name="linkType" value="0" checked="checked" /><label for="rdoHot_0">文字链接</label><input id="rdoHot_1" type="radio" name="linkType" value="1" /><label for="rdoHot_1">图片链接</label></span>
        <script>
            var ckhot = "<%=mo.linkType %>"; if (ckhot == 0) $("input[name='linkType']:eq(0)").attr("checked", "true"); else { $('input[name="linkType"]').each(function() { if ($(this).val() == ckhot) $(this).attr("checked", "true") }) }
        </script>
      </div>
    </dd>
  </dl>
        <dl>
            <dt>链接图片</dt>
            <dd>
                <input type="file" id="file_nImg" runat="server" class="input normal " datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/"
                    sucmsg=" " />&nbsp;<%=mo.linkImgurl %>
                <input type="hidden" name="linkImgurl" value="<%=mo.linkImgurl %>" />
            </dd>
        </dl>
        <%--<dl>
    <dt>创立时间</dt>
    <dd>
      <div class="input-date">
        <input name="cropregtime" type="text" id="txtcropregtime" value="<%=mo.cropregtime %>" class="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" datatype="/^\s*$|^\d{4}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip">添加链接时间</span>
    </dd>
  </dl>--%>
    </div>
    <div class="page-footer">
        <div class="btn-list">
            <input type="submit" name="btnSubmit" value="提交保存" id="btnSubmit" class="btn" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>
