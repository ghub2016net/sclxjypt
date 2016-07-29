using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HzsModel.Config;

namespace HzsController
{
    public interface ISiteConfig
    {
        SiteConfig LoadConfig(string path);
    }
}
