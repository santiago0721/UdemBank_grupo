using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal abstract class Sucursal
    {
        public abstract bool disponibilidad_retiro(int valor);

        public abstract void depositar(int valor);

        public abstract (Sucursal, int) retirar(int valor);
    }
}

