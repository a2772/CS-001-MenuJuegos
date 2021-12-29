using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Armas
{
    class cArma2 : cArma1
    {//Arma vertical, va de la capa 0 valor en Y hasta el límite
        protected int municiones;//A partir de aqui ya se cuenta con municiones específicas
        public cArma2(int mun)//Constructor del arma que pide las municiones iniciales y las almacena en la variable protegida municiones
        {
            municiones = mun;
        }
        public int getmun()//Regresa las municiones restantes
        {
            return municiones;
        }
        public int disparo(ref char[,,] tablero, int x, int y, int z, int maxY)
        {//Usa el disparo 2: Vertical de arriba a abajo
            int acertado = -1;//Si no acierta nada, se queda en -1
            int j;
            for (j = 0; j < maxY; j++)//Recorre de 0 al límite y comprueba que haya algo en el disparo básico
            {
                if (disp(ref tablero, x, j, z))
                {//Si se acierta, se sale del ciclo y marca acertado en la posición en y donde acertó
                    acertado = j;
                    j = maxY;
                }
            }
            municiones--;//Antes de llamar a este método comprobar que queden municiones, aquí se reducen
            return acertado;
        }
        public bool pantom(char[,,] tablero, int x, int y, int z, int maxY)//Phantom o fantasma, porque no es un disparo en si, sino que recorre el arreglo sin afectar nada
        {//Comprueba si el disparo vertical tendría sentido en alguna casilla o si todas están marcadas y por lo tanto se desperdició
            bool desperdiciado = true;//Es verdadero hasta que se demuetre que en al menos una casilla no se desperdicia
            int j;
            for (j = 0; j < maxY; j++)
            {
                if (!phant(tablero, x, j, z))//Si en alguna ubicación el phantom básico no se activa, el disparo se aprovechó
                {
                    desperdiciado = false;
                    j = maxY;
                }
            }
            return desperdiciado;
        }
    }
}
