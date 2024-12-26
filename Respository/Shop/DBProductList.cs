using System.Collections.Generic;

namespace Repositories.Shop
{
    public class DBProductList
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal salePrice { get; set; }
        public decimal discount { get; set; }
        public string shortDetails { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int isNew { get; set; }
        public int isSale { get; set; }
        public string category { get; set; }
        public List<string> pictures { get; set; }
        public List<string> colors { get; set; }
        public List<string> size { get; set; }
        public List<string> tags { get; set; }
       // public List<variant> variants { get; set; }
    }

    //public class variant
    //{
    //    public string color { get; set; }
    //    public string images { get; set; }
    //}
}