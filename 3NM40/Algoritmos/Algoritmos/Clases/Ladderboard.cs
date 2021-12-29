using System;

namespace Algoritmos.Clases
{
    class Ladderboard
    {
        private int idPuntaje;
        private int puntaje;
        private String alias;
        private DateTime fecha;
        private int idPassword;
        private int idJuego;
        public int getIdPuntaje()
        {
            return idPuntaje;
        }
        public void setIdPuntaje(int idPuntaje)
        {
            this.idPuntaje = idPuntaje;
        }
        public int getPuntaje()
        {
            return puntaje;
        }
        public void setPuntaje(int puntaje)
        {
            this.puntaje = puntaje;
        }
        public String getAlias()
        {
            return alias;
        }
        public void setAlias(String alias)
        {
            this.alias = alias;
        }
        public DateTime getFecha()
        {
            return fecha;
        }
        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }
        public int getIdPassword()
        {
            return idPassword;
        }
        public void setIdPassword(int idPassword)
        {
            this.idPassword = idPassword;
        }
        public int getIdJuego()
        {
            return idJuego;
        }
        public void setIdJuego(int idJuego)
        {
            this.idJuego = idJuego;
        }
    }
}
