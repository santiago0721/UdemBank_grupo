using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class Usuario
    {
        protected int id;
        protected string contraseña;


        public Usuario(int id, string contraseña) 
        {
            this.id = id;
            this.contraseña = contraseña;
        }

        public bool iniciar_sesion(int id,string contraseña)
        {
            if ((this.id == id) & (this.contraseña == contraseña)) { return true; }
            else{ return false; }  
        }

    }
}
