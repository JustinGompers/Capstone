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
            string line = "";
            string[] lineArray = new string[4];
            string directory = @"C:\Users\Justin Gompers\Pairs\c-module-1-capstone-team-3\etc\vendingmachine.csv";
            //Below Reads the excel sheet and makes an array of products from the data read
            using (StreamReader sr = new StreamReader(directory))
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
            
            do
            {

            } while (!isDone);

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
