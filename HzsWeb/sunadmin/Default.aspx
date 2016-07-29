<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="sunadmin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台管理中心</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">if($.browser.msie&&$.browser.version=="6.0"){window.location.href='ie6update.htm'}</script>
    <script type="text/javascript" src="../scripts/jquery/jquery.nicescroll.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../scripts/layout.js"></script>
    <script type="text/javascript" src="js/popmenu.js"></script> 
</head>

<body class="indexbody">

    <!--全局菜单-->
    <a class="btn-paograms" onclick="triggerMenu(true);"></a>
    <div id="pop-menu" class="pop-menu">
        <div class="pop-box">
            <h1 class="title"><i></i>导航菜单</h1>
            <i class="close" onclick="triggerMenu(false);">关闭</i>
            <div class="list-box"></div>
        </div>
        <i class="arrow">箭头</i>
    </div>
    <!--/全局菜单-->
    <div class="header">
        <div class="header-box">
            <h1 class="logo"></h1>
            <ul id="nav" class="nav"></ul>
            <div class="nav-right">
                <div class="icon-info">
                    <span>您好，<%=DataCache.GetCache(HzsKey.CACHE_HTM) %><br />
                        管理员
                    </span>
                </div>
                <div class="icon-option">
                    <i></i>
                    <div class="drop-box">
                        <div class="arrow"></div>
                        <ul class="drop-item">
                            <li><a target="_blank" href="../">预览网站</a></li>
                            <li><a href="center.aspx" target="mainframe">管理中心</a></li>
                            <li><a onclick="linkMenuTree(false, '');" href="manager/manager_pwd.aspx" target="mainframe">修改密码</a></li>
                            <li><a id="lbtnExit" href="/AjaxLogin/Logout.ashx">注销登录</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="nav-right2"><div class="icon-date"><span id="bgclock"><script>clockon();</script></span></div></div>
        </div>
    </div>
    <div class="main-sidebar">
        <div id="sidebar-nav" class="sidebar-nav">
            <div class="list-box"></div>
        </div>
    </div>
    <div class="main-container"> 
        <iframe id="mainframe" name="mainframe" frameborder="0" src=""></iframe>
    </div>
</body>
</html>

