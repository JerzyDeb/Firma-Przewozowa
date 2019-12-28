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
        public int cena_za_kilometr;
        public int cena_za_osobe;
        public Firma(string n)
        {
            this.nazwa = n;
            this.siedziba = "Warszawa";
            this.Lista_Pojazdow_Firmy = new List<Pojazd>();
            this.Lista_Kierowcow_Firmy = new List<Kierowca>();
            this.cena_za_kilometr = 2;
            this.cena_za_osobe = 10;
        }
        public void Dodaj_Pojazd(Pojazd p)
        {
            this.Lista_Pojazdow_Firmy.Add(p);
        }
    }
}
