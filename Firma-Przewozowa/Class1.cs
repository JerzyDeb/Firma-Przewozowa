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
            Console.Write("  (ABY PODEJRZEĆ WYBIERZ NA KLAWIATURZE '1')");
            Console.Write("\nLICZBA POJAZDÓW  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(firma.Lista_Pojazdow_Firmy.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (ABY PODEJRZEĆ WYBIERZ NA KLAWIATURZE '2')");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n--------------------------------\n");
            Console.Write("9999 - POWRÓT\n");
            var wybor = int.Parse(Console.ReadLine());
            if(wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            if (wybor == 1)
                kierowcy(lista_k, lista_p, lista_m, lista_s, firma);
            if (wybor == 2)
                pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
            else
                glowne(lista_k, lista_p, lista_m, lista_s, firma);

        }
        public void pojazdy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            int i = 1;
            Console.Clear();
            Console.Write("--------OTO TWOJE POJAZDY------ \n");
            Console.Write("--------------------------------\n");
            foreach (var item in lista_p)
            {
                var stan_bool = item.CzyZajety;
                var stan = "";

                if (stan_bool == true)
                    stan = "zajęty";
                else
                    stan = "wolny";
                Console.Write(i+"."+item.model + " || Pojemność baku: " + item.pojemnosc + " || Ilość miejsc: " + item.ilosc_miejsc + " || stan: "+stan+"\n");
            }
            Console.Write("--------------------------------\n");
            Console.Write("ABY ZARZĄDZAĆ POJAZDEM WYBIERZ LICZBĘ OD 1 DO 10\n");
            Console.Write("9999 - POWRÓT\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                szczegoly(lista_k, lista_p, lista_m, lista_s, firma);
            else
            {
                Console.Clear();
                Console.Write("-------ZARZĄDZANIE POJAZDEM------\n");
                Console.Write("----------------------------------\n");
                Console.Write("---" + lista_p[wybor - 1].model + "---\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("STAN PALIWA: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(lista_p[wybor - 1].stan_paliwa + "/" + lista_p[wybor - 1].pojemnosc + "\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("MIEJSCE POSTOJU: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(lista_p[wybor - 1].postoj.nazwa + "\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("KIEROWCA: ");
                Console.ForegroundColor = ConsoleColor.White;
                if (lista_p[wybor - 1].kierowca == null)
                    Console.Write("BRAK");
                else
                    Console.Write(lista_p[wybor - 1].kierowca.imie + " " + lista_p[wybor - 1].kierowca.nazwisko);
                Console.Write("\n----------------------------------\n");
                Console.Write("1 - ZATANKUJ       2 - WRACAJ DO SIEDZIBY(WARSZAWA)       3 - ZMIEŃ KIEROWCĘ\n9999 - POWRÓT\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor1 == 1)
                {
                    Console.Write("CENA PALIWA TO 5ZŁ/L. ILE LITRÓW CHCESZ ZATANKOWAĆ? MAKSYMALNIE MOŻESZ " + (lista_p[wybor1 - 1].pojemnosc - lista_p[wybor1 - 1].stan_paliwa) + "L  ");
                    var ilosc = int.Parse(Console.ReadLine());
                    lista_p[wybor - 1].Zatankuj(ilosc);
                    Console.ReadKey();
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor1 == 2)
                {
                    lista_p[wybor - 1].Wracaj(lista_p[wybor - 1].postoj);
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
                    Console.Write("-------------------------\n");
                    Console.Write("WYBIERZ NR OD 0 DO 10. \n 9999 - POWRÓT\n");
                    var wybor2 = int.Parse(Console.ReadLine());
                    if (wybor2 == 0)
                    {
                        lista_p[wybor - 1].Zwolnij_Pojazd();
                        Console.ReadKey();
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                    else
                    {
                        lista_p[wybor - 1].Dodaj_Kierowce(firma.Lista_Kierowcow_Firmy[wybor2 - 1]);
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
            Console.Write("OTO TWOI KIEROWCY: \n");
            Console.Write("-------------------\n");
            Console.Write("0.ZATRUDNIJ NOWEGO KIEROWCĘ\n");
            foreach (var item in firma.Lista_Kierowcow_Firmy)
            {
                Console.Write(i + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek);
                i++;
            }
            Console.Write("\n-------------------");
            Console.Write("\n9999 - POWRÓT\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 0)
            {
                int j = 1;
                Console.Clear();
                Console.Write("KTÓREGO KIEROWCĘ CHCESZ ZATRUDNIĆ?\n");
                Console.Write("-----------------------------------\n");
                foreach (var item in lista_k)
                {
                    Console.Write(j + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek + " || premia za podpis: " + item.placa + " || Doświadczenie: " + item.lata_doswiadczenia+"\n");
                    j++;
                }
                Console.Write("-----------------------------------\n");
                Console.Write("WYBIERZ NR 1-10\n9999 - POWRÓT\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor1 >= 1 && wybor1 <= 10)
                {
                    if (firma.budzet < lista_k[wybor1 - 1].placa)
                    {
                        Console.Write("NIE STAĆ CIĘ NA TEGO PRACOWNIKA");
                        Console.ReadKey();
                        kierowcy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                    else
                    {
                        firma.budzet -= lista_k[wybor - 1].placa;
                        firma.Lista_Kierowcow_Firmy.Add(lista_k[wybor - 1]);
                        kierowcy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                }
            }
            if (wybor == 9999)
                szczegoly(lista_k, lista_p, lista_m, lista_s, firma);
        }
        public void miejscowosci(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.Write("Gdzie chcesz jechać: ");
            foreach (var item in lista_m)
            {
                Console.Write(i+"."+item.nazwa + " Odległość: " + item.odleglosc_km + " Czas przejazdu: " + item.czas_przejazdu_h + "\n");
                i++;
            }
            Console.Write("(Wpisz nr 1-10)  9999 - POWRÓT");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor >= 1 && wybor <= 10)
            {
                int j = 1;
                Console.Write("Którym pojazdem chcesz wyruszyć? ");
                foreach (var item in lista_p)
                {
                    Console.Write(j+"."+item.model + " Pojemność baku: " + item.pojemnosc + " Ilość miejsc: " + item.ilosc_miejsc + "\n");
                    j++;
                }
                Console.Write("(Wpisz nr 1-10)  9999 - POWRÓT");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor >= 1 && wybor <= 10)
                {
                    firma.Lista_Pojazdow_Firmy[wybor1 - 1].Jedz(lista_m[wybor - 1]);
                    glowne(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor == 9999)
                    miejscowosci(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
        }
        public void sklepy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.Write("Oto dostępne sklepy: \n");
            foreach (var item in lista_s)
            {
                Console.Write(i + "." + item.nazwa + "\n");
                i++;
            }
            Console.Write("(Wpisz nr 1 - 5)  9999 - POWRÓT");
            var wybor = int.Parse(Console.ReadLine());
            if(wybor >=1 && wybor <=5)
            {
                Console.Write("SKLEPY: \n");
                foreach(var item in lista_s[wybor-1].Lista_Pojazdow_Sklepu)
                {
                    Console.Write(item.model + " Pojemność baku: " + item.pojemnosc + " Ilość miejsc: " + item.ilosc_miejsc + "\n");
                }
                Console.Write("(Wpisz nr 1-2) 9999 - POWRÓT");
                var wybor1 = int.Parse(Console.ReadLine());
                if(wybor1 == 1 || wybor1 == 2)
                {
                    if (firma.budzet < lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1].cena)
                    {
                        Console.Write("Nie stać Cię na ten pojazd");
                        Console.ReadKey();
                        sklepy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                    else
                    {
                        firma.Lista_Pojazdow_Firmy.Add(lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1]);
                        firma.budzet -= lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1].cena;
                        Console.Write("Kupiono: " + lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1].model);
                        Console.ReadKey();
                        sklepy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                }
            }
            
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
        }
        public void glowne(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("---------MENU---------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-------------------------\n");
            Console.Write("1.SZCZEGÓŁY\n2.SKLEPY\n3.MIEJSCOWOŚCI\n");
            Console.Write("-------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if(wybor == 1)
            {
                Console.Clear();
                szczegoly(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if(wybor == 2)
            {
                sklepy(lista_k, lista_p, lista_m, lista_s, firma);
            }
            if(wybor == 3)
            {
                miejscowosci(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
    }
}
