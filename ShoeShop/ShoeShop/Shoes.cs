using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop
{
    public class Shoes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public string Category { get; set; }
    }
}
