using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bank : BankCard
    {

        public Client[] clientArr { get; set; }

        public void showCardBalance(BankCard[] bankCards, int Index)
        {
            Console.Clear();
            int size = 0;

            foreach (var item in bankCards)
            {
                size++;
                if (size == Index)
                {
                    Console.WriteLine("\n-----------------------------\n");
                    Console.WriteLine($"Bank Name : {item.BankName}\nFull Name : {item.FullName}\nBalance : {item.Balance}");
                    Console.WriteLine("\n-----------------------------\n");
                }
                else continue;
            };

            Thread.Sleep(2000);
        }
    }
}
