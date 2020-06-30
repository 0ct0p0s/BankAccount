using System;

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
        public decimal accountBalance { get; set; }

        public BankAccount(string name, decimal initialBalance)
        {
            this.accountOwner = name;
            this.accountBalance = initialBalance;
        }

        public static void makeDeposit(decimal amount, DateTime date, string note)
        {

        }

        public static void makeWithdrawal(decimal amount, DateTime date, string note)
        {

        }
    }
}
