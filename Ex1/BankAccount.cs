using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public decimal OverdraftLimit {  get; set; }

        public BankAccount() {
            Balance = 0;
            OverdraftLimit = 0;
        }

        public BankAccount(decimal overdraftLimit)
        {
            Balance = 0;
            OverdraftLimit = overdraftLimit;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if(Balance + OverdraftLimit < amount)
            {
                Console.WriteLine("Could not withdraw. Insufficient funds.");
                return;
            }
            Balance -= amount;
        }
    }
}
