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
                "[3] salir\n ");
            var seleccion = Console.ReadLine();
            if (seleccion == "1")
            {
                var inicio_sesion = this.menu_inicial();
                var cliente = banco.buscar(inicio_sesion.Item1);
                if (cliente is null) { Console.WriteLine("esta cuenta no existe "); this.menu(); }

                else
                {
                    if (cliente.iniciar_sesion(inicio_sesion.Item1, inicio_sesion.Item2))
                    { this.menu_cliente(cliente); }
                    else 
                    {
                        Console.WriteLine("ingreso algun dato mal Vuelva hacer el proceso"); this.menu();
                    }
                }
            }
            else if (seleccion == "2")
            {
                var inicio_sesion = this.menu_inicial();
                Admin admin = banco.devolver_admin();
                if (admin.iniciar_sesion(inicio_sesion.Item1, inicio_sesion.Item2)) 
                {
                    this.menu_admin(admin);
                }
                else { Console.WriteLine("ingreso algun dato mal"); this.menu(); }


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

        private void menu_cliente(Cliente cliente) 
        {

            Console.WriteLine("BIENVENIDO\n" +
                "[1] depositar\n" +
                "[2] retirar en atm\n" +
                "[3] retirar en sucursal virtual\n" +
                "[4] transferir a otro usuario\n");
            
            string opcion = Console.ReadLine();

            switch(opcion) 
            {
                case "1":
                    this.depositar(cliente);
                    break;
                case "2":
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine();
                    break;
                default: 
                    Console.WriteLine("opcion incorrecta ");
                    this.menu_cliente(cliente);
                    break;
            }
        
        }

        public void menu_admin(Admin admin) 
        {
            Console.WriteLine("BIENVENIDO\n" +
                "[1] Crear cliente\n" +
                "[2] eliminar usuario\n" +
                "[3] modificar usuario\n" +
                "[4] crear atm\n");//falta

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    var d_nuevo_u = crear_usuario(admin);
                    var x = banco.crear_usuario(d_nuevo_u.Item1, d_nuevo_u.Item2, d_nuevo_u.Item3, d_nuevo_u.Item4,d_nuevo_u.Item5);
                    if (x) { Console.WriteLine("usuario creado"); }
                    else { Console.WriteLine("usuario ya existente"); }
                    Console.Read();
                    break;
                case "2":
                    Console.WriteLine("ingrese cuenta que desea eliminar");
                    int cuenta = int.Parse(Console.ReadLine());
                    if (banco.eliminar_usuario(cuenta)) { Console.WriteLine("cuenta eliminada"); }
                    else { Console.WriteLine("no se pudo hacer esto ya que no existe esta cuenta"); }
                    Console.Read();
                    break;
                case "3":
                    var actualizar = this.actualizar();
                    if (banco.modificar(actualizar.Item1, actualizar.Item2, actualizar.Item3, actualizar.Item4))
                        {
                        Console.WriteLine("se actualizo el usuario");
                        }
                    else { Console.WriteLine("no existe el usuario"); }
                    
                    Console.Read();
                    break;
                case "4":
                    Console.WriteLine("ingrese balance");
                    int balance = int.Parse(Console.ReadLine());
                    banco.crear_atm(balance);

                    Console.WriteLine("se creo correctamente");
                    Console.ReadLine();
                    
                    break;


                default:
                    Console.WriteLine("opcion incorrecta ");
                    this.menu_admin(admin);
                    break;
            }
        }

        private void depositar(Cliente cliente) 
        {
            Console.WriteLine("ingrese el valor que desee depositar");
            int opcion = int.Parse(Console.ReadLine());
            var atms_disponibles = banco.disponibilidad_lista_atms(opcion);

            if (atms_disponibles is null) { Console.WriteLine("ningun Atm puede hacer esto"); }

            else 
            {
                Console.WriteLine("escoja el atm que prefiera ");
                int indice = 0;
                foreach(ATM atm in atms_disponibles) 
                {
                    Console.WriteLine($"[{indice}] {atm}");
                    indice++;
                }

                int op = int.Parse(Console.ReadLine());
                ATM atm_ = atms_disponibles[op];
                atm_.depositar(opcion);
                banco.actualizar_atm(atm_);
                cliente.sumar_al_balance_cliente(opcion);
                banco.actualizar_cliente(cliente);

                Console.WriteLine("se realizo la operacion");
                Console.ReadLine();
            }

        }


        public (int, string, int, int,int) crear_usuario(Admin admin)
        {
            Console.WriteLine("ingrese id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("ingrese contraseña");
            string contraseña = Console.ReadLine();
            Console.WriteLine("ingrese balance");
            int balance = int.Parse(Console.ReadLine());
            int cuenta = admin.cuenta_disponilible__();
            int tabla = int.Parse(Console.ReadLine());
            return (id, contraseña, balance, cuenta,tabla) ;//ingrese tabla
        }

        public (int, string, int, int) actualizar ()
        {
            Console.WriteLine("ingrese id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("ingrese contraseña");
            string contraseña = Console.ReadLine();
            Console.WriteLine("ingrese balance");
            int balance = int.Parse(Console.ReadLine());
            Console.WriteLine("ingrese balance");
            int cuenta = int.Parse(Console.ReadLine());
            return (id, contraseña, balance, cuenta);
        }
    }

    

}


