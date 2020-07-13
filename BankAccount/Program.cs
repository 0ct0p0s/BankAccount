using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var account = new BankAccount("Sean", 100000);
            account.makeDeposit(100000, DateTime.Now, "Bonus");
            account.makeWithdrawal(10000, DateTime.Now, "Investment");
            account.makeDeposit(5000, DateTime.Now, "Got paid");
            account.makeWithdrawal(1000, DateTime.Now, "Bought Nintendo");

            Console.WriteLine(account.FetchBiggestTransaction());
            */

            var everyAccount = new List<BankAccount>();

            everyAccount.Add(new BankAccount("Sean", 100000));
            Console.WriteLine($"Account number {everyAccount[0].Number} was created for {everyAccount[0].Owner} with an initial balance of ${everyAccount[0].FetchAccountBalance()}");

            everyAccount.Add(new BankAccount("Pascal", 100000));
            Console.WriteLine($"Account number {everyAccount[1].Number} was created for {everyAccount[1].Owner} with an initial balance of ${everyAccount[1].FetchAccountBalance()}");

            // Sean
            everyAccount[0].makeWithdrawal(1000, DateTime.Now, "Buy Nintendo");
            everyAccount[0].makeDeposit(50000, DateTime.Now, "Sold car");
            everyAccount[0].makeDeposit(1000, DateTime.Now, "Got paid");
            everyAccount[0].makeDeposit(150000, DateTime.Now, "Bonus");

            // Pascal
            everyAccount[1].makeWithdrawal(2000, DateTime.Now, "Buy Nintendo");
            everyAccount[1].makeDeposit(60000, DateTime.Now, "Sold car");
            everyAccount[1].makeDeposit(2000, DateTime.Now, "Got paid");
            everyAccount[1].makeDeposit(140000, DateTime.Now, "Bonus");

            Console.WriteLine(everyAccount[0].FetchAccountHistory());
            Console.WriteLine($"The largest transaction for account number {everyAccount[0].Number} is ${everyAccount[0].FetchBiggestTransaction()}");
            Console.WriteLine();

            Console.WriteLine(everyAccount[1].FetchAccountHistory());
            Console.WriteLine($"The largest transaction for account number {everyAccount[0].Number} is ${everyAccount[1].FetchBiggestTransaction()}");



            // var account2 = new BankAccount("Pascal", 100000);

            /*
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            try
            {
                account.makeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            */
        }
    }
}
