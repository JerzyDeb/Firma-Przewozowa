using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{ 
    public class Pojazd:IPodroz
    {
        public string marka;
        public int rocznik;
        public int ilosc_miejsc;
        public int przebieg;
        public Kierowca kierowca;
        public bool CzyZajety;
        public Pojazd(string m, int r, int i)
        {
            this.marka = m;
            this.rocznik = r;
            this.ilosc_miejsc = i;
            this.przebieg = 0;
        }
        public void Jedz()
        {
            this.CzyZajety = true;
        }
        public void Wracaj()
        {
            this.CzyZajety = false;
        }
    }
   
}
