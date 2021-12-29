using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Navios
{
    class Barcos : Vehiculos
    {
        public Barcos(int ubix, int ubiy, int ubiz) : base(ubix, ubiy, ubiz)
        {
            tamano = 8;
            ubi_restates = tamano - 2;
        }
        public bool coord(int x, int y, int z)//Deben ser del arreglo, no del tablero
        {//Busca si la coordenada forma parte del barco, como en tablero, en función del char se verifica si hay que quitar o no, aqui solo se verifica si forma parte de el avión con el objeto en cuestión
            bool ispart = false;
            if (y == ubi_centy)//Como es igual la atura en todos los casos puede comprobarse antes
            {
                if (x == ubi_centx && z == ubi_centz)//cabeza posición 1
                    ispart = true;
                if (x == ubi_centx - 1 && z == ubi_centz)//Fila cabeza posición 2
                    ispart = true;
                if (x == ubi_centx - 2 && z == ubi_centz)//Fila cabeza posición 3
                    ispart = true;
                if (x == ubi_centx - 3 && z == ubi_centz)//Fila cabeza posición 4
                    ispart = true;
                if (x == ubi_centx && z == ubi_centz + 1)//Fondo posición 1
                    ispart = true;
                if (x == ubi_centx - 1 && z == ubi_centz + 1)//Fila Fondo posición 2
                    ispart = true;
                if (x == ubi_centx - 2 && z == ubi_centz + 1)//Fila Fondo posición 3
                    ispart = true;
                if (x == ubi_centx - 3 && z == ubi_centz + 1)//Fila Fondo posición 4
                    ispart = true;
            }
            else
                ispart = false;
            return ispart;
        }
        public int gettype(int x, int y, int z)//Devuelve el tipo de parte del avión a partir de un sistema complejo de coordenadas x,y,z: 1-cabeza,2-parte central,3-ala izquierda,4-ala derecha,5-parte trasera,6-cola
        {//regresa 0 si no es parte de este avión
            if (y == ubi_centy)//Como es igual la atura en todos los casos puede comprobarse antes
            {
                if (x == ubi_centx && z == ubi_centz)//Fila cabeza: cabeza
                    return 1;
                else if (x == ubi_centx - 1 && z == ubi_centz)//Fila cabeza: parte media alta
                    return 2;
                else if (x == ubi_centx - 2 && z == ubi_centz)//Fila cabeza: parte media baja
                    return 3;
                else if (x == ubi_centx - 3 && z == ubi_centz)//Fila cabeza: parte trasera
                    return 4;
                else if (x == ubi_centx && z == ubi_centz + 1)//Fila fondo: parte delantera
                    return 5;
                else if (x == ubi_centx - 1 && z == ubi_centz + 1)//Fila fondo: parte media alta
                    return 6;
                else if (x == ubi_centx - 2 && z == ubi_centz + 1)//Fila fondo: parte media baja
                    return 7;
                else if (x == ubi_centx - 3 && z == ubi_centz + 1)//Fila fondo: parte trasera
                    return 8;
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
