using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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

            decimal input = 10.00m;

            decimal output = 0.00m;

            decimal result = testObject.Withdraw(input);

            Assert.AreEqual(output, result);

        }
        [TestMethod]
        public void GettingChangeTest()
        {

            decimal input = 100.00m;

            decimal output = 0.00m;

            decimal result = testObject.Deposit(input);

            Assert.AreEqual(output, result);

        }

    }
}
