using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class ATM:Sucursal
    {
        int id;
        int balance;

        public ATM(int id, int balance)
        {
            this.id = id;
            this.balance = balance;
        }

        public override bool disponibilidad_retiro(int valor) 
        {
            if (valor <= balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public override void depositar(int valor)
        {
            balance += valor;
            
        }

        public override (Sucursal, int) retirar(int valor)
        {
            if (this.disponibilidad_retiro(valor))
            {
                balance -= valor;
                return (this, valor);
            }
            else
            {
                throw new Exception("Falta");
            }
        }

        public (int,double) datos() 
        { return (this.id, this.balance); }

    }
}
