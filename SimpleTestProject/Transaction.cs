using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTestProject
{
    public class Transaction
    {
        public int Id { get; }
        public string Message { get; }
        public double Amount { get; }

        public Transaction(int id, string message, double amount)
        {
            Id = id;
            Message = message;
            Amount = amount;
        }
    }
}
