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

            


        }
    }
}
