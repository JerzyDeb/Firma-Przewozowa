using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    class Menu
    {
        public string nazwa;
        public Menu(string n)
        {
            this.nazwa = n;
        }
        public void szczegoly(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            Console.Write("----SZCZEGÓŁY TWOJEJ FIRMY----\n");
            Console.Write("--------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("NAZWA: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(firma.nazwa);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nSIEDZIBA: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(firma.siedziba);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nLICZBA KIEROWCÓW  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(firma.Lista_Kierowcow_Firmy.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nLICZBA POJAZDÓW  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(firma.Lista_Pojazdow_Firmy.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nBUDŻET  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(firma.budzet);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n\n9999 -- POWRÓT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n--------------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if(wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
        }
        public void pojazdy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            int i = 1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("--------OTO TWOJE POJAZDY------ \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("--------------------------------\n");
            foreach (var item in firma.Lista_Pojazdow_Firmy)
            {
                var stan_bool = item.CzyZajety;
                var stan = "";

                if (stan_bool == true)
                    stan = "W TRASIE";
                else
                    stan = "WOLNY";
                Console.Write(i+"."+item.model + " || POJEMNOŚĆ BAKU: " + item.pojemnosc + " || ILOŚĆ MIEJSC: " + item.ilosc_miejsc + " || STAN: "+stan+"\n");
                i++;
            }
            Console.Write("\nABY ZARZĄDZAĆ POJAZDEM WYBIERZ JEGO NR\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 -- POWRÓT\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("--------------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else
            {
                Console.Clear();
                Console.Write("-------ZARZĄDZANIE POJAZDEM------\n");
                Console.Write("----------------------------------\n");
                Console.Write("---" + firma.Lista_Pojazdow_Firmy[wybor - 1].model + "---\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("STAN PALIWA: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(firma.Lista_Pojazdow_Firmy[wybor - 1].stan_paliwa + "/" + firma.Lista_Pojazdow_Firmy[wybor - 1].pojemnosc + "\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("MIEJSCE POSTOJU: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(firma.Lista_Pojazdow_Firmy[wybor - 1].postoj.nazwa + "\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("KIEROWCA: ");
                Console.ForegroundColor = ConsoleColor.White;
                if (firma.Lista_Pojazdow_Firmy[wybor - 1].kierowca == null)
                    Console.Write("BRAK");
                else
                    Console.Write(firma.Lista_Pojazdow_Firmy[wybor - 1].kierowca.imie + " " + firma.Lista_Pojazdow_Firmy[wybor - 1].kierowca.nazwisko);
                Console.Write("\n\n1 - ZATANKUJ       2 - WRACAJ DO SIEDZIBY(WARSZAWA)       3 - ZMIEŃ KIEROWCĘ\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n9999 -- POWRÓT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n----------------------------------\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor1 == 1)
                {
                    firma.Lista_Pojazdow_Firmy[wybor - 1].Zatankuj();
                    Console.ReadKey();
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor1 == 2)
                {
                    firma.Lista_Pojazdow_Firmy[wybor - 1].Wracaj(firma.Lista_Pojazdow_Firmy[wybor - 1].postoj);
                    Console.ReadKey();
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor1 == 3)
                {
                    Console.Clear();
                    int j = 1;
                    Console.Write("KTÓREGO KIEROWCĘ CHCESZ PRZYDZIELIĆ DO TEGO POJAZDU?");
                    Console.Write("\n-------------------------\n");
                    Console.Write("0.ZWOLNIJ POJAZD\n");
                    foreach (var item in firma.Lista_Kierowcow_Firmy)
                    {
                        Console.Write(j + "." + item.imie + " " + item.nazwisko + "\n");
                        j++;
                    }
                    Console.Write("\nWYBIERZ NR KIEROWCY. \n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n9999 - POWRÓT\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-------------------------\n");
                    var wybor2 = int.Parse(Console.ReadLine());
                    if (wybor2 == 0)
                    {
                        firma.Lista_Pojazdow_Firmy[wybor - 1].Zwolnij_Pojazd();
                        Console.ReadKey();
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                    else
                    {
                        firma.Lista_Pojazdow_Firmy[wybor - 1].Dodaj_Kierowce(firma.Lista_Kierowcow_Firmy[wybor2 - 1]);
                        Console.ReadKey();
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                    if (wybor2 == 9999)
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor1 == 9999)
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
        public void kierowcy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-----OTO TWOI KIEROWCY----- \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-------------------\n");
            foreach (var item in firma.Lista_Kierowcow_Firmy)
            {
                Console.Write(i + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek+"\n");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 - POWRÓT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n-------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
        }
        public void miejscowosci(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.Write("-------GDZIE CHCESZ JECHAĆ?-------");
            Console.Write("\n----------------------------------\n");
            foreach (var item in lista_m)
            {
                Console.Write(i+"."+item.nazwa + " || ODLEGŁOŚĆ: " + item.odleglosc_km + "  || CZAS PRZEJAZDU: " + item.czas_przejazdu_h + "H\n");
                i++;
            }
            Console.Write("----------------------------------\n");
            Console.Write("WYBIERZ NR OD 1 DO 10\n9999 - POWRÓT\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else
            {
                Console.Clear();
                int j = 1;
                Console.Write("-------KTÓRYM POJAZDEM CHCESZ WYRUSZYĆ?-------");
                Console.Write("\n----------------------------------------------\n");
                foreach (var item in lista_p)
                {
                    Console.Write(j + "." + item.model + "\n");
                    j++;
                }
                Console.Write("----------------------------------------------\n");
                Console.Write("WYBIERZ NR OD 1 DO 10\n9999 - POWRÓT\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor1 == 9999)
                    miejscowosci(lista_k, lista_p, lista_m, lista_s, firma);
                else
                {
                    firma.Lista_Pojazdow_Firmy[wybor1 - 1].Jedz(lista_m[wybor - 1]);
                    Console.ReadKey();
                    glowne(lista_k, lista_p, lista_m, lista_s, firma);
                }

            }
        }
        public void sklepy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-------OTO DOSTĘPNE SKLEPY-------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("----------------------------------\n");
            foreach (var item in lista_s)
            {
                Console.Write(i + "." + item.nazwa + "\n");
                i++;
            }
            Console.Write("\nWPISZ NR OD 1 DO 5\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 -- POWRÓT\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("----------------------------------\n");           
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else
            {
                int j = 1;
                Console.Clear();
                Console.Write("-------POJAZDY W TYM SKLEPIE-------\n");
                Console.Write("------------------------------------\n");
                foreach(var item in lista_s[wybor-1].Lista_Pojazdow_Sklepu)
                {
                    Console.Write(j+"."+item.model + " || ROCZNIK: " +item.rocznik +" || ILOŚĆ MIEJSC: "+item.ilosc_miejsc+" || POJEMNOŚĆ BAKU: "+item.pojemnosc+"\n");
                    j++;
                }
                Console.Write("\nKUP 1 LUB 2\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n9999 - POWRÓT\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("------------------------------------\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if(wybor1 == 1 || wybor1 == 2)
                {
                    lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1].Kup(lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1], firma);
                    Console.ReadKey();
                    sklepy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if(wybor1 == 9999)
                    sklepy(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
        public void zatrudnij(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            int i = 1;
            Console.Clear();
            Console.Write("KTÓREGO KIEROWCĘ CHCESZ ZATRUDNIĆ?\n");
            Console.Write("--------------------------------------------\n");
            foreach (var item in lista_k)
            {
                Console.Write(i + "." + item.imie + " " + item.nazwisko + " || WIEK: " + item.wiek + " || PREMIA ZA PODPIS: " + item.placa + " || DOŚWIADCZENIE: " + item.lata_doswiadczenia + "\n");
                i++;
            }
            Console.Write("\nWYBIERZ NR OD 1 DO 10\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 - POWRÓT\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("--------------------------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else
            {
                lista_k[wybor - 1].Zatrudnij(lista_k[wybor - 1], firma);
                Console.ReadKey();
                zatrudnij(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
        public void glowne(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("---------MENU---------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-------------------------\n");
            Console.Write("1.SZCZEGÓŁY FIRMY\n2.ZARZĄDZAJ POJAZDAMI\n3.PODGLĄD KIEROWCÓW\n4.KUP POJAZD\n5.ZATRUDNIJ KIEROWCĘ\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 -- WYJŚCIE\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if(wybor == 1)
            { 
                szczegoly(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if(wybor == 2)
            {
                pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if(wybor == 3)
            {
                kierowcy(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if(wybor == 4)
            {
                sklepy(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if(wybor == 5)
            {
                zatrudnij(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
    }
}
