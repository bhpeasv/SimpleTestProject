
using SimpleTestProject;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class BankAccountTest
    {
        [Fact]
        public void CreateBankAccount_ValidAccNumber()
        {
            int accNumber = 1;

            BankAccount acc = new BankAccount(accNumber);

            Assert.NotNull(acc);
            Assert.Equal(accNumber, acc.AccNumber);
            Assert.Equal(0.0, acc.Balance);
            Assert.Equal(BankAccount.DEFAULT_INTEREST_RATE, acc.InterestRate);
        }

        [Fact]
        public void CreateBankAccount_InvalidAccNumber_Expect_ArgumentException()
        {
            int accNumber = 0;
            BankAccount acc = null;
            try
            {

                acc = new BankAccount(accNumber);
                Assert.True(false);
            }
            catch (ArgumentException)
            {
                Assert.Null(acc);
            }
        }

        [Fact]
        public void CreateBankAccount_ValidInitialBalance()
        {
            double initialBalance = 1234.56;
            BankAccount acc = new BankAccount(1, initialBalance);
            Assert.Equal(initialBalance, acc.Balance);
        }

        [Fact]
        public void CreateBankAccount_InvalidInitialBalance_ExceptArgumentException()
        {
            double initialBalance = -0.01;
            BankAccount acc = null;
            var ex = Assert.Throws<ArgumentException>(() => acc = new BankAccount(1, initialBalance));
            Assert.True(ex.Message == "Initial balance must be above zero");
            Assert.Null(acc);
        }

        [Fact]
        public void DepositValidAmount()
        {
            double initialBalance = 123.45;
            BankAccount acc = new BankAccount(1, initialBalance);
            double amount = 0.01;
            acc.Deposit(amount);
            Assert.Equal(initialBalance + amount, acc.Balance);
        }

        [Theory]
        [InlineData(0.00)]
        [InlineData(-0.01)]
        public void DepositInvalidAmountExpectArgumentException(double amount)
        {
            double initialBalance = 123.45;
            BankAccount acc = new BankAccount(1, initialBalance);
            var ex = Assert.Throws<ArgumentException>(() => acc.Deposit(amount));
            Assert.Equal("Amount to deposit must be greater than zero", ex.Message);
        }

        [Theory]
        [InlineData(123.45, 0.01)]
        [InlineData(123.45, 123.45)]
        public void WithdrawValidAmount(double initialBalance, double amount)
        {
            BankAccount acc = new BankAccount(1, initialBalance);
            acc.Withdraw(amount);
            Assert.Equal(initialBalance - amount, acc.Balance);
        }

        [Fact]
        public void WithdrawNonPositiveAmountExpectArgumentException()
        {
            double initialBalance = 123.45;
            double amount = -0.01;
            BankAccount acc = new BankAccount(1, initialBalance);

            var ex = Assert.Throws<ArgumentException>(() => acc.Withdraw(amount));
            Assert.Equal("Amount to withdraw must be greater than zero", ex.Message);
            Assert.Equal(initialBalance, acc.Balance);
        }

        [Fact]
        public void WithdrawAmountExceedingTheBalanceExpectArgumentException()
        {
            double initialBalance = 123.45;
            double amount = initialBalance + 0.01;
            BankAccount acc = new BankAccount(1, initialBalance);

            var ex = Assert.Throws<ArgumentException>(() => acc.Withdraw(amount));
            Assert.Equal("Amount to withdraw exceeds the current balance", ex.Message);
            Assert.Equal(initialBalance, acc.Balance);
        }
    }
}
