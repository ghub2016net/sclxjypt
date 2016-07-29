<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="controls/xsheader.ascx" tagname="xsheader" tagprefix="uc1" %>
<%@ Register src="controls/login.ascx" tagname="login" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="css/css.css">
<title>泸县数字农经网</title>
<meta name="keywords" content="泸县数字农经网,泸县农业局,农民专业合作社,农民专业合作社网,泸县特产,供应求购泸县农产品" />
<meta name="description" content="泸县数字农经网,泸县农业局,农民专业合作社,农民专业合作社网,泸县特产,供应求购泸县农产品" />
<script src="scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="scripts/jquery/jquery.form.min.js" type="text/javascript"></script>
<script src="scripts/MSClass.js" type="text/javascript"></script>
<script src="scripts/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript" src="scripts/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="js/areajs.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#KinSlideshow").KinSlideshow({
                moveStyle: "down",
                intervalTime: 8,
                mouseEvent: "mouseover",
                isHasTitleBar: true,
                titleBar: { titleBar_height: 30, titleBar_bgColor: "#3a3a3a", titleBar_alpha: 0.5 },
                titleFont: { TitleFont_size: 14, TitleFont_color: "#ffffff" }
            });
            //图片延迟加载    
            $(".snqyimgScrollCenter img").lazyload({
                placeholder : "images/grey.gif",
                effect: "fadeIn",
                container: $(".snqyimgScrollCenter")
            });
            	
            $(".imgScrollCenter4 img").lazyload({
            	placeholder : "images/grey.gif",
            	effect: "fadeIn",
                container: $(".imgScrollCenter4")
            });
            	
            $(".lsdwCenter img").lazyload({
            	placeholder : "images/grey.gif",
            	effect: "fadeIn",
                container: $(".lsdwCenter")
            });
        });
        </script>
</head>

