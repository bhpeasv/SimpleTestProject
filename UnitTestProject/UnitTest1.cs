using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTestProject;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBankAccount_ValidAccNumber()
        {
            int accNumber = 1;

            BankAccount acc = new BankAccount(accNumber);
            
            Assert.IsNotNull(acc);
            Assert.AreEqual(accNumber, acc.AccNumber);
            Assert.AreEqual(0.0, acc.Balance);
            Assert.AreEqual(BankAccount.DEFAULT_INTEREST_RATE, acc.InterestRate);         
        }

        [TestMethod]
        public void CreateBankAccount_InvalidAccNumber_Expect_ArgumentException()
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

        [TestMethod]
        public void CreateBankAccount_ValidInitialBalance()
        {
            double initialBalance = 1234.56;
            BankAccount acc = new BankAccount(1, initialBalance);
            Assert.AreEqual(initialBalance, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBankAccount_InvalidInitialBalance_ExceptArgumentException()
        {
            double initialBalance = -0.01;
            BankAccount acc = null;
            acc = new BankAccount(1, initialBalance);
            Assert.IsNull(acc);
        }
    }
}
