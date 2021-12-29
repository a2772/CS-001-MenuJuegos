using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Armas
{
    class cArma4 : cArma2
    {//Es una bomba que explota las casillas a su alrededor
        public cArma4(int mun) : base(mun)
        {
            municiones = mun;
        }
        public int disparo(ref char[,,] tablero, int x, int y, int z, int maxX, int maxY, int maxZ, ref int pi, ref int pj, ref int pk, ref int li, ref int lj, ref int lk)//Sobreescritura
        {//x,y,z se dan según el arreglo (0 en adelante). MaxX,Y,Z se dan en términos de tamaño reales, (1 en adelante)
            int acertados = 0, i = x - 1, j = y - 1, k = z - 1;
            li = x + 1; lj = y + 1; lk = z + 1;//Se establecen los límites
            //Luego, si es el caso de que esté en aguna orilla hace los cambios necesarios
            if (x == 0)//Limites X
                i = 0;
            else if (x == maxX - 1)
                li = maxX - 1;
            if (y == 0)//Limites Y
                j = 0;
            else if (y == maxY - 1)
                lj = maxY - 1;
            if (z == 0)//Limites Z
                k = 0;
            else if (z == maxZ - 1)
                lk = maxZ - 1;
            //Se asignan a los parametros por referencia
            pi = i; pj = j; pk = k;
            //Comienza el recorrido del arreglo en los límites establecidos comenzando desde el vértice origen (0,0,0)
            for (i = pi; i <= li; i++)
                for (j = pj; j <= lj; j++)
                    for (k = pk; k <= lk; k++)
                        if (disp(ref tablero, i, j, k))//Si el disparo marca la ubicacion se agrega un acertado
                            acertados++;
            municiones--;//Antes de llamar a este método comprobar que queden municiones
            return acertados;//En este caso como pueden ser varios objetivos regresa solo cuantos fueron afectados
        }
        public bool phantom(char[,,] tablero, int x, int y, int z, int maxX, int maxY, int maxZ)//Sobreescritura
        {//x,y,z se dan según el arreglo (0 en adelante). MaxX,Y,Z se dan en términos de tamaño, (1 en adelante)
            int i = x - 1, j = y - 1, k = z - 1, li = x + 1, lj = y + 1, lk = z + 1, ij, ik;
            bool desperdiciado = true;
            //En este caso se cuenta cuantas veces se acierta. Se hacen 6 comprobaciones laterales donde se detarmina la posición de inicio
            //inicializa de donde partirá
            if (x == 0)//Limites X
                i = 0;
            else if (x == maxX - 1)
                li = maxX - 1;
            if (y == 0)//Limites Y
                j = 0;
            else if (y == maxY - 1)
                lj = maxY - 1;
            if (z == 0)//Limites Z
                k = 0;
            else if (z == maxZ - 1)
                lk = maxZ - 1;
            //Se asignan a los parametros por referencia
            ij = j; ik = k;
            //Comienza el recorrido del arreglo en los límites establecidos comenzando desde el vértice origen (0,0,0)
            for (; i <= li; i++)
                for (j = ij; j <= lj; j++)
                    for (k = ik; k <= lk; k++)
                        if (!phant(tablero, i, j, k))
                        {//Si alguno no se desperdicia, se sale
                            desperdiciado = false;
                            k = lk + 1;
                            j = lj + 1;
                            i = li + 1;
                        }
            return desperdiciado;
        }
    }
}
