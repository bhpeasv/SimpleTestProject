using NUnit.Framework;
using SimpleTestProject;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class BankAccountTest
    {
        [Test]
        public void CreateBankAccount_ValidAccNumber()
        {
            int accNumber = 1;

            BankAccount acc = new BankAccount(accNumber);

            Assert.IsNotNull(acc);
            Assert.AreEqual(accNumber, acc.AccNumber);
            Assert.AreEqual(0.0, acc.Balance);
            Assert.AreEqual(BankAccount.DEFAULT_INTEREST_RATE, acc.InterestRate);
        }

        [Test]
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

        [Test]
        public void CreateBankAccount_ValidInitialBalance()
        {
            double initialBalance = 1234.56;
            BankAccount acc = new BankAccount(1, initialBalance);
            Assert.AreEqual(initialBalance, acc.Balance);
        }

        [Test]
        public void CreateBankAccount_InvalidInitialBalance_ExceptArgumentException()
        {
            double initialBalance = -0.01;
            BankAccount acc = null;
            var ex = Assert.Throws<ArgumentException>(() =>  acc = new BankAccount(1, initialBalance));
            Assert.That(ex.Message == "Initial balance must be above zero");
            Assert.IsNull(acc);
        }
    }
}
