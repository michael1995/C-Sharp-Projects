using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class Stock
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Decimal Price { get; set; }
        public long QtyOnHand { get; set; }
        public long QtyOnOrder { get; set; }
    }
}