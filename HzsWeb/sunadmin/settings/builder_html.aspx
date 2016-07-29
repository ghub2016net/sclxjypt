<%@ Page Language="C#" AutoEventWireup="true" CodeFile="builder_html.aspx.cs" Inherits="sunadmin_settings_builder_html" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>生成静态页面</title>
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //全局变量声明
    var isLock = false; //是否锁定正在执行操作
    var dialogDG; //dialog窗口实例

    //①提示且生成相应的频道
    function builerTip(obj) {
        //检查是否正在执行操作
        if (isLock) {
            $.dialog.alert('上次操作未完成，不可同时执行！');
            return false;
        }
        //提示是否执行
        $.dialog.confirm('此操作将会消耗大量的资源，确认要继续吗？', function () {
            getBuilerUrl(obj);
        });
    }
    //②发送AJAX请求获取生成地址
    function getBuilerUrl(obj) {
        //如dialog窗口不存在则创建
        if (!dialogDG || dialogDG.closed) {
            createDialogObj();
        }
        //重置dialog窗口的值
        dialogDG.title('正在获取信息...');
        dialogDG.content('正在加载，请稍候...');
        isLock = true; //锁定操作
        //发送AJAX请求
        $.ajax({
            url: $(obj).attr("url"),
            type: "POST",
            success: function (data) {


                if (data == 0) {
                    dialogDG.title('执行生成处理完毕');
                    dialogDG.content('该栏目下没有内容！');
                    isLock = false; //解除锁定
                }
                else if (data == -1) {
                    dialogDG.title('执行请求完毕');
                    dialogDG.content('<font color=red>登陆超时！</font>');
                    isLock = false; //解除锁定
                }
                else if (data == -2) {
                    dialogDG.title('执行请求完毕');
                    dialogDG.content('<font color=red>您没有操作生成静态的权限！</font>');
                    isLock = false; //解除锁定
                }
                else if (data == -3) {
                    dialogDG.title('执行请求完毕');
                    dialogDG.content('<font color=red>您还未开启生成静态功能！<a navid=\"site_config\" href=\"settings/sys_config.aspx\" target=\"mainframe\">立即开启</a></font>');
                    isLock = false; //解除锁定
                }
                else {
                    var json = eval(data);


                    if (json == "") {
                        dialogDG.title('执行生成处理完毕');
                        dialogDG.content('<font color=red>没有需要生成数据！</font>');
                        isLock = false; //解除锁定
                    }
                    else {
                        execBuilerHtml(json, 0);
                    }
                }
            }
        });
    }
    //③迭代执行生成
    function execBuilerHtml(jsonUrl, k) {


        $.ajax({
            url: jsonUrl[k],
            type: "POST",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            error: function () {
                getBuilerStatus(jsonUrl, k, "需要生成的静态页面路径有误！");
            },
            success: function (data) {
                if (data != 1 && data != 2 && data != 0)
                    data = "错误";
                getBuilerStatus(jsonUrl, k, data);
            }
        });
    }
    //④返回执行结果及状态
    function getBuilerStatus(jsonUrl, k, msg) {
        var fodname = jsonUrl[k].split('&catalogue=');
        var fname = jsonUrl[k].split('&html_filename=');
        fname = fname[1].split('&catalogue=');
        fname[0] = unescape(fname[0]);
        var finame = !fodname[1] ? fname[0] + '.html' : fodname[1];

        var spanTxt = msg == 0 ? '<span class="suc">成功</span>' : '<span class="error">失败</span>';
        var linkTxt = spanTxt + '<a href="/' + finame + '" target="_blank">/' + finame + '</a>';

        dialogDG.title('已完成页面生成' + '[' + jsonUrl.length + '/' + (k + 1) + ']');
        if ($(".build-box", parent.document).length == 0) {
            dialogDG.content('<div class="build-box"></div>');
        }
        $(".build-box", parent.document).append('<div class="xlist">' + linkTxt + '</div>');
        if (k == jsonUrl.length - 1) {
            isLock = false; //解除锁定
            //完成提示
            $.dialog.tips('页面全部生成完毕', 2, '32X32/succ.png', function () { });
        } else {
            k++;
            execBuilerHtml(jsonUrl, k);
        }
    }
    //创建dialog窗口
    function createDialogObj() {
        dialogDG = $.dialog({
            id: 'buildDialog',
            width: 300,
            height: 150,
            padding: '5px',
            left: '99%',
            top: '99%',
            fixed: true,
            resize: false,
            min: false,
            max: false
        });
    }
