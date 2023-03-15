using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var s = new BaseDatos();
            s.escribir_basedatos(1234, "t12", 3,68,1);
            //s.actualizar_basedatos(132, "Q1", 3, 68, 0);
            s.leer_basedatos(1);
        }
    }
}
