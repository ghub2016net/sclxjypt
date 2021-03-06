﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="glory_edit.aspx.cs" Inherits="user_company_glory_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑荣誉证书</title>
    <link rel="stylesheet" type="text/css" href="../../Style/common.css" />
    <script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../js/yz.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
</script>
</head>
<body>
<div class="mainRighTitle mainRighTitleMessageIco">独立合作社管理 > 编辑荣誉证书</div>

<div class="clear02"></div>
<form name="form1" method="post" action="<%=ac %>" id="form1" enctype="multipart/form-data">
<div><input type="hidden" name="id" value="<%=mo.id %>" /><input type="hidden" name="uid" value="<%=mo.uid %>" /></div>
<table border="0" id="edittable" class="searchTable borderNone">
<tr>
    <td class="textAlignR">荣誉证书标题：</td>
    <td>
    <input name="title" type="text" id="txtTitle" class="textInput02" datatype="*2-100" sucmsg=" " value="<%=mo.title %>" />
    <span class="Validform_checktip">*标题最多100个字符</span>
    </td>
</tr>
<tr>
    <td class="textAlignR">上传图片：</td>
    <td><input type="file"  id="file_nImg" class="textInput02 floatLef" runat="server" datatype="/^\s*$/ | /^.+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$/" sucmsg=" " />
    &nbsp;<%=mo.pic%>
    </td>
</tr>
<tr>
    <td class="textAlignR">证书介绍：</td>
    <td ><textarea name="intro" rows="2" cols="20" id="txtIntro" style="width:400px;" class="textarea02" datatype="*0-255" sucmsg=" "><%=mo.intro %></textarea>
    <span class="Validform_checktip">最多255字符</span>
    </td>
</tr>

<tr>
    <td></td>
    <td><input type="submit" name="btnSubmit" value="提交" id="btnSubmit" class="botton" />
              <input name="btnReturn" type="button" value="返回" class="botton marginLef10" onclick="javascript: history.back(-1);" /></td>
</tr>
</table>
</form>
<div class="clear02"></div>
</body>
</html>
