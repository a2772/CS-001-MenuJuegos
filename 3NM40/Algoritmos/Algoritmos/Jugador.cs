using System;

namespace Algoritmos
{
    class Jugador
    {
        private int Aviones, Barcos, Sub_p, Sub_g, lim;
        public Jugador(int tam_x, int tam_y, int tam_z)//Los tamaños máximos y mínimos se validan antes
        {//En función del tamaño, se generan los navíos, las municiones se eligen y reciben en esta clase
            int esp_aereo, esp_mar;
            //Definimos el número de navíos en función del tamaño con las fórmulas:
            lim = Convert.ToInt32(tam_y * 0.3);
            esp_mar = (tam_y - lim) * tam_x * tam_z;
            esp_aereo = lim * tam_x * tam_z;
            Aviones = Convert.ToInt32(Math.Round(esp_aereo * 0.02));//Modificable
            if (Aviones == 0) Aviones++;
            Barcos = Convert.ToInt32(tam_z * tam_x * 0.004);
            if (Barcos == 0) Barcos++;
            Sub_g = Convert.ToInt32(Math.Round(.5 * esp_mar * .04));
            Sub_p = Convert.ToInt32(Math.Round(.5 * esp_mar * .06) + 1);
        }
        public void retira(string tipo)//Retira un vehículo
        {
            switch (tipo)
            {
                case "Sub_p":
                    Sub_p--;
                    break;
                case "Sub_g":
                    Sub_g--;
                    break;
                case "Barco":
                    Barcos--;
                    break;
                case "Avion":
                    Aviones--;
                    break;
            }
        }
        public int getlimit()
        {
            return lim;
        }
        public int getAviones()
        {
            return Aviones;
        }
        public int getBarcos()
        {
            return Barcos;
        }
        public int getSub_p()
        {
            return Sub_p;
        }
        public int getSub_g()
        {
            return Sub_g;
        }
    }
}
