using System;
using System.Collections.Generic;
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
            if (depositAmount == 1 || depositAmount == 2 || depositAmount == 5 || depositAmount == 10)
            {
                amountInserted = depositAmount;
                amountInMachine += amountInserted;
                Console.WriteLine($"${amountInserted} : ${amountInMachine}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"${depositAmount}: There is no such bill as that. You will be returned to the menu.");
                Console.ReadKey();
            }

        }

        public void Withraw(decimal productPrice)
        {
            amountWithTransaction = amountInMachine;
            amountWithTransaction -= productPrice;
            Console.WriteLine($"{amountInMachine} : {amountWithTransaction}");
            amountInMachine -= amountWithTransaction;
        }

        public void GettingChange()
        {

        }

        public void TransactionLog(decimal beforeTansaction, decimal afterTransaction)
        {

        }
    }
}
