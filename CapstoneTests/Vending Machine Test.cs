using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass()]
    public class VendingMachineTest
    {
        private Machine testObject = new Machine();
        Cashdrawer vendingMachine = new Cashdrawer();

        [TestMethod]
        public void DepositTest()
        {
            
            decimal input = 10.00m;

            decimal output = 10.00m;

            decimal result = testObject.Deposit(input);

            Assert.AreEqual(output, result);

        }
        [TestMethod]
        public void DepositWrongBillTest()
        {

            decimal input = 100.00m;

            decimal output = 0.00m;

            decimal result = testObject.Deposit(input);

            Assert.AreEqual(output, result);

        }
        [TestMethod]
        public void WithdrawalTest()
        {
            decimal productPrice = 3.05m;
            string itemDeposited = "Potato Crisps";
            string itemLocation = "A1";

            testObject.Deposit(10);
            bool output = true;

            bool result = testObject.Withdraw(productPrice, itemDeposited, itemLocation);

            Assert.AreEqual(output, result);

        }
        [TestMethod]
        public void GettingChangeTest()
        {

            decimal input = 2.46m;

            Dictionary<string, int> CoinCount = new Dictionary<string, int>
            {
                {"Quarters", 9},
                {"Dimes",  2},
                {"Nickles", 0 },
                {"Pennies", 1 }
                
            };
   
            Dictionary<string, int> result = testObject.GettingChange(input);

            CollectionAssert.AreEqual(CoinCount, result);

        }
        

    }
}
