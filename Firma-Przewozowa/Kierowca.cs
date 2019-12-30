using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    public class Kierowca : Osoba
    {
        public Kierowca(string i, string n, int w, int p, int l) : base(i, n, w)
        {
            this.placa = p;
            this.lata_doswiadczenia = l;
        }
        public int placa;
        public int lata_doswiadczenia;
        public void Zatrudnij(Kierowca k,Firma firma)
        {
            if (firma.budzet < k.placa)
            {
                Console.Write("NIE STAĆ CIĘ NA TEGO PRACOWNIKA");
            }
            else
            {
                Console.Write("ZATRUDNIONO NOWEGO KIEROWCĘ");
                firma.budzet -= k.placa;
                firma.Lista_Kierowcow_Firmy.Add(k);
            }
        }

    }
}
