using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    class Sklep
    {
        public string nazwa;
        public List<Pojazd> Lista_Pojazdow_Sklepu = new List<Pojazd>();
        public Sklep(string n, Pojazd p, Pojazd p1)
        {
            this.nazwa = n;
            this.Lista_Pojazdow_Sklepu = new List<Pojazd>();
            this.Lista_Pojazdow_Sklepu.Add(p);
            this.Lista_Pojazdow_Sklepu.Add(p1);
        }
    }
}
