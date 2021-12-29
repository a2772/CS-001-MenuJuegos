using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Navios
{
    class Vehiculos
    {
        protected int tamano;//Casillas totales que ocupa
        protected int ubi_centx;//X Donde se ocupa su punto principal (ej. cabina=cabeza del avión)
        protected int ubi_centy;//Y Donde se ocupa su punto principal (ej. cabina=cabeza del avión)
        protected int ubi_centz;//Z Donde se ocupa su punto principal (ej. cabina=cabeza del avión)
        protected int ubi_restates;//Vida restante
        public Vehiculos(int ubix, int ubiy, int ubiz)
        {
            ubi_centx = ubix;
            ubi_centy = ubiy;
            ubi_centz = ubiz;
        }
        public int getx()
        {
            return ubi_centx;
        }
        public int gety()
        {
            return ubi_centy;
        }
        public int getz()
        {
            return ubi_centz;
        }
        public bool getestado()
        {
            if (ubi_restates > 0)
                return true;//Aun le quedan vidas
            else
                return false;//Ya ha sido hundido
        }
        public bool disminuye()//Validando en el objeto Tablero que hay ubicacion actual de este vehículo
        {
            ubi_restates--;
            if (ubi_restates <= 0)
                return true;//se ha hundido y debe retirarse
            else
                return false;
        }
    }
}