<body>
<div class="contents">
<%= UcExecutor.Render("~/controls/header.ascx", null)%>
<uc1:xsheader ID="xsheader1" runat="server" />
    <div class="clear01"></div>
    <div class="contentsRight">
    <uc2:login ID="login1" runat="server" />
        <div class="clear01"></div>
        <div><img src="images/img01.jpg" style="width:246px; height:93px;" /></div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">通知公告</div>
        <div class="moreR"><a href="/info/list.aspx?sort=43" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
            <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.tongzhigonggao })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">热点新闻</div>
        <div class="moreR"><a href="/info/list.aspx?sort=272" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.redianxinwen })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">农超对接</div>
        <div class="moreR"><a href="/info/list.aspx?sort=49" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.nongchaoduijie })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">质量安全</div>
        <div class="moreR"><a href="/info/list.aspx?sort=55" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.zhilianganquan })%></ul> 
          </div>
        </div>
    </div>
    <div class="contentsLeft">
        <div class="banner" id="KinSlideshow" style="visibility:hidden;">
        <%if (result.lunbotupian.Count > 0)
          {
              foreach (HzsModel.Models.NewsInfo lunbo in result.lunbotupian)
              {%>
             <a href="/info/detail.aspx?id=<%=lunbo.id %>" target="_blank"><img src="<%=string.IsNullOrEmpty(lunbo.nimg)?"../images/noimg.png":("newsimg/s/"+lunbo.nimg) %>" alt="<%=StringClass.CutString(lunbo.title,14) %>" width="369" height="232"></a>
        <%}
          }
          else
          {%>  
        <img src="../images/noimg.png" width="369" height="232" />
        <%} %>         
        </div>
        <div class="mainNews2 rig">
        <div class="biaoti">新闻资讯</div>
        <div class="biaotiMore02"><a href="/info/list.aspx?sort=1" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews2">
           <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.xinwenzixun })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
    	<div class="newsImgbg">
        <div class="flanmu2 moreL3">热点图片</div>
        <div class="moreImgR">更多&gt;&gt;</div>
		<div class="imgScrollCenter" id="hottitle1">
            <ul  id="ulid1">
            <%if (result.rediantupian.Count > 0)
              {
                  foreach (HzsModel.Models.NewsInfo mo in result.rediantupian)
                  { %>
            <li class="imgScroll">
                    <div class="imgNewsbg"><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>" target="_blank"><img src="/newsimg/s/<%=mo.nimg %>" width="97" height="97"></a></div>
                    <div class="imgScrollTxt"><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>" target="_blank"><%=StringClass.CutString(mo.title, 16)%></a></div>
                    </li>
<li><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>"><%=StringClass.CutString(mo.title, 36)%></a></li>
            <%} } %>
            </ul>
            </div>     
        <script>            new Marquee(["hottitle1", "ulid1"], 2, 2, 740, 161, 20, 0, 0);</script>      
		</div>
        <div class="clear01"></div>
        <div class="mainNewsCheng">
        <div class="biaotiCheng">经管动态</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=36" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNewsCheng">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.jingguandongtai })%></ul> 
          </div>
        </div>
        <div class="mainNewsCheng rig">
        <div class="biaotiCheng">示范社库</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=83" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNewsCheng">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.shifansheku })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>  
        <div class="mainNewsCheng">
        <div class="biaotiCheng">工作简报</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=38" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNewsCheng">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.gongzuojianbao })%></ul> 
          </div>
        </div>
        <div class="mainNewsCheng rig">
        <div class="biaotiCheng">项目管理</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=39" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNewsCheng">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.xiangmuguanli })%></ul> 
          </div>
        </div> 
        <div class="clear01"></div>
        <div class="newsImgbg">
        <div class="flanmu2 moreL3">精彩瞬间</div>
        <div class="moreImgR"><a href="/info/list.aspx?sort=273" target="_blank">更多&gt;&gt;</a></div>
		<div class="imgScrollCenter" id="hottitle2">
            <ul  id="ulid2">
            <%if (result.jingcaishunjian.Count > 0)
              {
                  foreach (HzsModel.Models.NewsInfo mo in result.jingcaishunjian)
                  { %>
            <li class="imgScroll">
                <div class="imgNewsbg"><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>" target="_blank"><img src="/newsimg/s/<%=mo.nimg %>" width="97" height="97"></a></div>
                <div class="imgScrollTxt"><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>" target="_blank"><%=StringClass.CutString(mo.title, 16)%></a></div>
                </li>
<li><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>"><%=StringClass.CutString(mo.title, 36)%></a></li>
            <%} } %>
            </ul>
            </div>   
        <script>            new Marquee(["hottitle2", "ulid2"], 2, 2, 740, 161, 20, 0, 0);</script>                       
		</div>
        <div class="clear01"></div>
    <div><img src="images/banner01.jpg" /></div>
    </div>
    <div class="clear01"></div>
    <div class="newsImgbg4">
	<div class="imgScrollCenter4" style="margin-left:55px;" id="hottitle3">
            <ul id="ulid3">
             <%if (result.nongyouchanpin.Count > 0)
               {
                   foreach (HzsModel.Models.NewsInfo mo in result.nongyouchanpin)
                  { %>
            <li class="imgScroll">
                <div ><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>" target="_blank"><img data-original="/newsimg/s/<%=mo.nimg %>" width="150" height="113"></a></div>
                <div class="imgScrollTxt2"><a href="/info/detail?id=<%=mo.id %>" title="<%=mo.title %>" target="_blank"><%=StringClass.CutString(mo.title, 20)%></a></div>
                </li>
            <%} } %>
            </ul>
            </div>
            <script>                new Marquee(["hottitle3", "ulid3"], 2, 6, 857, 188, 100, 0, 0);</script>              
	</div>
    <div class="clear01"></div>
    <div class="contentsRight">
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">政策法规</div>
        <div class="moreR"><a href="/info/list.aspx?sort=40" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.zhengcefagui })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">调查研究</div>
        <div class="moreR"><a href="/info/list.aspx?sort=91" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.diaochayanjiu })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">行业自律</div>
        <div class="moreR"><a href="/info/list.aspx?sort=53" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.hangyezilv })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNewsL">
        <div class="flanmu3 moreL2">名优特产</div>
        <div class="moreR"><a href="/info/list.aspx?sort=51" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.mingyoutechan })%></ul> 
          </div>
        </div>
    </div>
    <div class="contentsLeft">
    <div class="mainNews3">
        <div class="biaoti">各地政策</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=45" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.gedizhengce })%></ul> 
          </div>
        </div>
        <div class="mainNews3 rig">
        <div class="biaoti">统计报表</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=46" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.tongjibaobiao })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>  
        <div class="mainNews3">
        <div class="biaoti">农业科技</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=47" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.nongyekeji })%></ul> 
          </div>
        </div>
        <div class="mainNews3 rig">
        <div class="biaoti">会员风采</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=48" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews3">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.huiyuanfengcai })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="lsdwImgbg">
        <div class="flanmu2 moreL3">理事单位</div>
        <div class="moreImgR"><a href="/lishi.aspx" target="_blank">更多&gt;&gt;</a></div>
		<div class="lsdwCenter" id="roll" style=" margin-top:10px;">
            <ul>
            <%if (result.lishidanwei.Count > 0)
              {
                  foreach (HzsModel.Models.HzsUser lishi in result.lishidanwei)
                  { %>
            <li class="imgScroll">
                <div class="lsdwimgNewsbg"><a target="_blank" href="/company/index?uid=<%=lishi.uid %>"><img data-original="corpimg/icon/s/<%=lishi.corppic %>" src="../images/grey.gif"/></a></div>
                <div class="lsdwCenterTxt"> <a href="/company/index?uid=<%=lishi.uid %>" target="_blank" title="<%=lishi.corpname %>" style="color:#257C00;"><%=StringClass.CutString(lishi.corpname,28)%></a></div>
                <div class="lsdwJianjieCenterTxt"><span>简介：</span><%=StringClass.CutString(lishi.hzsintro, 26)%>...</div>
                </li>
            <%} } %>
            </ul>
            </div>  
            <script>new Marquee("roll", 0, 1, 740, 376, 20, 0, 0);</script>                      
		</div>    
    </div>
    <div class="clear01"></div>
    <div><img src="images/banner02.jpg" /></div>
    <div class="hezuoshe">
    <div class="clear01"></div>
    <div class="contentsLeft2">
    	<div class="mainNews4">
        <div class="biaoti2">地方频道</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=37" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews4">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.difangpindao })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div><img src="images/banner04.jpg" /></div>
        <div class="clear01"></div>
        <div class="mainNews4">
        <div class="biaoti2">产品展会</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=50" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews4">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.chanpinzhanhui })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNews4">
        <div class="biaoti2">三品一标</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=56" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews4">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.sanpinyibiao })%></ul> 
          </div>
        </div>
        <div class="clear01"></div>
        <div class="mainNews4">
        <div class="biaoti2">转基因知识</div>
        <div class="biaotiMore"><a href="/info/list.aspx?sort=63" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews4">
            <ul><%= UcExecutor.Render("~/controls/mok/newsinfo_datetime.ascx", new Newsinfo_Controlcs() { molist = result.zhuanjiyinzhishi })%></ul> 
          </div>
        </div>
    </div>
    <div class="contentsRight2">
   	  <div class="gongyingImgbg">
        <div class="flanmu4 moreL3">供应信息</div>
        <div class="moreImgR"><a href="trade/list.aspx?trade_type=10" target="_blank">更多&gt;&gt;</a></div>
		<div class="gongyingCenter">
            <table border="0" class="mainTable">
        <tr>              
              <th class="width80">地　区</th>
              <th class="width170">品　种</th>
              <th class="width100">价　格</th>
              <th class="width80">日　期</th>
            </tr>
        <%= UcExecutor.Render("~/controls/mok/tradeinfo.ascx", new Trade_Controlcs() { molist = result.gongyinginfo })%>
          </table>
          </div>            
		</div>
        <div class="clear01"></div>
        <div class="gongyingImgbg">
        <div class="flanmu4 moreL3">需求信息</div>
        <div class="moreImgR"><a href="trade/list.aspx?trade_type=20" target="_blank">更多&gt;&gt;</a></div>
		<div class="gongyingCenter">
            <table border="0" class="mainTable">
        <tr>              
              <th class="width80">地　区</th>
              <th class="width170">品　种</th>
              <th class="width100">价　格</th>
              <th class="width80">日　期</th>
            </tr>
         <%= UcExecutor.Render("~/controls/mok/tradeinfo.ascx", new Trade_Controlcs() { molist = result.xuqiuinfo })%>
          </table>
          </div>            
		</div>
         <div class="clear01"></div>
        <div class="gongyingImgbg">
        <div class="flanmu4 moreL3">合作信息</div>
        <div class="moreImgR"><a href="trade/list.aspx?trade_type=10" target="_blank">更多&gt;&gt;</a></div>
		<div class="gongyingCenter">
            <table border="0" class="mainTable">
        <tr>              
              <th class="width80">地　区</th>
              <th class="width170">品　种</th>
              <th class="width100">价　格</th>
              <th class="width80">日　期</th>
            </tr>
        <%= UcExecutor.Render("~/controls/mok/tradeinfo.ascx", new Trade_Controlcs() { molist = result.hezuoinfo })%>
          </table>
          </div>            
		</div>
        <div class="clear01"></div>
        <div class="mainNews5">
        <div class="flanmu4 moreL3">会员名录</div>
        <div class="moreImgR"><a href="/community/list.aspx" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews5">
            <table border="0" class="mainTable">
        <tr>              
            <th class="width80">地　区</th>
            <th class="width170">合作社名称</th>
            <th class="width100">负责人</th>
            <th class="width80">联系电话</th>
        </tr>
        <%if (result.huiyuanminglu.Count > 0) {
              foreach (HzsModel.Models.HzsUser hyml in result.huiyuanminglu){ %>
        <tr>
            <td><script>$.each(arrarea, function (i, n) { if (n.oid == <%=hyml.province %>) { document.write(n.oname); } });</script>
                <script>$.each(arrarea, function (i, n) { if (n.oid == <%=hyml.city %>) { document.write(" "+n.oname); } });</script></td>
            <td><a target="_blank" href="/company/Default.aspx?uid=<%=hyml.uid %>"><%=hyml.corpname%></a></td>
            <td><%=hyml.hzsboss %></td>
            <td><%=hyml.tel %></td>
        </tr>
            <%} } %>
          </table>

          </div>
        </div>
    </div>
    <div class="clear01"></div>
    </div>
    
    <div class="clear01"></div>
    <div class="snqyImgbg">
        <div class="flanmu3 moreL4">网销平台</div>
        <div class="moreImgR02">更多&gt;&gt;</div>
		<div class="snqyimgScrollCenter" id="hottitle5" style="margin-left:15px;">
            <ul id="ulid5">
            <%if (result.wangxiaopingtai.Count > 0){ foreach (HzsModel.Models.NewsInfo wxpt in result.wangxiaopingtai){ %>
                <li class="imgScroll">
                <div class="imgNewsbg"><a href="/info/infodetail.aspx?id=<%=wxpt.id %>" title="<%=wxpt.title %>" target="_blank"><img data-original="newsimg/s/<%=wxpt.nimg %>"  width="97" height="97" border="0" hspace="1"></a></div>
                <div class="imgScrollTxt"><a href="/info/infodetail.aspx?id=<%=wxpt.id %>" title="<%=wxpt.title %>" target="_blank"><%=StringClass.CutString(wxpt.title, 16)%></a></div>
                </li> 
            <%} } %> 
            </ul>
            </div>    
            <script>new Marquee(["hottitle5", "ulid5"], 2, 6, 940, 170, 100, 0, 0);</script>           
		</div>
        <div class="clear01"></div>
        <div class="contentsLeft3">
        	<div class="mainNewsL">
        <div class="flanmu3 moreL2">人才培训</div>
        <div class="moreR"><a href="/info/list.aspx?sort=127" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.rencaipeixun })%></ul> 
          </div>
        </div>
        <div class="mainNewsL rig">
        <div class="flanmu3 moreL2">品牌建设</div>
        <div class="moreR"><a href="/info/list.aspx?sort=239" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
           <ul><%= UcExecutor.Render("~/controls/mok/right_newsinfo.ascx", new Newsinfo_Controlcs() { molist = result.pinpaijianshe })%></ul> 
          </div>
        </div>
        </div>
        <div class="contentsRight3">
        	<div class="mainNewsL">
        <div class="flanmu3 moreL2">理事会员</div>
        <div class="moreR"><a href="/lishi" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
            <ul>
            <%if (result.lishidanwei.Count > 0)
              {
                  int lscount = 0;
                  foreach (HzsModel.Models.HzsUser lishi6 in result.lishidanwei)
                  {
                      lscount = lscount + 1; if (lscount > 5) { break; } %>
            <li><a href="/company/index?uid=<%=lishi6.uid %>" title="<%=lishi6.corpname %>"><%=StringClass.CutString(lishi6.corpname,36) %></a></li>
            <%} }%>
                </ul> 
          </div>
        </div>
        <div class="mainNewsL rig">
        <div class="flanmu3 moreL2">新会员公示</div>
        <div class="moreR"><a href="/community/list.aspx" target="_blank">更多&gt;&gt;</a></div>
        <div class="mainLNews">
            <ul>
            <%if (result.xinhuiyuangongshi.Count > 0)
              {
                  foreach (HzsModel.Models.HzsUser huiyuan in result.xinhuiyuangongshi)
                  { %>
            <li><a href="/company/index?uid=<%=huiyuan.uid %>" title="<%=huiyuan.corpname %>"><%=StringClass.CutString(huiyuan.corpname, 36)%></a></li>
            <%} }%>
                </ul> 
          </div>
        </div>
        </div>
            <div class="clear01"></div>
<%=UcExecutor.Render("~/controls/footer.ascx", null)%>
</div>
</body>
</html>
