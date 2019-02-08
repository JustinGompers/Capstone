using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Machine : Cashdrawer
    {
        public bool MenuSetup(List<Product> products)
        {
            bool isExiting = false;
            do
            {
                HeadingSetter();
                Console.WriteLine("\nMenu Options:\n Please enter a number for the following options");
                Console.WriteLine("\n 1.) Deposit Money\n 2.) View Inventory\n 3.) Exit Vending Machine");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        HeadingSetter();
                        try
                        {
                            Console.WriteLine("\n How much would you like to deposit?");
                            decimal depositAmount = int.Parse(Console.ReadLine());
                            Deposit(depositAmount);
                        }
                        catch
                        {
                            HeadingSetter();
                            Console.WriteLine("\n You did not have a correct input.\n Please press a key and you will be sent back to the menu ");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        HeadingSetter();
                        inventoryDisplay(products);
                        break;
                    case "3":
                        isExiting = true;
                        break;
                    default:
                        HeadingSetter();
                        Console.WriteLine("\n You did not input a correct number.\n Press any key to reset back to the menu.");
                        Console.ReadKey();
                        break;
                }
            } while (!isExiting);
            return true;
        }
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
                        
                        Withdraw(products[i].productPrice, products[i].productName, products[i].productLocation);
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
                    Console.WriteLine($"{products[i].productLocation} : \t{products[i].productName.PadRight(20)}{products[i].productPrice}\t'SOLD OUT'");
                }
                else
                {
                    Console.WriteLine($"{products[i].productLocation} : \t{products[i].productName.PadRight(20)}\t{products[i].productPrice}\t{products[i].amountInMachine}");
                }
            }
            Console.ReadKey();
        }
        public void DispensingProducts(List<Product> products)
        {
            bool isDone = false;
            do
            {
                HeadingSetter();
                inventoryDisplay(products);
                Console.WriteLine("\n Would you like to buy a product?  (Y)es/(N)o");
                string answer = Console.ReadLine().ToUpper();
                if (answer.Contains('Y'))
                {
                    HeadingSetter();
                    inventoryDisplay(products);
                    Console.WriteLine("Enter the Item location of the product you want.");
                    answer = Console.ReadLine();
                }
                else if (answer.Contains('N'))
                {
                    isDone = true;
                }
                else
                {
                    HeadingSetter();
                    Console.WriteLine("\n That is not a correct input.\n Press any key to return to the menu.");
                    isDone = true;
                }
            } while (!isDone);

        }

    }
}
