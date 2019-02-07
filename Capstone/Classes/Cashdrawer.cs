using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Cashdrawer
    {
        protected decimal amountInMachine { get; private set; }
        protected decimal amountWithTransaction { get; set; }
        protected decimal amountInserted { get; set; }

        Cashdrawer()
        {
            amountInMachine = 0;
            amountInserted = 0;

        }

        public void Deposit(decimal depositAmount)
        {
            amountInserted = depositAmount;
            amountInMachine += amountInserted;
            Console.WriteLine($"{amountInserted} : {amountInMachine}");

        }

        public void Withraw(decimal productPrice)
        {
            amountWithTransaction = amountInMachine;
            amountWithTransaction -= productPrice;
            Console.WriteLine($"{amountInMachine} : {amountWithTransaction}");
            amountInMachine -= amountWithTransaction;
        }

        public void TransactionLog(decimal beforeTansaction, decimal afterTransaction)
        {

        }
    }
}
