using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class StockProduct
    {
        public int ProductId { get; set; }
        public char SKUId { get; set; }
        public string StockProductName { get; set; }
        public decimal PricePerUnit { get; set; }

        public static List<StockProduct> GetProducts()
        {
            return new List<StockProduct>() { 
                new StockProduct{ ProductId=1, SKUId = 'A', StockProductName="apricot", PricePerUnit = 50},
                new StockProduct{ ProductId=2, SKUId = 'B', StockProductName="banana", PricePerUnit = 30},
                new StockProduct{ ProductId=3, SKUId = 'C', StockProductName="cherris", PricePerUnit = 20},
                new StockProduct{ ProductId=4, SKUId = 'D', StockProductName="durian", PricePerUnit = 15},
            };
        }
    }
}
