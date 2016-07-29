using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClownFish;
using HzsModel.Config;
using HzsCommon;

namespace HzsController
{
    public class SiteConfigSqlBLL : ISiteConfig
    {
        /// <summary>
        /// 获取Cinfig内容
        /// </summary>
        /// <param name="path">webconfig中对应的名称</param>
        /// <returns></returns>
        public SiteConfig LoadConfig(string path)
        {
           return XmlHelper.XmlDeserializeFromFile<SiteConfig>(Utils.GetXmlMapPath(path), Encoding.UTF8);
        }
    }
}
