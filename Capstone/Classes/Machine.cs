﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Machine : Cashdrawer
    {
        public void HeadingSetter()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t    Welcome to Umbrella Corp's Vendo-Matic 500");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine($"Amount in the machine:  ${amountInMachine.ToString("0.00")}");
        }
        public bool MenuSetup()
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
                            HeadingSetter();
                            Console.WriteLine($"\n You deposited! : {depositAmount.ToString("0.00")}");
                            Console.ReadKey();
                        }
                        catch
                        {
                            HeadingSetter();
                            Console.WriteLine("\n You did not have a correct input.\n Please press a key and you will be sent back to the menu ");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
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
                    Console.WriteLine($"{products[i].productLocation} : \t{products[i].productName.PadRight(20)}{products[i].productPrice}\t'SOLD OUT'");
                }
                else
                {
                    Console.WriteLine($"{products[i].productLocation} : \t{products[i].productName.PadRight(20)}\t{products[i].productPrice}\t{products[i].amountInMachine}");
                }
            }
            Console.ReadKey();
        }

    }
}
