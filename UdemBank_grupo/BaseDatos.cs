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
                Console.WriteLine(lector.GetInt32(3));

            }

            lector.Close();
            conexion.Close();
            Console.ReadLine();

        }

        public void escribir_basedatos(int id,string contraseña,int balance,int cuenta,int ubicacion_tabla)
        {
            
            string str1 = "INSERT INTO ";
            string str2 = "(id,contraseña,balance,cuenta) VALUES (@id,@contraseña,@balance,@cuenta)";

            query = ubicacion(ubicacion_tabla, str1, str2);

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            comando.Parameters.AddWithValue("@balance",balance);
            comando.Parameters.AddWithValue("@cuenta",cuenta);
            comando.ExecuteNonQuery();
            conexion.Close() ;  


        }

        public void actualizar_basedatos(int id, string contraseña, double balance, int cuenta, int ubicacion_tabla)
        {
            string str1 = "UPDATE ";
            string str2 = " SET id = @id ,contraseña = @contraseña ,balance = @balance WHERE cuenta = @cuenta";
            query = ubicacion(ubicacion_tabla, str1, str2);


            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            comando.Parameters.AddWithValue("@balance", balance);
            comando.Parameters.AddWithValue("@cuenta", cuenta);
            comando.ExecuteNonQuery();
            conexion.Close();

        }
        
        public (int,string,int,int)? buscar(int cuenta,int ubicacion_tabla)
        {
    
            string str1 = "SELECT * FROM ";
            string str2 = " WHERE id LIKE '%" + cuenta.ToString() + "%'";

            query = ubicacion(ubicacion_tabla, str1, str2);

            conexion.Open();
            SqlCommand comando = new SqlCommand(query,conexion);
            SqlDataReader lector = comando.ExecuteReader();
            
            if (lector.Read()) 
            {
                int id = lector.GetInt32(0);
                string contraseña = lector.GetString(1).ToString();
                int balance = lector.GetInt32(2);
                int cuenta_ = lector.GetInt32(3);

                conexion.Close();
                return (id,contraseña,balance, cuenta_);
            }
            else {
                conexion.Close();
                return null;
            }

        }

        public void eliminar(int cuenta, int ubicacion_tabla)
        {
            string str1 = "DELETE FROM ";
            string str2 = " WHERE cuenta = " + cuenta.ToString();
            
            query = ubicacion(ubicacion_tabla,str1,str2);

            var comprobacion = 0;
            conexion.Open();
            SqlCommand comando = new SqlCommand(query,conexion);
            comprobacion =comando.ExecuteNonQuery();//0 si no lo encuentra 1 si si lo encuentra
            Console.WriteLine(comprobacion.ToString());
            conexion.Close() ;
        }

        private string ubicacion(int ubicacion,string str1, string str2)
        {
            string text;
            switch (ubicacion)
            {
                case 0:
                    text = str1 + "ClientesPLatino" + str2;
                    return text;
                case 1:
                    text = str1 + "ClientesNormales" + str2;
                    return text;
                default:
                    throw new Exception("implementar para cuando el numero sea mayor de 1");
            }
        }



        // ATM
        public List<(int,int)> leer_basedatos_atm()
        {
            List<(int,int)> auxiliar = new List<(int,int)> ();  
            query = "SELECT * FROM Atm";
    
            conexion.Open();

            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {

                auxiliar.Add((lector.GetInt32(0),lector.GetInt32(1)));

            }

            lector.Close();
            conexion.Close();
            return auxiliar;

        }

        public void escribir_basedatos_atm(int id, double balance)
        {

            query = "INSERT INTO Atm (id,balance) VALUES (@id,@balance)";    

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@balance", balance);
            comando.ExecuteNonQuery();
            conexion.Close();


        }

    }
}
