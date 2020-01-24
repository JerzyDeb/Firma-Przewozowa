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
            //Wyświetlenie szczegółów firmy:
            Console.Clear();
            Console.Write("----SZCZEGÓŁY TWOJEJ FIRMY----\n");
            Console.Write("--------------------------------\n");
            firma.szczegoly_firmy();
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)
                glowne(lista_k, lista_p, lista_m, lista_s, firma); //Powrót do menu głównego
        }
        public void pojazdy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            //Wyświetlenie pojazdów firmy:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("--------OTO TWOJE POJAZDY------ \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("--------------------------------\n");
            firma.wyswietl_pojazdy();
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
                //Zarządzanie wybranym pojazdem:
                Console.Clear();
                Console.Write("-------ZARZĄDZANIE POJAZDEM------\n");
                Console.Write("----------------------------------\n");
                firma.Lista_Pojazdow_Firmy[wybor - 1].wyswietl_info(firma, wybor);
                Console.Write("\n\n1 - ZATANKUJ       2 - WRACAJ DO SIEDZIBY(WARSZAWA)       3 - ZMIEŃ KIEROWCĘ\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n9999 -- POWRÓT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n----------------------------------\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor1 == 1)//Zatankowanie pojazdem
                {
                    firma.Lista_Pojazdow_Firmy[wybor - 1].Zatankuj(firma);
                    Console.ReadKey();
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor1 == 2)//Powrót pojazdem do firmy
                {
                    firma.Lista_Pojazdow_Firmy[wybor - 1].Wracaj(firma,firma.Lista_Pojazdow_Firmy[wybor - 1].postoj);                 
                    Console.ReadKey();
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if (wybor1 == 3) //Zmienianie kierowcy w pojeździe
                {
                    Console.Clear();
                    int j = 1;
                    Console.Write("KTÓREGO KIEROWCĘ CHCESZ PRZYDZIELIĆ DO TEGO POJAZDU?");
                    Console.Write("\n-------------------------\n");
                    Console.Write("0.ZWOLNIJ POJAZD\n");
                    foreach (var item in firma.Lista_Kierowcow_Firmy)//Wybór nowego kierowcy
                    {
                        if (item.CzyZajety == true)
                            Console.Write(j + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek + " || stan: W POJEŹDZIE: "+item.pojazd.model+"\n");
                        else
                            Console.Write(j + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek + " || stan: BEZ POJAZDU\n");
                        j++;
                    }
                    Console.Write("\nWYBIERZ NR KIEROWCY. \n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n9999 - POWRÓT\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-------------------------\n");
                    var wybor2 = int.Parse(Console.ReadLine());
                    if (wybor2 == 0)//Zwolnienie pojazdu
                    {
                        firma.Lista_Pojazdow_Firmy[wybor - 1].Zwolnij_Pojazd();
                        Console.ReadKey();
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                    if (wybor2 == 9999)//Powrót
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                    else//Dodanie kierowcy do pojazdu
                    {
                        firma.Lista_Pojazdow_Firmy[wybor - 1].Dodaj_Kierowce(firma.Lista_Kierowcow_Firmy[wybor2 - 1]);
                        Console.ReadKey();
                        pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
                    }
                }
                if (wybor1 == 9999)//Powrót
                    pojazdy(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
        //Wyświetlanie listy kierowców firmy:
        public void kierowcy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-----OTO TWOI KIEROWCY----- \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-------------------\n");
            firma.wyswietl_kierowcow();
            Console.Write("--------------------\n");
            Console.Write("WYBIERZ NR KIEROWCY ABY GO ROZWIĄZAĆ Z NIM UMOWĘ\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("9999 - POWRÓT\n");
            Console.ForegroundColor = ConsoleColor.White;
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)//Powrót do menu głównego
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else//Zwolnienie kierowcy
            {
                firma.Lista_Kierowcow_Firmy[wybor-1].Zwolnij(firma.Lista_Kierowcow_Firmy[wybor - 1],firma);
                Console.ReadKey();
                kierowcy(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
        //Wyswietlanie zleceń:
        public void miejscowosci(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.Write("-------GDZIE CHCESZ JECHAĆ?-------");
            Console.Write("\n----------------------------------\n");
            foreach (var item in lista_m)//Wypis dostępnych zleceń:
            {
                Console.Write(i+"."+item.nazwa + " || ODLEGŁOŚĆ: " + item.odleglosc_km + "  || CZAS PRZEJAZDU: " + item.czas_przejazdu_h + "H  || LICZBA OSÓB:"+item.ilosc_osob+"\n");
                i++;
            }
            Console.Write("\nWYBIERZ NR OD 1 DO 10\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 - POWRÓT\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("----------------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if (wybor == 9999)//Powrót do menu głównego
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else//Wybór pojazdu do podróży:
            {
                Console.Clear();
                Console.Write("-------KTÓRYM POJAZDEM CHCESZ WYRUSZYĆ?-------");
                Console.Write("\n----------------------------------------------\n");
                firma.wyswietl_pojazdy();
                Console.Write("\nWYBIERZ NR POJAZDU\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n9999 - POWRÓT\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("----------------------------------------------\n");
                var wybor1 = int.Parse(Console.ReadLine());
                if (wybor1 == 9999)//Powrót
                    miejscowosci(lista_k, lista_p, lista_m, lista_s, firma);
                else//Podróż
                {
                    firma.Lista_Pojazdow_Firmy[wybor1 - 1].Jedz(firma,lista_m[wybor - 1]);
                    Console.ReadKey();
                    glowne(lista_k, lista_p, lista_m, lista_s, firma);
                }

            }
        }
        //Kupowanie pojazdów:
        public void sklepy(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            Console.Clear();
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-------OTO DOSTĘPNE SKLEPY-------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("----------------------------------\n");
            foreach (var item in lista_s)//Wyświetlenie dostępnych sklepów:
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
            if (wybor == 9999)//Powrót do menu głównego
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else//Wybór w sklepie:
            {
                int j = 1;
                Console.Clear();
                Console.Write("-------POJAZDY W TYM SKLEPIE-------\n");
                Console.Write("------------------------------------\n");
                foreach(var item in lista_s[wybor-1].Lista_Pojazdow_Sklepu)//Pojazdy w tym sklepie:
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
                if(wybor1 == 1 || wybor1 == 2)//Kupno pojazdu:
                {
                    lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1].Kup(lista_s[wybor - 1].Lista_Pojazdow_Sklepu[wybor1 - 1], firma);
                    Console.ReadKey();
                    sklepy(lista_k, lista_p, lista_m, lista_s, firma);
                }
                if(wybor1 == 9999)//Powrót
                    sklepy(lista_k, lista_p, lista_m, lista_s, firma);
            }
        }
        //Zatrudnianie kierowców:
        public void zatrudnij(List<Kierowca> lista_k, List<Pojazd> lista_p, List<Miejscowosc> lista_m, List<Sklep> lista_s, Firma firma)
        {
            int i = 1;
            Console.Clear();
            Console.Write("KTÓREGO KIEROWCĘ CHCESZ ZATRUDNIĆ?\n");
            Console.Write("--------------------------------------------\n");
            foreach (var item in lista_k)//Wypisanie kierowców:
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
            if (wybor == 9999)//Powrót
                glowne(lista_k, lista_p, lista_m, lista_s, firma);
            else//Zatrudnienie
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
            Console.Write("1.SZCZEGÓŁY FIRMY\n2.ZARZĄDZAJ POJAZDAMI\n3.PODGLĄD KIEROWCÓW\n4.KUP POJAZD\n5.ZATRUDNIJ KIEROWCĘ\n6.JEDŹ\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n9999 -- WYJŚCIE\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-------------------------\n");
            var wybor = int.Parse(Console.ReadLine());
            if(wybor == 1)
            { 
                szczegoly(lista_k, lista_p, lista_m, lista_s, firma);//Szczegóły firmy
            }
            if(wybor == 2)
            {
                pojazdy(lista_k, lista_p, lista_m, lista_s, firma);//Pojazdy firmy
            }
            if(wybor == 3)
            {
                kierowcy(lista_k, lista_p, lista_m, lista_s, firma);//Kierowcy firmy
            }
            if(wybor == 4)
            {
                sklepy(lista_k, lista_p, lista_m, lista_s, firma);//Sklepy
            }
            if(wybor == 5)
            {
                zatrudnij(lista_k, lista_p, lista_m, lista_s, firma);//Zatrudnianie kierowców
            }
            if(wybor == 6)
            {
                miejscowosci(lista_k, lista_p, lista_m, lista_s, firma);//Zlecenia
            }
        }
    }
}
