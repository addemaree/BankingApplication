using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Account
    {
        #region Constructors

        public Account()
        {

        }

        public Account(string firstName, string lastName)
        {
            OwnerFirstName = firstName;
            OwnerLastName = lastName;
            OwnerFullName = GetFullName();
        }

        public Account(ulong accountId)
        {
            AccountId = accountId;
        }


        #endregion

        #region Enum

        public enum AccountType
        {
            Checking,
            Investment
        }

        #endregion

        // Properties
        private ulong AccountId { get; }
        private string OwnerFirstName { get; }
        private string OwnerLastName { get; }
        private string OwnerFullName { get; }

        private string GetFullName()
        {
            return $"{OwnerFirstName}, {OwnerLastName}";
        }
        public decimal Balance { get; set; }
        public string TypeOfAccount { get; set; }
    }
}
