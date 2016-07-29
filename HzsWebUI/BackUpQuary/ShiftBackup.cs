using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Quartz;
using System.Text;
using ClownFish;
using System.IO;
using Quartz.Impl;
using HzsController;
using HzsCommon;
using HzsModel.Config;

namespace HzsWebUI
{
    public class ShiftBackUp : IJob
    {
        /// <summary>
        /// 定义设置配置备份的ＸＭＬ文件
        /// </summary>
        static string xmlpath = Utils.GetXmlMapPath("BackUpPath");
        #region IJob 成员

        public void Execute(IJobExecutionContext context)
        {
            new HzsController.Admin.AjaxBackup().BackupBakQuartz((getVal().address + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak"));
        }

        #endregion

        #region XML操作+++
        /// <summary>
        /// 创建配置XML
        /// </summary>
        public static void CreateBackUpXml()
        {
            BackUpConfig st = new BackUpConfig();
            st.address = @"D:\beifen\".Trim();
            st.settime = "0 15 2 8 * ?";/*每月8号凌晨2点15分触发*/ //"0 * 10 * ?";//
            XmlHelper.XmlSerializeToFile(st, xmlpath, Encoding.UTF8);
        }

        /// <summary>
        /// 获取设置的XML参数
        /// </summary>
        /// <returns>SetBackUp</returns>
        public static BackUpConfig getVal()
        {
            BackUpConfig set = null;
            if (File.Exists(xmlpath))
                set = XmlHelper.XmlDeserializeFromFile<BackUpConfig>(xmlpath, Encoding.UTF8);
            else
            {
                CreateBackUpXml();
                set = XmlHelper.XmlDeserializeFromFile<BackUpConfig>(xmlpath, Encoding.UTF8);
            }
            return set;
        }
        #endregion

        public static void Beifen()
        {
            #region 定时调度器Quartz.NET +++

            //实例化调度器工厂
            ISchedulerFactory factory = new StdSchedulerFactory();
            //创建一个调度器
            IScheduler scheduler = factory.GetScheduler();
            //启动
            scheduler.Start();
            //创建任务
            IJobDetail job = JobBuilder.Create<ShiftBackUp>().WithIdentity("backup", "group1").Build();
            //创建任务触发器
            //复杂应用
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create().WithIdentity("backup", "group1").WithCronSchedule(getVal().settime).Build();
            //简单应用
            //Quartz.Impl.Triggers.SimpleTriggerImpl trigger = new Quartz.Impl.Triggers.SimpleTriggerImpl("backup", "group1", 10, new TimeSpan(0, 0, 5));     
            scheduler.ScheduleJob(job, trigger);
            #endregion
        }
    }

}

