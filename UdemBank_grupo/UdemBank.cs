using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class UdemBank
    {
        int balance_general;
        List<ATM> lista_atms;

        public List<ATM> disponibilidad_lista_atms(int valor)
        {
            List<ATM> lista_ = new List<ATM>();
            foreach (ATM atm in lista_atms)
            {
                if (atm.disponibilidad_retiro(valor))
                {
                    lista_.Add(atm);

                }
            }
            if (lista_.Count > 0)
            {
                return lista_;
            }
            else
            {
                return null;
            }

        }
    }
}
