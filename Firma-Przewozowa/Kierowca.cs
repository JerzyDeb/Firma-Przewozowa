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
        public int placa;//placa za podpis
        public int lata_doswiadczenia;
        public void Zatrudnij(Kierowca k,Firma firma) //Zatrudnienie kierowcy
        {
            if (firma.budzet < k.placa)//Jeśli firmy nie stać na kierowcę to nie kupuje
            {
                Console.Write("NIE STAĆ CIĘ NA TEGO PRACOWNIKA");
            }
            else //Jeśli stać
            {
                if (firma.Lista_Kierowcow_Firmy.Contains(k))//ale ten jest już zatrudniony to nie zatrudnia
                {
                    Console.Write("TEN KIEROWCA JEST JUŻ PRZEZ CIEBIE ZATRUDNIONY");
                }
                else //zatrudnia
                {
                    Console.Write("ZATRUDNIONO NOWEGO KIEROWCĘ");
                    firma.budzet -= k.placa;//Budżet firmy zmniejszony
                    firma.Lista_Kierowcow_Firmy.Add(k);//Dodanie kierowcy do firmy
                }
            }
        }
        public void Zwolnij(Kierowca k, Firma firma)
        {
            firma.Lista_Kierowcow_Firmy.Remove(k);
            Console.Write("Zwolniono kierowcę");
        }

    }
}
