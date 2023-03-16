using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class ClienteRegular:Cliente
    {
        public ClienteRegular(int id, string contraseña, int balance, int numero_cuenta_) : base(id, contraseña, balance)
        {
            cobro = 0.15;
            numero_cuenta = numero_cuenta_;
        } 
    }
}
