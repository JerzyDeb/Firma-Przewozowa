using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Miejscowosc
    {
        string nazwa;
        int odleglosc_km;
        int czas_przejazdu_h;
        public Miejscowosc(string n, int o)
        {
            this.nazwa = n;
            this.odleglosc_km = o;
            this.czas_przejazdu_h = this.odleglosc_km / 60;
        }
    }
}
