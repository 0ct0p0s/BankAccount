using System;
using System.Collections.Generic;

/*Key Features
 * 10 digit number that is unique
 * balance can be stored with the name or names of the owners
 * The balance can be retrieved
 * It accepts deposits
 * It accepts withdrawals
 * The initial balance must be positive
 * You cannot overdraw the account
 */


namespace BankAccount
{
    public class BankAccount
    {
        public string accountNumber { get; set; }
        public string accountOwner { get; set; }
        public decimal accountBalance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountNumberSeed = 1000000001;

        public BankAccount(string name, decimal initialBalance)
        {
            this.accountOwner = name;
            makeDeposit(initialBalance, DateTime.Now, "Initial balance");

            this.accountNumber = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void makeDeposit(decimal amount, DateTime date, string note)
        { 
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }

        public void makeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if (accountBalance - amount < 0)
            {
                throw new InvalidOperationException("Attempting to overdraw the account");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
           
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
