<%@ Page Language="C#" AutoEventWireup="true" CodeFile="consulting.aspx.cs" Inherits="sunadmin_trade_consulting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>评论管理</title>
<script type="text/javascript" src="../../scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/layout.js"></script>
<link  href="../../skin/pagination.css" rel="stylesheet" type="text/css" />
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form method="post" action="comment_list.aspx?channel_id=1" id="form1">

<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>评论管理</span>
  <i class="arrow"></i>
  <span>评论列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><a onclick="return ExePostBack(&#39;btnAudit&#39;,&#39;审核通过后将在前台显示，是否继续？&#39;);" id="btnAudit" class="save" href="javascript:__doPostBack(&#39;btnAudit&#39;,&#39;&#39;)"><i></i><span>审核</span></a></li>
        <li><a onclick="return ExePostBack(&#39;btnDelete&#39;);" id="btnDelete" class="del" href="javascript:__doPostBack(&#39;btnDelete&#39;,&#39;&#39;)"><i></i><span>删除</span></a></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <select name="ddlProperty" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;ddlProperty\&#39;,\&#39;\&#39;)&#39;, 0)" id="ddlProperty">
	<option selected="selected" value="">所有属性</option>
	<option value="isLock">未审核</option>
	<option value="unLoock">已审核</option>

</select>
        </div>
      </div>
    </div>
    <div class="r-list">
      <input name="txtKeywords" type="text" id="txtKeywords" class="keyword" />
      <a id="lbtnSearch" class="btn-search" href="javascript:__doPostBack(&#39;lbtnSearch&#39;,&#39;&#39;)">查询</a>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-14 10:17:26</i><i class="reply"><a href="comment_edit.aspx?id=63">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_0" type="checkbox" name="rptList$ctl01$chkId" /></span><input type="hidden" name="rptList$ctl01$hidId" id="rptList_hidId_0" value="63" /></b>
        历史性时刻：ARM首次成功模拟运行x86
      </div>
      <div class="ask">
        aaaaaaaaaaaa
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-14 10:17:15</i><i class="reply"><a href="comment_edit.aspx?id=62">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_1" type="checkbox" name="rptList$ctl02$chkId" /></span><input type="hidden" name="rptList$ctl02$hidId" id="rptList_hidId_1" value="62" /></b>
        历史性时刻：ARM首次成功模拟运行x86
      </div>
      <div class="ask">
        adsf
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-13 22:25:44</i><i class="reply"><a href="comment_edit.aspx?id=61">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_2" type="checkbox" name="rptList$ctl03$chkId" /></span><input type="hidden" name="rptList$ctl03$hidId" id="rptList_hidId_2" value="61" /></b>
        超级黑客Comex离开苹果
      </div>
      <div class="ask">
        大苏打sag
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>11111</i><i>2014-1-13 21:36:50</i><i class="reply"><a href="comment_edit.aspx?id=60">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_3" type="checkbox" name="rptList$ctl04$chkId" /></span><input type="hidden" name="rptList$ctl04$hidId" id="rptList_hidId_3" value="60" /></b>
        超级黑客Comex离开苹果
      </div>
      <div class="ask">
        adfasdfasd
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>brigie</i><i>2014-1-9 17:00:14</i><i class="reply"><a href="comment_edit.aspx?id=58">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_4" type="checkbox" name="rptList$ctl05$chkId" /></span><input type="hidden" name="rptList$ctl05$hidId" id="rptList_hidId_4" value="58" /></b>
        Win8，最后的Windows操作系统
      </div>
      <div class="ask">
        不太习惯用win8
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-8 16:39:00</i><i class="reply"><a href="comment_edit.aspx?id=57">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_5" type="checkbox" name="rptList$ctl06$chkId" /></span><input type="hidden" name="rptList$ctl06$hidId" id="rptList_hidId_5" value="57" /></b>
        全球仅此一台！雷蛇星战版Blade游戏本
      </div>
      <div class="ask">
        &lt;a href="javascript:alert('1111')"/&gt;
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-3 18:54:21</i><i class="reply"><a href="comment_edit.aspx?id=52">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_6" type="checkbox" name="rptList$ctl07$chkId" /></span><input type="hidden" name="rptList$ctl07$hidId" id="rptList_hidId_6" value="52" /></b>
        全球仅此一台！雷蛇星战版Blade游戏本
      </div>
      <div class="ask">
        哈哈哈！哈哈哈！哈哈哈！哈哈哈！哈哈哈！哈哈哈！哈哈哈！哈哈哈！哈哈哈！哈哈哈！
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-3 18:53:52</i><i class="reply"><a href="comment_edit.aspx?id=51">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_7" type="checkbox" name="rptList$ctl08$chkId" /></span><input type="hidden" name="rptList$ctl08$hidId" id="rptList_hidId_7" value="51" /></b>
        全球仅此一台！雷蛇星战版Blade游戏本
      </div>
      <div class="ask">
        sadfffffffffffffffffffffff
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2014-1-3 18:53:28</i><i class="reply"><a href="comment_edit.aspx?id=50">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_8" type="checkbox" name="rptList$ctl09$chkId" /></span><input type="hidden" name="rptList$ctl09$hidId" id="rptList_hidId_8" value="50" /></b>
        全球仅此一台！雷蛇星战版Blade游戏本
      </div>
      <div class="ask">
        sdfsfsdf
        
      </div>
    </td>
  </tr>

  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i>匿名用户</i><i>2013-12-31 15:38:38</i><i class="reply"><a href="comment_edit.aspx?id=47">回复</a></i></span>
        <b><span class="checkall"><input id="rptList_chkId_9" type="checkbox" name="rptList$ctl10$chkId" /></span><input type="hidden" name="rptList$ctl10$hidId" id="rptList_hidId_9" value="47" /></b>
        历史性时刻：ARM首次成功模拟运行x86
      </div>
      <div class="ask">
        fvghdfg
        
      </div>
    </td>
  </tr>

  
</table>

<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><input name="txtPageNum" type="text" value="10" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;txtPageNum\&#39;,\&#39;\&#39;)&#39;, 0)" onkeypress="if (WebForm_TextBoxKeyHandler(event) == false) return false;" id="txtPageNum" class="pagenum" onkeydown="return checkNumber(event);" /><span>条/页</span>
  </div>
  <div id="PageContent" class="default"><span>共30记录</span><span class="disabled">«上一页</span><span class="current">1</span><a href="comment_list.aspx?channel_id=1&page=2">2</a><a href="comment_list.aspx?channel_id=1&page=3">3</a><a href="comment_list.aspx?channel_id=1&page=2">下一页»</a></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
