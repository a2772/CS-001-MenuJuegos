using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Armas
{
    class cArma3 : cArma2
    {
        public cArma3(int mun) : base(mun)
        {//Arma horizontal, va desde el frente de la armada (la posición final de X desde el punto de vista del jugador) hasta el final (posición 0)
            municiones = mun;
        }
        public int disparo(ref char[,,] tablero, int y, int z, int maxX)//Sobreescritura del metodo en arma 2
        {//Como va del limite a 0 se pude el límite
            int acertado = -1;//Si no golpea en ninguna parte regresa -1
            int i;
            for (i = maxX - 1; i >= 0; i--)//Como MaxX es el valor real, se le resta 1 para posición del arreglo
            {
                if (disp(ref tablero, i, y, z))
                {//Si se acierta, se sale del ciclo y marca acertado en la posición de x
                    acertado = i;//Primero se marca la posición
                    i = -1;//Luego sale
                }
            }
            municiones--;//Antes de llamar a este método comprobar que queden municiones
            return acertado;
        }
        public bool phantom(char[,,] tablero, int y, int z, int maxX)//Regresa true si se desperdicia
        {
            bool desperdiciado = true;
            int i;
            for (i = maxX - 1; i >= 0; i--)
            {
                if (!phant(tablero, i, y, z))
                {
                    desperdiciado = false;
                    i = -1;//sale
                }
            }
            return desperdiciado;
        }
    }
}
