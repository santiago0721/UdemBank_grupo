using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class Ui
    {
        UdemBank banco;
        public Ui() 
        
        {
            banco = new UdemBank();
            this.menu();

        }

        private void menu()
        {
            Console.Write("que usuario eres\n" +
                "[1] Cliente\n" +
                "[2] Admin\n" +
                "[3] salir ");
            var seleccion = Console.ReadLine();
            if (seleccion == "1")
            {
                var inicio_sesion = this.menu_inicial();
                var cliente = banco.buscar(inicio_sesion.Item1);
                if (cliente is null) { Console.WriteLine("esta cuenta no existe "); this.menu(); }

                else
                {
                    if (!(cliente.iniciar_sesion(inicio_sesion.Item1, inicio_sesion.Item2)))

                    { Console.WriteLine("ingreso algun dato mal Vuelva hacer el proceso"); }

                }
            }
            else if (seleccion == "2")
            {
                var s = this.menu_inicial();
            }
            else if (seleccion == "3") { }
            else
            {
                Console.WriteLine("opcion invalida");
                this.menu();
            }
        }

        private (int,string) menu_inicial() 
        {
            Console.WriteLine("INICIAR SESION");
            Console.WriteLine("ingrese usuario");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("ingrese contraseña");
            var contraseña = Console.ReadLine();

            return (id, contraseña);
        }
    }
}
