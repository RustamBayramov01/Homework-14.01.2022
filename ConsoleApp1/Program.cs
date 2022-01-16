using ConsoleApp1;
using System;

Menu menu = new();

DateTime start1 = new DateTime(2023, 01, 23);
DateTime start2 = new DateTime(2025, 11, 20);
DateTime start3 = new DateTime(2024, 05, 13);
DateTime start4 = new DateTime(2026, 12, 05);
DateTime start5 = new DateTime(2028, 01, 25);


BankCard card1 = new("Kapital Bank","Rustam Bayramov", "4099811192831923", "2134","409", start1, 200);
BankCard card2 = new("Kapital Bank", "Resul Aliyarli", "4099811112909203", "4423", "851", start2, 1500);
BankCard card3 = new("Kapital Bank", "Hemid Qurbanov", "4099811189519120", "1823", "234", start3, 3200);
BankCard card4 = new("Kapital Bank", "Ismayil Gozelov", "4099811119239231", "5234", "524", start4, 1200);
BankCard card5 = new("Kapital Bank", "Murad Ceferov", "4099811112334823", "7381", "589", start5, 700);


BankCard[] cards = new BankCard[]
{
    card1,
    card2,
    card3,
    card4,
    card5,
};


menu.Menuu(cards,false);