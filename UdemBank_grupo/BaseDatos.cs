using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank_grupo
{
    internal class BaseDatos
    {
        string query;
        string conexion_string;
        SqlConnection conexion;
        public BaseDatos()
        {
            conexion_string = "server=LAPTOP-5H1A7EVN ; database=Banco ; integrated security = true";
            conexion = new SqlConnection(conexion_string);
        }
        
        public void leer_basedatos(int ubicacion_tabla)
        {
            string str1 = "SELECT * FROM ";
            switch (ubicacion_tabla)
            {
                case 0:
                    query = str1 + "ClientesPLatino";
                    break;
                case 1:
                    query = str1 + "ClientesNormales";
                    break;
                default:
                    throw new Exception("implementar para cuando el numero sea mayor de 1");
            }


            conexion.Open();

            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {

                Console.WriteLine(lector.GetString(1).ToString());
                Console.WriteLine(lector.GetInt32(0));

            }

            lector.Close();
            conexion.Close();
            Console.ReadLine();

        }

        public void escribir_basedatos(int id,string contraseña,int balance,int cuenta,int ubicacion_tabla)
        {
            
            string str1 = "INSERT INTO ";
            string str2 = "(id,contraseña,balance,cuenta) VALUES (@id,@contraseña,@balance,@cuenta)";
            switch(ubicacion_tabla)
            {
                case 0:
                    query = str1 + "ClientesPLatino" + str2;
                    break;
                case 1:
                    query = str1 + "ClientesNormales" + str2;
                    break;
                default:
                    throw new Exception("implementar para cuando el numero sea mayor de 1");
            }

            
            
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            comando.Parameters.AddWithValue("@balance",balance);
            comando.Parameters.AddWithValue("@cuenta",cuenta);
            comando.ExecuteNonQuery();
            conexion.Close() ;  


        }

        public void actualizar_basedatos(int id, string contraseña, int balance, int cuenta, int ubicacion_tabla)
        {
            string str1 = "UPDATE ";
            string str2 = " SET id = @id ,contraseña = @contraseña ,balance = @balance WHERE cuenta = @cuenta";
            switch (ubicacion_tabla)
            {
                case 0:
                    query = str1 + "ClientesPLatino" + str2;
                    break;
                case 1:
                    query = str1 + "ClientesNormales" + str2;
                    break;
                default:
                    throw new Exception("implementar para cuando el numero sea mayor de 1");
            }



            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            comando.Parameters.AddWithValue("@balance", balance);
            comando.Parameters.AddWithValue("@cuenta", cuenta);
            comando.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
