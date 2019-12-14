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
    public class Osoba
    {
        public string imie;
        public string nazwisko;
        public int wiek;
        public Osoba(string i, string n, int w)
        {
            this.imie = i;
            this.nazwisko = n;
            this.wiek = w;
        }
    }
}
