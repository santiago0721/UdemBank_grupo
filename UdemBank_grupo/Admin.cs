using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class Admin:Usuario
    {
        private int numero_cuenta_disponible;
        private int numero_cuenta_disponible_atm;

        public Admin(int id, string contraseña,int num_cuenta,int num_cuenta_atm ) : base(id, contraseña)
        {
            numero_cuenta_disponible = num_cuenta;
            numero_cuenta_disponible_atm= num_cuenta_atm;
        }

        public (int,string,int,int) datos() 
        {
            return (id, contraseña, numero_cuenta_disponible, numero_cuenta_disponible_atm);
        }

        public Cliente crear_usuario(int id, string contraseña, int balance, int seleccion)
        {
            Cliente new_client;
            switch(seleccion)
            {
                case 1:
                    
                    new_client = new ClienteRegular(id, contraseña, balance, numero_cuenta_disponible);
                    numero_cuenta_disponible-= 1;
                    return new_client;

                case 2:

                    new_client = new ClientePlatino(id, contraseña, balance, numero_cuenta_disponible);
                    numero_cuenta_disponible-= 1;
                    return new_client;

                default:
                    throw new Exception("opcion invalida");
                
                 
            }
        }
        public int cuenta_disponilible__() { return numero_cuenta_disponible; }

        public ATM crear_atm(int balance) 
        {
            // validar si ya no existe el id.
            numero_cuenta_disponible_atm += 1;
            return new ATM(numero_cuenta_disponible_atm, balance);

        }


        public Cliente actualizar_usuario(int id, string contraseña, int balance, int numero_cuenta,Cliente cliente) 
        {
            cliente.actualizar_datos(id,contraseña,balance,numero_cuenta);

            return cliente;
        }

        public int eliminar_usuario(Cliente usuario)
        {
            return usuario.numero_cuenta_();
            //eliminar usuario en base de datos Falta implementar 
        }


       

    }
}
