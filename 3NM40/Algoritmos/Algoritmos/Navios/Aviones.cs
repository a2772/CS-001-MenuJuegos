using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Navios
{
    class Aviones : Vehiculos
    {
        public Aviones(int ubix, int ubiy, int ubiz) : base(ubix, ubiy, ubiz)
        {
            tamano = 6;
            ubi_restates = tamano - 4;//Solo tiene dos impactos
        }
        public bool coord(int x, int y, int z)//Deben ser del arreglo, no del tablero
        {//Busca si la coordenada forma parte del avión, como en tablero se verifica si hay que quitar o no, aqui solo se verifica si forma parte de el avión con el objeto en cuestión llamando a este método
            bool ispart = false;
            if (y == ubi_centy)//Como es igual la atura en todos los casos puede comprobarse antes
            {
                if (x == ubi_centx && z == ubi_centz)//cabeza
                    ispart = true;
                else if (x == ubi_centx - 1 && z == ubi_centz)//centro
                    ispart = true;
                else if (x == ubi_centx - 1 && z == ubi_centz + 1)//ala izquierda
                    ispart = true;
                else if (x == ubi_centx - 1 && z == ubi_centz - 1)//ala derecha
                    ispart = true;
                else if (x == ubi_centx - 2 && z == ubi_centz)//Detrás de las alas
                    ispart = true;
                else if (x == ubi_centx - 3 && z == ubi_centz)//Cola
                    ispart = true;
            }
            return ispart;
        }
        public int gettype(int x, int y, int z)//Devuelve el tipo de parte del avión a partir de un sistema complejo de coordenadas x,y,z: 1-cabeza,2-parte central,3-ala izquierda,4-ala derecha,5-parte trasera,6-cola
        {//regresa 0 si no es parte de este avión
            if (y == ubi_centy)//Como es igual la atura en todos los casos puede comprobarse antes
            {
                if (x == ubi_centx && z == ubi_centz)//cabeza
                    return 1;
                else if (x == ubi_centx - 1 && z == ubi_centz)//centro
                    return 2;
                else if (x == ubi_centx - 1 && z == ubi_centz + 1)//ala izquierda
                    return 3;
                else if (x == ubi_centx - 1 && z == ubi_centz - 1)//ala derecha
                    return 4;
                else if (x == ubi_centx - 2 && z == ubi_centz)//Detrás de las alas
                    return 5;
                else if (x == ubi_centx - 3 && z == ubi_centz)//Cola
                    return 6;
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
