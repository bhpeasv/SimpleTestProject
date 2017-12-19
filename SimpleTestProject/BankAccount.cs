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
    }

}
