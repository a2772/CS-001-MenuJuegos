using System;

namespace Algoritmos
{
    class Tablero
    {//Guarda el estado del tablero, los vehículos y los disparos que ha RECIBIDO, no dado
        private int limit, avis, bars, subgs, subps;//Son fijos, los que se modifican están en Jugador
        private char[,,] ABS = new char[8, 8, 5];//Tamaños máximos y se modificará al determinar el tamaño
        //Instancias para los objetos, donde en el tamaño 8x8x5 corresponden los siguientes
        Navios.Aviones[] veh0 = new Navios.Aviones[2];
        Navios.Barcos[] veh1 = new Navios.Barcos[1];
        Navios.Subs_g[] veh2 = new Navios.Subs_g[5];
        Navios.Subs_p[] veh3 = new Navios.Subs_p[8];
        public Tablero(int Sub_p, int Sub_g, int Avion, int Barco, int limite, int x, int y, int z)
        {//se crea el tablero del jugador--Nota en espa y espm tomar el valor final de c/u siendo el mínimo 1 ejemplo: si Y vale 15 como lim = 0.3X10 espa vale 3 y espm vale 7
            //Sub_g = 1;Sub_p = 1;
            int i, j, k, _x = x, _y = y, _z = z, _Avion = Avion, _Barco = Barco, _Sub_p = Sub_p, _Sub_g = Sub_g;//Vehiculo,x,y,z
            bool asignar;
            limit = limite - 1; avis = Avion; bars = Barco; subgs = Sub_g; subps = Sub_p;//Asigna el limite en valor arreglo y otras variables
            char vacio = Convert.ToChar(254), avion = Convert.ToChar(253), barco = Convert.ToChar(252), sg = Convert.ToChar(251), sp = Convert.ToChar(250);
            ///Inicializar llenadno el arreglo con el símbolo que indica que no hay nada: char 254
            for (i = 0; i < x; i++)
                for (j = 0; j < y; j++)
                    for (k = 0; k < z; k++)
                        ABS[i, j, k] = vacio;
            ///Fin inicialización
            var random = new Random(Guid.NewGuid().GetHashCode());
            ///Aviones
            ///El avión es así:       *    (Con esa orientación)
            ///                     ****
            ///                       *
            do//Se realizará hasta que todos los aviones se coloquen, sin embargo puede tomar más veces que el numero de éstos ya que se genera aleatoriamente la posicion de uno y en el ciclo se evalúa si es una ubicación válida (véase reglas de colocación)
            {//                    N - s: El tamaño menos (ubicación final+1) un N-1 significa que toma en cuenta el extremo también
                asignar = false;
                i = random.Next(3, x);//Marca donde se ubicará uno por uno hasta que se acaben, por distancias horizontales aleatorias ubicando la cabeza a la derecha (por eso se inicializa desde la posicion 3 del arreglo)
                j = random.Next(0, limite);//Debe estar en espacio aéreo
                k = random.Next(1, z - 1);//La cabeza no puede ubicarse hasta el frente ni al fondo por las alas
                //Una vez elegida la coordenada de la cabeza, se verifica si se puede colocar ahi un avión, todos los lugares deben estar vacíos
                if (ABS[i, j, k] == vacio && ABS[i - 1, j, k] == vacio && ABS[i - 1, j, k + 1] == vacio && ABS[i - 1, j, k - 1] == vacio && ABS[i - 2, j, k] == vacio && ABS[i - 3, j, k] == vacio)
                {
                    //Cabeza,                parte siguiente,           ala izquierda,                 ala derecha,                   detrás de las alas y         cola.                      Se verifican aquí
                    asignar = true;
                    //Como ya se verificó lo anterior, deben verificarse las periferias y que haya un espacio entre aviones, pero antes ver si está en los limites o enmedio para no salirnos del arreglo
                    //Valida todos excepto el centro y alas: laterales izquierdos
                    if (ABS[i, j, k + 1] != vacio || ABS[i - 2, j, k + 1] != vacio || ABS[i - 3, j, k + 1] != vacio)
                        asignar = false;
                    //Valida ala izquierda: laterales izquierdos (solo si no es el extremo)
                    if (k < z - 2)
                        if (ABS[i - 1, j, k + 2] != vacio)
                            asignar = false;
                    //Valida todos excepto el centro y alas: laterales derechos
                    if (ABS[i, j, k - 1] != vacio || ABS[i - 2, j, k - 1] != vacio || ABS[i - 3, j, k - 1] != vacio)
                        asignar = false;
                    //Valida ala derecha: laterales derechos (solo si no es el extremo)
                    if (k > 1)
                        if (ABS[i - 1, j, k - 2] != vacio)
                            asignar = false;
                    //Valida frente de la cabeza
                    if (i < x - 1)
                        if (ABS[i + 1, j, k] != vacio)
                            asignar = false;
                    //Valida detrás del avión (solo la cola del avión)
                    if (i > 3)
                        if (ABS[i - 4, j, k] != vacio)
                            asignar = false;
                }
                else
                    asignar = false;
                //Una vez validado que se puede ubicar ahí, se ubica y se guarda la ubicación
                if (asignar)
                {//Se ubica la cabeza del avión y se guarda su número de serie
                    veh0[Avion - _Avion] = new Navios.Aviones(i, j, k);//Arreglo del objeto avión
                    //Se agrega en el arreglo tablero: Cabeza, parte siguiente, alas, parte trasera y cola
                    ABS[i, j, k] = avion;
                    ABS[i - 1, j, k] = avion;
                    ABS[i - 1, j, k - 1] = avion;
                    ABS[i - 1, j, k + 1] = avion;
                    ABS[i - 2, j, k] = avion;
                    ABS[i - 3, j, k] = avion;
                    //Se reduce el avión agregado del total por asignar
                    _Avion--;
                }//De otro modo sigue en el ciclo y se asigna otro número
            } while (_Avion > 0);//Cuando no hay aviones por asignar se termina este ciclo
            ///Barcos
            do
            {
                asignar = false;
                ///El barco es así:     ****
                ///                     **** <//- Este ultimo es la "cabeza"
                i = random.Next(3, x);
                j = limite;//No se resta 1 porque su equivalente en el arreglo es la primera capa del espacio marítimo
                k = random.Next(0, z - 1);//0 porque se cuenta desde el vértice frontal y -2 porque debe estar despegado 1 cuadro del ultimo espacio del fondo
                //Una vez elegida la coordenada de la cabeza, se verifica si se puede colocar ahi un barco, todos los lugares deben estar vacíos
                if (ABS[i, j, k] == vacio && ABS[i - 1, j, k] == vacio && ABS[i - 2, j, k] == vacio && ABS[i - 3, j, k] == vacio && ABS[i, j, k + 1] == vacio && ABS[i - 1, j, k + 1] == vacio && ABS[i - 2, j, k + 1] == vacio && ABS[i - 3, j, k + 1] == vacio)
                {
                    //Fila de la cabeza                                                                                       //Fila  del fondo
                    asignar = true;
                    //Como ya se verificó lo anterior, deben verificarse las periferias y que haya un espacio entre barcos, pero antes ver si está en los limites o enmedio para no salirnos del arreglo
                    //Parte de la derecha (fila de la cabeza)
                    if (k > 0)
                        if (ABS[i, j, k - 1] != vacio || ABS[i - 1, j, k - 1] != vacio || ABS[i - 2, j, k - 1] != vacio || ABS[i - 3, j, k - 1] != vacio)
                            asignar = false;
                    //Parte de la izquierda (fila del fondo)
                    if (k + 1 < z - 1)
                        if (ABS[i, j, k + 2] != vacio || ABS[i - 1, j, k + 2] != vacio || ABS[i - 2, j, k + 2] != vacio || ABS[i - 3, j, k + 2] != vacio)
                            asignar = false;
                    //Parte de enfrente
                    if (i < x - 1)
                        if (ABS[i + 1, j, k] != vacio || ABS[i + 1, j, k + 1] != vacio)
                            asignar = false;
                    //Parte de atrás
                    if (i > 3)
                        if (ABS[i - 4, j, k] != vacio || ABS[i - 4, j, k + 1] != vacio)
                            asignar = false;
                }
                else
                    asignar = false;
                //Una vez validado que se puede ubicar ahí, se ubica y se guarda la ubicación
                if (asignar)
                {//Se ubica la cabeza del avión y se guarda su número de serie
                    veh1[Barco - _Barco] = new Navios.Barcos(i, j, k);//Arreglo del objeto barco
                    //Se agrega en el arreglo tablero
                    ABS[i, j, k] = barco;
                    ABS[i - 1, j, k] = barco;
                    ABS[i - 2, j, k] = barco;
                    ABS[i - 3, j, k] = barco;
                    ABS[i, j, k + 1] = barco;
                    ABS[i - 1, j, k + 1] = barco;
                    ABS[i - 2, j, k + 1] = barco;
                    ABS[i - 3, j, k + 1] = barco;
                    //Se reduce el barco agregado del total por asignar
                    _Barco--;
                }//De otro modo sigue en el ciclo y se asigna otro número
            } while (_Barco > 0);//Cuando no hay barcos por asignar se termina este ciclo
            ///Submarinos Grandes (Se asignan primero para que haya menos iteraciones o probabilidad de estas)
            do
            {
                asignar = false;
                ///El submarino grande es así:     **** <//- Este ultimo es la "cabeza"
                //Se generan i,j,k iguales para ambos submarinos
                i = random.Next(3, x);
                j = random.Next(limite + 1, y);//Espa=lim, espm=y: Aqui se inicia en espacio marino y el +1 es para no ocupar la capa de los barcos
                k = random.Next(0, z);
                //Una vez elegida la coordenada de la cabeza, se verifica si se puede colocar ahi un submrino grande, todos los lugares deben estar vacíos
                if (ABS[i, j, k] == vacio && ABS[i - 1, j, k] == vacio && ABS[i - 2, j, k] == vacio && ABS[i - 3, j, k] == vacio)
                {
                    asignar = true;
                    //Como ya se verificó lo anterior, deben verificarse las periferias y que haya un espacio entre submarinos, pero antes ver si está en los limites o enmedio para no salirnos del arreglo
                    //Parte de la derecha
                    if (k > 0)
                        if (ABS[i, j, k - 1] != vacio || ABS[i - 1, j, k - 1] != vacio || ABS[i - 2, j, k - 1] != vacio || ABS[i - 3, j, k - 1] != vacio)
                            asignar = false;
                    //Parte de la izquierda
                    if (k < z - 1)
                        if (ABS[i, j, k + 1] != vacio || ABS[i - 1, j, k + 1] != vacio || ABS[i - 2, j, k + 1] != vacio || ABS[i - 3, j, k + 1] != vacio)
                            asignar = false;
                    //Parte de enfrente
                    if (i < x - 1)
                        if (ABS[i + 1, j, k] != vacio)
                            asignar = false;
                    //Parte de atrás
                    if (i > 3)
                        if (ABS[i - 4, j, k] != vacio)
                            asignar = false;
                }
                else
                    asignar = false;
                //Una vez validado que se puede ubicar ahí, se ubica y se guarda la ubicación
                if (asignar)
                {//Se ubica la cabeza del avión y se guarda su número de serie
                    veh2[Sub_g - _Sub_g] = new Navios.Subs_g(i, j, k);//Arreglo del objeto barco
                    //Se agrega en el arreglo tablero
                    ABS[i, j, k] = sg;
                    ABS[i - 1, j, k] = sg;
                    ABS[i - 2, j, k] = sg;
                    ABS[i - 3, j, k] = sg;
                    //Se reduce el submarino agregado del total por asignar
                    _Sub_g--;
                }//De otro modo sigue en el ciclo y se asigna otro número
            } while (_Sub_g > 0);//Cuando no hay barcos por asignar se termina este ciclo
            ///Submarinos Pequeños
            do
            {
                asignar = false;
                ///El submarino pequeño es así:     ** <//- Este ultimo es la "cabeza"
                //Se generan i,j,k iguales para ambos submarinos (el grande y pequeño)
                i = random.Next(1, x);
                j = random.Next(limite + 1, y);//Espa=lim, espm=y: Aqui se inicia en espacio marino y el +1 es para no ocupar la capa de los barcos
                k = random.Next(0, z);
                if (i == x)
                    i--;
                if (j == y)
                    j--;
                if (k == z)
                    k--;
                //Una vez elegida la coordenada de la cabeza, se verifica si se puede colocar ahi un submrino grande, todos los lugares deben estar vacíos
                if (ABS[i, j, k] == vacio && ABS[i - 1, j, k] == vacio)
                {
                    asignar = true;
                    //Como ya se verificó lo anterior, deben verificarse las periferias y que haya un espacio entre submarinos, pero antes ver si está en los limites o enmedio para no salirnos del arreglo
                    //Parte de la derecha
                    if (k > 0)
                        if (ABS[i, j, k - 1] != vacio || ABS[i - 1, j, k - 1] != vacio)
                            asignar = false;
                    //Parte de la izquierda
                    if (k < z - 1)
                        if (ABS[i, j, k + 1] != vacio || ABS[i - 1, j, k + 1] != vacio)
                            asignar = false;
                    //Parte de enfrente
                    if (i < x - 1)
                        if (ABS[i + 1, j, k] != vacio)
                            asignar = false;
                    //Parte de atrás
                    if (i > 1)
                        if (ABS[i - 2, j, k] != vacio)
                            asignar = false;
                }
                else
                    asignar = false;
                //Una vez validado que se puede ubicar ahí, se ubica y se guarda la ubicación
                if (asignar)
                {//Se ubica la cabeza del avión y se guarda su número de serie
                    veh3[Sub_p - _Sub_p] = new Navios.Subs_p(i, j, k);//Arreglo del objeto barco
                    //Se agrega en el arreglo tablero
                    ABS[i, j, k] = sp;
                    ABS[i - 1, j, k] = sp;
                    //Se reduce el submarino agregado del total por asignar
                    _Sub_p--;
                }//De otro modo sigue en el ciclo y se asigna otro número
            } while (_Sub_p > 0);//Cuando no hay barcos por asignar se termina este ciclo
        }
        public void actualiza(char[,,] pseudotab)//Copia el arreglo que recibe a éste
        {
            ABS = pseudotab;
        }
        public void enviaTab(ref char[,,] pseudotab)//Modifica el arreglo que recibe de frm un jugador
        {
            pseudotab = ABS;
        }
        public int parteveh(int x, int y, int z)//Devuelve que se encuentra ahí como extensión en funcion de la parte ejemplo: ala derecha del avión intacta:2534 donde el ultimo 4 es la parte de este y lo demás es su estado
        {//debe recibir valores diferentes a vacio (se debe comprobar que no sea coordenada vacía o errada)
            int type = 0, i;//Type se compone de 3 cosas: 100,200,etc valor en centenas, indica que es: avión, barco etc. 10,20, etc valor en decenas indica su estado (intacto, atacado,hundido indirectamente, etc.). el 3er numero indica su parte como las alas, cola, etc.
            if (y <= limit)//Es un avión
            {
                type = 100;//El 100 indica avión
                if (ABS[x, y, z] == 253)
                    type += 10;//Intacto
                else if (ABS[x, y, z] == 243)
                    type += 20;//Atacado
                else if (ABS[x, y, z] == 233)
                    type += 30;//Hundido por limite de vida
                for (i = 0; i < avis; i++)
                    if (veh0[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se busca que parte es
                    {
                        type += veh0[i].gettype(x, y, z);//Obtiene la parte del avión
                        i = avis;//Sale del ciclo
                    }
            }
            else if (y == limit + 1)//Busca en barcos
            {
                type = 200;//El 200 indica barco
                if (ABS[x, y, z] == 252)
                    type += 10;//Intacto
                else if (ABS[x, y, z] == 242)
                    type += 20;//Atacado
                else if (ABS[x, y, z] == 232)
                    type += 30;//Hundido por limite de vida
                for (i = 0; i < bars; i++)
                    if (veh1[i].coord(x, y, z))
                    {
                        type += veh1[i].gettype(x, y, z);//Obtiene la parte del barco
                        i = bars;//Sale del ciclo
                    }
            }
            else//Busca submarinos grandes y pequeños
            {
                for (i = 0; i < subgs; i++)
                    if (veh2[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se disminuye
                    {//Además como solo es una posición, se sale del ciclo
                        type = 300;
                        if (ABS[x, y, z] == 251)
                            type += 10;//Intacto
                        else if (ABS[x, y, z] == 241)
                            type += 20;//Atacado
                        else if (ABS[x, y, z] == 231)
                            type += 30;//Hundido por limite de vida
                        type += veh2[i].gettype(x, y, z);//Obtiene la parte del sub
                        i = subgs;//Sale del ciclo
                    }
                for (i = 0; i < subps; i++)
                    if (veh3[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se disminuye
                    {//Además como solo es una posición, se sale del ciclo
                        type = 400;
                        if (ABS[x, y, z] == 250)
                            type += 10;//Intacto
                        else if (ABS[x, y, z] == 240)
                            type += 20;//Atacado
                        type += veh3[i].gettype(x, y, z);//Obtiene la parte del sub
                        i = subps;//Sale del ciclo
                    }
            }
            return type;
        }
        public bool aciertauno(ref int x, ref int y, ref int z)//Retira del tablero de ese jugador la casilla correspondiente a un vehículo y regresa true si se hunde (además, si es que se hunde retira las casillas relacionadas del vehículo y las marca como hundidas)
        {//Char(230)->Marca las casillas en las que el vehículo se hundió/derribó porque no le quedaba "vida"
            bool hundido = false;
            int i;//iterador
            //Se busca en el área correspondiente
            if (y <= limit)//Es un avión
            {
                for (i = 0; i < avis; i++)
                    if (veh0[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se disminuye
                    {//Además como solo es una posición, se sale del ciclo
                        if (veh0[i].disminuye())
                        {
                            hundido = true;//Al hundirse, se debe marcar en el tablero, se pasan por referencia los valores de la cabeza
                            x = veh0[i].getx();
                            y = veh0[i].gety();
                            z = veh0[i].getz();
                        }
                        i = avis;//Sale del ciclo
                    }
            }
            else if (y == limit + 1)//Busca en barcos
            {
                for (i = 0; i < bars; i++)
                    if (veh1[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se disminuye
                    {//Además como solo es una posición, se sale del ciclo
                        if (veh1[i].disminuye())
                        {
                            hundido = true;//Al hundirse, se debe marcar en el tablero, se pasan por referencia los valores de la cabeza
                            x = veh1[i].getx();
                            y = veh1[i].gety();
                            z = veh1[i].getz();
                        }
                        i = bars;//Sale del ciclo
                    }
            }
            else//Busca submarinos grandes y pequeños
            {
                for (i = 0; i < subgs; i++)
                    if (veh2[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se disminuye
                    {//Además como solo es una posición, se sale del ciclo
                        if (veh2[i].disminuye())
                        {
                            hundido = true;//Al hundirse, se debe marcar en el tablero, se pasan por referencia los valores de la cabeza
                            x = veh2[i].getx();
                            y = veh2[i].gety();
                            z = veh2[i].getz();
                        }
                        i = subgs;//Sale del ciclo
                    }
                if (!hundido)
                    for (i = 0; i < subps; i++)
                        if (veh3[i].coord(x, y, z))//Si es parte de ese avión esa coordenada, se disminuye
                        {//Además como solo es una posición, se sale del ciclo
                            if (veh3[i].disminuye())
                            {
                                hundido = true;//Al hundirse, se debe marcar en el tablero, se pasan por referencia los valores de la cabeza
                                x = veh3[i].getx();
                                y = veh3[i].gety();
                                z = veh3[i].getz();
                            }
                            i = subps;//Sale del ciclo
                        }
            }
            return hundido;
        }//Combprobar si al atacar 4 veces en una zona no se hunde un submarino o avión
        public bool unoomas(int pi, int pj, int pk, int li, int lj, int lk, ref int Avi, ref int Bar, ref int Sgr, ref int Spe)
        {//Hace algo parecida a la anterior pero con mas de una casilla y devuelve cuanto se retiró de aviones, barcos, etc
            Avi = 0; Bar = 0; Sgr = 0; Spe = 0;//Se limpian porque van a ser acumulados
            int i, j, k, i1, i11, j11, k11;//Iteradores
            bool hunde = false;
            //Se busca en el área correspondiente
            for (i = pi; i <= li; i++)
                for (j = pj; j <= lj; j++)
                    for (k = pk; k <= lk; k++)
                    {
                        if (j <= limit)//Es un avión si está antes del límite del tablero o en él
                        {
                            for (i1 = 0; i1 < avis; i1++)
                                if (veh0[i1].coord(i, j, k))//Si es parte de ese avión esa coordenada, se disminuye
                                {
                                    if (veh0[i1].getestado())//Si es true sigue vivo, por lo que en ese caso si se hace el cmabio, sino, como ya está hundido no tiene caso
                                        if (veh0[i1].disminuye())
                                        {//Si se hunde
                                            hunde = true;
                                            Avi++;
                                            i11 = veh0[i1].getx();
                                            j11 = veh0[i1].gety();
                                            k11 = veh0[i1].getz();
                                            buscayretira(i11, j11, k11);
                                        }
                                }
                        }
                        else if (j == limit + 1)//Busca en barcos
                        {
                            for (i1 = 0; i1 < bars; i1++)
                                if (veh1[i1].coord(i, j, k))//Si es parte de ese avión esa coordenada, se disminuye
                                {//Además como solo es una posición, se sale del ciclo
                                    if (veh1[i1].getestado())
                                        if (veh1[i1].disminuye())
                                        {
                                            hunde = true;
                                            Bar++;
                                            i11 = veh1[i1].getx();
                                            j11 = veh1[i1].gety();
                                            k11 = veh1[i1].getz();
                                            buscayretira(i11, j11, k11);
                                        }
                                }
                        }
                        else//Busca submarinos grandes y pequeños
                        {
                            for (i1 = 0; i1 < subgs; i1++)
                                if (veh2[i1].coord(i, j, k))//Si es parte de ese avión esa coordenada, se disminuye
                                {//Además como solo es una posición, se sale del ciclo
                                    if (veh2[i1].getestado())
                                        if (veh2[i1].disminuye())
                                        {
                                            hunde = true;
                                            Sgr++;
                                            i11 = veh2[i1].getx();
                                            j11 = veh2[i1].gety();
                                            k11 = veh2[i1].getz();
                                            buscayretira(i11, j11, k11);
                                        }
                                }
                            for (i1 = 0; i1 < subps; i1++)
                                if (veh3[i1].coord(i, j, k))//Si es parte de ese avión esa coordenada, se disminuye
                                {//Además como solo es una posición, se sale del ciclo
                                    if (veh3[i1].getestado())
                                        if (veh3[i1].disminuye())
                                        {
                                            hunde = true;
                                            Spe++;
                                            i11 = veh3[i1].getx();
                                            j11 = veh3[i1].gety();
                                            k11 = veh3[i1].getz();
                                            buscayretira(i11, j11, k11);
                                        }
                                }
                        }
                    }
            return hunde;
        }
        public string buscayretira(int x, int y, int z)//Recibe coordenadas de la cabeza y lo busca
        {
            string tipo_retirado = "";
            if (y <= limit)//Es un avión
            {
                tipo_retirado = "Avion";
                //Se recorre todo el avión, y si está intacto (char 253) se cambia no a acertado, pero hundido
                if (ABS[x, y, z] == Convert.ToChar(253))//Cabeza
                    ABS[x, y, z] = Convert.ToChar(233);
                if (ABS[x - 1, y, z] == Convert.ToChar(253))//parte media
                    ABS[x - 1, y, z] = Convert.ToChar(233);
                if (ABS[x - 1, y, z + 1] == Convert.ToChar(253))//Ala izquierda
                    ABS[x - 1, y, z + 1] = Convert.ToChar(233);
                if (ABS[x - 1, y, z - 1] == Convert.ToChar(253))//Ala derecha
                    ABS[x - 1, y, z - 1] = Convert.ToChar(233);
                if (ABS[x - 2, y, z] == Convert.ToChar(253))//Parte trasera
                    ABS[x - 2, y, z] = Convert.ToChar(233);
                if (ABS[x - 3, y, z] == Convert.ToChar(253))//Cola
                    ABS[x - 3, y, z] = Convert.ToChar(233);
            }
            else if (y == limit + 1)//Busca en barcos
            {
                tipo_retirado = "Barco";
                //Se recorre todo el barco, y si está intacto (char 252) se cambia no a acertado, pero hundido
                if (ABS[x, y, z] == Convert.ToChar(252))//Fila de la cabeza
                    ABS[x, y, z] = Convert.ToChar(232);
                if (ABS[x - 1, y, z] == Convert.ToChar(252))
                    ABS[x - 1, y, z] = Convert.ToChar(232);
                if (ABS[x - 2, y, z] == Convert.ToChar(252))
                    ABS[x - 2, y, z] = Convert.ToChar(232);
                if (ABS[x - 3, y, z] == Convert.ToChar(252))
                    ABS[x - 3, y, z] = Convert.ToChar(232);
                if (ABS[x, y, z + 1] == Convert.ToChar(252))//Fila del fondo
                    ABS[x, y, z + 1] = Convert.ToChar(232);
                if (ABS[x - 1, y, z + 1] == Convert.ToChar(252))
                    ABS[x - 1, y, z + 1] = Convert.ToChar(232);
                if (ABS[x - 2, y, z + 1] == Convert.ToChar(252))
                    ABS[x - 2, y, z + 1] = Convert.ToChar(232);
                if (ABS[x - 3, y, z + 1] == Convert.ToChar(252))
                    ABS[x - 3, y, z + 1] = Convert.ToChar(232);
            }
            else//Busca submarinos grandes y pequeños
            {
                if (ABS[x, y, z] == Convert.ToChar(251) || ABS[x, y, z] == Convert.ToChar(241))//Si es grande
                {
                    tipo_retirado = "Submarino grande";
                    if (ABS[x, y, z] == Convert.ToChar(251))//Submarino grande
                        ABS[x, y, z] = Convert.ToChar(231);
                    if (ABS[x - 1, y, z] == Convert.ToChar(251))
                        ABS[x - 1, y, z] = Convert.ToChar(231);
                    if (ABS[x - 2, y, z] == Convert.ToChar(251))
                        ABS[x - 2, y, z] = Convert.ToChar(231);
                    if (ABS[x - 3, y, z] == Convert.ToChar(251))
                        ABS[x - 3, y, z] = Convert.ToChar(231);
                }
                else//es pequeño
                {
                    tipo_retirado = "Submarino pequeño";//Como sus 2 ubicaciones osn sus 2 vidas no se hace lo anterior
                }
            }
            return tipo_retirado;
        }
    }
}
