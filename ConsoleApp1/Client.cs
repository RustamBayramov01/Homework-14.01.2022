using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Client
    {
        Menu menu = new();
        Card card = new();

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public decimal Salary { get; set; }

        public Client(string name, string surname, string age, decimal salary)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
        }


        public Client() { }


        public void GetACard(BankCard[] bankCards)
        {
            string intAge;
            string name, surname, age;
            decimal salary = 0;
            decimal bankcard = 0;

            Console.Clear();

            Console.Write("Name : ");
            name = Console.ReadLine();
            Console.Write("Surname : ");
            surname = Console.ReadLine();
            Console.Write("Age : ");
            age = Console.ReadLine();
            Console.Write("Salary : ");
            salary = int.Parse(Console.ReadLine());

            Client client = new(name,surname,age,salary);

            Client[] clientArr = new Client[] { client };

            intAge = client.Age;

            if(int.Parse(intAge) < 18)
            {
                Console.Clear();
                Console.WriteLine("You must be 18+ years or older");
                Thread.Sleep(1000);
                menu.Menuu(bankCards, false);
            }
            else
            {
                card.GetACardCreate(clientArr, ref bankCards);
            }

        }
    }
}
