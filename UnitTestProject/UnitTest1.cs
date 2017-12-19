using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTestProject;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBankAccount_ValidAccNumber_Test()
        {
            int accNumber = 1;

            BankAccount acc = new BankAccount(accNumber);
            
            Assert.IsNotNull(acc);
            Assert.AreEqual(accNumber, acc.AccNumber);
            Assert.AreEqual(0.0, acc.Balance);
            Assert.AreEqual(BankAccount.DEFAULT_INTEREST_RATE, acc.InterestRate);         
        }

        [TestMethod]
        public void CreateBankAccount_InvalidAccNumber_Expect_ArgumentException_Test()
        {
            int accNumber = 0;
            BankAccount acc = null;
            try
            { 
            
                acc = new BankAccount(accNumber);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsNull(acc);
            }

        }
    }
}
