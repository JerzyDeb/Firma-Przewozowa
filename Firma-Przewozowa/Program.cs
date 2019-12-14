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
    public class Firma
    {
        public string nazwa;
        public int budzet;
        public string siedziba;
        public Firma(string n, string s)
        {
            this.nazwa = n;
            this.siedziba = s;
        }
    }
}
