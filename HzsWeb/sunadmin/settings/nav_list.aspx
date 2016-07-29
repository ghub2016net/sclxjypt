<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nav_list.aspx.cs" Inherits="sunadmin_settings_nav_list" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>后台导航管理</title>
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form method="post" action="nav_list.aspx" id="form1">

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>后台导航管理</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="nav_edit.aspx?action=Add"><i></i><span>新增</span></a></li>
        <li><a id="btnSave" class="save" href="javascript:__doPostBack(&#39;btnSave&#39;,&#39;&#39;)"><i></i><span>保存</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack(&#39;btnDelete&#39;,&#39;本操作会删除本导航及下属子导航，是否继续？&#39;);" id="btnDelete" class="del" href="javascript:__doPostBack(&#39;btnDelete&#39;,&#39;&#39;)"><i></i><span>删除</span></a></li>
      </ul>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="12%">调用ID</th>
    <th align="left">导航标题</th>
    <th width="8%">显示</th>
    <th width="8%">默认</th>
    <th align="left" width="65">排序</th>
    <th width="12%">操作</th>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_0" type="checkbox" name="rptList$ctl01$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl01$hidId" id="rptList_hidId_0" value="1" />
      <input type="hidden" name="rptList$ctl01$hidLayer" id="rptList_hidLayer_0" value="1" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">sys_contents</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=1">内容管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl01$txtSortId" type="text" value="99" id="rptList_txtSortId_0" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=1">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=1">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_1" type="checkbox" name="rptList$ctl02$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl02$hidId" id="rptList_hidId_1" value="43" />
      <input type="hidden" name="rptList$ctl02$hidLayer" id="rptList_hidLayer_1" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_main</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=43">默认站点</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl02$txtSortId" type="text" value="99" id="rptList_txtSortId_1" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=43">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=43">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_2" type="checkbox" name="rptList$ctl03$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl03$hidId" id="rptList_hidId_2" value="44" />
      <input type="hidden" name="rptList$ctl03$hidLayer" id="rptList_hidLayer_2" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_news</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=44">新闻资讯</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl03$txtSortId" type="text" value="99" id="rptList_txtSortId_2" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=44">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=44">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_3" type="checkbox" name="rptList$ctl04$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl04$hidId" id="rptList_hidId_3" value="45" />
      <input type="hidden" name="rptList$ctl04$hidLayer" id="rptList_hidLayer_3" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_news_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=45">内容管理</a>
      (链接：article/article_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl04$txtSortId" type="text" value="99" id="rptList_txtSortId_3" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=45">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=45">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_4" type="checkbox" name="rptList$ctl05$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl05$hidId" id="rptList_hidId_4" value="46" />
      <input type="hidden" name="rptList$ctl05$hidLayer" id="rptList_hidLayer_4" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_news_category</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=46">栏目类别</a>
      (链接：article/category_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl05$txtSortId" type="text" value="100" id="rptList_txtSortId_4" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=46">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=46">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_5" type="checkbox" name="rptList$ctl06$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl06$hidId" id="rptList_hidId_5" value="47" />
      <input type="hidden" name="rptList$ctl06$hidLayer" id="rptList_hidLayer_5" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_news_comment</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=47">评论管理</a>
      (链接：article/comment_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl06$txtSortId" type="text" value="101" id="rptList_txtSortId_5" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=47">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=47">修改</a>
    </td>
  </tr>

  

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_7" type="checkbox" name="rptList$ctl08$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl08$hidId" id="rptList_hidId_7" value="49" />
      <input type="hidden" name="rptList$ctl08$hidLayer" id="rptList_hidLayer_7" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_goods_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=49">内容管理</a>
      (链接：article/article_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl08$txtSortId" type="text" value="99" id="rptList_txtSortId_7" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=49">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=49">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_8" type="checkbox" name="rptList$ctl09$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl09$hidId" id="rptList_hidId_8" value="50" />
      <input type="hidden" name="rptList$ctl09$hidLayer" id="rptList_hidLayer_8" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_goods_category</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=50">栏目类别</a>
      (链接：article/category_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl09$txtSortId" type="text" value="100" id="rptList_txtSortId_8" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=50">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=50">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_9" type="checkbox" name="rptList$ctl10$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl10$hidId" id="rptList_hidId_9" value="51" />
      <input type="hidden" name="rptList$ctl10$hidLayer" id="rptList_hidLayer_9" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_goods_comment</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=51">评论管理</a>
      (链接：article/comment_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl10$txtSortId" type="text" value="101" id="rptList_txtSortId_9" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=51">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=51">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_10" type="checkbox" name="rptList$ctl11$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl11$hidId" id="rptList_hidId_10" value="56" />
      <input type="hidden" name="rptList$ctl11$hidLayer" id="rptList_hidLayer_10" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_down</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=56">资源下载</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl11$txtSortId" type="text" value="99" id="rptList_txtSortId_10" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=56">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=56">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_11" type="checkbox" name="rptList$ctl12$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl12$hidId" id="rptList_hidId_11" value="57" />
      <input type="hidden" name="rptList$ctl12$hidLayer" id="rptList_hidLayer_11" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_down_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=57">内容管理</a>
      (链接：article/article_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl12$txtSortId" type="text" value="99" id="rptList_txtSortId_11" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=57">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=57">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_12" type="checkbox" name="rptList$ctl13$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl13$hidId" id="rptList_hidId_12" value="58" />
      <input type="hidden" name="rptList$ctl13$hidLayer" id="rptList_hidLayer_12" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_down_category</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=58">栏目类别</a>
      (链接：article/category_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl13$txtSortId" type="text" value="100" id="rptList_txtSortId_12" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=58">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=58">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_13" type="checkbox" name="rptList$ctl14$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl14$hidId" id="rptList_hidId_13" value="59" />
      <input type="hidden" name="rptList$ctl14$hidLayer" id="rptList_hidLayer_13" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_down_comment</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=59">评论管理</a>
      (链接：article/comment_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl14$txtSortId" type="text" value="101" id="rptList_txtSortId_13" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=59">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=59">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_14" type="checkbox" name="rptList$ctl15$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl15$hidId" id="rptList_hidId_14" value="52" />
      <input type="hidden" name="rptList$ctl15$hidLayer" id="rptList_hidLayer_14" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_photo</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=52">图片分享</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl15$txtSortId" type="text" value="102" id="rptList_txtSortId_14" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=52">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=52">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_15" type="checkbox" name="rptList$ctl16$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl16$hidId" id="rptList_hidId_15" value="53" />
      <input type="hidden" name="rptList$ctl16$hidLayer" id="rptList_hidLayer_15" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_photo_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=53">内容管理</a>
      (链接：article/article_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl16$txtSortId" type="text" value="99" id="rptList_txtSortId_15" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=53">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=53">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_16" type="checkbox" name="rptList$ctl17$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl17$hidId" id="rptList_hidId_16" value="54" />
      <input type="hidden" name="rptList$ctl17$hidLayer" id="rptList_hidLayer_16" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_photo_category</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=54">栏目类别</a>
      (链接：article/category_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl17$txtSortId" type="text" value="100" id="rptList_txtSortId_16" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=54">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=54">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_17" type="checkbox" name="rptList$ctl18$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl18$hidId" id="rptList_hidId_17" value="55" />
      <input type="hidden" name="rptList$ctl18$hidLayer" id="rptList_hidLayer_17" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_photo_comment</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=55">评论管理</a>
      (链接：article/comment_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl18$txtSortId" type="text" value="101" id="rptList_txtSortId_17" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=55">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=55">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_18" type="checkbox" name="rptList$ctl19$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl19$hidId" id="rptList_hidId_18" value="60" />
      <input type="hidden" name="rptList$ctl19$hidLayer" id="rptList_hidLayer_18" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_content</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=60">公司介绍</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl19$txtSortId" type="text" value="103" id="rptList_txtSortId_18" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=60">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=60">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_19" type="checkbox" name="rptList$ctl20$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl20$hidId" id="rptList_hidId_19" value="61" />
      <input type="hidden" name="rptList$ctl20$hidLayer" id="rptList_hidLayer_19" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_content_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=61">内容管理</a>
      (链接：article/article_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl20$txtSortId" type="text" value="99" id="rptList_txtSortId_19" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=61">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=61">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_20" type="checkbox" name="rptList$ctl21$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl21$hidId" id="rptList_hidId_20" value="62" />
      <input type="hidden" name="rptList$ctl21$hidLayer" id="rptList_hidLayer_20" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_content_category</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=62">栏目类别</a>
      (链接：article/category_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl21$txtSortId" type="text" value="100" id="rptList_txtSortId_20" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=62">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=62">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_21" type="checkbox" name="rptList$ctl22$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl22$hidId" id="rptList_hidId_21" value="63" />
      <input type="hidden" name="rptList$ctl22$hidLayer" id="rptList_hidLayer_21" value="4" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">channel_content_comment</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:48px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=63">评论管理</a>
      (链接：article/comment_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl22$txtSortId" type="text" value="101" id="rptList_txtSortId_21" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=63">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=63">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_22" type="checkbox" name="rptList$ctl23$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl23$hidId" id="rptList_hidId_22" value="6" />
      <input type="hidden" name="rptList$ctl23$hidLayer" id="rptList_hidLayer_22" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">sys_plugins</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=6">插件管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl23$txtSortId" type="text" value="999" id="rptList_txtSortId_22" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=6">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=6">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_23" type="checkbox" name="rptList$ctl24$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl24$hidId" id="rptList_hidId_23" value="64" />
      <input type="hidden" name="rptList$ctl24$hidLayer" id="rptList_hidLayer_23" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">plugin_link</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=64">链接管理</a>
      (链接：/plugins/link/admin/index.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl24$txtSortId" type="text" value="99" id="rptList_txtSortId_23" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=64">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=64">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_24" type="checkbox" name="rptList$ctl25$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl25$hidId" id="rptList_hidId_24" value="65" />
      <input type="hidden" name="rptList$ctl25$hidLayer" id="rptList_hidLayer_24" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">plugin_feedback</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=65">留言管理</a>
      (链接：/plugins/feedback/admin/index.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl25$txtSortId" type="text" value="99" id="rptList_txtSortId_24" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=65">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=65">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_25" type="checkbox" name="rptList$ctl26$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl26$hidId" id="rptList_hidId_25" value="2" />
      <input type="hidden" name="rptList$ctl26$hidLayer" id="rptList_hidLayer_25" value="1" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">sys_users</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=2">会员管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl26$txtSortId" type="text" value="100" id="rptList_txtSortId_25" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=2">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=2">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_26" type="checkbox" name="rptList$ctl27$chkId" /></span>
      <input type="hidden" name="rptList$ctl27$hidId" id="rptList_hidId_26" value="7" />
      <input type="hidden" name="rptList$ctl27$hidLayer" id="rptList_hidLayer_26" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_manage</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=7">会员管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl27$txtSortId" type="text" value="99" id="rptList_txtSortId_26" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=7">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=7">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_27" type="checkbox" name="rptList$ctl28$chkId" /></span>
      <input type="hidden" name="rptList$ctl28$hidId" id="rptList_hidId_27" value="15" />
      <input type="hidden" name="rptList$ctl28$hidLayer" id="rptList_hidLayer_27" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_audit</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=15">审核会员</a>
      (链接：users/user_audit.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl28$txtSortId" type="text" value="99" id="rptList_txtSortId_27" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=15">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=15">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_28" type="checkbox" name="rptList$ctl29$chkId" /></span>
      <input type="hidden" name="rptList$ctl29$hidId" id="rptList_hidId_28" value="16" />
      <input type="hidden" name="rptList$ctl29$hidLayer" id="rptList_hidLayer_28" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=16">所有会员</a>
      (链接：users/user_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl29$txtSortId" type="text" value="100" id="rptList_txtSortId_28" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=16">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=16">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_29" type="checkbox" name="rptList$ctl30$chkId" /></span>
      <input type="hidden" name="rptList$ctl30$hidId" id="rptList_hidId_29" value="17" />
      <input type="hidden" name="rptList$ctl30$hidLayer" id="rptList_hidLayer_29" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_group</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=17">会员组别</a>
      (链接：users/group_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl30$txtSortId" type="text" value="101" id="rptList_txtSortId_29" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=17">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=17">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_30" type="checkbox" name="rptList$ctl31$chkId" /></span>
      <input type="hidden" name="rptList$ctl31$hidId" id="rptList_hidId_30" value="8" />
      <input type="hidden" name="rptList$ctl31$hidLayer" id="rptList_hidLayer_30" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_log</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open">/span>
      <a href="nav_edit.aspx?action=Edit&id=8">会员日志</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl31$txtSortId" type="text" value="100" id="rptList_txtSortId_30" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=8">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=8">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_31" type="checkbox" name="rptList$ctl32$chkId" /></span>
      <input type="hidden" name="rptList$ctl32$hidId" id="rptList_hidId_31" value="18" />
      <input type="hidden" name="rptList$ctl32$hidLayer" id="rptList_hidLayer_31" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_sms</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=18">发送短信</a>
      (链接：users/user_sms.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl32$txtSortId" type="text" value="99" id="rptList_txtSortId_31" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=18">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=18">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_32" type="checkbox" name="rptList$ctl33$chkId" /></span>
      <input type="hidden" name="rptList$ctl33$hidId" id="rptList_hidId_32" value="19" />
      <input type="hidden" name="rptList$ctl33$hidLayer" id="rptList_hidLayer_32" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_message</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=19">站内消息</a>
      (链接：users/message_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl33$txtSortId" type="text" value="100" id="rptList_txtSortId_32" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=19">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=19">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_33" type="checkbox" name="rptList$ctl34$chkId" /></span>
      <input type="hidden" name="rptList$ctl34$hidId" id="rptList_hidId_33" value="20" />
      <input type="hidden" name="rptList$ctl34$hidLayer" id="rptList_hidLayer_33" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_point_log</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=20">积分记录</a>
      (链接：users/point_log.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl34$txtSortId" type="text" value="101" id="rptList_txtSortId_33" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=20">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=20">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_34" type="checkbox" name="rptList$ctl35$chkId" /></span>
      <input type="hidden" name="rptList$ctl35$hidId" id="rptList_hidId_34" value="21" />
      <input type="hidden" name="rptList$ctl35$hidLayer" id="rptList_hidLayer_34" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_amount_log</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=21">消费记录</a>
      (链接：users/amount_log.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl35$txtSortId" type="text" value="102" id="rptList_txtSortId_34" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=21">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=21">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_35" type="checkbox" name="rptList$ctl36$chkId" /></span>
      <input type="hidden" name="rptList$ctl36$hidId" id="rptList_hidId_35" value="9" />
      <input type="hidden" name="rptList$ctl36$hidLayer" id="rptList_hidLayer_35" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">user_settings</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=9">会员设置</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl36$txtSortId" type="text" value="101" id="rptList_txtSortId_35" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=9">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=9">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_48" type="checkbox" name="rptList$ctl49$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl49$hidId" id="rptList_hidId_48" value="4" />
      <input type="hidden" name="rptList$ctl49$hidLayer" id="rptList_hidLayer_48" value="1" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">sys_design</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=4">界面管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl49$txtSortId" type="text" value="102" id="rptList_txtSortId_48" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=4">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=4">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_49" type="checkbox" name="rptList$ctl50$chkId" /></span>
      <input type="hidden" name="rptList$ctl50$hidId" id="rptList_hidId_49" value="12" />
      <input type="hidden" name="rptList$ctl50$hidLayer" id="rptList_hidLayer_49" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">app_manage</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=12">应用管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl50$txtSortId" type="text" value="99" id="rptList_txtSortId_49" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=12">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=12">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_50" type="checkbox" name="rptList$ctl51$chkId" /></span>
      <input type="hidden" name="rptList$ctl51$hidId" id="rptList_hidId_50" value="31" />
      <input type="hidden" name="rptList$ctl51$hidLayer" id="rptList_hidLayer_50" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">app_templet_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=31">网站模板管理</a>
      (链接：settings/templet_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl51$txtSortId" type="text" value="99" id="rptList_txtSortId_50" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=31">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=31">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_51" type="checkbox" name="rptList$ctl52$chkId" /></span>
      <input type="hidden" name="rptList$ctl52$hidId" id="rptList_hidId_51" value="32" />
      <input type="hidden" name="rptList$ctl52$hidLayer" id="rptList_hidLayer_51" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">app_plugin_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=32">插件安装配置</a>
      (链接：settings/plugin_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl52$txtSortId" type="text" value="100" id="rptList_txtSortId_51" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=32">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=32">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_52" type="checkbox" name="rptList$ctl53$chkId" /></span>
      <input type="hidden" name="rptList$ctl53$hidId" id="rptList_hidId_52" value="33" />
      <input type="hidden" name="rptList$ctl53$hidLayer" id="rptList_hidLayer_52" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">app_builder_html</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=33">生成静态页面</a>
      (链接：settings/builder_html.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl53$txtSortId" type="text" value="101" id="rptList_txtSortId_52" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=33">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=33">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_53" type="checkbox" name="rptList$ctl54$chkId" /></span>
      <input type="hidden" name="rptList$ctl54$hidId" id="rptList_hidId_53" value="34" />
      <input type="hidden" name="rptList$ctl54$hidLayer" id="rptList_hidLayer_53" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">app_navigation_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=34">后台导航管理</a>
      (链接：settings/nav_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl54$txtSortId" type="text" value="102" id="rptList_txtSortId_53" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=34">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=34">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="aspNetDisabled checkall" style="vertical-align:middle;"><input id="rptList_chkId_54" type="checkbox" name="rptList$ctl55$chkId" disabled="disabled" /></span>
      <input type="hidden" name="rptList$ctl55$hidId" id="rptList_hidId_54" value="5" />
      <input type="hidden" name="rptList$ctl55$hidLayer" id="rptList_hidLayer_54" value="1" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">sys_controller</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=5">控制面板</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">是</td>
    <td><input name="rptList$ctl55$txtSortId" type="text" value="103" id="rptList_txtSortId_54" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=5">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=5">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_55" type="checkbox" name="rptList$ctl56$chkId" /></span>
      <input type="hidden" name="rptList$ctl56$hidId" id="rptList_hidId_55" value="13" />
      <input type="hidden" name="rptList$ctl56$hidLayer" id="rptList_hidLayer_55" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">site_manage</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=13">系统管理</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl56$txtSortId" type="text" value="99" id="rptList_txtSortId_55" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=13">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=13">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_56" type="checkbox" name="rptList$ctl57$chkId" /></span>
      <input type="hidden" name="rptList$ctl57$hidId" id="rptList_hidId_56" value="35" />
      <input type="hidden" name="rptList$ctl57$hidLayer" id="rptList_hidLayer_56" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">site_config</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=35">系统设置</a>
      (链接：settings/sys_config.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl57$txtSortId" type="text" value="99" id="rptList_txtSortId_56" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=35">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=35">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_57" type="checkbox" name="rptList$ctl58$chkId" /></span>
      <input type="hidden" name="rptList$ctl58$hidId" id="rptList_hidId_57" value="36" />
      <input type="hidden" name="rptList$ctl58$hidLayer" id="rptList_hidLayer_57" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">site_url_rewrite</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=36">URL配置</a>
      (链接：settings/url_rewrite_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl58$txtSortId" type="text" value="100" id="rptList_txtSortId_57" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=36">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=36">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_58" type="checkbox" name="rptList$ctl59$chkId" /></span>
      <input type="hidden" name="rptList$ctl59$hidId" id="rptList_hidId_58" value="37" />
      <input type="hidden" name="rptList$ctl59$hidLayer" id="rptList_hidLayer_58" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">site_channel_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=37">频道管理</a>
      (链接：channel/channel_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl59$txtSortId" type="text" value="101" id="rptList_txtSortId_58" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=37">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=37">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_59" type="checkbox" name="rptList$ctl60$chkId" /></span>
      <input type="hidden" name="rptList$ctl60$hidId" id="rptList_hidId_59" value="38" />
      <input type="hidden" name="rptList$ctl60$hidLayer" id="rptList_hidLayer_59" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">site_channel_category</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=38">频道分类</a>
      (链接：channel/category_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl60$txtSortId" type="text" value="102" id="rptList_txtSortId_59" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=38">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=38">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_60" type="checkbox" name="rptList$ctl61$chkId" /></span>
      <input type="hidden" name="rptList$ctl61$hidId" id="rptList_hidId_60" value="39" />
      <input type="hidden" name="rptList$ctl61$hidLayer" id="rptList_hidLayer_60" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">site_channel_field</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=39">扩展字段</a>
      (链接：channel/attribute_field_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl61$txtSortId" type="text" value="103" id="rptList_txtSortId_60" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=39">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=39">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_61" type="checkbox" name="rptList$ctl62$chkId" /></span>
      <input type="hidden" name="rptList$ctl62$hidId" id="rptList_hidId_61" value="14" />
      <input type="hidden" name="rptList$ctl62$hidLayer" id="rptList_hidLayer_61" value="2" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">sys_manager</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:0px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=14">系统用户</a>
      
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl62$txtSortId" type="text" value="101" id="rptList_txtSortId_61" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=14">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=14">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_62" type="checkbox" name="rptList$ctl63$chkId" /></span>
      <input type="hidden" name="rptList$ctl63$hidId" id="rptList_hidId_62" value="40" />
      <input type="hidden" name="rptList$ctl63$hidLayer" id="rptList_hidLayer_62" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">manager_list</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=40">管理员管理</a>
      (链接：manager/manager_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl63$txtSortId" type="text" value="99" id="rptList_txtSortId_62" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=40">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=40">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_63" type="checkbox" name="rptList$ctl64$chkId" /></span>
      <input type="hidden" name="rptList$ctl64$hidId" id="rptList_hidId_63" value="41" />
      <input type="hidden" name="rptList$ctl64$hidLayer" id="rptList_hidLayer_63" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">manager_role</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=41">角色管理</a>
      (链接：manager/role_list.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl64$txtSortId" type="text" value="100" id="rptList_txtSortId_63" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=41">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=41">修改</a>
    </td>
  </tr>

  <tr>
    <td align="center">
      <span class="checkall" style="vertical-align:middle;"><input id="rptList_chkId_64" type="checkbox" name="rptList$ctl65$chkId" /></span>
      <input type="hidden" name="rptList$ctl65$hidId" id="rptList_hidId_64" value="42" />
      <input type="hidden" name="rptList$ctl65$hidLayer" id="rptList_hidLayer_64" value="3" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">manager_log</td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span style="display:inline-block;width:24px;"></span><span class="folder-line"></span><span class="folder-open"></span>
      <a href="nav_edit.aspx?action=Edit&id=42">管理日志</a>
      (链接：manager/manager_log.aspx)
    </td>
    <td align="center">是</td>
    <td align="center">否</td>
    <td><input name="rptList$ctl65$txtSortId" type="text" value="101" id="rptList_txtSortId_64" class="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="nav_edit.aspx?action=Add&id=42">添加子级</a>
      <a href="nav_edit.aspx?action=Edit&id=42">修改</a>
    </td>
  </tr>

  
</table>

<!--/列表-->
</form>
</body>
</html>

