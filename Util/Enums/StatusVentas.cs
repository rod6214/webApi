using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Enums
{
    public enum StatusVentas
    {
        ESPERANDO = 4,
        FINALIZADO = 8,
        ALL = ESPERANDO | FINALIZADO
    }
}
