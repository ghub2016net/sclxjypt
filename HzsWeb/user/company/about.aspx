﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="user_company_about" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑联系我们</title>
    <link rel="stylesheet" type="text/css" href="../../Style/common.css" />
    <script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/yz.js"></script>
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
<div class="mainRighTitle mainRighTitleMessageIco">独立合作社管理 > 编辑联系我们</div>

<div class="clear02"></div>
<form name="form1" method="post" action="<%=ac %>" id="form1">
<table border="0" id="edittable" class="searchTable borderNone">
<tr>
    <td class="textAlignR">联系我们简介：</td>
    <td ><textarea name="intro" rows="2" cols="20" id="txtIntro" style="width:400px;" class="textarea02" datatype="*0-255" sucmsg=" "><%=mo.intro %></textarea>
    <span class="Validform_checktip">最多255字符</span>
    </td>
</tr>
<tr>
    <td class="textAlignR">详细介绍：</td>
    <td > <textarea name="content" id="txtContent" class="editor" style="visibility:hidden;"><%=mo.content %></textarea></td>
</tr>
<tr>
    <td></td>
    <td><input type="submit" name="btnSubmit" value="提交" id="btnSubmit" class="botton" />
              <input name="btnReturn" type="button" value="返回" class="botton marginLef10" onclick="javascript: history.back(-1);" /></td>
</tr>
</table>
<div><input type="hidden" name="id" value="<%=mo.id %>" /><input type="hidden" name="uid" value="<%=mo.uid %>" /><input type="hidden" name="typeid" value="<%=mo.typeid %>" /></div>
</form>
<div class="clear02"></div>
</body>
</html>
