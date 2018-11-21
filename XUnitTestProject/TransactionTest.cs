using SimpleTestProject;
using Xunit;

namespace MSTestProject
{
    public class TransactionTest
    {
        [Fact]
        public void CreateTransaction()
        {
            int id = 1;
            string message = "Transaction message";
            double amount = 123.45;

            Transaction t = new Transaction(id, message, amount);

            Assert.Equal(id, t.Id);
            Assert.Equal(message, t.Message);
            Assert.Equal(amount, t.Amount);
        }
    }
}
