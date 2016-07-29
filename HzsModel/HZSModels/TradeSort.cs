using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HzsModel.HZSModels
{
    public class TradeSort
    {
        public int tid { get; set; }
        public int sortid { get; set; }
        public short depth { get; set; }
        public int array { get; set; }
        public string sname { get; set; }
        public int pid { get; set; }
        public short ispublic { get; set; }
        public int isrose { get; set; }
    }
}
