using System.Data;
using System.Data.SqlClient;

namespace Algoritmos.Clases.Pacmac
{
    class PacmacLadder
    {
        public static bool newPunctuation(Ladderboard ladderboard)//Da de alta un usuario, si todo va bien devuelve true
        {
            bool valid = true;
            if (existPunct(ladderboard) > 0)
            {
                try
                {
                    using (SqlConnection con = Conexion.getConn())
                    {
                        con.Open();
                        SqlCommand comand = new SqlCommand("spUpdScore", con);
                        comand.CommandType = CommandType.StoredProcedure;
                        comand.Parameters.Add("@idJuego", SqlDbType.Int).Value = ladderboard.getIdJuego();
                        comand.Parameters.Add("@fecha", SqlDbType.Date).Value = ladderboard.getFecha();
                        comand.Parameters.Add("@usrName", SqlDbType.NVarChar, 150).Value = ladderboard.getAlias();
                        comand.Parameters.Add("@puntaje", SqlDbType.Int).Value = ladderboard.getPuntaje();
                        comand.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (SqlException)
                {
                    valid = false;
                }
            }
            else
            {//Se inserta
                try
                {
                    using (SqlConnection con = Conexion.getConn())
                    {
                        con.Open();
                        SqlCommand comand = new SqlCommand("spSetScore", con);
                        comand.CommandType = CommandType.StoredProcedure;
                        comand.Parameters.Add("@idJuego", SqlDbType.Int).Value = ladderboard.getIdJuego();
                        comand.Parameters.Add("@fecha", SqlDbType.Date).Value = ladderboard.getFecha();
                        comand.Parameters.Add("@usrName", SqlDbType.NVarChar, 150).Value = ladderboard.getAlias();
                        comand.Parameters.Add("@puntaje", SqlDbType.Int).Value = ladderboard.getPuntaje();
                        comand.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (SqlException)
                {
                    valid = false;
                }
            }
            return valid;
        }
        public static int existPunct(Ladderboard ladderboard)
        {
            int exist = 0;
            try
            {
                using (SqlConnection con = Conexion.getConn())
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand("spIsAPunct", con);
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add("@idJuego", SqlDbType.Int).Value = ladderboard.getIdJuego();
                    comand.Parameters.Add("@usrName", SqlDbType.NVarChar, 150).Value = ladderboard.getAlias();
                    SqlParameter p_result = new SqlParameter("@exist", SqlDbType.Int);
                    p_result.Direction = ParameterDirection.Output;
                    comand.Parameters.Add(p_result);
                    comand.ExecuteNonQuery();
                    exist = int.Parse(comand.Parameters["@exist"].Value.ToString());
                    con.Close();
                }
            }
            catch (SqlException)
            {

            }
            return exist;
        }
    }
}
