using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Machine : Cashdrawer
    {

        public void itemRemoval(ref List<Product> products, string itemwantedlocation)
        {
            bool productExists = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].productLocation == itemwantedlocation)
                {
                    productExists = true;
                    if (products[i].productPrice <= amountInMachine)
                    {
                        
                        Withraw(products[i].productPrice, products[i].productName, products[i].productLocation);
                        products[i].amountInMachine--;
                        switch (products[i].productType)
                        {
                            case "Chip":
                                Console.WriteLine($"You received a bag of chips!\nCrunch Crunch, Yum!");
                                break;
                            case "Candy":
                                Console.WriteLine($" You received some candy!\nMunch, Munch, Yum!");
                                break;
                            case "Drink":
                                Console.WriteLine($"You received a nice cold drink!\nGlug Glug, Yum!");
                                break;
                            case "Gum":
                                Console.WriteLine($" You received some candy!\nMunch, Munch, Yum!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                        Console.ReadKey();
                    }
                }
            }
            if (!productExists)
            {
                Console.WriteLine($"'{itemwantedlocation}' Does not exist.  You will be taken back to the menu.");
                Console.ReadKey();
            }
        }
        public void inventoryDisplay(List<Product> products)
        {
            Console.WriteLine("Location\tName\t$Price$\tAmountLeft");
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].amountInMachine == 0)
                {
                    Console.WriteLine($"{products[i].productLocation} : \t{products[i].productName}\t{products[i].productPrice}\t'SOLD OUT'");
                }
                else
                {
                    Console.WriteLine($"{products[i].productLocation} : \t{products[i].productName}\t{products[i].productPrice}\t{products[i].amountInMachine}");
                }
            }
            Console.ReadKey();
        }

    }
}
