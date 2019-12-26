using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FIRMA PRZEWOZOWA - PROJEKT NA PROGRAMOWANIE OBIEKTOWE. ***JERZY DĘBOWSKI***");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Witaj! Oto symulator firmy przewozowej. Będziesz mógł/(-a) w nim zarządzać własną firmą " +
                "przewozową.\nTo Ty decydujesz o przyjmowaniu kursów,Ty ustalasz stawkę przejazdu, a za zarobione pieniądze\n" +
                "możesz ulepszać swoje pojazdy oraz zatrudniać nowych pracowników. Miłej zabawy!\n\n" +
                "Aby kontynuować naciśnij dowolny klawisz...");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Podaj nazwę swojej firmy");
            string nazwa = Console.ReadLine();
            Console.Write("Gdzie Twoja firma ma siedzibę? ");
            string siedziba = Console.ReadLine();
            Console.ReadKey();
        }
    }
    public class Firma
    {
        public string nazwa;
        public int budzet;
        public string siedziba;
        public Firma(string n, string s)
        {
            this.nazwa = n;
            this.siedziba = s;
        }
    }
    public class Miejscowosc
    {
        string nazwa;
        int odleglosc_km;
        int czas_przejazdu_h;
        public Miejscowosc(string n, int o)
        {
            this.nazwa = n;
            this.odleglosc_km = o;
            this.czas_przejazdu_h = this.odleglosc_km / 60;
        }
    }
}
