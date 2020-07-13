using System;
using System.Linq; // unleashes the power of the list 
using System.Collections.Generic;
using System.Text;

/*Key Features
 * 10 digit number that is unique
 * balance can be stored with the name or names of the owners
 * The balance can be retrieved
 * It accepts deposits
 * It accepts withdrawals
 * The initial balance must be positive
 * You cannot overdraw the account
 */
// Function F2 -> you can rename any name within a class / method / etc.

/* Exercises 
 * make a function in the bank account -> display the biggest transaction 
 * in Program.cs, create two or three bank accounts
 */


namespace BankAccount
{
    public class BankAccount
    {

        //private below public when defining props. All props at the top
        public string Number { get; set; } //always first letter of a prop is capital (convention)
        public string Owner { get; set; }
        /* public decimal accountBalance { get; set; }
            get //Called a 'getter' that executes a function, think of this like a method
            {
                //put this into a function so you know where the computations are
                //props are expected to only return a value
                //create a 'UpdateBalanceFromTransaction' method instead
                return allTransactions.Sum(item => item.Amount); // => means an element of the list, and the sum function will sum what you want in the list

                // exercise, make a function in the bank account -> create the biggest transaction 
            }
        */
        private static int accountNumberSeed = 1000000001; // private = lower case in the front / public is upper case
        private List<Transaction> allTransactions = new List<Transaction>();
        //move New 'List', the initialization to the constructor 
        //list vs. array. Array there is less overhead, it is more raw
        //less automatic management in an array. Low level, less overhead, raw
        //can do more low level stuff in an array, but tougher to work with
        /* Array you have to know the length when you declare it 
         * Have to know the number of elements at the point of initialization
         * List is unlimited and dynamic 
         * Always use 'list' when you can
         * 99% of time 'Lists' 
         * Square brackets 
         */


        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            makeDeposit(initialBalance, DateTime.Now, "Initial balance");

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            //allTransactions = new List<Transaction>(); //initialize it here versus in the properties
            // ** Ask -> when initializing here versus as a prop, it gives me an error 
        }

        public decimal FetchAccountBalance() // don't use static with an object, always follow the convention of the class 
        {
            return allTransactions.Sum(item => item.Amount);
        }

        public decimal FetchBiggestTransaction()
        {
            return allTransactions.Max(item => item.Amount);
        }

        /*
        public decimal CurrencyConverter()
        {
            var cadUSD = 0.74;
            var cadEUR = 0.65;

            if ()
        }
        */

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

            if (FetchAccountBalance() - amount < 0)
            {
                throw new InvalidOperationException("Attempting to overdraw the account");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
           
        }

        public string FetchAccountHistory()
        {
            var report = new StringBuilder();

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
