﻿using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Machine vendingMachine = new Machine();
            List<Product> product = new List<Product>();
            bool isDone = false;
            bool startMachine = false;
            string line = "";
            string[] lineArray = new string[4];
            string directory = Environment.CurrentDirectory;
            string path = @"etc\vendingmachine.csv";
            string fullpath = Path.Combine(directory, path);
            //Below Reads the excel sheet and makes an array of products from the data read
            using (StreamReader sr = new StreamReader(fullpath))
            {
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        line = sr.ReadLine();
                        lineArray = line.Split('|');
                        product.Add(new Product(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]), lineArray[3]));
                    }

                }
            }
            //Start of the user interface
            do {
                vendingMachine.HeadingSetter();
                Console.Write("\n\n Would you like to use our machine?  (Y)es/(N)o   ");
                string userAnswer = Console.ReadLine().ToUpper();
                if (userAnswer.Contains('Y'))
                {
                    do
                    {
                        vendingMachine.HeadingSetter();
                        isDone = vendingMachine.MenuSetup();
                    } while (!isDone);
                    startMachine = true;
                } else if (userAnswer.Contains('N'))
                {
                    vendingMachine.HeadingSetter();
                    Console.WriteLine(" Thank you for coming!\n Have a great day!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The entered data was ");
                }
            } while (!startMachine);
            vendingMachine.HeadingSetter();
            Console.WriteLine("\n Thank you for coming!\n Have a great day!");
            Console.ReadKey();
            Environment.Exit(0);

            //vendingMachine.Deposit(10.00m);
            //vendingMachine.Deposit(10.00m);
            //vendingMachine.Deposit(4.00m);
            //vendingMachine.itemRemoval(ref product, "A7");
            //vendingMachine.itemRemoval(ref product, "A1");
            //vendingMachine.inventoryDisplay(product);
            //vendingMachine.GettingChange();
            Console.ReadKey();
        }
    }
}
