using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            LeerRegistros();
        }

        static void LeerRegistros()
        {
            String cadenaconexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;PASSWORD=azure";
            SqlConnection cn = new SqlConnection(cadenaconexion);
            SqlCommand com = new SqlCommand();
            SqlDataReader reader;
            //creamos la consulta
            String consulta = "SELECT * FROM DEPT";
            //conexion a usar
            com.Connection = cn;
            //consulta a realizar
            com.CommandText = consulta;
            //tipo de consulta
            com.CommandType = System.Data.CommandType.Text;
            //abrimos conexion
            cn.Open();
            //ejecutamos la consulta con un lector
            reader = com.ExecuteReader();
            //cada vez que ejecutamos read lee una fila
            //reader.Read();
            //para recuperar datos se utiliza ["columna"]
            //String nombre = reader["DNOMBRE"].ToString();
            //Console.WriteLine(nombre);
            //leer filas mientras haya
            while (reader.Read())
            {
                String nombre = reader["DNOMBRE"].ToString();
                String localidad = reader["LOC"].ToString();
                Console.WriteLine(nombre + " - " + localidad);
            }
            //cerramos conexion
            reader.Close();
            cn.Close();

        }
    }
}
