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
        public int rocznik;
        public int ilosc_miejsc;
        public int przebieg;
        public int cena;
        public Kierowca kierowca;
        public bool CzyZajety;
        public int pojemnosc;
        public int stan_paliwa;
        public Pojazd(string m, int r, int i, int c, int p)
        {
            this.marka = m;
            this.rocznik = r;
            this.ilosc_miejsc = i;
            this.przebieg = 0;
            this.cena = c;
            this.pojemnosc = p;
            this.stan_paliwa = this.pojemnosc;
        }
        public void Jedz(int odl)
        {
            this.CzyZajety = true;
            this.stan_paliwa -= (odl/20);
        }
        public void Wracaj(int odl)
        {
            this.CzyZajety = false;
            this.stan_paliwa -= (odl/20);
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
    }
   
}
