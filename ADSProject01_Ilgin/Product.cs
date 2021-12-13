using System;
using System.Linq;

namespace ADSProject01_Ilgin
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int stock { get; set; }

        public Product(int pId, string name, string desc, int price, int stock)
        {
            this.id = pId;
            this.name = name;
            this.description = desc;
            this.price = price;
            this.stock = stock;
        }

        //Searches for product in list of products in order to add to Linked List - Ilgin 22.06.2021
        public static Product searchProductId(Product[] productList, int id)
        {

            var exProduct = productList.Where(product => product.id == id).FirstOrDefault();
            return exProduct;
        }

    }
}
