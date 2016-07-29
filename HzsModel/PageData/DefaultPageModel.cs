using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HzsModel.Models;

namespace HzsModel
{
    public class DefaultPageModel
    {
        /// <summary>
        /// 首页轮播图片
        /// </summary>
        public List<NewsInfo> lunbotupian { get; set; }
        /// <summary>
        /// 通知公告
        /// </summary>
        public List<NewsInfo> tongzhigonggao { get; set; }
        /// <summary>
        /// 热点新闻
        /// </summary>
        public List<NewsInfo> redianxinwen { get; set; }
        /// <summary>
        /// 农超对接
        /// </summary>
        public List<NewsInfo> nongchaoduijie { get; set; }
        /// <summary>
        /// 质量安全
        /// </summary>
        public List<NewsInfo> zhilianganquan { get; set; }
        /// <summary>
        /// 新闻资讯
        /// </summary>
        public List<NewsInfo> xinwenzixun { get; set; }
        /// <summary>
        /// 热点图片
        /// </summary>
        public List<NewsInfo> rediantupian { get; set; }
        /// <summary>
        /// 经管动态
        /// </summary>
        public List<NewsInfo> jingguandongtai { get; set; }
        /// <summary>
        /// 示范社库
        /// </summary>
        public List<NewsInfo> shifansheku { get; set; }
        /// <summary>
        /// 工作简报
        /// </summary>
        public List<NewsInfo> gongzuojianbao { get; set; }
        /// <summary>
        /// 项目管理
        /// </summary>
        public List<NewsInfo> xiangmuguanli { get; set; }
        /// <summary>
        /// 精彩瞬间
        /// </summary>
        public List<NewsInfo> jingcaishunjian { get; set; }
        /// <summary>
        /// 农优产品
        /// </summary>
        public List<NewsInfo> nongyouchanpin { get; set; }
        /// <summary>
        /// 政策法规
        /// </summary>
        public List<NewsInfo> zhengcefagui { get; set; }
        /// <summary>
        /// 调查研究
        /// </summary>
        public List<NewsInfo> diaochayanjiu { get; set; }
        /// <summary>
        /// 行业自律
        /// </summary>
        public List<NewsInfo> hangyezilv { get; set; }
        /// <summary>
        /// 名优特产
        /// </summary>
        public List<NewsInfo> mingyoutechan { get; set; }
        /// <summary>
        /// 各地政策
        /// </summary>
        public List<NewsInfo> gedizhengce { get; set; }
        /// <summary>
        /// 统计报表
        /// </summary>
        public List<NewsInfo> tongjibaobiao { get; set; }
        /// <summary>
        /// 农业科技
        /// </summary>
        public List<NewsInfo> nongyekeji { get; set; }
        /// <summary>
        /// 会员风采
        /// </summary>
        public List<NewsInfo> huiyuanfengcai { get; set; }
        /// <summary>
        /// 地方频道
        /// </summary>
        public List<NewsInfo> difangpindao { get; set; }
        /// <summary>
        /// 产品展会
        /// </summary>
        public List<NewsInfo> chanpinzhanhui { get; set; }
        /// <summary>
        /// 三品一标
        /// </summary>
        public List<NewsInfo> sanpinyibiao { get; set; }
        /// <summary>
        /// 转基因知识
        /// </summary>
        public List<NewsInfo> zhuanjiyinzhishi { get; set; }
        /// <summary>
        /// 人才培训
        /// </summary>
        public List<NewsInfo> rencaipeixun { get; set; }
        /// <summary>
        /// 品牌建设
        /// </summary>
        public List<NewsInfo> pinpaijianshe { get; set; }
        /// <summary>
        /// 网销平台
        /// </summary>
        public List<NewsInfo> wangxiaopingtai { get; set; }

        /// <summary>
        /// 理事单位
        /// </summary>
        public List<HzsUser> lishidanwei { get; set; }
        /// <summary>
        /// 新会员公示
        /// </summary>
        public List<HzsUser> xinhuiyuangongshi { get; set; }
        /// <summary>
        /// 会员名录
        /// </summary>
        public List<HzsUser> huiyuanminglu { get; set; }

        /// <summary>
        /// 供应信息
        /// </summary>
        public List<Trade> gongyinginfo { get; set; }
        /// <summary>
        /// 需求信息
        /// </summary>
        public List<Trade> xuqiuinfo { get; set; }
        /// <summary>
        /// 合作信息
        /// </summary>
        public List<Trade> hezuoinfo { get; set; }
    }
}
