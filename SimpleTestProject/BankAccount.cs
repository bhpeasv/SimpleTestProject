using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTestProject
{
    public class BankAccount
    {
        public static readonly double DEFAULT_INTEREST_RATE = 0.01;

        public int AccNumber { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }

        public BankAccount(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Account Number must be positive");
            AccNumber = id;
            Balance = 0.0;
            InterestRate = DEFAULT_INTEREST_RATE;
        }

        public BankAccount(int id, double initialBalance) : this(id)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance must be above zero");
            this.Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0.00)
                throw new ArgumentException("Amount to deposit must be greater than zero");
            Balance += amount;
        }
    }

}
