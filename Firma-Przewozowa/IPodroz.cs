using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    interface IPodroz
    {
        void Jedz(Firma f,Miejscowosc m);
        void Wracaj(Firma f,Miejscowosc m);

        void Zatankuj(Firma firma);
    }
}
