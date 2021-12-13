using System;
namespace ADSProject01_Ilgin
{
    public class LinkedList
    {
        public CartItem first;
        public CartItem last;

        public LinkedList()
        {
        }

        //Creating a linked list with product and product quantity - Ilgin 22.06.2021
        public bool CreateList(Product p, int quant)
        {
            if (first == null)
            {
                CartItem headNode = new CartItem(p, quant);
                first = headNode;
                if (first != null)
                {
                    last = first;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                
                return false;
            }

        }

        //If there is no linked list, this method creates one or adds new item to the start of an existing LinkedList - Ilgin 22.06.2021
        public void addCartItem(Product p, int quantity)
        {
            if (first == null)
            {
                CreateList(p, quantity);
            }
            else
            {
                CartItem node = new CartItem(p, quantity);
                node.next = first;
                first = node;


            }
        }


        //Displays all items in users cart - Ilgin 24.06.2021

        public void viewCart()
        {

            CartItem node = first;
            Console.WriteLine("Shopping cart \n");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID | Name                           |  Price   |   Quantity  |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

            while (node != null)
            {
                Console.WriteLine(String.Format("{0,-2} | {1,-30} | {2,-8} | {3,-8} |", node.product.id, node.product.name, node.product.price, " x " + node.quantity));
                
                node = node.next;
               
            }
            Console.WriteLine("\n");
            //calls on get total price method to show the price of the items in the cart - Ilgin 26.06.2021
            Console.WriteLine("Your total price is: $" + getTotalPrice() + "\n");

        }

        //Deletes cart item based on id - Ilgin 26.06.2021
        public void DeleteCartItem(int value)
        {
            CartItem temp = first, prev = first;

            while (temp != null)
            {
                if (temp.product.id == value)
                    break;
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                Console.WriteLine("CartItem {0} is not found in the list", value);
            }
            else
            {
                prev.next = temp.next;
            }
        }

        //Method to clear cart -- Ilgin 22.06.2021
        public void clearCart()
        {
            CartItem node = first;
            while(first != null)
            {
                DeleteCartItem(node.product.id);
            }
        }

        //Method to update cart once the user is at checkout - Ilgin 27.06.2021
        public void changeQuantityOfCartItem(Product [] allProducts, int id, int qty)
        {
            CartItem node = first;
            if (node.product == Product.searchProductId(allProducts, id))
            {
                node.quantity = qty;
            }
            else
            {
                Console.WriteLine("Item not found in cart");
            }
        }

        //Calculates total price of the shopping cart - Ilgin 27.06.2021
        public int getTotalPrice()
        {
            CartItem node = first;
            int totalPrice = 0;
            int individualPrice = 0;
           
            while (node != null)
            {
                individualPrice = node.quantity * node.product.price;
                node = node.next;
                totalPrice += individualPrice;
            }
            return totalPrice;
        }

        //Prints all available items - Ilgin 22.06.2021
        public static void printAllItems(Product[] allProducts)
        {
            int n = allProducts.Length;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID | Name                           |  Price   |   Stock  |   Description");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < n; i++)
                Console.WriteLine(String.Format("{0,-2} | {1,-30} | {2,-8} | {3,-8} | {4,-100}", allProducts[i].id, allProducts[i].name, allProducts[i].price, allProducts[i].stock, allProducts[i].description));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

        }


        //Displays a menu for user input - - Ilgin 22.06.2021
        public static void mainMenu(Product[] allProducts)
        {

            bool isValid;
            do
            {
                Console.WriteLine("\n Welcome to My Shopping App \n");
                Console.WriteLine("To sort products in Alphabetical order type A");
                Console.WriteLine("To sort by price type P");
                Console.WriteLine("To Sort by Quantity type Q");

                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "A":
                        //Uses bubble sort to display products in alphabetical order -- Ilgin 22.06.2021
                        Console.WriteLine("Products in alphabetical order");
                        BubbleSort.bubbleSort(allProducts);
                        printAllItems(allProducts);
                        shop(allProducts);
                        isValid = true;
                        break;

                    case "P":
                        //Uses insertion sort to display prices in ascending or descending order - Ilgin 22.06.2021
                        Console.WriteLine("You've selected to sort by price. Prices from high to low (Y/N)?");
                        string x = Console.ReadLine();
                        if (x == "Y")
                        {
                            InsertionSort.insertionSortDescending(allProducts);
                            printAllItems(allProducts);
                            shop(allProducts);
                            isValid = true;

                        }
                        else
                        {
                            InsertionSort.insertionSortAscending(allProducts);
                            printAllItems(allProducts);
                            shop(allProducts);
                            isValid = true;

                        }
                        break;
                    case "Q":
                        //Uses selection sort to display all products based on quantity - Ilgin 22.06.2021
                        SelectionSort.SelectionSort1(allProducts);
                        printAllItems(allProducts);
                        shop(allProducts);
                        isValid = true;

                        break;

                    default:
                        //If user enters any other letter or number it returns to the start of the main menu - Ilgin 22.06.2021
                        Console.WriteLine("Please enter a valid letter");
                        isValid = false;
                        break;
                }
            }
            while (isValid != true);



        }

