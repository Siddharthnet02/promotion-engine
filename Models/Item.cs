using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Item
    {
        public decimal GetItemAmount(int quantity, char sku, bool isCombo)
        {
            Promotion pro = Promotion.GetPromotions().Where(i => i.SKUId.Equals(sku)).SingleOrDefault();
            Promotion promotion = Promotion.GetPromotions().Where(p => p.PromotionId == pro.PromotionId).SingleOrDefault();

            StockProduct product = StockProduct.GetProducts().Where(p=> p.SKUId.Equals(sku)).SingleOrDefault();
            
            decimal value = 0.0M;
            if (quantity >= promotion.ProductQtyForPromo)
            {
                if (quantity % promotion.ProductQtyForPromo == 0)
                {
                    if (!isCombo)
                    {
                        value = quantity * product.PricePerUnit;
                    }
                    else 
                    {
                        value = (quantity / promotion.ProductQtyForPromo) * promotion.PromoAmount;
                    }
                }
                else
                {
                    int noPromoProductQty = quantity - ((quantity / promotion.ProductQtyForPromo) * promotion.ProductQtyForPromo);
                    value = noPromoProductQty * product.PricePerUnit;
                    value = value + (quantity / promotion.ProductQtyForPromo) * promotion.PromoAmount;
                }
            }
            else
            {
                value = quantity * product.PricePerUnit;
            }

            return value;
        }
    }
}
