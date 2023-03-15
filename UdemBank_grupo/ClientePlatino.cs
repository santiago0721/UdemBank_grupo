using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class ClientePlatino:Cliente
    {
        public ClientePlatino(int id, string contraseña, int balance, int numero_cuenta_):base(id,contraseña,balance) 
        {
            cobro = 0.5;
            numero_cuenta = numero_cuenta_;
        }
    }
}
