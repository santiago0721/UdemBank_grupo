using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UdemBank_grupo
{
    internal class Cliente:Usuario
    {
        protected double cobro;
        protected int balance;
        protected int numero_cuenta;
        public Cliente(int id, string contraseña,int balance) : base(id, contraseña) 
        {
            this.balance = balance;
        }

        public bool verificar_monto_a_retirar(int monto)
        {
            if (monto <= balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
