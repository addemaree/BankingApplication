using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Transaction : Account
    {
        #region Constructors

        public Transaction()
        {
           
        }

        public Transaction(ulong transactionId)
        {
            TransactionId = transactionId;
        }

        #endregion

        private ulong TransactionId { get; set; }

        // Methods:
        public decimal Withdraw(Account account, InvestmentAccount investmentAccount, decimal withdrawAmount)
        {
            // If there is not investment account, or the type is not Individual then there is no limit to check
            if (investmentAccount == null) return account.Balance -= withdrawAmount;
            if (investmentAccount.AccountType != InvestmentAccount.InvestmentAccountType.Individual.ToString())
                return account.Balance -= withdrawAmount;

            // check the limit and if it is over throw the exception
            if (withdrawAmount > investmentAccount.WithdrawLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(withdrawAmount), "Amount exceeds limit for this account type.");
            }

            return account.Balance -= withdrawAmount;
        }

        public decimal Deposit(Account account, decimal depositAmount)
        {
            return account.Balance += depositAmount;
        }

        public string TransferFunds(Account fromAccount, Account toAccount, decimal transferAmount)
        {
            fromAccount.Balance -= transferAmount;
            toAccount.Balance += transferAmount;

            return $"Funds were successfully transferred. ${transferAmount} was transferred. Transferring account balance now is ${fromAccount.Balance}, while receiving balance is ${toAccount.Balance}";
        }
    }
}
