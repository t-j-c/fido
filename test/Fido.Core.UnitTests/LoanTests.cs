using Xunit;

namespace Fido.Core.UnitTests
{
    public class LoanTests
    {
        [Fact]
        public void NewLoan_BalanceReturnsInitial()
        {
            var loan = new Loan(1000);

            Assert.Equal<uint>(1000, loan.Balance);
        }

        [Fact]
        public void Pay_WithinBalance_BalanceReturnsRemaining()
        {
            var loan = new Loan(1000);
            loan.Pay(100);

            Assert.Equal<uint>(900, loan.Balance);
        }

        [Fact]
        public void Pay_WithinBalance_MultiplePayments_BalanceReturnsRemaining()
        {
            var loan = new Loan(1000);
            loan.Pay(100);
            loan.Pay(200);

            Assert.Equal<uint>(700, loan.Balance);
        }

        [Fact]
        public void Pay_TotalBalance_BalanceReturnsZero()
        {
            var loan = new Loan(1000);
            loan.Pay(1000);

            Assert.Equal<uint>(0, loan.Balance);
        }

        [Fact]
        public void Pay_TotalBalance_MultiplePayments_BalanceReturnsZero()
        {
            var loan = new Loan(1000);
            loan.Pay(100);
            loan.Pay(200);
            loan.Pay(300);
            loan.Pay(400);

            Assert.Equal<uint>(0, loan.Balance);
        }

        [Fact]
        public void Pay_OverBalance_BalanceReturnsZero()
        {
            var loan = new Loan(1000);
            loan.Pay(1100);

            Assert.Equal<uint>(0, loan.Balance);
        }

        [Fact]
        public void Pay_OverBalance_MultiplePayments_BalanceReturnsZero()
        {
            var loan = new Loan(1000);
            loan.Pay(500);
            loan.Pay(600);

            Assert.Equal<uint>(0, loan.Balance);
        }
    }
}
