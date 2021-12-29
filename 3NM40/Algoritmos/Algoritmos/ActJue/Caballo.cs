using System;
using System.Diagnostics;

namespace Algoritmos.ActJue
{
    class Caballo
    {
        private static int[] ejex = { -1, -2, -2, -1, 1, 2, 2, 1 };//Son los movimientos que puede hacer el caballo en los ejes
        private static int[] ejey = { -2, -1, 1, 2, 2, 1, -1, -2 };//Y y X
        public static void Excecute(Clases.Usuario usuario)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            char opc;
            int size = 5;//Por default el tamaño es 5
            int caminos, x = 0, y = 0;//Posiciones iniciales (coordenada inicial por defecto es 0,0)
            bool q;
            double segundos;
            Stopwatch time = new Stopwatch();
            String result;
            opc = menu();//Leemos para ver si entra al ciclo
            while (opc != '5')
            {
                switch (opc)
                {//Como ya se valida en menu que sea una opción dentro del menú, no se requiere el default
                    case '1'://Modificar un tamaño
                        Console.WriteLine("Ingresa el tamaño que peude ir de 3 a 8");
                        size = leeIntRang(3, 8);//Valida que este de 3 a 8
                        Console.WriteLine("Tamaño modificado a: " + size);
                        break;
                    case '2'://Indicar posición de inicio
                        String answ = "Coordenada inicial X,Y: (" + x + "," + y + ")" + Environment.NewLine;
                        Console.WriteLine("Ingresa la nueva posición en X");
                        x = leeIntRang(1, size);//Valida inclusive
                        Console.WriteLine("Ingresa la nueva posición en Y");
                        y = leeIntRang(1, size);//Valida inclusive
                        Console.WriteLine(answ + "Nueva coordenada: (" + x + "," + y + ")");
                        break;
                    case '3'://Ver mi configuración
                        Console.WriteLine("Tamaño del tablero: " + size);
                        Console.WriteLine("Coordenada de inicio X,Y: (" + x + "," + y + ")");
                        break;
                    case '4'://Proceder a la simulación
                             //Inicializando
                        result = "";
                        caminos = 0;
                        q = false;
                        //Inicio
                        opc = menu();
                        int[,] tablero = new int[size, size];
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
                        if (q)
                        { /* hay solucion: la muestra. */
                            for (int i = 0; i < size; i++)
                            {
                                for (int j = 0; j < size; j++)
                                    Console.Write(tablero[i, j]);
                                Console.WriteLine();//Cada fin de renglón, saltamos la línea
                            }
                            result += "Se encontró un resultado partiendo de la coordenada (" + x + "," + y + ")" + Environment.NewLine;
                            result += "Tiempo de búsqueda que se demoró la solución: " + segundos.ToString() + Environment.NewLine;
                            result += "Caminos explorados (contando la solución): " + caminos;
                        }
                        else
                        {
                            result += "No encontró un resultado partiendo de la coordenada (" + x + "," + y + ")" + Environment.NewLine;
                            result += "Tiempo de búsqueda sin éxito: " + segundos.ToString() + Environment.NewLine;
                            result += "Caminos explorados sin éxito: " + caminos;
                        }
                        break;
                    case '5'://Salir
                        Console.WriteLine("Finalizando el sistema.");
                        break;
                }
                Console.WriteLine("Ingresa una tecla para continuar...");
                Console.ReadKey();
                FrmUsrHub salir = new FrmUsrHub(usuario.getUsrName());
                salir.Show();
            }
            /* pone el primer movimiento */
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
                if (tam < min || tam > min)
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
                Console.WriteLine("Bienvenid@ a El caballo.\n\tSelecciona una opción:\n\t\t1. Modificar un tamaño (por defecto es 5 unidades)\n\t\t2. Indicar posición de inicio\n\t\t3. Ver mi configuración\n\t\t4.Proceder a la simulación\n\t\t5. Salir");
                opc = isChar();//Leemos y valida que sea estrictamente un valor
                if (opc != '1' && opc != '2' && opc != '3' && opc != '4' && opc != '5')
                {
                    Console.WriteLine(Environment.NewLine + "Error. Ingresa una opción del menú" + Environment.NewLine);
                    val = false;
                }
                else
                {//Si es una opción del menú, regresamos el valor al main
                    val = true;
                }
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
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
