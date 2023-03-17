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
        BaseDatos base_datos;

        public UdemBank() 
        {
            base_datos = new BaseDatos();
            lista_atms= new List<ATM>();    
        }

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

        public Cliente buscar(int id) 
        {
            var buscar_cliente = base_datos.buscar(id, 0);
            if ( buscar_cliente is null) 
            {
                buscar_cliente = base_datos.buscar(id, 1);
                if (buscar_cliente is null)

                    
                    { return null ; }

                else 
                {
                    Cliente cliente = new ClienteRegular(buscar_cliente.Value.Item1, buscar_cliente.Value.Item2, buscar_cliente.Value.Item3, buscar_cliente.Value.Item4);
                    return cliente;
                }
            }
            else
            {
                Cliente cliente = new ClientePlatino(buscar_cliente.Value.Item1, buscar_cliente.Value.Item2, buscar_cliente.Value.Item3, buscar_cliente.Value.Item4);
                return cliente ;
            }
        }


        public void actualizar_cliente(Cliente cliente)
        {
            if (cliente is ClientePlatino) 
            {
                base_datos.actualizar_basedatos()
            }
        }

        
    }
}
