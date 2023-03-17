using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class SucursalVirtual:Sucursal
    {
        public override bool disponibilidad_retiro(int valor) { return true;  }

        public override void depositar(int valor) {}

        public override (Sucursal, int) retirar(int valor) { return (this, valor); }
    }
}
