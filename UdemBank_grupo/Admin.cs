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

        public Admin(int id, string contraseña) : base(id, contraseña)
        {
            numero_cuenta_disponible = 0000000001;
        }

        public Cliente crear_usuario(int id, string contraseña, int balance, int seleccion)
        {
            Cliente new_client;

            switch(seleccion)
            {
                case 1:
                    
                    new_client = new ClienteRegular(id, contraseña, balance, numero_cuenta_disponible);
                    numero_cuenta_disponible+= 1;
                    return new_client;

                case 2:

                    new_client = new ClientePlatino(id, contraseña, balance, numero_cuenta_disponible);
                    numero_cuenta_disponible+= 1;
                    return new_client;

                default:
                    throw new Exception("hpta");
                
                 
            }
        }

       

    }
}
