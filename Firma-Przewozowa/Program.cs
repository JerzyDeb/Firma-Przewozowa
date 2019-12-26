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
    



}
