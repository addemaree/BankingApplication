using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankingApp.Models;

namespace BankAppTests
{
    [TestClass]
    public class BankingAppTests
    {
        [TestMethod]
        public void DepositTransaction_DepositAmount_ReturnNewAmountValue()
        {
            // Arrange
            var depositAmount = 200.00M;
            var account = new Account{ Balance = 500M };
            var transaction = new Transaction();

            // Act
            var expected = 700.00M;
            var result = transaction.Deposit(account, depositAmount);
            
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithdrawTransaction_WithdrawAmount_ReturnNewAmountValue()
        {
            // Arrange
            var withdrawAmount = 200.00M;
            var account = new Account{ Balance = 500M };
            var transaction = new Transaction();

            // Act
            var expected = 300.00M;
            var result = transaction.Withdraw(account, null, withdrawAmount);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithdrawTransaction_WithdrawAmountExceedsLimit_ThrowOutOfRangeException()
        {
            // Arrange
            var withdrawAmount = 600.00M;
            var account = new Account{ Balance = 1000M };
            var transaction = new Transaction();
            var investmentAccount = new InvestmentAccount
            {
                AccountType = InvestmentAccount.InvestmentAccountType.Individual.ToString()
            };

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => transaction.Withdraw(account, investmentAccount, withdrawAmount));
        }

        [TestMethod]
        public void TransferTransaction_TransferFundsFromOneAccountToTheOther_ReturnSuccessMessage()
        {
            // Arrange
            var accountFrom = new Account { Balance = 450M };
            var accountTo = new Account {Balance = 300M};
            var transaction = new Transaction();
            var transferAmount = 50M;

            // Act
            const string expected = "Funds were successfully transferred. $50 was transferred. Transferring account balance now is $400, while receiving balance is $350";
            var result = transaction.TransferFunds(accountFrom, accountTo, transferAmount);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
