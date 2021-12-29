using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Clases
{
    class Actualizaciones
    {
        public static void updtFoto(Usuario usuario)
        {
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand("updtFoto", con);
                    comand.CommandType = CommandType.StoredProcedure;
                    //Parámetros
                    SqlParameter idPasswd = new SqlParameter() { ParameterName = "@idPasswd", Value = usuario.getIdPassword()};
                    comand.Parameters.Add(idPasswd);
                    SqlParameter foto = new SqlParameter() { ParameterName = "@foto", Value = usuario.getFoto() };
                    comand.Parameters.Add(foto);
                    comand.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
