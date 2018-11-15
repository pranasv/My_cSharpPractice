using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ChildProductInfo
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int QtyInParent { get; set; }
    }
}
