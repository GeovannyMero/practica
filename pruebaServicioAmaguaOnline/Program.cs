using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaServicioAmaguaOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceAmagua.ConciliacionAmaguaClient cliente = new ServiceAmagua.ConciliacionAmaguaClient();
            cliente.GenerarArchivoTransaccionesOnLine(1,"10.107.41.77");
        }
    }
}
