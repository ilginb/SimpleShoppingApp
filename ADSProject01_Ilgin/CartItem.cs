using System;
namespace ADSProject01_Ilgin
{
    public class CartItem
    {
        public Product product { get; set; }
        public int quantity { get; set; }
        public CartItem next { set; get; }
        public CartItem()
        {
            next = null;
        }
        public CartItem(Product p, int q)
        {
            product = p;
            quantity = q; 
            next = null;
        }

      
    }
}
