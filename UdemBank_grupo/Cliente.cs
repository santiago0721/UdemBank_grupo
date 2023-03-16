using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UdemBank_grupo
{
    internal class Cliente : Usuario
    {
        protected double cobro;
        protected double balance;
        protected int numero_cuenta;
        public Cliente(int id, string contraseña, int balance) : base(id, contraseña)
        {
            this.balance = balance;
        }

        public int numero_cuenta_()
        {
            return numero_cuenta;
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

        public void actualizar_datos(int id, string contraseña, int balance, int numero_cuenta_) 
        {
            this.id = id;
            this.contraseña = contraseña; 
            this.balance = balance;
            this.numero_cuenta= numero_cuenta_;
        }

    }
}
