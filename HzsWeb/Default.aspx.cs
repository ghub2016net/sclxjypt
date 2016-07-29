using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel;
using ClownFish;
using HzsModel.Models;
using System.Data;

public partial class _Default : MyMVC.MyBasePage
{
    public DefaultPageModel result = new DefaultPageModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        using (DbContext db = new DbContext(false))
        {
            ///供求信息模块
            db.CreateCommand("select top 6 * from Trade where tradetype=10 and isverify=10 order by id desc", CommandType.Text);
            result.gongyinginfo = db.FillList<Trade>();//供应信息
            db.CreateCommand("select top 6 * from Trade where tradetype=20 and isverify=10 order by id desc", CommandType.Text);
            result.xuqiuinfo = db.FillList<Trade>();//需求信息
            db.CreateCommand("select top 6 * from Trade where tradetype=30 and isverify=10 order by id desc", CommandType.Text);
            result.hezuoinfo = db.FillList<Trade>();//合作信息
            ///合作社会员相关模块
            db.CreateCommand("select top 30 uid,corpname,corppic,hzsintro from HzsUser where isverify=10 and submitverify=10 and htype>1 Order By htype desc", CommandType.Text);
            result.lishidanwei = db.FillList<HzsUser>();//理事单位     isverify后台审核10通过 and  submitverify审核10通过显示
            db.CreateCommand("select top 30 uid,corpname,corppic,hzsintro from HzsUser where isverify=10 and submitverify=10 and addtime>'" + (DateTime.Now.AddMonths(-3).ToString("yyyy-MM") + "-01") + "' Order By htype desc", CommandType.Text);
            result.xinhuiyuangongshi = db.FillList<HzsUser>();//新会员公示 3个月内新注册会员
            db.CreateCommand("select top 4 * from HzsUser where isverify=10 and htype>1 Order By htype desc", CommandType.Text);
            result.huiyuanminglu = db.FillList<HzsUser>();//会员名录   isverify后台审核10通过 and  submitverify审核10通过显示

            ///图片新闻相关模块
            db.CreateCommand("SELECT top 8 id,title,addtime,nimg from NewsInfo where nimg<>null Order by id desc", CommandType.Text);
            result.lunbotupian = db.FillList<NewsInfo>();//首页轮播图片
            db.CreateCommand("SELECT TOP 10 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 271 and nimg<>null  Order By id DESC", CommandType.Text);
            result.rediantupian = db.FillList<NewsInfo>();//热点图片
            db.CreateCommand("SELECT TOP 10 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 273 and nimg<>null  Order By id DESC", CommandType.Text);
            result.jingcaishunjian = db.FillList<NewsInfo>();//精彩瞬间
            db.CreateCommand("SELECT TOP 12 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 51 and nimg<>null  Order By id DESC", CommandType.Text);
            result.nongyouchanpin = db.FillList<NewsInfo>();// 农优产品

            ///新闻模块
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 43 Order by id desc", CommandType.Text);
            result.tongzhigonggao = db.FillList<NewsInfo>();//通知公告
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 272 Order by id desc", CommandType.Text);
            result.redianxinwen = db.FillList<NewsInfo>();//热点新闻
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 49 Order by id desc", CommandType.Text);
            result.nongchaoduijie = db.FillList<NewsInfo>();//农超对接
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 55 Order by id desc", CommandType.Text);
            result.zhilianganquan = db.FillList<NewsInfo>();//质量安全
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 40 Order by id desc", CommandType.Text);
            result.zhengcefagui = db.FillList<NewsInfo>();//政策法规
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 91 Order by id desc", CommandType.Text);
            result.diaochayanjiu = db.FillList<NewsInfo>();//调查研究
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 53 Order by id desc", CommandType.Text);
            result.hangyezilv = db.FillList<NewsInfo>();//行业自律
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 51 Order by id desc", CommandType.Text);
            result.mingyoutechan = db.FillList<NewsInfo>();//名优特产
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 127 Order by id desc", CommandType.Text);
            result.rencaipeixun = db.FillList<NewsInfo>();//人才培训
            db.CreateCommand("SELECT top 6 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 239 Order by id desc", CommandType.Text);
            result.pinpaijianshe = db.FillList<NewsInfo>();//品牌建设
            db.CreateCommand("SELECT top 10 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 270 Order by id desc", CommandType.Text);
            result.wangxiaopingtai = db.FillList<NewsInfo>();//网销平台

            //新闻模块（带时间）
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 1 Order by id desc", CommandType.Text);
            result.xinwenzixun = db.FillList<NewsInfo>();//新闻资讯
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 36 Order by id desc", CommandType.Text);
            result.jingguandongtai = db.FillList<NewsInfo>();//经管动态
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 83 Order by id desc", CommandType.Text);
            result.shifansheku = db.FillList<NewsInfo>();//示范社库
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 38 Order by id desc", CommandType.Text);
            result.gongzuojianbao = db.FillList<NewsInfo>();//工作简报
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 39 Order by id desc", CommandType.Text);
            result.xiangmuguanli = db.FillList<NewsInfo>();//项目管理
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 39 Order by id desc", CommandType.Text);
            result.gedizhengce = db.FillList<NewsInfo>();//各地政策
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 46 Order by id desc", CommandType.Text);
            result.tongjibaobiao = db.FillList<NewsInfo>();//统计报表
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 47 Order by id desc", CommandType.Text);
            result.nongyekeji = db.FillList<NewsInfo>();//农业科技
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 48 Order by id desc", CommandType.Text);
            result.huiyuanfengcai = db.FillList<NewsInfo>();//会员风采
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 37 Order by id desc", CommandType.Text);
            result.difangpindao = db.FillList<NewsInfo>();//地方频道
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 50 Order by id desc", CommandType.Text);
            result.chanpinzhanhui = db.FillList<NewsInfo>();//产品展会
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 56 Order by id desc", CommandType.Text);
            result.sanpinyibiao = db.FillList<NewsInfo>();//三品一标
            db.CreateCommand("SELECT top 7 id,title,addtime,htmlpath from NewsInfo where [ntypeid] = 63 Order by id desc", CommandType.Text);
            result.zhuanjiyinzhishi = db.FillList<NewsInfo>();//转基因知识
        }
    }
}