using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HzsModel.HZSModels
{
    public class NewsType
    {
        public int ntypeid { get; set; }
        public int pid { get; set; }
        public int array { get; set; }
        public string name { get; set; }
        public string intro { get; set; }
        public string editor { get; set; }
        public short isdel { get; set; }
        public DateTime addtime { get; set; }
        public short ispublic { get; set; }
        public int id { get; set; }
    }

}
