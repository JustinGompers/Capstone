using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Machine : Cashdrawer
    {
        public decimal TotalSales { get; set; }
        public void HeadingSetter()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t    Welcome to Umbrella Corp's Vendo-Matic 500");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine($" Amount in the machine:  ${amountInMachine.ToString("0.00")}");
        }

        public decimal MenuSetup(List<Product> products)
        {
            bool isExiting = false;
            do
            {
                HeadingSetter();
                Console.WriteLine("\n Menu Options:\n Please enter a number for the following options");
                Console.WriteLine("\n 1.) Deposit Money\n 2.) View Inventory\n 3.) Exit Vending Machine");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        HeadingSetter();
                        try
                        {
                            Console.WriteLine("\n How much would you like to deposit?");
                            double depositAnswer = double.Parse(Console.ReadLine());
                            decimal depositAmount = (decimal)depositAnswer;
                            HeadingSetter();
                            decimal returnedDecimal = Deposit(depositAmount);
                            if (returnedDecimal != 0)
                            {
                                Console.WriteLine($"\n You deposited ${depositAmount.ToString("0.00")} into the machine!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($" ${depositAmount.ToString("0.00")} is not a valid entry.\n Press any key to return to the menu.");
                                Console.ReadKey();
                            }
                        }
                        catch
                        {
                            HeadingSetter();
                            Console.WriteLine("\n You did not have a correct input.\n Please press a key and you will be sent back to the menu ");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        DispensingProducts(products);
                        break;
                    case "3":
                        isExiting = true;
                        break;
                    case "bananahammock":
                        AdminProfile(products);
                        break;
                    default:
                        HeadingSetter();
                        Console.WriteLine("\n You did not input a correct number.\n Press any key to reset back to the menu.");
                        Console.ReadKey();
                        break;
                }
            } while (!isExiting);
            SalesRecordLog(products, TotalSales);
            return amountInMachine;
        }

        public Dictionary<string, int> GettingChange()
        {
            throw new NotImplementedException();
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
                        if (products[i].amountInMachine > 0)
                        {
                            Withdraw(products[i].productPrice, products[i].productName, products[i].productLocation);
                            products[i].amountInMachine--;
                            products[i].amountSold++;
                            TotalSales += products[i].productPrice;
                            products[i].totalAmountMoneyMade += products[i].productPrice;
                            switch (products[i].productType)
                            {
                                case "Chip":
                                    HeadingSetter();
                                    inventoryDisplay(products);
                                    Console.WriteLine($"\n You received a bag of chips!\n Crunch Crunch, Yum!");
                                    Console.ReadKey();
                                    break;
                                case "Candy":
                                    HeadingSetter();
                                    inventoryDisplay(products);
                                    Console.WriteLine($"\n You received some candy!\n Munch, Munch, Yum!");
                                    Console.ReadKey();
                                    break;
                                case "Drink":
                                    HeadingSetter();
                                    inventoryDisplay(products);
                                    Console.WriteLine($"\n You received a nice cold drink!\n Glug Glug, Yum!");
                                    Console.ReadKey();
                                    break;
                                case "Gum":
                                    HeadingSetter();
                                    inventoryDisplay(products);
                                    Console.WriteLine($"\n You received some candy!\n Munch, Munch, Yum!");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        else
                        {
                            HeadingSetter();
                            inventoryDisplay(products);
                            Console.WriteLine($"\n {products[i].productName} is Sold Out..... Sorry!");
                            Console.ReadKey();
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
            Console.WriteLine("Location    Name\t   $Price$\tAmountLeft");
            Console.WriteLine("----------------------------------------------------");
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].amountInMachine == 0)
                {
                    Console.WriteLine($"{products[i].productLocation} :\t{products[i].productName.PadRight(20)}${products[i].productPrice}\t\t'SOLD OUT'");
                }
                else
                {
                    Console.WriteLine($"{products[i].productLocation} :\t{products[i].productName.PadRight(20)}${products[i].productPrice}\t\t{products[i].amountInMachine}");
                }
            }
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
                if (answer == "Y")
                {
                    HeadingSetter();
                    inventoryDisplay(products);
                    Console.WriteLine("\n Enter the Item location of the product you want.");
                    answer = Console.ReadLine().ToUpper();
                    itemRemoval(ref products, answer);
                }
                else if (answer == "N")
                {
                    isDone = true;
                }
                else
                {
                    HeadingSetter();
                    inventoryDisplay(products);
                    Console.WriteLine("\n That is not a correct input.\n Press any key to return to the menu.");
                    Console.ReadKey();
                    isDone = true;
                }
            } while (!isDone);

        }
        public List<Product> AdminProfile(List<Product> products)
        {
            bool IsDone = false;
            do
            {
                HeadingSetter();
                Console.WriteLine("\n\n Admin Menu:");
                Console.WriteLine("-----------------------");
                Console.WriteLine(" 1.) Restock machine.\n 2.) Empty Machine.\n 3.) Change Product Price.\n 4.) Exit Admin Menu.");
                Console.Write("Enter the admin command: ");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case ("1"):
                        for (int i = 0; i < products.Count; i++)
                        {
                            products[i].amountInMachine = 5;
                        }
                        HeadingSetter();
                        inventoryDisplay(products);
                        Console.WriteLine("\n The machine has been restocked.");
                        Console.ReadKey();
                        break;
                    case ("2"):
                        for (int i = 0; i < products.Count; i++)
                        {
                            products[i].amountInMachine = 0;
                        }
                        HeadingSetter();
                        inventoryDisplay(products);
                        Console.WriteLine("\n The machine has been emptied.");
                        Console.ReadKey();
                        break;
                    case ("3"):
                        HeadingSetter();
                        inventoryDisplay(products);
                        Console.WriteLine("\n Which products price would like to change.");
                        answer = Console.ReadLine();
                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].productName.Contains(answer))
                            {
                                try
                                {
                                    HeadingSetter();
                                    inventoryDisplay(products);
                                    Console.WriteLine($" {products[i].productName} costs ${products[i].productPrice}.\n What would you like to change it to?");
                                    double changePrice = double.Parse(Console.ReadLine());
                                    products[i].productPrice = (decimal)changePrice;
                                    HeadingSetter();
                                    inventoryDisplay(products);
                                    Console.WriteLine($" {products[i].productName} price has been changed!");
                                    Console.ReadKey();
                                }
                                catch (Exception)
                                {

                                    HeadingSetter();
                                    Console.WriteLine("\n You entered an invalid price.\n You will be sent back to the admin menu.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                HeadingSetter();
                                Console.WriteLine("\n The product you entered is invalid.\n You will be sent back to the admin menu.");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case ("4"):
                        IsDone = true;
                        break;
                    default:
                        HeadingSetter();
                        Console.WriteLine("\n The admin code you entered was invalid.");
                        Console.ReadKey();
                        break;
                }
            } while (!IsDone);
            return products;
        }

    }
}
