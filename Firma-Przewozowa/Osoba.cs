using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    public abstract class Osoba
    {
        public string imie;
        public string nazwisko;
        public int wiek;
        public Pojazd pojazd;
        public bool CzyZajety;
        public Osoba(string i, string n, int w)
        {
            this.imie = i;
            this.nazwisko = n;
            this.wiek = w;
        }
    }
}
