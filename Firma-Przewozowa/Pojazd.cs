using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{ 
    public class Pojazd:IPodroz
    {
        //Zużycie paliwa - 20l/100km
        //Cena paliwa - 5zł/1l
        public string marka;
        public string model;
        public int rocznik;
        public int ilosc_miejsc;
        public int przebieg;
        public int cena;
        public Kierowca kierowca;
        public bool CzyZajety;
        public int pojemnosc;
        public int stan_paliwa;
        public Miejscowosc postoj_default = new Miejscowosc("WARSZAWA", 0,0);
        public Miejscowosc postoj;
        public Pojazd(string m, string mo, int r, int i, int c, int p, Miejscowosc postoj)
        {
            this.marka = m;
            this.model = mo;
            this.rocznik = r;
            this.ilosc_miejsc = i;
            this.przebieg = 0;
            this.cena = c;
            this.pojemnosc = p;
            this.stan_paliwa = this.pojemnosc;
            this.postoj = postoj;
        }
        public void Jedz(Firma firma, Miejscowosc m)
        {
            if (this.CzyZajety == true) //Jeśli pojazd jest już w trasie to nie jedzie
            {
                Console.Write("Ten pojazd jest aktualnie w mieście " + this.postoj.nazwa + " Jeżeli chcesz go użyć, to wróć nim do siedziby.");
            }
            else
            {
                if (this.kierowca == null) //jeśli pojazd nie ma kierowcy to nie jedzie
                {
                    Console.Write("Ten pojazd nie ma kierowcy");
                }
                else
                {
                    if (this.ilosc_miejsc < m.ilosc_osob) //Jeśli nie ma wystarczjąco miejsc to nie jedzie
                        Console.Write("W POJEŹDZIE NIE MA WYSTARCZAJĄCEJ LICZBY MIEJSC(" + m.ilosc_osob + ")");
                    else
                    {
                        
                        if (this.stan_paliwa < m.odleglosc_km / 20) //Jeśli nie ma wystarczjąco paliwa to nie jedzie
                        {
                            Console.Write("Nie maszwystarczająco paliwa. Zatankuj przynajmniej: " + (Math.Abs(this.stan_paliwa - m.odleglosc_km / 20)));
                        }
                        else //Jedzie
                        {
                            this.CzyZajety = true; //=w trasie
                            this.stan_paliwa -= (m.odleglosc_km / 20); //Zmiejszanie stanu paliwa
                            this.postoj = m; //Aktualny miejsce pobytu
                            Console.Write("Jadę");
                            firma.budzet += (m.odleglosc_km * firma.cena_za_kilometr) + (m.ilosc_osob * firma.cena_za_osobe); //Budżet firmy zwiększony o km*5ł + 10zł* ilosc osob
                        }
                    }
                }
            }
        }
        public void Wracaj(Firma firma, Miejscowosc m)
        {
            if (this.CzyZajety == false) //Jeśli pojazd jest w siedzibie to nie wraca
            {
                Console.Write("Ten pojazd jest aktualnie wolny. Możesz nim śmiało jechać");
            }
            else
            {
                if (this.stan_paliwa < m.odleglosc_km / 20) //Jeśli nie ma wystarczająco paliwa to nie wraca
                {
                    Console.Write("Nie maszwystarczająco paliwa. Zatankuj przynajmniej: " + (Math.Abs(this.stan_paliwa - m.odleglosc_km / 20)));
                }
                else //Wraca
                {
                    Console.Write("WRACAM DO SIEDZIBY FIRMY");
                    this.postoj = this.postoj_default; //Miejsce pobytu = Warszawa
                    this.CzyZajety = false; //=w siedzibie
                    this.stan_paliwa -= (m.odleglosc_km / 20); //Zmiejszanie stanu paliwa
                    firma.budzet += (m.odleglosc_km * firma.cena_za_kilometr) + (m.ilosc_osob * firma.cena_za_osobe);//Budżet firmy zwiększony o km*5ł + 10zł* ilosc osob
                }
            }
        }
        public void Zatankuj(Firma firma)//Tankowanie
        {
            Console.Write("CENA PALIWA TO 5ZŁ/L. ILE LITRÓW CHCESZ ZATANKOWAĆ? MAKSYMALNIE MOŻESZ " + (this.pojemnosc - this.stan_paliwa) + "L  ");
            var ilosc = int.Parse(Console.ReadLine());//ilosc paliwa do zatankowania
            if (this.stan_paliwa + ilosc > this.pojemnosc)//Jeśli przekroczona pojemnosc baku to nie tankuje
            {
                Console.Write("NIE MOŻESZ TYLE ZATANKOWAĆ. MAKSYMALNIE MOŻESZ WLAĆ DO BAKU: " + (this.pojemnosc - this.stan_paliwa)+"L ");
            }
            else //Tankuje
            {
                Console.Write("ZATANKOWANO " + ilosc + "L PALIWA. CENA: " + (ilosc * 5) + "ZŁ");
                this.stan_paliwa += ilosc;//Zwiększenie stanu paliwa
                firma.budzet -= ilosc * 5;//Budżet zmniejszony
            }
        }
        public void Kup(Pojazd p, Firma firma)//Kupno pojazdu
        {
            if (firma.budzet < p.cena)//Jeśli firmy nie stać to nie kupuje
                Console.Write("Nie stać Cię na ten pojazd");
            else //Kupuje
            {
                Console.Write("UDAŁO CI SIĘ KUPIĆ POJAZD");
                firma.budzet -= cena;//Budżet firmy zmniejszony
                firma.Lista_Pojazdow_Firmy.Add(p);//Dodanie pojazdu do  firmy
            }
        }
        public void Dodaj_Kierowce(Kierowca k) //Metoda, która  dodaje do pojazdu kierowcę
        {
            if(this.kierowca != null) //Jeśli ten pojazd ma już kierowcę
            {
                var tmp = this.kierowca; //To usuwamy aktualnego
                this.kierowca = null; 
                tmp.CzyZajety = false;
            }

            if (k.CzyZajety == true)//Jeśli dodawany kierowca jest już zajęty to nie dodaje
            {
                Console.Write("\nTEN KIEROWCA JEST JUŻ ZAJĘTY");
            }
            else//Dodano kierowce
            {
                Console.Write("DODANO KIEROWCĘ DO TEGO POJAZDU");
                this.kierowca = k;
                k.CzyZajety = true;
                k.pojazd = this;
            }
        }
        public void Zwolnij_Pojazd() //Metoda, która usuwa kierowcę z pojazdu
        {
            if (this.kierowca == null)//Jeśli pojazd nie ma kierowcy to nie zwalniamy miejsca w pojeździe
            {
                Console.Write("TEN POJAZD JEST JUŻ PUSTY"); 
            }
            else //Zwalniemy miejsce w pojeździe i kierowca jest wolny
            {
                Console.Write("\nPOJAZD JEST WOLNY. ŻADEN KIEROWCA NIE SIEDZI ZA KIEROWNICĄ");
                var tmp = this.kierowca; //Kierowca to tmp
                this.kierowca = null; //Kierowca pojazdu null
                tmp.CzyZajety = false; //Stan kierowcy to wolny
            }
        }
        public void wyswietl_info(Firma firma,int wybor) //Info o pojeździe:
        {

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
        }
    }
   
}
