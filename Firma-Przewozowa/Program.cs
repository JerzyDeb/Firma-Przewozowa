﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    class Program
    {
        static Miejscowosc miejscowosc1 = new Miejscowosc("Gdańsk", 339);
        static Miejscowosc miejscowosc2 = new Miejscowosc("Kraków", 294);
        static Miejscowosc miejscowosc3 = new Miejscowosc("Gdynia", 439);
        static Miejscowosc miejscowosc4 = new Miejscowosc("Szczecin", 566);
        static Miejscowosc miejscowosc5 = new Miejscowosc("Opole", 336);
        static Miejscowosc miejscowosc6 = new Miejscowosc("Białystok", 214);
        static Miejscowosc miejscowosc7 = new Miejscowosc("Olsztyn", 218);
        static Miejscowosc miejscowosc8 = new Miejscowosc("Zakopane", 407);
        static Miejscowosc miejscowosc9 = new Miejscowosc("Wrocław", 354);
        static Miejscowosc miejscowosc10 = new Miejscowosc("Poznań", 310);
        //Tworzenie Kierowców: (imie, nazwisko, wiek, Premia za podpis, doświadczenie)
        static Kierowca kierowca1 = new Kierowca("Jan", "Kowalski", 40, 500, 2);
        static Kierowca kierowca2 = new Kierowca("Zbigniew", "Moczywąs", 55, 100, 10);
        static Kierowca kierowca3 = new Kierowca("Maciej", "Nowicki", 37, 50, 1);
        static Kierowca kierowca4 = new Kierowca("Jerzy", "Hubroń", 18, 10, 0);
        static Kierowca kierowca5 = new Kierowca("Tomasz", "Rączka", 22, 30, 3);
        static Kierowca kierowca6 = new Kierowca("Hubert", "Rajdowiec", 30, 75, 8);
        static Kierowca kierowca7 = new Kierowca("Zbigniew", "Towarowiec", 60, 350, 30);
        static Kierowca kierowca8 = new Kierowca("Piotr", "Kwaśnik", 41, 100, 10);
        static Kierowca kierowca9 = new Kierowca("Bartłomiej", "Zbój", 50 , 120, 15);
        static Kierowca kierowca10 = new Kierowca("Stanisław", "Lubicki", 59 , 450, 30);
        //Tworzenie sklepów i dodanie do nich pojazdów:
        static Sklep autosan = new Sklep("AUTOSAN", autosan1, autosan2);
        static Sklep scania = new Sklep("SCANIA",scania1, scania2);
        static Sklep ursus = new Sklep("URSUS BUS", ursus1, ursus2);
        static Sklep nissan = new Sklep("NISSAN", nissan1, nissan2);
        static Sklep mercedes = new Sklep("Mercedes", mercedes1, mercedes2);
        //Tworzenie pojazdów: 
        static Pojazd autosan1 = new Pojazd("Autosan H9", 1980, 20);
        static Pojazd autosan2 = new Pojazd("Autosan A10", 2000,  40);
        static Pojazd scania1 = new Pojazd("Scania Irizar", 1999, 40);
        static Pojazd scania2 = new Pojazd("Scania Omniline", 1999, 40);
        static Pojazd ursus1 = new Pojazd("Ursus Smile", 1999, 40);
        static Pojazd ursus2 = new Pojazd("Ursus Smile Plus", 1999, 40);
        static Pojazd nissan1 = new Pojazd("Nissan Clivilian", 1999, 20);
        static Pojazd nissan2 = new Pojazd("Nissan Coaster", 2010, 60);
        static Pojazd mercedes1 = new Pojazd("Mercedes Intouro", 2018, 85);
        static Pojazd mercedes2 = new Pojazd("Merceces Tourismo", 2019, 100);
        static void Main(string[] args)
        {
            //Stworzenie listy pojazdów i uzupełnienie jej:
            List<Pojazd> Lista_Pojazdow = new List<Pojazd>();
            Lista_Pojazdow.Add(autosan1); Lista_Pojazdow.Add(autosan2); Lista_Pojazdow.Add(scania1); Lista_Pojazdow.Add(scania2);
            Lista_Pojazdow.Add(ursus1); Lista_Pojazdow.Add(ursus2); Lista_Pojazdow.Add(nissan1); Lista_Pojazdow.Add(nissan2);
            Lista_Pojazdow.Add(mercedes1); Lista_Pojazdow.Add(mercedes2);
            //Stworzenie listy kierowców i uzupełnienie jej:
            List<Kierowca> Lista_Kierowcow = new List<Kierowca>();
            Lista_Kierowcow.Add(kierowca1); Lista_Kierowcow.Add(kierowca2); Lista_Kierowcow.Add(kierowca3); Lista_Kierowcow.Add(kierowca4);
            Lista_Kierowcow.Add(kierowca5); Lista_Kierowcow.Add(kierowca6); Lista_Kierowcow.Add(kierowca7); Lista_Kierowcow.Add(kierowca8);
            Lista_Kierowcow.Add(kierowca9); Lista_Kierowcow.Add(kierowca10);
            //Stworzenie listy miejscowości i uzupełnienie jej:
            List<Miejscowosc> Lista_Miejscowosci = new List<Miejscowosc>();
            Lista_Miejscowosci.Add(miejscowosc1); Lista_Miejscowosci.Add(miejscowosc2); Lista_Miejscowosci.Add(miejscowosc3); Lista_Miejscowosci.Add(miejscowosc4);
            Lista_Miejscowosci.Add(miejscowosc5); Lista_Miejscowosci.Add(miejscowosc6); Lista_Miejscowosci.Add(miejscowosc7); Lista_Miejscowosci.Add(miejscowosc8);
            Lista_Miejscowosci.Add(miejscowosc9); Lista_Miejscowosci.Add(miejscowosc10);
            //Stworzenie listy sklepów i uzupełnienie jej:
            List<Sklep> Lista_Sklepow = new List<Sklep>();
            Lista_Sklepow.Add(autosan); Lista_Sklepow.Add(scania); Lista_Sklepow.Add(ursus); Lista_Sklepow.Add(nissan);
            Lista_Sklepow.Add(mercedes);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FIRMA PRZEWOZOWA - PROJEKT NA PROGRAMOWANIE OBIEKTOWE. ***JERZY DĘBOWSKI***");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Witaj! Oto symulator firmy przewozowej. Będziesz mógł/(-a) w nim zarządzać własną firmą " +
                "przewozową.\nTo Ty decydujesz o przyjmowaniu kursów,Ty ustalasz stawkę przejazdu, a za zarobione pieniądze\n" +
                "możesz ulepszać swoje pojazdy oraz zatrudniać nowych pracowników. Miłej zabawy!\n\n" +
                "Aby kontynuować naciśnij dowolny klawisz...");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Podaj nazwę swojej firmy:  ");
            string nazwa = Console.ReadLine();
            Console.ReadKey();
            Firma Firma = new Firma(nazwa);
            Console.Write("Twoja firma nazywa się: " + Firma.nazwa + " i ma siedzibę w mieście: " + Firma.siedziba);
            Console.ReadKey();
        }
    }
    



}
