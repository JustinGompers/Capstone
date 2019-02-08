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

        public Dictionary<string, int> GettingChange()
        {
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
                sw.WriteLine($"{DateTime.UtcNow}  {actionPerformed}:  ${beforeTansaction}    ${afterTransaction}");
            }

        }

        public void SalesRecordLog()
        {
            string directory = Environment.CurrentDirectory;
            string path = @"etc\Sales_Record.txt";
            string fullpath = Path.Combine(directory, path);

            using (StreamWriter sr = new StreamWriter(fullpath, true))
            {
                
            }
        }
    }
}
