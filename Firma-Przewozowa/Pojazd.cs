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
        public void Jedz(Miejscowosc m)
        {
            if (this.CzyZajety == true )
            {
                Console.Write("Ten pojazd jest aktualnie w mieście" + m.nazwa + " Jeżeli chcesz go użyć, to wróć nim do siedziby.");
            }
            if (this.kierowca == null)
            {
                Console.Write("Ten pojazd nie ma kierowcy");
            }
            else
            {
                if (this.stan_paliwa < m.odleglosc_km / 20)
                {
                    Console.Write("Nie maszwystarczająco paliwa. Zatankuj przynajmniej: " + (Math.Abs(this.stan_paliwa - m.odleglosc_km / 20)));
                }
                else
                {
                    this.CzyZajety = true;
                    this.stan_paliwa -= (m.odleglosc_km / 20);
                    this.postoj = m;
                    Console.Write("Jadę");
                }
            }
        }
        public void Wracaj(Miejscowosc m)
        {
            if (this.CzyZajety == false)
            {
                Console.Write("Ten pojazd jest aktualnie wolny. Możesz nim śmiało jechać");
            }
            else
            {
                if (this.stan_paliwa < m.odleglosc_km / 20)
                {
                    Console.Write("Nie maszwystarczająco paliwa. Zatankuj przynajmniej: " + (Math.Abs(this.stan_paliwa - m.odleglosc_km / 20)));
                }
                else
                {
                    Console.Write("WRACAM DO SIEDZIBY FIRMY");
                    this.CzyZajety = false;
                    this.stan_paliwa -= (m.odleglosc_km / 20);
                }
            }
        }
        public void Zatankuj(int ilosc)
        {
            if (this.stan_paliwa + ilosc > this.pojemnosc)
            {
                Console.Write("Nie możesz tyle zatankować. Maksymalna ilość paliwa, którą możesz wlać do baku to: " + (this.pojemnosc - this.stan_paliwa)+"l");
            }
            else
            {
                Console.Write("Zatankowano " + ilosc + "l paliwa. Cena: " + (ilosc * 5) + "zl");
                this.stan_paliwa += ilosc;
            }
        }
        public void Kup(Firma firma, int cena)
        {
            if (firma.budzet < cena)
                Console.Write("Nie stać Cię na ten pojazd");
            else
            {
                firma.budzet -= cena;
            }
        }
        public void Dodaj_Kierowce(Kierowca k)
        {
            if (k.CzyZajety == true)
            {
                Console.Write("\nTEN KIEROWCA JEST JUŻ ZAJĘTY");
            }
            else
            {
                Console.Write("DODANO KIEROWCĘ DO TEGO POJAZDU");
                this.kierowca = k;
                k.CzyZajety = true;
            }
        }
        public void Zwolnij_Pojazd()
        {
            if (this.kierowca == null)
            {
                Console.Write("TEN POJAZD JEST JUŻ PUSTY");
            }
            else
            {
                Console.Write("\nPOJAZD JEST WOLNY. ŻADEN KIEROWCA NIE SIEDZI ZA KIEROWNICĄ");
                var tmp = this.kierowca;
                this.kierowca = null;
                tmp.CzyZajety = false;
            }
        }
    }
   
}
