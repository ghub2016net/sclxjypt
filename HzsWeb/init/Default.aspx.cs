using System;
using System.Collections.Generic;
using ClownFish;
using System.Text;
using NewLife.Web;
using HzsModel.Models;
using HzsModel.Config;
using XCode;
using HzsCommon;
using System.IO;
using System.Data.SqlClient;
using HzsController;
using System.Xml.Serialization;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading;
public partial class init_Default : MyMVC.MyBasePage
{
    protected internal SiteConfig siteConfig;

    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);
        Stopwatch st = Stopwatch.StartNew();
        siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
        if (siteConfig == null)
        {
            DataCache.Insert(HzsKey.CACHE_SITE_CONFIG, BllFactory.GetISiteConfigBLL().LoadConfig("Configpath"), Utils.GetXmlMapPath("Configpath"));
            siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
        }
        st.Stop();
        Response.Write("预加载时间："+st.ElapsedMilliseconds+"毫秒。<br>");

    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        #region 检测组织单位，生成AreaJS+++
        Stopwatch st1 = Stopwatch.StartNew();
        EntityList<HzsArea> hlist = HzsArea.FindAll();
        st1.Stop();
        Response.Write("数据库耗时：" + st1.ElapsedMilliseconds + "毫秒.<br>");
        if (hlist.Count > 0) { sb.Append("组织单位已存在。<br>"); }//BtnArea.Visible = false;
        else
        {
            string xml = Utils.GetMapPath("~/xmlconfig/area.xml");
            ArrayOfHzsArea ah = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsArea>(xml, Encoding.UTF8);
            Stopwatch s = Stopwatch.StartNew();
            SqlBulkCopy bulk = new SqlBulkCopy(ConKey.SqlConfigValue(siteConfig.dbname));
            bulk.DestinationTableName = "HzsArea";
            DataTable dt = ToDataTable(ah.HzsArea);
            try
            {
                bulk.WriteToServer(dt);
            }
            catch (Exception ec)
            {
                sb.Append("<span style='color:red;'>" + ec.ToString() + "</span><br>");
            }
            finally
            {
                bulk.Close();
                s.Stop();
                sb.Append("<span style='color:green;'>添加组织单位" + ah.HzsArea.Count + "条，用时：" + s.ElapsedMilliseconds + "毫秒。</span><br>");
            }
        }

        AreaJs();
        #endregion

        #region 检测供求类型，生成tradejs.js+++
        EntityList<TradeSort> tlist = TradeSort.FindAll();
        if (tlist.Count > 0) { sb.Append("供求类型已存在。<br>"); }//BtnTradeSort.Visible = false;
        else
        {
            string xml = Utils.GetMapPath("~/xmlconfig/tradesort.xml");
            ArrayOfTradeSort ah = XmlHelper.XmlDeserializeFromFile<ArrayOfTradeSort>(xml, Encoding.UTF8);
            Stopwatch s2 = Stopwatch.StartNew();
            SqlBulkCopy bulk2 = new SqlBulkCopy(ConKey.SqlConfigValue(siteConfig.dbname));
            bulk2.DestinationTableName = "TradeSort";
            DataTable dtTradeSort = ToDataTable(ah.TradeSort);
            try
            {
                bulk2.WriteToServer(dtTradeSort);
            }
            catch (Exception ec)
            {
                sb.Append("<span style='color:red;'>" + ec.ToString() + "</span><br>");
            }
            finally
            {
                bulk2.Close();
                s2.Stop();
                sb.Append("<span style='color:green;'>添加供求类型" + ah.TradeSort.Count + "条，用时：" + s2.ElapsedMilliseconds + "毫秒。</span><br>");
            }
        }
        TradeJs();
        #endregion

        #region 检测供求类型，生成newsjs.js+++
        EntityList<NewsType> nlist = NewsType.FindAll();
        if (nlist.Count > 0) { sb.Append("供求类型已存在。<br>"); }//BtnNewsType.Visible = false;
        else
        {
            string xml = Utils.GetMapPath("~/xmlconfig/newstype.xml");
            ArrayOfNewsType ah = XmlHelper.XmlDeserializeFromFile<ArrayOfNewsType>(xml, Encoding.UTF8);
            Stopwatch s3 = Stopwatch.StartNew();
            SqlBulkCopy bulk3 = new SqlBulkCopy(ConKey.SqlConfigValue(siteConfig.dbname));
            bulk3.DestinationTableName = "NewsType";
            DataTable dtNewsType = ToDataTable(ah.NewsType);
            try
            {
                bulk3.WriteToServer(dtNewsType);
            }
            catch (Exception ec)
            {
                sb.Append("<span style='color:red;'>" + ec.ToString() + "</span><br>");
            }
            finally
            {
                bulk3.Close();
                s3.Stop();
                sb.Append("<span style='color:green;'>添加新闻类型" + ah.NewsType.Count + "条，用时：" + s3.ElapsedMilliseconds + "毫秒。</span><br>");
            }
        }
        NewsJs();
        #endregion

        #region 检测合作社类型，生成hzsclassjs.js+++
        EntityList<HzsClass> clist = HzsClass.FindAll();
        if (clist.Count > 0) { sb.Append("合作社类型已存在。<br>"); }//BtnHzsClass.Visible = false;
        else
        {
            string xml = Utils.GetMapPath("~/xmlconfig/hzsclass.xml");
            ArrayOfHzsClass ah = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsClass>(xml, Encoding.UTF8);
            Stopwatch s30 = Stopwatch.StartNew();
            SqlBulkCopy bulk30 = new SqlBulkCopy(ConKey.SqlConfigValue(siteConfig.dbname));
            bulk30.DestinationTableName = "HzsClass";
            DataTable dtHzsClass = ToDataTable(ah.HzsClass);
            try
            {
                bulk30.WriteToServer(dtHzsClass);
            }
            catch (Exception ec)
            {
                sb.Append("<span style='color:red;'>" + ec.ToString() + "</span><br>");
            }
            finally
            {
                bulk30.Close();
                s30.Stop();
                sb.Append("<span style='color:green;'>添加合作社类型" + ah.HzsClass.Count + "条，用时：" + s30.ElapsedMilliseconds + "毫秒。</span><br>");
            }
        }
        HzsClassJs();
        #endregion 

        #region 生成地区类型XML文件+++
        //Stopwatch s4 = Stopwatch.StartNew();
        
        //try
        //{
        //    Thread nthread = new Thread(PlacesTypeXML);
        //    nthread.Name = "PlacesTypeXML";
        //    nthread.Start();
        //}
        //catch (Exception ed)
        //{
        //    sb.Append("<span style='color:red;'>" + ed.Message.ToString() + "<br>placestype.xml 地方类型文件生成失败！</span><br>");
        //}
        //s4.Stop();
        //sb.Append("<span style='color:green;'>placestype.xml 地方类型文件生成成功。用时：" + s4.ElapsedMilliseconds + "毫秒。</span><br>");
        #endregion

        #region 生成合作社会员类型XML文件+++
        //Stopwatch s5 = Stopwatch.StartNew();
        //try
        //{
        //    Thread nthread2 = new Thread(HzsUserTypeXML);
        //    nthread2.Name = "HzsUserTypeXML";
        //    nthread2.Start();
        //}
        //catch (Exception ed)
        //{
        //    sb.Append("<span style='color:red;'>" + ed.Message.ToString() + "<br>hzsusertype.xml 地方类型文件生成失败！</span><br>");
        //}
        //s5.Stop();
        //sb.Append("<span style='color:green;'>hzsusertype.xml 地方类型文件生成成功。用时：" + s5.ElapsedMilliseconds + "毫秒。</span><br>");
        #endregion

        #region 生成合作社会员示范社级别类型XML文件+++
        //Stopwatch s6 = Stopwatch.StartNew();
        //try
        //{
        //    Thread nthread3 = new Thread(HzsUserSfsjbXML);
        //    nthread3.Name = "HzsUserSfsjbXML";
        //    nthread3.Start();
        //}
        //catch (Exception es)
        //{
        //    sb.Append("<span style='color:red;'>" + es.Message.ToString() + "<br>hzsusersfsjb.xml 地方类型文件生成失败！</span><br>");
        //}
        //s6.Stop();
        //sb.Append("<span style='color:green;'>hzsusersfsjb.xml 地方类型文件生成成功。用时：" + s6.ElapsedMilliseconds + "毫秒。</span><br>");
        #endregion

        #region 生成经营模式Xml文件++++++
        //Stopwatch s7 = Stopwatch.StartNew();
        //try
        //{
        //    Thread nthread4 = new Thread(HzsUserJymsXML);
        //    nthread4.Name = "HzsUserJymsXML";
        //    nthread4.Start();
        //}
        //catch (Exception es)
        //{
        //    sb.Append("<span style='color:red;'>" + es.Message.ToString() + "<br>hzsuserjyms.xml 地方类型文件生成失败！</span><br>");
        //}
        //s7.Stop();
        //sb.Append("<span style='color:green;'>hzsuserjyms.xml 地方类型文件生成成功。用时：" + s7.ElapsedMilliseconds + "毫秒。</span><br>");
        #endregion

        #region 生成合作社单独页面（企业页面）新闻类型Xml文件++++++
        Stopwatch s8 = Stopwatch.StartNew();
        try
        {
            Thread nthread5 = new Thread(CompanyTypeXML);
            nthread5.Name = "CompanyTypeXML";
            nthread5.Start();
        }
        catch (Exception es)
        {
            sb.Append("<span style='color:red;'>" + es.Message.ToString() + "<br>companytype.xml 企业类型文件生成失败！</span><br>");
        }
        s8.Stop();
        sb.Append("<span style='color:green;'>companytype.xml 企业类型文件生成成功。用时：" + s8.ElapsedMilliseconds + "毫秒。</span><br>");
        #endregion

        Response.Write(sb.ToString());
    }

    #region 初始化系统。。。+++
    /// <summary>
    /// 初始化系统。。。+++
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btnstart_Click(object sender, EventArgs e)
    {
        StringBuilder s = new StringBuilder();
        string xmlpath = Utils.GetXmlMapPath("Configpath");
        CreateDirectory(xmlpath.Substring(0, xmlpath.LastIndexOf(@"\")));
        #region 创建site.config文件 数据库名称修改，则在此对应修改+++
        try
        {
            SiteConfig siteConfig = new SiteConfig();
            siteConfig.ffmpeg = "/video/tool/ffmpeg.exe"; //视频转换工具地址
            siteConfig.ishtml = "false";
            siteConfig.numtongji = "false";
            siteConfig.sitename = "泸县合作社";  //合作社名称
            siteConfig.dbname = "hzsweb";//数据库名称 ，修改数据库时此处要修改
            siteConfig.systempath = HttpRuntime.AppDomainAppPath;
            siteConfig.webpath = "/";
            siteConfig.webadminpath = "sunadmin";//后台地址文件名称
            siteConfig.website = "www.chinasunsoft.net";
            siteConfig.companyname = "太阳软件有限公司";
            XmlHelper.XmlSerializeToFile(siteConfig, xmlpath, System.Text.Encoding.UTF8);
            s.Append("<span style='color:green;'>创建site.config文件成功<span><br>");
        }
        catch //(Exception ex)
        {
            s.Append("<span style='color:red;'>创建site.config文件失败<span><br>");
        }
        #endregion

        #region 创建backup.config文件 数据备份修改，则在此对应修改+++
        try
        {
            string xmlbackup = Utils.GetXmlMapPath("BackUpPath");
            BackUpConfig bakConfig = new BackUpConfig();
            bakConfig.address = @"D:\beifen\".Trim();
            bakConfig.settime = "0 15 2 8 * ?";/*每月8号凌晨2点15分触发*/ //"0 * 10 * ?";//
            XmlHelper.XmlSerializeToFile(bakConfig, xmlbackup, System.Text.Encoding.UTF8);
            s.Append("<span style='color:green;'>创建backup.config文件成功<span><br>");
        }
        catch
        {
            s.Append("<span style='color:red;'>创建backup.config文件失败<span><br>");
        }
        #endregion
        if (AdminUser.FindAll("utype", 1).Count <= 0)
        {
            AdminUser Entity = new AdminUser();
            Entity.utype = 1;
            Entity.name = "admin";
            Entity.apwd = Encryption.Encrypt("sunsoft");
            Entity.email = "xiukun@163.com";
            Entity.isdel = 0;
            int i = Entity.Save();
        }
        Response.Write(s.ToString());
    } 
    #endregion

    #region 创建文件夹、文件+++++
    public void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    public void CreateFile(string path)
    {
        if (!File.Exists(path))
            File.Create(path);
        
    } 
    #endregion

    #region 创建JS文件++++++
    /// <summary>
    /// 生成AreaJS脚本文件
    /// </summary>
    public void AreaJs()
    {
        Stopwatch s = Stopwatch.StartNew();
        EntityList<HzsArea> olist = HzsArea.FindAll();
        StringBuilder str = new StringBuilder();
        str.Append(@"var arrarea = new Array();
");
        str.Append(@"function org(pid,oid,oname) {this.pid = pid;this.oid = oid;this.oname = oname;}");
        str.Append(@"arrarea = new Array(" + olist.Count + @");
");
        for (int i = 0; i < olist.Count; i++)
        {
            str.Append(@"arrarea[" + i + "]=new org('" + olist[i].fid + "','" + olist[i].areaid + "','" + olist[i].sortarea + @"');");
        }

        string jsurl = Server.MapPath("~/js/");
        CreateDirectory(jsurl);
        jsurl = jsurl + "areajs.js";
        StreamWriter sw = new StreamWriter(jsurl, false, Encoding.UTF8);
        sw.WriteLine(str.ToString());
        sw.Flush();
        sw.Close();
        s.Stop();
        //str.Clear();
        str = new StringBuilder();
        if (File.Exists(jsurl))
        {
            str.Append("<span style='color:green;'>成功创建areajs.js. 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }
        else
        {
            str.Append("<span style='color:red;'>创建areajs.js失败，请检查是否源码错误或文件无写入权限！ 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }

        Response.Write(str.ToString());
    }

    /// <summary>
    /// 生成TradeJs脚本文件
    /// </summary>
    public void TradeJs()
    {
        Stopwatch s = Stopwatch.StartNew();
        EntityList<TradeSort> olist = TradeSort.FindAll();
        StringBuilder str = new StringBuilder();
        str.Append(@"var arrtrade = new Array();
");
        str.Append(@"function tsort(pid,tid,tname) {this.pid = pid;this.tid = tid;this.tname = tname;}");
        str.Append(@"arrtrade = new Array(" + olist.Count + @");
");
        for (int i = 0; i < olist.Count; i++)
        {
            str.Append(@"arrtrade[" + i + "]=new tsort('" + olist[i].pid + "','" + olist[i].tid + "','" + olist[i].sname + @"');");
        }

        string jsurl = Server.MapPath("~/js/");
        CreateDirectory(jsurl);
        jsurl = jsurl + "tradejs.js";
        StreamWriter sw = new StreamWriter(jsurl, false, Encoding.UTF8);
        sw.WriteLine(str.ToString());
        sw.Flush();
        sw.Close();
        s.Stop();
        //str.Clear();
        str = new StringBuilder();
        if (File.Exists(jsurl))
        {
            str.Append("<span style='color:green;'>成功创建tradejs.js. 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }
        else
        {
            str.Append("<span style='color:red;'>创建tradejs.js失败，请检查是否源码错误或文件无写入权限！ 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }

        Response.Write(str.ToString());
    }

    /// <summary>
    /// 生成NewsJs脚本文件
    /// </summary>
    public void NewsJs()
    {
        Stopwatch s = Stopwatch.StartNew();
        EntityList<NewsType> olist = NewsType.FindAll();
        StringBuilder str = new StringBuilder();
        str.Append(@"var arrnew = new Array();
");
        str.Append(@"function nsort(pid,nid,nname) {this.pid = pid;this.nid = nid;this.nname = nname;}");
        str.Append(@"arrnew = new Array(" + olist.Count + @");
");
        for (int i = 0; i < olist.Count; i++)
        {
            str.Append(@"arrnew[" + i + "]=new nsort('" + olist[i].pid + "','" + olist[i].ntypeid + "','" + olist[i].name + @"');");
        }

        string jsurl = Server.MapPath("~/js/");
        CreateDirectory(jsurl);
        jsurl = jsurl + "newsjs.js";
        StreamWriter sw = new StreamWriter(jsurl, false, Encoding.UTF8);
        sw.WriteLine(str.ToString());
        sw.Flush();
        sw.Close();
        s.Stop();
        //str.Clear();
        str = new StringBuilder();
        if (File.Exists(jsurl))
        {
            str.Append("<span style='color:green;'>成功创建newsjs.js. 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }
        else
        {
            str.Append("<span style='color:red;'>创建newsjs.js失败，请检查是否源码错误或文件无写入权限！ 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }

        Response.Write(str.ToString());
    }

    /// <summary>
    /// 生成HzsClassJs脚本文件
    /// </summary>
    public void HzsClassJs()
    {
        Stopwatch s = Stopwatch.StartNew();
        EntityList<HzsClass> olist = HzsClass.FindAll();
        StringBuilder str = new StringBuilder();
        str.Append(@"var arrclass = new Array();
");
        str.Append(@"function hsort(pid,hid,cname) {this.pid = pid;this.hid = hid;this.cname = cname;}");
        str.Append(@"arrclass = new Array(" + olist.Count + @");
");
        for (int i = 0; i < olist.Count; i++)
        {
            str.Append(@"arrclass[" + i + "]=new hsort('" + olist[i].pid + "','" + olist[i].hid + "','" + olist[i].cname + @"');");
        }
        string jsurl = Server.MapPath("~/js/");
        CreateDirectory(jsurl);
        jsurl = jsurl + "hzsclassjs.js";
        StreamWriter sw = new StreamWriter(jsurl, false, Encoding.UTF8);
        sw.WriteLine(str.ToString());
        sw.Flush();
        sw.Close();
        s.Stop();
        //str.Clear();
        str = new StringBuilder();
        if (File.Exists(jsurl))
        {
            str.Append("<span style='color:green;'>成功创建hzsclassjs.js. 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }
        else
        {
            str.Append("<span style='color:red;'>创建hzsclassjs.js失败，请检查是否源码错误或文件无写入权限！ 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
        }

        Response.Write(str.ToString());
    }
    #endregion

    #region 无用+++++
    //public void NewsJson()
    //{
    //    Stopwatch s = Stopwatch.StartNew();
    //    EntityList<NewsType> olist = NewsType.FindAll();
    //    StringBuilder str = new StringBuilder();
    //    str.Append(@"var  NewsTypeNodes =");
    //    String Josnurl = Server.MapPath("~/js/");
    //    CreateDirectory(Josnurl);
    //    Josnurl = Josnurl + "newsjosn.js";
    //    StreamWriter sw = new StreamWriter(Josnurl, false, Encoding.UTF8);
    //    sw.WriteLine(str.ToString() + GetNewsTypeByPId(0));
    //    sw.Flush();
    //    sw.Close();
    //    s.Stop();
    //    str.Clear();
    //    if (File.Exists(Josnurl))
    //    {
    //        str.Append("<span style='color:green;'>成功创建newsjosn.js. 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
    //    }
    //    else
    //    {
    //        str.Append("<span style='color:red;'>创建newsjosn.js失败，请检查是否源码错误或文件无写入权限！ 用时：" + s.ElapsedMilliseconds + "毫秒</span><br>");
    //    }

    //    Response.Write(str.ToString());
    //} 
    #endregion

    #region 创建类型XML Thread... +++
    /// <summary>
    /// 写入地方类型placestype.xml
    /// </summary>
    public void PlacesTypeXML()
    {
        List<HzsModel.HZSModels.PlacesType> placestypelist = new List<HzsModel.HZSModels.PlacesType>();
        placestypelist.Add(new HzsModel.HZSModels.PlacesType() { id = 1, value = "信息新闻" });
        placestypelist.Add(new HzsModel.HZSModels.PlacesType() { id = 2, value = "图片新闻" });
        placestypelist.Add(new HzsModel.HZSModels.PlacesType() { id = 3, value = "农优特产" });
        placestypelist.Add(new HzsModel.HZSModels.PlacesType() { id = 4, value = "合作社风采" });
        string pxml = Utils.GetMapPath(@"xmlconfig\placestype.xml");
        object a = new object();
        XmlHelper.XmlSerializeToFile(placestypelist, pxml, System.Text.Encoding.UTF8);//写入xml文件
    }
    /// <summary>
    /// 写入合作社类型hzsusertype.xml
    /// </summary>
    public void HzsUserTypeXML()
    {
        List<HzsModel.HZSModels.HzsUserType> usertypelist = new List<HzsModel.HZSModels.HzsUserType>();
        usertypelist.Add(new HzsModel.HZSModels.HzsUserType() { id = 1, tname = "非会员单位" });
        usertypelist.Add(new HzsModel.HZSModels.HzsUserType() { id = 2, tname = "会员单位" });
        usertypelist.Add(new HzsModel.HZSModels.HzsUserType() { id = 3, tname = "理事单位" });
        usertypelist.Add(new HzsModel.HZSModels.HzsUserType() { id = 4, tname = "副会长单位" });
        string txml = Utils.GetMapPath(@"xmlconfig\hzsusertype.xml");
        XmlHelper.XmlSerializeToFile(usertypelist, txml, System.Text.Encoding.UTF8);//写入xml文件
    }
    /// <summary>
    /// 写入示范社等级hzsusersfsjb.xml
    /// </summary>
    public void HzsUserSfsjbXML()
    {
        List<HzsModel.HZSModels.HzsUserSfsjb> sfslist = new List<HzsModel.HZSModels.HzsUserSfsjb>();
        sfslist.Add(new HzsModel.HZSModels.HzsUserSfsjb() { id = 1, gname = "国家级示范社" });
        sfslist.Add(new HzsModel.HZSModels.HzsUserSfsjb() { id = 2, gname = "省级示范社" });
        sfslist.Add(new HzsModel.HZSModels.HzsUserSfsjb() { id = 3, gname = "市级示范社" });
        sfslist.Add(new HzsModel.HZSModels.HzsUserSfsjb() { id = 4, gname = "县级示范社" });
        sfslist.Add(new HzsModel.HZSModels.HzsUserSfsjb() { id = 5, gname = "非示范社" });
        string sfsxml = Utils.GetMapPath(@"xmlconfig\hzsusersfsjb.xml");
        object a = new object();
        XmlHelper.XmlSerializeToFile(sfslist, sfsxml, Encoding.UTF8);//写入信息
    }
    /// <summary>
    /// 写入经营模式hzsuserjyms.xml 
    /// </summary>
    public void HzsUserJymsXML()
    {
        List<HzsModel.HZSModels.HzsUserJyms> jlist = new List<HzsModel.HZSModels.HzsUserJyms>();
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 1, jname = "工业生产型" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 2, jname = "农业生产型" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 3, jname = "商业贸易型" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 4, jname = "政府或其他机构" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 5, jname = "综合" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 6, jname = "农产品加工型" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 7, jname = "土地流转型" });
        jlist.Add(new HzsModel.HZSModels.HzsUserJyms() { id = 8, jname = "其他" });
        string jxml = Utils.GetMapPath(@"xmlconfig\hzsuserjyms.xml");
        object a = new object();
        XmlHelper.XmlSerializeToFile(jlist, jxml, Encoding.UTF8);//写入信息
    }
    /// <summary>
    /// 写入合作社单独页面（企业页面）新闻类型companytype.xml 
    /// </summary>
    public void CompanyTypeXML()
    {
        List<HzsModel.HZSModels.CompanyType> clist = new List<HzsModel.HZSModels.CompanyType>();
        clist.Add(new HzsModel.HZSModels.CompanyType() { id = 1, value = "合作社介绍" });
        clist.Add(new HzsModel.HZSModels.CompanyType() { id = 2, value = "新闻中心" });
        clist.Add(new HzsModel.HZSModels.CompanyType() { id = 3, value = "产品中心" });
        clist.Add(new HzsModel.HZSModels.CompanyType() { id = 4, value = "联系我们" });

        string jxml = Utils.GetMapPath(@"xmlconfig\companytype.xml");
        object a = new object();
        XmlHelper.XmlSerializeToFile(clist, jxml, Encoding.UTF8);//写入信息
    }
    #endregion
    

    /// <summary>
    /// ListToDataTable
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static DataTable ToDataTable(IList list)
    {
        DataTable result = new DataTable();
        if (list.Count > 0)
        {
            PropertyInfo[] propertys = list[0].GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                result.Columns.Add(pi.Name, pi.PropertyType);
            }

            for (int i = 0; i < list.Count; i++)
            {
                ArrayList tempList = new ArrayList();
                foreach (PropertyInfo pi in propertys)
                {
                    object obj = pi.GetValue(list[i], null);
                    tempList.Add(obj);
                }
                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }
        }
        return result;
    }

    /// <summary>
    /// 更改Init文件夹名称
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnDeleteInit_Click(object sender, EventArgs e)
    {
        String path =Utils.GetMapPath("~/init");
        Random r = new Random(new Guid().GetHashCode());
        String newpath = Utils.GetMapPath("~/init"+r.Next());
        if (Directory.Exists(path))
            Directory.Move(path, newpath);
        else
            Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/");
        Response.Redirect("~/" + siteConfig.webpath + siteConfig.webadminpath + "/");
    }

    /// <summary>
    /// 组织单位表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnArea_Click(object sender, EventArgs e)
    {
        EntityList<HzsArea> hlist = HzsArea.FindAll();
        if (hlist.Count > 0)
        {
            string xml = Utils.GetMapPath("~/xmlconfig/area.xml");
            CreateDirectory(xml.Substring(0, xml.LastIndexOf(@"\")));
            XmlHelper.XmlSerializeToFile(hlist, xml, System.Text.Encoding.UTF8);
            Response.Write("area.xml数据已存在。");
        }

    }
    /// <summary>
    /// 供求类型表XML文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnTradeSort_Click(object sender, EventArgs e)
    {
        EntityList<TradeSort> tlist = TradeSort.FindAll();
        if (tlist.Count > 0)
        {
            string xml = Utils.GetMapPath("~/xmlconfig/tradesort.xml");
            //CreateDirectory(xml.Substring(0, xml.LastIndexOf(@"\")));
            try
            {
                XmlHelper.XmlSerializeToFile(tlist, xml, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:red;'>" + ex.Message.ToString() + "<br>tradesort.xml生成失败！</span><br>");
            }
            Response.Write("<span style='color:green;'>tradesort.xml生成成功。</span><br>");
        }
    }


    /// <summary>
    /// 新闻类型表XML文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnNewsType_Click(object sender, EventArgs e)
    {
        EntityList<NewsType> nlist = NewsType.FindAll();
        if (nlist.Count > 0)
        {
            string xml = Utils.GetMapPath("~/xmlconfig/newstype.xml");
            //CreateDirectory(xml.Substring(0, xml.LastIndexOf(@"\")));
            try
            {
                XmlHelper.XmlSerializeToFile(nlist, xml, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:red;'>" + ex.Message.ToString() + "<br>newstype.xml生成失败！</span><br>");
            }
            Response.Write("<span style='color:green;'>newstype.xml生成成功。</span><br>");
        }
    }
    /// <summary>
    /// 生成合作社类型XML
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnHzsClass_Click(object sender, EventArgs e)
    {
        EntityList<HzsClass> clist = HzsClass.FindAll();
        if (clist.Count > 0)
        {
            string xml = Utils.GetMapPath("~/xmlconfig/hzsclass.xml");
            //CreateDirectory(xml.Substring(0, xml.LastIndexOf(@"\")));
            try
            {
                XmlHelper.XmlSerializeToFile(clist, xml, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:red;'>" + ex.Message.ToString() + "<br>hzsclass.xml生成失败！</span><br>");
            }
            Response.Write("<span style='color:green;'>hzsclass.xml生成成功。</span><br>");
        }
    }
}
