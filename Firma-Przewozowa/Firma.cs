using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
public class Firma
    {
        public string nazwa;
        public int budzet;
        public string siedziba;
        public List<Pojazd> Lista_Pojazdow_Firmy = new List<Pojazd>();
        public List<Kierowca> Lista_Kierowcow_Firmy = new List<Kierowca>();
        public int cena_za_kilometr; //5zł
        public int cena_za_osobe; //10zł
        public Firma(string n)
        {
            this.nazwa = n;
            this.siedziba = "WARSZAWA";
            this.Lista_Pojazdow_Firmy = new List<Pojazd>();
            this.Lista_Kierowcow_Firmy = new List<Kierowca>();
            this.cena_za_kilometr = 1;
            this.cena_za_osobe = 10;
            this.budzet = 100000;
        }
        public void Dodaj_Pojazd(Pojazd p)
        {
            this.Lista_Pojazdow_Firmy.Add(p); //Dodawanie pojazdu do firmy
        }
        public void szczegoly_firmy() //Szczegóły firmy
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("NAZWA: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.nazwa);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nSIEDZIBA: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.siedziba);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nLICZBA KIEROWCÓW  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.Lista_Kierowcow_Firmy.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nLICZBA POJAZDÓW  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.Lista_Pojazdow_Firmy.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nBUDŻET  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.budzet);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n\n9999 -- POWRÓT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n--------------------------------\n");
        }
        public void wyswietl_pojazdy() //Wyświetlanie pojazdów firmy
        {
            int i = 1;
            foreach (var item in this.Lista_Pojazdow_Firmy)
            {
                if (item.CzyZajety == true)
                    Console.Write(i + "." + item.model + " || POJEMNOŚĆ BAKU: " + item.pojemnosc + " || ILOŚĆ MIEJSC: " + item.ilosc_miejsc + " || STAN: W TRASIE\n");
                else
                    Console.Write(i + "." + item.model + " || POJEMNOŚĆ BAKU: " + item.pojemnosc + " || ILOŚĆ MIEJSC: " + item.ilosc_miejsc + " || STAN: W SIEDZIBIE\n");
                i++;
            }
        }
        public void wyswietl_kierowcow() //Wyświetlanie kierowców firmy
        {
            int i = 1;
            foreach (var item in this.Lista_Kierowcow_Firmy)
            {
                if (item.CzyZajety == true)
                    Console.Write(i + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek + " || stan: W POJEŹDZIE\n");
                else
                    Console.Write(i + "." + item.imie + " " + item.nazwisko + " || wiek: " + item.wiek + " || stan: BEZ POJAZDU\n");
                i++;
            }

        }
    }
}