        //Method to add items into shopping cart - Ilgin 22.06.2021
        public static void shop(Product [] allProducts)
        {
            Console.WriteLine("Time to shop!");
            LinkedList shoppingCart = new LinkedList();
            int searchId;
            Product product;
            int quantity;

            //Using try catch to make sure user doesn't exceed 10 minutes when shopping - Ilgin 25.06.2021
            try
            {
                do
                {
                    //User input for id and quantity to add to the linked list "shoppingCart" - Ilgin 22.06.2021
                    Console.WriteLine("Enter item ID:");
                    searchId = int.Parse(Reader.ReadLine(5000));
                    product = Product.searchProductId(allProducts, searchId);
                    Console.WriteLine("Enter item Quantity:");
                    quantity = int.Parse(Console.ReadLine());

                    //Checks if there is enough stock - Ilgin 22.06.2021
                    if (product.stock >= quantity)
                    {
                        //If enough stock adds to shopping Cart -- Ilgin 22.06.2021
                        shoppingCart.addCartItem(product, quantity);
                        Console.WriteLine(product.name + " x " + quantity + " has been added to your cart");
                        Console.WriteLine("To proceed to checkout type C. To continue shopping hit enter");
                    }
                    else
                    {
                        Console.Write("We do not have enough stock. To keep shopping please hit enter.");

                    }

                }
                //Takes user to the update cart menu in order to purchase items - Ilgin 22.06.2021
                while (Console.ReadLine() != "C");
                Console.WriteLine("\n");
                shoppingCart.viewCart();
                shoppingCart.updateCartItems(allProducts);


            }
            catch (TimeoutException)
            {
                //Returns user to main menu if user goes over 10 minutes without shopping - Ilgin 25.06.2021
                Console.WriteLine("Sorry, your session has expired.");
                mainMenu(allProducts);
            }
        }

        //Updates stock numbers once purchase has been made - Ilgin 27.06.2021
        public Product[] updateStock(Product[] allProducts)
        {
            CartItem node = first;
            int newQuantity = 0;


            while (node != null)
            {
                foreach(Product p in allProducts)
                {
                    if (node.product.id == p.id)
                    {
                        newQuantity = p.stock - node.quantity;
                        p.stock = newQuantity;
                        return allProducts;

                    }
                   
                }
                

            }
            return allProducts;

        }

        //Menu to update cart items once user is at checkout - Ilgin 27.06.2021
        public void updateCartItems(Product [] allProducts)
        {
            bool isValid;
            do
            {
                Product product;
                int quantity;
                Console.WriteLine("1. Change the quantity of an item");
                Console.WriteLine("2. Delete item");
                Console.WriteLine("3. Purchase items");
                int update = int.Parse(Console.ReadLine());


                switch (update)
                {
                    case 1:
                        //Allows user to change the quantity of an item and returns to the update menu- Ilgin 27.06.2021
                        Console.WriteLine("Enter product ID you would like to update");
                        int id = int.Parse(Reader.ReadLine(600000));
                        product = Product.searchProductId(allProducts, id);
                        Console.WriteLine("Enter new quantity of item:");
                        quantity = int.Parse(Reader.ReadLine(600000));
                        changeQuantityOfCartItem(allProducts, id, quantity);
                        Console.WriteLine("Item has been modified");
                        viewCart();
                        updateCartItems(allProducts);
                        isValid = true;

                        break;
                    case 2:
                        //Allows user to delete items from cart - Ilgin 27.06.2021
                        Console.WriteLine("Enter product ID of item to delete");
                        int delId = int.Parse(Reader.ReadLine(600000));
                        DeleteCartItem(delId);
                        viewCart();
                        updateCartItems(allProducts);
                        isValid = true;
                        break;
                    case 3:
                        //Allows user to purchase items and returns to main menu with the updates stock numbers - Ilgin 27.06.2021
                        Console.WriteLine("Your total price is " + getTotalPrice() + "\n Are you sure you would like to purchase these items? Y/N");
                        string response = Console.ReadLine();
                        if (response == "Y")
                        {
                            Console.WriteLine("Items have been purchased. Thank you \n");
                            Product [] updated = updateStock(allProducts);
                            mainMenu(updated);
                            
                        }
                        else
                        {
                            viewCart();
                            updateCartItems(allProducts);
                        }
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        isValid = false;
                        break;

                }

            }
            while (isValid != true);
        }

    }
}
