using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public int ProductQtyForPromo { get; set; }
        public decimal PromoAmount { get; set; }
        public bool IsActive { get; set; }
        public char SKUId { get; set; }

        public static List<Promotion> GetPromotions()
        {
            return new List<Promotion>() { 
                new Promotion{ PromotionId= 1, ProductQtyForPromo = 3, PromoAmount = 130, IsActive= true, SKUId='A' },
                new Promotion{ PromotionId= 2, ProductQtyForPromo = 2, PromoAmount = 45, IsActive= true, SKUId='B' },
                new Promotion{ PromotionId= 3, ProductQtyForPromo = 1, PromoAmount = 30, IsActive= true, SKUId='C' },
                new Promotion{ PromotionId= 4, ProductQtyForPromo = 1, PromoAmount = 30, IsActive= true, SKUId='D' },
            };
        }
    }
}
