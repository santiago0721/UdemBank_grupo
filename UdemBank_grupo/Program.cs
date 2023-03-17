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
            var k = new UdemBank();
            /*s.eliminar(1222, 0);
            s.escribir_basedatos(121, "aa", 32,1222,0);
            s.escribir_basedatos(222, "bb", 32, 1231, 0);
            s.actualizar_basedatos(121,"11",21,1222,0);
            s.buscar(122, 0);
            s.eliminar(122, 0);
            //s.actualizar_basedatos(132, "Q1", 3, 68, 0);
            s.leer_basedatos(0);
            var Ui = new Ui();
            */
            s.escribir_basedatos_atm(3, 2111);
            s.escribir_basedatos_atm(2, 22);
            k.creacion_atms();


        }
    }
}
