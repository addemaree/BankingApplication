using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Models;

namespace BankingApp
{
    public class Bank
    {
        #region Constructors

        public Bank()
        {

        }

        public Bank(ulong bankId)
        {
            BankId = bankId;
        }

        #endregion

        private ulong BankId { get; }
        public string Name { get; set; }
        private List<Account> Accounts { get; }

    }
}
