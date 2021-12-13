using System;
using System.Linq;
namespace ADSProject01_Ilgin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Initializing product objects - Ilgin 22.06.2021
            Product p1 = new Product(1, "Dark Oak Table", "Iconic sculptural style, Scandinavian design", 860, 8);
            Product p2 = new Product(2, "Natural Oak Chair", "Solid Oak frame with a durable semi-gloss finish, rope cord seat and stoppers on feet.", 420, 40);
            Product p3 = new Product(3, "Macrocarpa Coffee Table", "Generous size and lightweight structure", 550, 3);
            Product p4 = new Product(4, "Palliser Side Table", "Solid oak and oak veneers and coated in a matt protective finish. ", 350, 10);
            Product p5 = new Product(5, "Palliser Side Table in Black", "Solid oak and oak veneers and coated in a matt protective finish. ", 350, 20);
            Product p6 = new Product(6, "New Yorker TV Unit", "Crafted from solid White Oak/Oak veneers and a matt black powder", 1600, 5);
            Product p7 = new Product(7, "Radius Desk in Oak", "Satin smooth and durable table top and solid oak legs.", 600, 40);
            Product p8 = new Product(8, "Radius Desk in White", "Satin smooth and durable table top and solid oak legs.", 750, 10);
            Product p9 = new Product(9, "Winston Armchair", "Soft, yet strong aniline leather and deep seating. ", 2000, 2);
           
            Product[] allProducts = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };

            //Calls on main menu to display products based on user input -Ilgin 22.06.2021
            LinkedList.mainMenu(allProducts);
          
            
        }
      




       

       

       


    }

  
}
