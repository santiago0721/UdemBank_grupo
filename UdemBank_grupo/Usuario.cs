﻿using System;
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
            Console.WriteLine(this.id);
            Console.WriteLine(this.contraseña);
            Console.WriteLine(id);
            Console.WriteLine(contraseña);
            if ((this.id == id) & (this.contraseña == contraseña)) {
                Console.WriteLine("siiiiii");
                Console.Read();
                return true; }
            else{ return false; }  
        }

    }
}
