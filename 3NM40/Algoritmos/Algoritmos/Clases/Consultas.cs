using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace Algoritmos.Clases
{
    class Consultas
    {
        public static Usuario getUsrByUsrname(String userNameStr)
        {
            Usuario usuario = new Usuario();
            String Passw;
            DateTime FechaNac;
            int IdPassw, IdSexo, IdTipoUser;
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand("spGetUsr", con);
                    comand.CommandType = CommandType.StoredProcedure;
                    //Parámetros
                    SqlParameter usrName = new SqlParameter() { ParameterName = "@usrName", Value = userNameStr };
                    comand.Parameters.Add(usrName);
                    SqlParameter passwd = new SqlParameter() { ParameterName = "@passwd", Size = 20, Direction = ParameterDirection.Output };
                    comand.Parameters.Add(passwd);
                    SqlParameter fechaNac = new SqlParameter() { ParameterName = "@fechaNac", Value = DateTime.Now, Direction = ParameterDirection.Output };
                    comand.Parameters.Add(fechaNac);
                    SqlParameter idPasswd = new SqlParameter() { ParameterName = "@idPasswd", Value = -1, Direction = ParameterDirection.Output };
                    comand.Parameters.Add(idPasswd);
                    SqlParameter idSexo = new SqlParameter() { ParameterName = "@idSexo", Value = -1, Direction = ParameterDirection.Output };
                    comand.Parameters.Add(idSexo);
                    SqlParameter idTipoUser = new SqlParameter() { ParameterName = "@idTipoUser", Value = -1, Direction = ParameterDirection.Output };
                    comand.Parameters.Add(idTipoUser);
                    //Ejecutando y recuperando valores
                    comand.ExecuteNonQuery();
                    Passw = comand.Parameters["@passwd"].Value.ToString();
                    FechaNac = Convert.ToDateTime(comand.Parameters["@fechaNac"].Value.ToString());
                    //usuario.setIdPassword(System.Text.Encoding.ASCII.GetBytes(comand.Parameters["@foto"].Value.ToString()));
                    IdPassw = Convert.ToInt32(comand.Parameters["@idPasswd"].Value.ToString());
                    IdSexo = Convert.ToInt32(comand.Parameters["@idSexo"].Value.ToString());
                    IdTipoUser = Convert.ToInt32(comand.Parameters["@idTipoUser"].Value.ToString());
                    con.Close();
                    //Obteniendo datos
                    usuario.setUsrName(userNameStr);
                    usuario.setPasswd(Passw);
                    usuario.setFechaNac(FechaNac);
                    usuario.setIdPassword(IdPassw);
                    usuario.setIdSexo(IdSexo);
                    usuario.setIdTipoUser(IdTipoUser);
                    //Foto
                    usuario.setFoto(getFotoById(usuario));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
                throw ex;
            }
            return usuario;
        }
        public static Byte[] getFotoById(Usuario usuario)
        {
            byte[] countryCodes = new byte[9999999];
            Byte[] array;
            using (SqlConnection con = Conexion.getConn())
            {
                SqlCommand command = new SqlCommand("getFotoById", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@idPasswd", SqlDbType.Int).Value = usuario.getIdPassword();
                SqlParameter foto = new SqlParameter() { ParameterName = "@foto", Value = countryCodes, Direction = ParameterDirection.Output };
                command.Parameters.Add(foto);
                con.Open();
                command.ExecuteNonQuery();
                array = Encoding.ASCII.GetBytes(command.Parameters["@foto"].Value.ToString());
                con.Close();
            }
            return array;
        }
        public static int getPunctTotal(Usuario usuario)
        {
            int puntuacion = 0;
            using (SqlConnection con = Conexion.getConn())
            {
                con.Open();
                SqlCommand command = new SqlCommand("getPunctTotal", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@idPasswd", SqlDbType.Int).Value = usuario.getIdPassword();
                SqlParameter p_result = new SqlParameter("@puntos", SqlDbType.Int);
                p_result.Direction = ParameterDirection.Output;
                command.Parameters.Add(p_result);
                command.ExecuteNonQuery();
                try
                {
                    puntuacion = int.Parse(command.Parameters["@puntos"].Value.ToString());
                }
                catch (Exception)
                {

                }
                con.Close();
            }
            return puntuacion;
        }
    }
}
