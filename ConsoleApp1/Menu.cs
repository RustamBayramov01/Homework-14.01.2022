using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Menu
    {

        ConsoleKey key;
        BankCard bankCard;
        Bank bank;
        Client client;

        public void Menuu(BankCard[] BankCard, bool verf, int Index = 0)
        {
            Console.Clear();

            bankCard = new();
            bank = new();
            client = new();

            int selection;
            string PIN = null;

        
            if (verf == true)
            {
                while (true)
                {

                    Console.Clear();

                    Console.WriteLine("[ 1 ] Balans\n[ 2 ] Nagd Pul\n[ 3 ] Card to card\n[ 4 ] Exit");

                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.D1) bank.showCardBalance(BankCard, Index);
                    else if (key == ConsoleKey.D2)
                    {
                        try
                        {
                            bankCard.Cash(BankCard, Index);
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("You don't have enough balance !");
                            Thread.Sleep(2000);
                        }
                    }
                    else if (key == ConsoleKey.D3)
                    {
                        try
                        {
                            bankCard.CardToCard(BankCard,Index);
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("No such PAN found !");
                            Thread.Sleep(2000);
                        }
                    }

                    else if (key == ConsoleKey.D4)
                    {
                        Console.Clear();
                        Menuu(BankCard,false);
                    }

                    else
                    {
                        Console.WriteLine("\nYou made the wrong choice !");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            }
            else
            {
                int size = 2;

                Console.WriteLine("[ 1 ] Get a card\n[ 2 ] PIN\n[ 3 ] Show All Bank Card");

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    client.GetACard(BankCard);
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.Write("PIN : ");
                    PIN = Console.ReadLine();
                    bank.PIN(PIN, BankCard);
                }
                else if (key == ConsoleKey.D3)
                {
                    Console.Clear();
                    foreach (var item in BankCard)
                    { 
                        Console.WriteLine($"---------------------------------\n\nBank Name : {item.BankName}\nFull Name : {item.FullName}\nPan : {item.Pan}\nPin : {item.Pin}\nCvc : {item.Cvc}\nExpire Date : {item.ExpireDate}\nBalance : {item.Balance}\n");
                    }

                    Console.WriteLine("\nAfter 5 seconds you will go to the menu");

                    Thread.Sleep(5000);

                    Menuu(BankCard, false);
                    
                }
                else
                {
                    Console.WriteLine("\nYou made the wrong choice !");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menuu(BankCard, false);
                }
            }


        }

      



        
    }
}
