using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class InvestmentAccount : Account
    {
        #region Constructors

        public InvestmentAccount()
        {

        }

        public InvestmentAccount(ulong investmentAccountId)
        {
            InvestmentAccountId = investmentAccountId;
        }
        #endregion

        #region Enum

        public enum InvestmentAccountType
        {
            Individual,
            Corporate
        }

        #endregion

        private ulong InvestmentAccountId { get; }
        public decimal WithdrawLimit = 500.00M;
        public new string AccountType { get; set; }
    }
}
