using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Sean", 100000);

            Console.WriteLine($"Account number {account.accountNumber} was created for {account.accountOwner} with an initial balance of ${account.accountBalance}");

            account.makeWithdrawal(1000, DateTime.Now, "Buy Nintendo");
            account.makeDeposit(1000, DateTime.Now, "Got paid");

            Console.WriteLine(account.GetAccountHistory());


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
