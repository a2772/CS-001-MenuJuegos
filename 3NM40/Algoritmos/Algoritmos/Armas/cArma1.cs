using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Armas
{
    class cArma1//El arma 1 hace un ataque en una coordenada específica
    {
        public bool disp(ref char[,,] tablero, int x, int y, int z)//Recibe el arreglo por referencia, ya que lo modifica con el ataque y la simbología correspondiente, así como la coordenada exacta en el teblaro a la que se está atacando. Recibe el tablero objetivo y la coordenada
        {//True: se acertó (A una pieza activa (c253,c252,c251,c250))
            ///La sibología para interpretar los caracteres básicos es: (todo en valor char)
            ///254-Vacío
            ///249-Atacado, pero no hay nada
            ///253-Avión intacto
            ///252-Barco intacto
            ///251-Submarino grande intacto
            ///250-Submarino pequeño intacto
            ///De ahí en adelante, se resta cada uno 10 para obtener los lugares impactados: (excepto para vacío y atacado a un lugar donde no hay nada)
            ///243-Avión golpeado
            ///242-Barco golpeado
            ///241-Submarino grande
            ///240-Submarino pequeño
            ///Al restarles otros 10 se obtiene los que se hunden automáticamente cuando se alcanza el límite de vidas de un vehículo
            ///233-Avión hundido automáticamente
            ///232-Barco hundido automáticamente
            ///231-Submarino grande hundido automáticamente 
            ///(No hay submarino pequeño porque sus vidas son igual a su tamaño)
            ///Estos últimos (233-230) Son asignados por otra función en el arreglo, en este caso solo se comprueba que si es uno de esos caracteres, no lo marcará como atacado, sino que lo dejará igual
            bool acertado = false;//Si acierta a algún objetivo INTACTO lo marca como acertado (verdadero), si es otra cosa regresará falso
            if (tablero[x, y, z] != Convert.ToChar(249) && tablero[x, y, z] != Convert.ToChar(243) && tablero[x, y, z] != Convert.ToChar(242) && tablero[x, y, z] != Convert.ToChar(241) && tablero[x, y, z] != Convert.ToChar(240) && tablero[x, y, z] != Convert.ToChar(233) && tablero[x, y, z] != Convert.ToChar(232) && tablero[x, y, z] != Convert.ToChar(231))
            {//Si es un lugar intacto o vacío, lo cambia aquí
                acertado = true;//Al entrar marca acertado (la mayoria de los casos son acertado, solo 1 no lo es)
                if (tablero[x, y, z] == Convert.ToChar(254))
                {
                    tablero[x, y, z] = Convert.ToChar(249);//Marca que se falló
                    acertado = false;//Como se falla regresa el estado de la variable a false
                }
                else if (tablero[x, y, z] == Convert.ToChar(253))
                    tablero[x, y, z] = Convert.ToChar(243);//Se acertó a un avión
                else if (tablero[x, y, z] == Convert.ToChar(252))
                    tablero[x, y, z] = Convert.ToChar(242);//Se acertó a un barco
                else if (tablero[x, y, z] == Convert.ToChar(251))
                    tablero[x, y, z] = Convert.ToChar(241);//Se acertó a un submarino grande
                else if (tablero[x, y, z] == Convert.ToChar(250))
                    tablero[x, y, z] = Convert.ToChar(240);//Se acertó a un submarino pequeño
            }
            return acertado;//Regresa si acertó o si no
        }
        public bool phant(char[,,] tablero, int x, int y, int z)
        {//True: Se ha desperdiciado el disparo ya que era una zona hundida o atacada (puede ser atacada y acertada o atacada y fallada), pero el punto es que ya se ocnocía la situacion de esa ubicación y no tenía sentido hacer un ataque a esa ubicación
            bool desperdiciado;
            //Si no es vacío o un lugar intacto (ya que el vacío se debe comprobar y los intactos no se conocen por lo que también deben de encontrarse), se marca como desperdiciado
            if (tablero[x, y, z] != Convert.ToChar(254) && tablero[x, y, z] != Convert.ToChar(253) && tablero[x, y, z] != Convert.ToChar(252) && tablero[x, y, z] != Convert.ToChar(251) && tablero[x, y, z] != Convert.ToChar(250))
                desperdiciado = true;
            else//Si habia algun lugar vacío (desconocido) o un barco intacto, no se ha desperdiciado
                desperdiciado = false;
            return desperdiciado;
        }
    }
}
