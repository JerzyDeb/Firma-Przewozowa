using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    interface IPodroz
    {
        void Jedz(Miejscowosc m);
        void Wracaj(Miejscowosc m);

        void Zatankuj(int ilosc);
    }
}
