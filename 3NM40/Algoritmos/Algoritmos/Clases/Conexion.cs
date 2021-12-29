using System;
using System.Data.SqlClient;

namespace Algoritmos.Clases
{
    class Conexion
    {
        public static SqlConnection getConn()//Regresa la conexión
        {
            String dataSrc = "SRP", dataBase = "dbAlgoritmos";
            SqlConnection conn = new SqlConnection(@"Data Source=" + dataSrc + ";Initial Catalog=" + dataBase +";Integrated Security=True");
            return conn;
        }
    }
}
