using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Przewozowa
{
    interface IPodroz
    {
        void Jedz(int odl);
        void Wracaj(int odl);

        void Zatankuj(int ilosc);
    }
}
