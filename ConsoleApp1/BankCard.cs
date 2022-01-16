using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BankCard 
    {
        int size;

        Menu menu = new();
      
        public string BankName { get; set; }
        public string FullName { get; set; }
        public string Pan { get; set; }
        public string Pin { get; set; }
        public string Cvc { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Balance { get; set; }


        public BankCard(string bankName, string fullName, string pan, string pin, string cvc, DateTime expireDate, decimal balance)
        {
            BankName = bankName;
            FullName = fullName;
            Pan = pan;
            Pin = pin;
            Cvc = cvc;
            ExpireDate = expireDate; 
            Balance = balance;
        }

        public BankCard() { }


        public void PIN(string pin, BankCard[] bankCards)
        {

            foreach (var item in bankCards)
            { 
                size++;

                if (item.Pin == pin)
                {
                    Console.Clear();
                    Console.WriteLine($"[ {item.FullName} ] If you don't mind, you would choose one of the following");
                    Thread.Sleep(2000);
                    menu.Menuu(bankCards,true,size);
                    break;
                }

                if(size == bankCards.Length)
                {
                    Console.WriteLine("Not Found");
                    Thread.Sleep(1000);
                    Console.Clear();
                    menu.Menuu(bankCards,false);
                    break;
                }
            }

        }


        public void Cash(BankCard[] bankCards, int id)
        {

            Console.Clear();

            ConsoleKey key;

            Console.WriteLine("[ 1 ] 10 AZN\n[ 2 ] 20 AZN\n[ 3 ] 50 AZN\n[ 4 ] 100 AZN\n[ 5 ] Other");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
            {

                if(bankCards[id - 1].Balance <= 0) throw new Exception();
                else bankCards[id - 1].Balance -= 10;

            }
            else if (key == ConsoleKey.D2)
            {
            
                if (bankCards[id - 1].Balance <= 0) throw new Exception();
                else bankCards[id - 1].Balance -= 20;
            
            }
            else if (key == ConsoleKey.D3)
            {
            
                if (bankCards[id - 1].Balance <= 0) throw new Exception();
                else bankCards[id - 1].Balance -= 50;
            
            }
            else if (key == ConsoleKey.D4)
            {
            
                if (bankCards[id - 1].Balance <= 0) throw new Exception();
                else bankCards[id - 1].Balance -= 100;
            
            }
            else if (key == ConsoleKey.D5)
            { 
                int Other;

                Console.WriteLine();
                Console.Write("Cash : ");
                
                Other = int.Parse(Console.ReadLine());

                if ((bankCards[id - 1].Balance - Other) < 0) throw new Exception();
                else bankCards[id - 1].Balance -= Other;

            }
            else
            {
                Console.WriteLine("\nYou made the wrong choice !");
                Thread.Sleep(1000);
                Console.Clear();
            }   
        }

        public void CardToCard(BankCard[] bankCards, int index)
        {
            int sizee = 0;
            string panVerf;
            string Money;

            Console.Clear();

            Console.Write("PAN : ");
            panVerf = Console.ReadLine();

            if (panVerf == bankCards[index - 1].Pan)
            {
                Console.WriteLine("\nYou cannot send money to your own Card !");
                Thread.Sleep(1000);
            }
            else
            {
                foreach (var item in bankCards)
                {
                    sizee++;

                    if (item.Pan == panVerf)
                    {
                        Console.Write("\nMoney : ");
                        Money = Console.ReadLine();

                        if((bankCards[index - 1].Balance - int.Parse(Money)) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You don't have enough balance !");
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {
                            bankCards[index - 1].Balance -= int.Parse(Money);
                            bankCards[sizee - 1].Balance += int.Parse(Money);

                            Thread.Sleep(1000);

                            break;
                        }
                    }

                    if (sizee == bankCards.Length)
                    {
                        throw new Exception();
                    }
                }
            }
        }
    }
}
