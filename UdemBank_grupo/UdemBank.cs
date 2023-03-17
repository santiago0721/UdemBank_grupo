using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class UdemBank
    {
        static int balance_general;
        List<ATM> lista_atms;
        BaseDatos base_datos;
        Admin admin;


        public UdemBank() 
        {
            base_datos = new BaseDatos();
            var datos_admin = base_datos.basedatosAdmin();
            admin = new Admin(datos_admin.Item1, datos_admin.Item2,datos_admin.Item3,datos_admin.Item4);
            Console.WriteLine(admin);
            lista_atms= new List<ATM>();
            creacion_atms();

        }
        
        public Admin devolver_admin() {return admin;}

        public void creacion_atms() // siempre se debe llamar cuando se actualiza un atm
        {
            lista_atms.Clear();
            var x = base_datos.leer_basedatos_atm();
            foreach((int,int) creador in x) 
            {
                lista_atms.Add(new ATM(creador.Item1, creador.Item2));
            }

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

        public Cliente buscar(int cuenta) 
        {
            var buscar_cliente = base_datos.buscar(cuenta, 0);
            if ( buscar_cliente is null) 
            {
                buscar_cliente = base_datos.buscar(cuenta, 1);
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
            var datos = cliente.datos();
            if (cliente is ClientePlatino) 
            {
                base_datos.actualizar_basedatos(datos.Item1, datos.Item2, datos.Item3, datos.Item4, 0);
            }
            else 
            {
                base_datos.actualizar_basedatos(datos.Item1, datos.Item2, datos.Item3, datos.Item4, 1);
            }
        }

        public void actualizar_atm(ATM atm) 
        {
            var datos = atm.datos();
            base_datos.actualizar_basedatos_atm(datos.Item1,datos.Item2);
            this.creacion_atms();
        }

        public bool crear_usuario(int id_,string contraseña_,int balance_, int cuenta_,int tablabd) //organizar
        {
            admin.crear_usuario(id_, contraseña_, balance_, tablabd);
            if (base_datos.buscar(cuenta_,tablabd) is null) {return false;} 
            
            else 
            {
                Cliente cliente = admin.crear_usuario(id_, contraseña_, balance_, tablabd);
                base_datos.escribir_basedatos(id_, contraseña_, balance_, cliente.numero_cuenta_(), tablabd);
                return true;
            }
            
        }

        public bool eliminar_usuario(int cuenta) 
        {
            if (base_datos.buscar(cuenta,0) is null) 
            {
                if (base_datos.buscar(cuenta,1) is null) 
                {  
                    return false;
                }
                else 
                {
                    base_datos.eliminar(cuenta,1);
                    return true;
                }
            }
            else 
            {
                base_datos.eliminar(cuenta, 0);
                return true;
            }
        }

        public bool modificar(int id,string contraseña,int balance, int cuenta) 
        {
            if (base_datos.buscar(cuenta, 0) is null)
            {
                if (base_datos.buscar(cuenta, 1) is null)
                {
                    return false;
                }
                else
                {
                    base_datos.actualizar_basedatos(id,contraseña,balance,cuenta, 1);
                    return true;
                }
            }
            else
            {
                base_datos.actualizar_basedatos(id, contraseña, balance, cuenta, 0);
                return true;
            }
        }


        public List<ATM> devolver_lista() { return lista_atms; }

        public void crear_atm(int balance) 
        {
            
            var s = admin.crear_atm(balance);
            (int, double) resultado = s.datos(); 
            base_datos.escribir_basedatos_atm(resultado.Item1,resultado.Item2);
            this.creacion_atms();
           
        }

        public void actualizar_administrador() 
        {
            var datos = admin.datos();
            base_datos.actualizar_admin(datos.Item1, datos.Item2, datos.Item3, datos.Item4);
        }
        
    }
}
