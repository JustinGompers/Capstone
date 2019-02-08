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
        protected int quartersReturned { get; set; }
        protected int dimesReturned { get; set; }
        protected int nicklesReturned { get; set; }
        protected int penniesReturned { get; set; }

        public Cashdrawer()
        {
            amountInMachine = 0;
            amountInserted = 0;

        }

        public void Deposit(decimal depositAmount)
        {
            string typeOfTransaction = "USER DEPOSIT";
            if (depositAmount == 1 || depositAmount == 2 || depositAmount == 5 || depositAmount == 10)
            {
                amountInserted = depositAmount;
                amountInMachine += amountInserted;
                TransactionLog(depositAmount, amountInMachine, typeOfTransaction);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"${depositAmount}: There is no such bill as that. You will be returned to the menu.");
                Console.ReadKey();
            }

        }

        public void Withraw(decimal productPrice, string itemDeposited, string itemLocation)
        {
            string typeOfTransaction = itemDeposited + " " + itemLocation;
            amountWithTransaction = amountInMachine;
            amountWithTransaction -= productPrice;
            Console.WriteLine($"{amountInMachine} : {amountWithTransaction}");
            TransactionLog(amountInMachine, amountWithTransaction, typeOfTransaction);
            amountInMachine = amountWithTransaction;
        }

        public void GettingChange()
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
            TransactionLog(amountWithTransaction, amountInMachine, typeOfTransaction);
            Console.WriteLine($"{quartersReturned} : {dimesReturned} : {nicklesReturned} : {penniesReturned}");
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
    }
}
