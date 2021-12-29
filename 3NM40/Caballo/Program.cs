using System;
using System.Diagnostics;
using System.Threading;

namespace Caballo
{
    class Program
    {
        private static int[] ejex = { -1, -2, -2, -1, 1, 2, 2, 1 };//Son los movimientos que puede hacer el caballo en los ejes
        private static int[] ejey = { -2, -1, 1, 2, 2, 1, -1, -2 };//Y y X
        private static int[,] tablero;
        private static bool flagTimer = true;
        private static int gX, gY, gSize, counter;
        private static String result;
        private static String[,] cad = new String[8, 8];
        static void Main(String[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            char opc;
            int size = 5;//Por default el tamaño es 5
            int tiempo = 100, caminos, x = 0, y = 0;//Posiciones iniciales (coordenada inicial por defecto es 0,0)
            Timer t = new Timer(TimerCallback, null, 0, tiempo);
            bool q;
            double segundos;
            Stopwatch time = new Stopwatch();
            opc = menu();//Leemos para ver si entra al ciclo
            while (opc != '6')
            {
                switch (opc)
                {//Como ya se valida en menu que sea una opción dentro del menú, no se requiere el default
                    case '1'://Modificar un tamaño
                        Console.WriteLine("Ingresa el tamaño que puede ir de 5 a 9");
                        size = leeIntRang(5, 9);//Valida que este de 5 a 9
                        Console.WriteLine("Tamaño modificado a: " + size + " casillas");
                        break;
                    case '2'://Indicar posición de inicio
                        String answ = "Coordenada inicial X,Y: (" + (x + 1) + "," + (y + 1) + ")" + Environment.NewLine;
                        Console.Write("Ingresa la nueva posición en X: ");
                        x = leeIntRang(1, size)-1;//Valida inclusive
                        Console.Write(Environment.NewLine + "Ingresa la nueva posición en Y: ");
                        y = leeIntRang(1, size)-1;//Valida inclusive
                        Console.WriteLine(Environment.NewLine + answ + "Nueva coordenada: (" + (x + 1) + "," + (y + 1) + ")");
                        break;
                    case '3'://Tiempo de cada movimiento
                        Console.Write("Tiempo actual de muestra por movimiento: " + tiempo/1000 + "s" + Environment.NewLine + "Ingresa el nuevo tiempo (1s-60s): ");
                        tiempo = leeIntRang(1, 60)*1000;
                        Console.WriteLine(Environment.NewLine + "Tiempo nuevo: " + tiempo / 1000 + "s" + Environment.NewLine);
                        break;
                    case '4'://Ver mi configuración
                        Console.WriteLine("Tamaño del tablero: " + size + " casillas");
                        Console.WriteLine("Coordenada de inicio X,Y: (" + (x + 1) + "," + (y + 1) + ")");
                        Console.WriteLine("Tiempo por movimiento: " + tiempo/1000 + "s");
                        break;
                    case '5'://Proceder a la simulación
                             //Inicializando
                        t.Change(0, tiempo);
                        caminos = 0;
                        q = false;
                        tablero = new int[size, size];
                        //Se incializa el tablero seleccionado con 0s
                        for (int i = 0; i < size; i++)
                            for (int j = 0; j < size; j++)
                                tablero[i, j] = 0;
                        tablero[x, y] = 1;//Posición de inicio
                                          //Tomamos el tiempo
                        time.Start();
                        mover(ref tablero, 2, x, y, ref q, ref caminos, size);//Movemos recursivamente
                        time.Stop();//Medimos el tiempo que se tardó en encontrar una solución, sino encuentra se toma todo el que se la pasó buscando
                        segundos = time.Elapsed.TotalMilliseconds / 1000d;
                        result = "";
                        if (q)
                        { /* hay solucion: la muestra. */
                            for (int i = 0; i < size; i++)
                            {
                                for (int j = 0; j < size; j++)
                                    cad[i, j] = "   ";
                                cad[i, size - 1] += Environment.NewLine;
                            }
                            gSize = size;
                            gX = 0;
                            gY = 0;
                            //Imprimimos el resultado
                            result += "Se encontró un resultado partiendo de la coordenada (" + (x + 1) + "," + (y + 1) + ")" + Environment.NewLine;
                            result += "Tiempo de búsqueda que se demoró la solución(segundos): " + segundos.ToString() + Environment.NewLine;
                            result += "Caminos explorados (contando la solución): " + caminos;
                        }
                        else
                        {
                            result += "No encontró un resultado partiendo de la coordenada (" + (x + 1) + "," + (y + 1) + ")" + Environment.NewLine;
                            result += "Tiempo de búsqueda sin éxito(segundos): " + segundos.ToString() + Environment.NewLine;
                            result += "Caminos explorados sin éxito: " + caminos;
                        }
                        counter = 0;
                        flagTimer = false;//Activa el evento del timer
                        break;
                    case '6'://Modificar tiempo
                        Console.WriteLine("Finalizando el sistema.");
                        break;
                    case '7'://Salir
                        Console.WriteLine("Finalizando el sistema.");
                        break;
                }
                if (opc != '5')
                {
                    Console.WriteLine("Ingresa una tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Calculando (para cancelar presione una tecla)...");
                    Console.ReadKey();
                }
                if (opc != '6')
                    opc = menu();
            }
            /* pone el primer movimiento */
        }
        private static void TimerCallback(Object o)
        {
            if (!flagTimer)
            {
                counter++; 
                String[,] recorrido = new String[9, 9];
                for (int i = 0; i < gSize; i++)
                    for (int j = 0; j < gSize; j++)
                        if (tablero[i, j] == counter)
                        {
                            if (tablero[i, j] > 9)
                                cad[i, j] = tablero[i, j] + " ";
                            else
                                cad[i, j] = tablero[i, j] + "  ";
                            if (j == gSize - 1)
                                cad[i, j] += Environment.NewLine;
                        }
                //For de llenado
                Console.Clear();
                for (int i = 0; i < gSize; i++)
                    for (int j = 0; j < gSize; j++)
                        Console.Write(cad[i, j]);
                gY++;
                if (gY >= gSize)
                {
                    gY = 0;
                    gX++;
                }
                if (gX >= gSize)
                {
                    flagTimer = true;
                    flagTimer = true;
                    Console.WriteLine("\n" + result);
                }
            }
        }
        private static int leeIntRang(int min, int max)
        {//lee y valida un tamaño dentro de un rango inclusive
            int tam = 0;
            bool val = false;
            do
            {
                try
                {
                    try
                    {
                        tam = Convert.ToInt32(Console.ReadLine());
                        val = true;
                    }
                    catch (OverflowException)
                    { //Excepción de desbordamiento
                        Console.WriteLine("Error. valor demasiado grande, intenta con otro: ");
                    }
                }
                catch (FormatException)
                { //Excepción de tipo de formato
                    Console.WriteLine("No has ingresado un entero válido, intenta de nuevo: ");
                }
                if (tam < min || tam > max)
                {
                    Console.WriteLine("El valor puede ser únicamente de " + min + " a " + max);
                    val = false;
                }
            } while (!val);
            return tam;
        }
        private static void mover(ref int[,] tablero, int i, int pos_x, int pos_y, ref bool q, ref int caminos, int size)
        {
            int k, u, v;
            k = 0;
            q = false;//Se inicializa por si se regreso de un camino que no funcionó
            do
            {
                u = pos_x + ejex[k]; v = pos_y + ejey[k]; /* seleccionar candidato */
                if (u >= 0 && u < size && v >= 0 && v < size)
                { /* ¿está dentro de los limites? */
                    if (tablero[u, v] == 0)
                    {  /* ¿es válido? */
                        tablero[u, v] = i;  /* anota el candidato */
                        if (i < size * size)
                        {  /* ¿llega al final del recorrido? */
                            mover(ref tablero, i + 1, u, v, ref q, ref caminos, size);
                            if (!q)
                            {
                                tablero[u, v] = 0; /* borra el candidato */
                                caminos++;//Suma un camino explorado
                            }
                        }
                        else
                        {
                            q = true; /* hay solucion */
                            caminos++;
                        }
                    }
                }
                k++;
            } while (!q && k < 8);
        }
        private static char menu()
        {//Imprime y devuelve una opción válidada del menú
            char opc;
            bool val = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenid@ a El caballo loko.\n\tSelecciona una opción:\n\t\t1. Modificar un tamaño (por defecto es 5 unidades)\n\t\t2. Indicar posición de inicio\n\t\t3. Modificar tiempo de mostrar cada movimiento (default 1s)\n\t\t4. Ver mi configuración\n\t\t5. Proceder a la simulación\n\t\t6. Salir");
                opc = isChar();//Leemos y valida que sea estrictamente un valor
                if (opc != '1' && opc != '2' && opc != '3' && opc != '4' && opc != '5' && opc != '6')
                {
                    Console.WriteLine(Environment.NewLine + "Error. Ingresa una opción del menú" + Environment.NewLine);
                    val = false;
                }
                else
                {//Si es una opción del menú, regresamos el valor al main
                    val = true;
                }
            } while (!val);
            return opc;
        }
        private static char isChar()
        { //Lee un caracter
            char caracter = '<'; //Como nos pide inicializar para compilar, le puse eso
            string aux; //Aquí leemos
            bool valid = false; //Flag para validar
            do
            {
                aux = Console.ReadLine().ToString(); //Leemos
                if (aux.Length == 1)
                { //Si y solo si es un caracter (no más ni menos) se toma como válido
                    caracter = aux[0];
                    valid = true; //Se pone que fué valido
                }
                else //Si no, sigue en falso:
                    Console.WriteLine("Ingresa únicamente un caracter: ");
            } while (!valid);
            return caracter; //Regresamos el caracter con la validación de que sea solo 1
        }
    }
}