</script>
</head>

<body class="mainbody">
<form method="post" action="builder_html.aspx" id="form1">
<div class="aspNetHidden">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUJMTQwNzM5MzAzD2QWAmYPZBYCAgEPFgIeC18hSXRlbUNvdW50AgEWBAIBD2QWBGYPFQIM6buY6K6k56uZ54K5BG1haW5kAgEPFgIfAAIFFgpmD2QWAmYPFQkM5paw6Ze76LWE6K6vBG1haW4EbmV3cwRtYWluBG5ld3MEbWFpbgRuZXdzBG1haW4EbmV3c2QCAQ9kFgJmDxUJDOi0reeJqeWVhuWfjgRtYWluBWdvb2RzBG1haW4FZ29vZHMEbWFpbgVnb29kcwRtYWluBWdvb2RzZAICD2QWAmYPFQkM5Zu+54mH5YiG5LqrBG1haW4FcGhvdG8EbWFpbgVwaG90bwRtYWluBXBob3RvBG1haW4FcGhvdG9kAgMPZBYCZg8VCQzotYTmupDkuIvovb0EbWFpbgRkb3duBG1haW4EZG93bgRtYWluBGRvd24EbWFpbgRkb3duZAIED2QWAmYPFQkM5YWs5Y+45LuL57uNBG1haW4HY29udGVudARtYWluB2NvbnRlbnQEbWFpbgdjb250ZW50BG1haW4HY29udGVudGQCAg9kFgJmDxUBAGRk1J+xk79HwbSGbOSziPCZUYf7q+3vnTBXAi7rwJoGUzg=" />
</div>

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>界面管理</span>
  <i class="arrow"></i>
  <span>生成静态</span>
</div>
<!--/导航栏-->
<div class="line20"></div>

<!--列表-->

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th align="left" width="50%" style="padding-left:10px;">频道列表</th>
    <th align="left">操作</th>
  </tr>

  <tr>
    <td style="padding-left:10px;white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span class="folder-open"></span>
      默认站点
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=&type=index" onclick="builerTip(this);">生成首页</a>
    </td>
  </tr>
  
  <tr>
    <td style="padding-left:10px;">
      <span class="folder-line"></span>
      <span class="folder-open"></span>
      新闻资讯
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=news" onclick="builerTip(this);">全部生成</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=news&type=list" onclick="builerTip(this);">生成列表页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=news&type=category" onclick="builerTip(this);">生成栏目页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=news&type=detail" onclick="builerTip(this);">生成详细页</a>
    </td>
  </tr>
  
  <tr>
    <td style="padding-left:10px;">
      <span class="folder-line"></span>
      <span class="folder-open"></span>
      购物商城
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=goods" onclick="builerTip(this);">全部生成</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=goods&type=list" onclick="builerTip(this);">生成列表页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=goods&type=category" onclick="builerTip(this);">生成栏目页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=goods&type=detail" onclick="builerTip(this);">生成详细页</a>
    </td>
  </tr>
  
  <tr>
    <td style="padding-left:10px;">
      <span class="folder-line"></span>
      <span class="folder-open"></span>
      图片分享
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=photo" onclick="builerTip(this);">全部生成</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=photo&type=list" onclick="builerTip(this);">生成列表页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=photo&type=category" onclick="builerTip(this);">生成栏目页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=photo&type=detail" onclick="builerTip(this);">生成详细页</a>
    </td>
  </tr>
  
  <tr>
    <td style="padding-left:10px;">
      <span class="folder-line"></span>
      <span class="folder-open"></span>
      资源下载
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=down" onclick="builerTip(this);">全部生成</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=down&type=list" onclick="builerTip(this);">生成列表页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=down&type=category" onclick="builerTip(this);">生成栏目页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=down&type=detail" onclick="builerTip(this);">生成详细页</a>
    </td>
  </tr>
  
  <tr>
    <td style="padding-left:10px;">
      <span class="folder-line"></span>
      <span class="folder-open"></span>
      公司介绍
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=content" onclick="builerTip(this);">全部生成</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=content&type=list" onclick="builerTip(this);">生成列表页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=content&type=category" onclick="builerTip(this);">生成栏目页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=main&name=content&type=detail" onclick="builerTip(this);">生成详细页</a>
    </td>
  </tr>
  

  
</table>

<!--/列表-->
</form>
</body>
</html>
