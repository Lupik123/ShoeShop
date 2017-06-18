using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ShoesID { get; set; }
        public int UserID { get; set; }
    }
}
