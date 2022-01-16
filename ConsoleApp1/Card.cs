using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Card
    {
        Menu menu = new();

        public string BankName { get; set; }
        public string FullName { get; set; }
        public string Pan { get; set; }
        public string Pin { get; set; }
        public string Cvc { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Balance { get; set; }


        public Card(string bankName, string fullName, string pan, string pin, string cvc, DateTime expireDate, decimal balance)
        {
            BankName = bankName;
            FullName = fullName;
            Pan = pan;
            Pin = pin;
            Cvc = cvc;
            ExpireDate = expireDate;
            Balance = balance;
        }

        public Card() {}

        public void GetACardCreate(Client[] newClient, ref BankCard[] bankCard)
        {
            Console.Clear();

            int RandomPan, RandomPin, RandomCvc;

            string RandomPanS = "40998111", RandomPinS = "", RandomCvcS = "", FullName = " ", BankNameS = "Kapital Bank";
            DateTime ExpireDateS;
            decimal balanceS = 0;

            Random Rdn = new Random();

            int panSize = 15;
            while(panSize != 0)
            {
                if(RandomPanS.Length < 16)
                {
                    RandomPan = Rdn.Next(1, 9) + 1;
                    RandomPanS += RandomPan;

                    Console.WriteLine($"NEW PAN : {RandomPanS}");
                    Thread.Sleep(500);

                    Console.Clear();
                    panSize--;
                }

                if(RandomPanS.Length == 16 && RandomPinS.Length < 4)
                {
                    RandomPin = Rdn.Next(1, 9) + 1;
                    RandomPinS += RandomPin;

                    Console.WriteLine($"NEW PAN : {RandomPanS}");
                    Console.WriteLine($"NEW PAN : {RandomPinS}");
                    Thread.Sleep(500);
                    Console.Clear();
                    
                    panSize--;
                }

                if(RandomPinS.Length == 4 && RandomCvcS.Length < 3)
                {
                    RandomCvc = Rdn.Next(1, 9) + 1;
                    RandomCvcS += RandomCvc;

                    Console.WriteLine($"NEW PAN : {RandomPanS}");
                    Console.WriteLine($"NEW PAN : {RandomPinS}");
                    Console.WriteLine($"NEW CVC : {RandomCvcS}");
                    Thread.Sleep(500);
                    Console.Clear();

                    panSize--;
                }
            }

            DateTime year = DateTime.Now;
            ExpireDateS = year;

            foreach (var item in newClient)
            {
                balanceS = item.Salary;
                Console.WriteLine($"Name : {item.Name}\nSurname : {item.Surname}\nAge : {item.Age}");
            }

            foreach (var item in newClient) FullName = item.Name + " " + item.Surname;

            Console.WriteLine($"NEW PAN : {RandomPanS}");
            Console.WriteLine($"NEW PAN : {RandomPinS}");
            Console.WriteLine($"NEW CVC : {RandomCvcS}");
            Console.WriteLine($"EXPIRE DATE : {ExpireDateS}");
            Console.WriteLine($"BALANCE : {balanceS}");
            Thread.Sleep(1000);


            BankCard newCard = new(BankNameS, FullName, RandomPanS, RandomPinS, RandomCvcS, ExpireDateS, balanceS);

            BankCard[] newBankCards = new BankCard[bankCard.Length + 1];

            for (int i = 0; i < bankCard.Length; i++) newBankCards[i] = bankCard[i];

            newBankCards[newBankCards.Length - 1] = newCard;

            bankCard = newBankCards;
            menu.Menuu(bankCard,false);
            
        }
    }
}
