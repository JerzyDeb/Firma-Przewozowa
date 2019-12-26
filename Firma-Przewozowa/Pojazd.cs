using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    public class Pojazd
    {
        public int rocznik;
        public int ilosc_miejsc;
        public int przebieg;
        public Pojazd(int r, int i, int p)
        {
            this.rocznik = r;
            this.ilosc_miejsc = i;
            this.przebieg = p;
        }
    }
}
