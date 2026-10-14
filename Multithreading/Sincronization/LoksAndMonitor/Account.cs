using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoksAndMonitor
{
    public class Account
    {
        Object castomLock = new object();
        int balance;
        Random random = new Random();
        public Account(int initialBalance)
        {
            balance = initialBalance;
        }
        int Withdraw(int amount)
        {
            if(balance < 0)
            {
                throw new Exception("Not enough blanace");                
            }
            lock (castomLock)
            {
                
            //Monitor.Enter(castomLock);
            //try
            // {
                if(balance >= amount)
                {
                    Console.WriteLine($"Amount drawan: {amount}");
                    balance = balance-amount;
                    return balance;
                }
            // }
            // finally
            // {
            //     Monitor.Exit(castomLock);
            // }
            return 0;
            
            }
            
        }
        public void WitdrawRandom()
        {
            for (int i = 0; i < 100; i++)
            {                
                var balance = Withdraw(random.Next(2000, 5000));
                if(balance > 0)
                {
                    Console.WriteLine($"Balance left {balance}");                
                }else
                {
                    Console.WriteLine($"Balance left {balance}");                
                }
            }
        }
    }
}