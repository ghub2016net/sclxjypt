using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using ClownFish;
using System.Configuration;



namespace HzsWebUI
{
	public static class AppHelper
	{
        
		public static readonly int DefaultPageSize = 15; //默认每页显示数量
		public static readonly string AppName = "SunsoftHZS";

        public static void Init()
        {
            // 设置配置参数：当成功执行数据库操作后，如果有输出参数，则自动获取返回值并赋值到实体对象的对应数据成员中。
            DbContextDefaultSetting.AutoRetrieveOutputValues = true;

            //加载XmlCommand
            //string path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\XmlCommand");
            //XmlCommandManager.LoadCommnads(path);

            //注册编译失败事件，用于检查在编译实体加载器时有没有失败。
            BuildManager.OnBuildException += new BuildExceptionHandler(BuildManager_OnBuildException);

            //开始准备向ClownFishSQLProfiler发送所有的数据库访问操作日志
            Profiler.ApplicationName = "HIKYUU";
            Profiler.TryStartClownFishProfiler();

            // 注册SQLSERVER数据库连接字符串
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["hzsweb"];
            DbContext.RegisterDbConnectionInfo("sqlserver", settings.ProviderName, "@", settings.ConnectionString);

            // 启动自动编译数据实体加载器的工作模式。
            // 编译的触发条件：请求实体加载器超过2000次，或者，等待编译的类型数量超过100次
            BuildManager.StartAutoCompile(() => BuildManager.RequestCount > 2000 || BuildManager.WaitTypesCount > 100);

            // 手动提交要编译加载器的数据实体类型。
            // 说明：手动提交与自动编译不冲突，不论是同步还是异步。
            Type[] models = BuildManager.FindModelTypesFromCurrentApplication(t => t.FullName.StartsWith("HzsModel.Models."));
            BuildManager.CompileModelTypesSync(models, true);
        }


        public static void BuildManager_OnBuildException(Exception ex)
        {
            CompileException ce = ex as CompileException;
            if (ce != null)
                SafeLogException(ce.GetDetailMessages());
            else
                SafeLogException(ex.ToString());
        }

		/// <summary>
		/// 安全地记录一个异常对象到文本文件。
		/// </summary>
		/// <param name="ex"></param>
        public static void SafeLogException(string message)
		{
            try
            {
                string logfilePath = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\ErrorLog.txt");
                if (HttpContext.Current != null)
                    message = "Url: " + HttpContext.Current.Request.RawUrl + "\r\n" + message;
                File.AppendAllText(logfilePath, "=========================================\r\n" + message, System.Text.Encoding.UTF8);
            }
            catch { }
			
		}





	}
}