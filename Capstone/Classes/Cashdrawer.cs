using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Cashdrawer
    {
        protected decimal amountInMachine { get; private set; }
        protected decimal amountWithTransaction { get; set; }
        protected decimal amountInserted { get; set; }
        protected int quartersReturned { get; set; } = 0;
        protected int dimesReturned { get; set; } = 0;
        protected int nicklesReturned { get; set; } = 0;
        protected int penniesReturned { get; set; } = 0;

        public Cashdrawer()
        {
            amountInMachine = 0;
            amountInserted = 0;

        }

        public decimal Deposit(decimal depositAmount)
        {
            string typeOfTransaction = "USER DEPOSIT";
            if (depositAmount == 1 || depositAmount == 2 || depositAmount == 5 || depositAmount == 10)
            {
                amountInserted = depositAmount;
                amountInMachine += amountInserted;
                TransactionLog(depositAmount, amountInMachine, typeOfTransaction);
                return amountInMachine;
            }
            else
            {
                return 0;
            }
        }

        public bool Withdraw(decimal productPrice, string itemDeposited, string itemLocation)
        {
            string typeOfTransaction = itemDeposited + " " + itemLocation;
            amountWithTransaction = amountInMachine;
            amountWithTransaction -= productPrice;
            TransactionLog(amountInMachine, amountWithTransaction, typeOfTransaction);
            if (amountInMachine >= productPrice)
            {
                amountInMachine = amountWithTransaction;
                return true;
            }
            else return false;
            
        }

        public Dictionary<string, int> GettingChange(decimal totalLeftInMachine)
        {
            amountInMachine = totalLeftInMachine;
            string typeOfTransaction = "CHANGED DISPENSED";
            amountWithTransaction = amountInMachine;
            if (amountInMachine >= .25m)
            {
                quartersReturned = (int)(amountInMachine / .25m);
                amountInMachine -= (quartersReturned * .25m);
            }
            if (amountInMachine >= .10m)
            {
                dimesReturned = (int)(amountInMachine / .10m);
                amountInMachine -= (dimesReturned * .10m);
            }
            if (amountInMachine >= .05m)
            {
                nicklesReturned = (int)(amountInMachine / .05m);
                amountInMachine -= (nicklesReturned * .05m);
            }if (amountInMachine >= .01m)
            {
                penniesReturned = (int)(amountInMachine / .01m);
                amountInMachine -= (penniesReturned * .01m);
            }
            Dictionary<string, int> change = new Dictionary<string, int>
            {
                {"Quarters", quartersReturned },
                {"Dimes", dimesReturned },
                {"Nickles", nicklesReturned },
                {"Pennies", penniesReturned }
            };
            TransactionLog(amountWithTransaction, amountInMachine, typeOfTransaction);
            Console.WriteLine($"{quartersReturned} : {dimesReturned} : {nicklesReturned} : {penniesReturned}");

            return change;
        }

        public void TransactionLog(decimal beforeTansaction, decimal afterTransaction, string actionPerformed)
        {
            string directory = Environment.CurrentDirectory;
            string path = @"etc\Transaction_Record.txt";
            string fullpath = Path.Combine(directory, path);

            using (StreamWriter sw = new StreamWriter(fullpath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow}  {actionPerformed.PadRight(20)}:  ${beforeTansaction.ToString("0.00")}    ${afterTransaction.ToString("0.00")}");
            }

        }

        public void SalesRecordLog(List<Product> products, decimal totalSales)
        {
            string[] lineArray = new string[3];
            string directory = Environment.CurrentDirectory;
            string path = @"etc\Sales_Record.txt";
            string fullpath = Path.Combine(directory, path);
            string line = "";
            using (StreamReader sr = new StreamReader(fullpath))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (line.Contains('|'))
                        {
                            lineArray = line.Split('|');
                            lineArray[1] = lineArray[1].Replace('$', ' ');
                            lineArray[2] = lineArray[2].Replace('$', ' ');
                            if (lineArray[0].Contains(products[i].productName))
                            {
                                products[i].amountSold += int.Parse(lineArray[1]);
                                products[i].totalAmountMoneyMade += decimal.Parse(lineArray[2]);
                                totalSales += decimal.Parse(lineArray[2]);
                            }
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(fullpath, false))
            {
                sw.WriteLine("Name\t\t    Amount Sold\t  Total Product Sales");
                sw.WriteLine("======================================================================");
                for (int i = 0; i < products.Count; i++)
                {
                    sw.WriteLine($"{products[i].productName.PadRight(18)} |\t {products[i].amountSold}\t |\t  ${products[i].totalAmountMoneyMade}");
                }
                sw.WriteLine();
                sw.WriteLine($"**TotalSales**  ${totalSales}");
            }
        }
    }
}
