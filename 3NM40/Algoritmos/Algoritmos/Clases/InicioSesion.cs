using System;
using System.Data;
using System.Data.SqlClient;

namespace Algoritmos.Clases
{
    class InicioSesion
    {
        public static int login(string usuario, string password)//Encuentra si la cuenta y password son correctos devolviendo el tipo de usuario
        {
            int cuenta;
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand("sp_Login", con);
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add("@Cuenta", SqlDbType.NVarChar, 18).Value = usuario;
                    comand.Parameters.Add("@Pass", SqlDbType.NVarChar, 128).Value = password;
                    SqlParameter p_result = new SqlParameter("@Result", SqlDbType.Int);
                    p_result.Direction = ParameterDirection.Output;
                    comand.Parameters.Add(p_result);
                    comand.ExecuteNonQuery();
                    cuenta = int.Parse(comand.Parameters["@Result"].Value.ToString());
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return cuenta;
        }
        public static string getCveEntidad(int cve)
        {
            string cveEntity = "DF";
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand("spGetEntFedCve", con);
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add("@idEntidad", SqlDbType.Int).Value = cve;
                    SqlParameter p_result = new SqlParameter("@CveEntidad", SqlDbType.NVarChar, 2);
                    p_result.Direction = ParameterDirection.Output;
                    comand.Parameters.Add(p_result);
                    comand.ExecuteNonQuery();
                    cveEntity = comand.Parameters["@CveEntidad"].Value.ToString();
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return cveEntity;
        }
        public static DataTable llenadoddl(String sp)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sp;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(dt);
                        }
                    }
                    con.Close();
                }
            }
            catch (SqlException)
            {
                
            }
            return dt;
        }
        public static bool signUp(Usuario usuario)//Da de alta un usuario, si todo va bien devuelve true
        {
            bool valid = true;
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand("sp_SignUp", con);
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add("@Cuenta", SqlDbType.NVarChar, 150).Value = usuario.getUsrName();
                    comand.Parameters.Add("@Passwd", SqlDbType.NVarChar, 20).Value = usuario.getPasswd();
                    comand.Parameters.Add("@Nacimiento", SqlDbType.Date).Value = usuario.getFechaNac();
                    //Foto
                    SqlParameter paramImageData = new SqlParameter() { ParameterName = "@Foto", Value = usuario.getFoto() };
                    comand.Parameters.Add(paramImageData);
                    comand.Parameters.Add("@Sexo", SqlDbType.Int).Value = usuario.getIdSexo();
                    comand.Parameters.Add("@TipoUsr", SqlDbType.Int).Value = usuario.getIdTipoUser();
                    comand.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException)
            {
                valid = false;
            }
            return valid;
        }
    }
}
