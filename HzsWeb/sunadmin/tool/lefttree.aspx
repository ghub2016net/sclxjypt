<%@ Page Language="C#" %>
<div class="list-group" name="内容">
<h2>默认站点<i></i></h2>
<ul>
<li>
<a navid="channel_news" class="item">
<span>新闻资讯</span>
</a>
<ul>
<li>
<a navid="channel_news_list" href="info/" target="mainframe" class="item">
<span>内容管理</span>
</a>
</li>
<li>
<a navid="channel_local_list" href="info/local.aspx" target="mainframe" class="item">
<span>地方频道</span>
</a>
</li>
<li>
<a navid="channel_news_category" href="info/infotype.aspx" target="mainframe" class="item">
<span>栏目类别</span>
</a>
</li>
</ul>
</li>
<li>
<a navid="channel_trade" class="item">
<span>供求信息</span>
</a>
<ul>
<li>
<a navid="channel_trade_list" href="trade/supply.aspx" target="mainframe" class="item">
<span>供应信息</span>
</a>
</li>
<li>
<a navid="channel_trade_demand" href="trade/demand.aspx" target="mainframe" class="item">
<span>需求信息</span>
</a>
</li>
<li>
<a navid="channel_trade_cooperation" href="trade/cooperation.aspx" target="mainframe" class="item">
<span>合作信息</span>
</a>
</li>
<li>
<a navid="channel_trade_consulting" href="trade/consulting.aspx" target="mainframe" class="item">
<span>评论管理</span>
</a>
</li>
</ul>
</li>
<li>
<a navid="channel_huser" class="item">
<span>合作社会员</span>
</a>
<ul>
<li>
<a navid="channel_huser_list" href="huser/huserlist.aspx" target="mainframe" class="item">
<span>合作社会员管理</span>
</a>
</li>
</ul>
</li>
</ul>
<h2>其他管理<i></i></h2>
<ul>
<li>
<a navid="plugin_link" href="link/linklist.aspx" target="mainframe" class="item">
<span>链接管理</span>
</a>
</li>
<li>
<a navid="plugin_syslog" href="log/systemlog.aspx" target="mainframe" class="item">
<span>系统操作日志</span>
</a>
</li>
<li>
<a navid="plugin_userlog" href="log/adminloglist.aspx" target="mainframe" class="item">
<span>用户登录日志</span>
</a>
</li>
</ul>
</div>
<div class="list-group" name="会员">
<h2>会员管理<i></i></h2>
<ul>
<li>
<a navid="user_manage" class="item">
<span>会员管理</span>
</a>
<ul>
<li>
<a navid="user_verify" href="huser/huser_verify.aspx" target="mainframe" class="item">
<span>审核会员</span>
</a>
</li>
<li>
<a navid="user_list" href="huser/huserlist.aspx" target="mainframe" class="item">
<span>会员管理</span>
</a>
</li>
</ul>
</li>
<li>
<a navid="user_log" class="item">
<span>会员日志</span>
</a>
<ul>
<li>
<a navid="user_userlog" href="log/userloglist.aspx" target="mainframe" class="item">
<span>会员日志</span>
</a>
</li>
</ul>
</li>
</ul>
</div>

<div class="list-group" name="界面">
<h2>界面管理<i></i></h2>
<ul>
<li>
<a navid="app_manage" class="item">
<span>应用管理</span>
</a>
<ul>
<li>
<a navid="app_builder_html" href="settings/builder_html.aspx" target="mainframe" class="item">
<span>生成静态页面</span>
</a>
</li>
<li>
<a navid="app_navigation_list" href="settings/nav_list.aspx" target="mainframe" class="item">
<span>后台导航管理</span>
</a>
</li>
</ul>
</li>
</ul>
</div>
<div class="list-group" name="控制面板">
<h2>控制面板<i></i></h2>
<ul>
<li>
<a navid="sys_manager" class="item">
<span>系统用户</span>
</a>
<ul>
<li>
<a navid="manager_list" href="manager/managerlist.aspx" target="mainframe" class="item">
<span>管理员管理</span>
</a>
</li>
<li>
<a navid="manager_role" href="manager/rolelist.aspx" target="mainframe" class="item">
<span>角色管理</span>
</a>
</li>
<li>
<a navid="manager_log" href="log/userloglist.aspx" target="mainframe" class="item">
<span>管理日志</span>
</a>
</li>
</ul>
</li>
</ul>
</div>