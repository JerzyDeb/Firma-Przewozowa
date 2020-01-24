using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    public class Miejscowosc
    {
        public string nazwa;
        public int odleglosc_km;
        public int czas_przejazdu_h;
        public int ilosc_osob;
        public Miejscowosc(string n, int o, int os)
        {
            this.nazwa = n;
            this.odleglosc_km = o;
            this.czas_przejazdu_h = this.odleglosc_km / 60;
            this.ilosc_osob = os;
        }
    }
}
