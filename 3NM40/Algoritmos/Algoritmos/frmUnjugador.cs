using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class frmUnjugador : Form
    {
        private char[,,] pseudo = new char[8, 8, 8];//Pseudo arreglo
        private int tamtabx, tamtaby, tamtabz, turnos, dificultad;//Tamtab x,y,z si se usan para las posiciones de los arreglos aunque marque que no se utilizan
        bool endgame;
        Jugador[] player = new Jugador[2];//Arreglo de objetos jugador, se crean 2 (hay dos jugadores)
        Tablero[] tab = new Tablero[2];
        //Armas (al usarse, solo se restan del objeto Jugador o municiones)
        Armas.cArma1[] disparo1 = new Armas.cArma1[1];
        Armas.cArma2[] disparo2 = new Armas.cArma2[2];
        Armas.cArma3[] disparo3 = new Armas.cArma3[2];
        Armas.cArma4[] disparo4 = new Armas.cArma4[2];
        SoundPlayer hitmark = new SoundPlayer(Multimedia.HitmarkII);
        SoundPlayer espera = new SoundPlayer(Multimedia.Sonido_barcos);
        public frmUnjugador(int dif, string name)
        {
            InitializeComponent();
            chbxHold.Checked = true;
            //Tamaños de los limites del tablero
            dificultad = dif;//Asignamos la dificultad dif
            lbljugador.Text = name;
            switch (dificultad)
            {
                case 1:
                    lblRival.Text = "Teniente" + Environment.NewLine + "  Brigs";
                    picRival.Image = Multimedia.Teniente;
                    break;
                case 2:
                    lblRival.Text = " Capitán" + Environment.NewLine + "Degustador";
                    picRival.Image = Multimedia.Capitan;
                    break;
                case 3:
                    lblRival.Text = "General" + Environment.NewLine + "Farid";
                    picRival.Image = Multimedia.General;
                    break;
                case 4:
                    lblRival.Text = "Parche" + Environment.NewLine + "    El  " + Environment.NewLine + " Pirata";
                    picRival.Image = Multimedia.Parche;
                    break;
            }
            tamtabx = 8; tamtaby = 8; tamtabz = 5;
            endgame = false;
            turnos = 1;
            player[0] = new Jugador(tamtabx, tamtaby, tamtabz);//Para motivos didácticos y prácticos, los tamaños serán fijo, aunque si es necesario puede modificarse para que sean dinámicos en esta parte
            tab[0] = new Tablero(player[0].getSub_p(), player[0].getSub_g(), player[0].getAviones(), player[0].getBarcos(), player[0].getlimit(), tamtabx, tamtaby, tamtabz);
            player[1] = new Jugador(tamtabx, tamtaby, tamtabz);
            tab[1] = new Tablero(player[1].getSub_p(), player[1].getSub_g(), player[1].getAviones(), player[1].getBarcos(), player[1].getlimit(), tamtabx, tamtaby, tamtabz);
            //Armas
            disparo1[0] = new Armas.cArma1();//Una para ambos, ya que no usa munición y solo se utilizan sus métodos
            disparo2[0] = new Armas.cArma2(10);
            disparo2[1] = new Armas.cArma2(10);
            disparo3[0] = new Armas.cArma3(10);
            disparo3[1] = new Armas.cArma3(10);
            disparo4[0] = new Armas.cArma4(2);
            disparo4[1] = new Armas.cArma4(2);
            //Añadir al combo box vista de capa
            cboNivel.Items.Clear();
            cboNivel.Items.Add("1");
            cboNivel.Items.Add("2");
            cboNivel.Items.Add("3");
            cboNivel.Items.Add("4");
            cboNivel.Items.Add("5");
            cboNivel.Items.Add("6");
            cboNivel.Items.Add("7");
            cboNivel.Items.Add("8");
            cboNivel.SelectedIndex = 0;
            //Añadir a los combo box coordenadas
            cboposX.Items.Clear();
            cboposX.Items.Add("A");
            cboposX.Items.Add("B");
            cboposX.Items.Add("C");
            cboposX.Items.Add("D");
            cboposX.Items.Add("E");
            cboposX.Items.Add("F");
            cboposX.Items.Add("G");
            cboposX.Items.Add("H");
            cboposX.SelectedIndex = 0;
            //
            cboposY.Items.Clear();
            cboposY.Items.Add("1");
            cboposY.Items.Add("2");
            cboposY.Items.Add("3");
            cboposY.Items.Add("4");
            cboposY.Items.Add("5");
            cboposY.Items.Add("6");
            cboposY.Items.Add("7");
            cboposY.Items.Add("8");
            cboposY.SelectedIndex = 0;
            //
            cboposZ.Items.Clear();
            cboposZ.Items.Add("I");
            cboposZ.Items.Add("II");
            cboposZ.Items.Add("III");
            cboposZ.Items.Add("IV");
            cboposZ.Items.Add("V");
            cboposZ.SelectedIndex = 0;
            //Municiones restantes al inicio
            lblmunB.Text = "B: " + Convert.ToString(disparo2[0].getmun());
            lblmunC.Text = "C: " + Convert.ToString(disparo3[0].getmun());
            lblmunD.Text = "D: " + Convert.ToString(disparo4[0].getmun());
        }
        public void automata()//Lo que hace el bot durante su turno
        {
            //Inicia algoritmo de selección aleatorio en función de la dificultad, usará adecuadamente o de la manera menos reomendada los proyectiles
            SoundPlayer ruleta = new SoundPlayer(Multimedia.MarioK_Itemv2);
            SoundPlayer ruletF = new SoundPlayer(Multimedia.MarioK_Item2_2);
            var random = new Random(Guid.NewGuid().GetHashCode());//Semilla aleatoria
            int x, y, z, iterapensar = 0, recupx = cboposX.SelectedIndex, recupy = cboposY.SelectedIndex, recupz = cboposZ.SelectedIndex;
            int munB = disparo2[1].getmun(), munC = disparo3[1].getmun(), MunD = disparo4[1].getmun(), tipousado;
            char rbtn;
            if (rbtnDisparoA.Checked)
                rbtn = 'A';
            else if (rbtnDisparoB.Checked)
                rbtn = 'B';
            else if (rbtnDisparoC.Checked)
                rbtn = 'C';
            else
                rbtn = 'D';
            //Inicializamos municiones, como es el fácil casi nunca usará las municiones especiales, se limitará a los básicos
            bool usar;
            //Para los phantom se obtiene el tablero del jugador 0
            tab[0].enviaTab(ref pseudo);
            ruleta.PlayLooping();
            switch (dificultad)
            {
                case 1://Fácil: No verifica espacios ya atacados, usa los disparos especiales en las esquinas y en capas altas 
                    iterapensar = random.Next(10, 15);
                    do
                    {
                        usar = false;
                        tipousado = random.Next(0, 100);
                        if (tipousado < 5 && MunD > 0)//0-4 son 5 numeros enteros
                        {//Disparo D lo usa en las orillas
                            usar = true;
                            x = random.Next(0, 2);//De 0 a 1, cada uno es uno de los extremos
                            y = random.Next(0, 2);
                            z = random.Next(0, 2);
                            if (x > 0)
                                x = tamtabx - 1;//8-1, posicion 7
                            if (y > 0)
                                y = tamtaby - 1;//8-1, posicion 7
                            if (z > 0)
                                z = tamtabz - 1;//5-4, posicion 4
                                                //Asignada la posición random, se procede a asignar los valores para el ataque
                            rbtnDisparoD.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 14 && munC > 0)
                        {

                            usar = true;
                            y = random.Next(0, 2);
                            z = random.Next(0, 2);
                            x = tamtabx - 1;
                            if (y > 0)
                                y = tamtaby - 1;//8-1, posicion 7
                            if (z > 0)
                                z = tamtabz - 1;//5-4, posicion 4
                                                //Asignada la posición random, se procede a asignar los valores para el ataque
                            rbtnDisparoC.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 23 && munB > 0)
                        {
                            usar = true;
                            x = random.Next(0, 2);//De 0 a 1, cada uno es uno de los extremos
                            z = random.Next(0, 2);
                            if (x > 0)
                                x = tamtabx - 1;//8-1, posicion 7
                            y = 0;
                            if (z > 0)
                                z = tamtabz - 1;//5-4, posicion 4
                                                //Asignada la posición random, se procede a asignar los valores para el ataque
                            rbtnDisparoB.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado > 22 && tipousado < 101)
                        {
                            usar = true;
                            x = random.Next(0, tamtabx);//De 0 a 7 (tamytab vale 8 pero el random regresa de 0 a tamtab-1)
                            y = random.Next(0, tamtaby);
                            z = random.Next(0, tamtabz);
                            if (random.Next(0, 10) == 9)//10% de que ataque en una capa superior (donde menos ataques se requieren)
                                y = random.Next(0, Convert.ToInt32(Math.Round(tamtaby * 0.3)));
                            //Asignada la posición random, se procede a asignar los valores para el ataque
                            rbtnDisparoA.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                    } while (!usar);
                    break;
                case 2://Media, los ataques especiales D no los hace en las orillas, por lo demás es aleatorio y puede repetir ataques, pero el tipo A tiene una probabilidad del 66.6% de no repetir cada vez que se asigna
                    iterapensar = random.Next(15, 25);
                    do
                    {
                        usar = false;
                        tipousado = random.Next(0, 100);
                        if (tipousado < 10 && MunD > 0)//10%
                        {
                            usar = true;
                            x = random.Next(1, tamtabx - 1);
                            y = random.Next(1, tamtaby - 1);
                            z = random.Next(1, tamtabz - 1);
                            rbtnDisparoD.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 25 && munC > 0)//15%
                        {
                            usar = true;
                            y = random.Next(0, tamtaby);
                            z = random.Next(0, tamtabz);
                            x = tamtabx - 1;
                            rbtnDisparoC.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 40 && munB > 0)//15%
                        {
                            usar = true;
                            x = random.Next(0, tamtabx);
                            z = random.Next(0, tamtabz);
                            y = 0;
                            rbtnDisparoB.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado > 39 && tipousado < 101)
                        {
                            x = random.Next(0, tamtabx);//De 0 a 7 (tamytab vale 8 pero el random regresa de 0 a tamtab-1)
                            y = random.Next(0, tamtaby);
                            z = random.Next(0, tamtabz);
                            //Evalúa al 50% de que no se repita
                            if (disparo1[0].phant(pseudo, x, y, z) && (random.Next(0, 3) > 0))//Se desperdiciaría
                            {
                                rbtnDisparoA.Select();
                                cboposX.SelectedIndex = x;
                                cboposY.SelectedIndex = y;
                                cboposZ.SelectedIndex = z;
                                usar = true;
                            }//Si llega a cumplirse que se repite y el 66.6%, no lo usa y repite el ciclo
                        }
                    } while (!usar);
                    break;
                case 3://Dificil, juega los disparos de manera óptima y no los repite, además usa primero los dos disparos D en dos posiciones estratégicas (1 en capa 2-3 y el otro en la capa 5-7)
                    iterapensar = random.Next(25, 35);
                    do
                    {
                        usar = false;
                        tipousado = random.Next(0, 100);
                        if (MunD > 0)//100% mientras exista, por ello no usa phantom
                        {
                            usar = true;
                            x = random.Next(1, tamtabx - 1);
                            z = random.Next(1, tamtabz - 1);
                            if (MunD > 1)
                            {
                                y = random.Next(1, tamtaby - 5);//Capas2-3 en valor arreglo que equivalen a 1-2
                            }
                            else
                            {
                                y = random.Next(tamtaby - 4, tamtaby - 2);//Capas 5-7 qeu equivalen a 4-6
                            }
                            rbtnDisparoD.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 25 && munC > 0)//25%
                        {
                            usar = true;
                            int ite = 100;//En caso de que se repita 100 veces sale del ciclo (lo cual es muy poco probable)
                            do
                            {
                                y = random.Next(0, tamtaby);
                                z = random.Next(0, tamtabz);
                                ite--;
                            } while (disparo3[1].phantom(pseudo, y, z, tamtabx) && ite > 0);//Si se desperdiciaría, vuelve a generarlos
                            rbtnDisparoC.Select();
                            cboposX.SelectedIndex = tamtabx - 1;//siempre es la ultima posición
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 50 && munB > 0)//25%
                        {
                            usar = true;
                            int ite = 100;//En caso de que se repita 100 veces sale del ciclo (lo cual es muy poco probable)
                            do
                            {
                                x = random.Next(0, tamtabx);
                                z = random.Next(0, tamtabz);
                                ite--;
                            } while (disparo2[1].pantom(pseudo, x, 0, z, tamtaby) && ite > 0);
                            rbtnDisparoB.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = 0;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado > 49 && tipousado < 101)
                        {
                            int ite = 200;
                            do
                            {
                                x = random.Next(0, tamtabx);
                                y = random.Next(0, tamtaby);
                                z = random.Next(0, tamtabz);
                                ite--;
                            } while (disparo1[0].phant(pseudo, x, y, z) && ite > 0);
                            rbtnDisparoA.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                            usar = true;
                        }
                    } while (!usar);
                    break;
                case 4://Humano, juega con una manera óptima y lógica, no tanto al azar y evlúa las situaciones mejor incluso que algunos jugadores novatos... 
                    iterapensar = random.Next(35, 50);
                    do
                    {
                        usar = false;
                        tipousado = random.Next(0, 100);
                        if (MunD > 0)//100% mientras exista, por ello no usa phantom
                        {
                            usar = true;
                            x = random.Next(1, tamtabx - 1);
                            z = random.Next(1, tamtabz - 1);
                            if (MunD > 1)
                            {
                                y = random.Next(1, tamtaby - 5);//Capas2-3 en valor arreglo que equivalen a 1-2
                            }
                            else
                            {
                                y = random.Next(tamtaby - 4, tamtaby - 2);//Capas 5-7 qeu equivalen a 4-6
                            }
                            rbtnDisparoD.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 50 && munC > 0)//50%
                        {
                            usar = true;
                            int ite = 100;//En caso de que se repita 100 veces sale del ciclo (lo cual es muy poco probable)
                            do
                            {
                                y = random.Next(0, tamtaby);
                                z = random.Next(0, tamtabz);
                                ite--;
                            } while (disparo3[1].phantom(pseudo, y, z, tamtabx) && ite > 0);//Si se desperdiciaría, vuelve a generarlos
                            rbtnDisparoC.Select();
                            cboposX.SelectedIndex = tamtabx - 1;//siempre es la ultima posición
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                        }
                        else if (tipousado < 101 && munB > 0)//50%
                        {
                            usar = true;
                            int ite = 100;//En caso de que se repita 100 veces sale del ciclo (lo cual es muy poco probable)
                            do
                            {
                                x = random.Next(0, tamtabx);
                                z = random.Next(0, tamtabz);
                                ite--;
                            } while (disparo2[1].pantom(pseudo, x, 0, z, tamtaby) && ite > 0);
                            rbtnDisparoB.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = 0;
                            cboposZ.SelectedIndex = z;
                        }
                        else//Cuando ya no hay munición especial
                        {
                            int ite = 200;
                            x = 0;
                            y = 0;
                            z = 0;//Me pide inicializar
                            //El iniciaY y va a servir para que los ataques no sean tan aleatorios
                            int iniciaY = 0;//Por default va en 0
                            if (player[0].getAviones() == 0 && player[0].getBarcos() == 0)
                                iniciaY = 3;
                            else if (player[0].getAviones() == 0)
                                iniciaY = 2;
                            do
                            {
                                if (random.Next(0, 100) > 54)
                                {//55% de usar wallhacks
                                    int auxi, auxj, auxk;
                                    for (auxj = iniciaY; auxj < tamtaby; auxj++)//Va de arriba a abajo
                                        for (auxi = 0; auxi < tamtabx; auxi++)
                                            for (auxk = 0; auxk < tamtabz; auxk++)
                                            {
                                                if (pseudo[auxi, auxj, auxk] == Convert.ToChar(253) || pseudo[auxi, auxj, auxk] == Convert.ToChar(252) || pseudo[auxi, auxj, auxk] == Convert.ToChar(251) || pseudo[auxi, auxj, auxk] == Convert.ToChar(250))
                                                {
                                                    x = auxi;
                                                    y = auxj;
                                                    z = auxk;
                                                    //salir
                                                    auxi = tamtabx;
                                                    auxj = tamtaby;
                                                    auxk = tamtabz;
                                                }
                                            }
                                }
                                else//Usa un disparo normal que no se repita
                                {
                                    x = random.Next(0, tamtabx);
                                    y = random.Next(0, tamtaby);
                                    z = random.Next(0, tamtabz);
                                }
                                ite--;
                            } while (disparo1[0].phant(pseudo, x, y, z));
                            rbtnDisparoA.Select();
                            cboposX.SelectedIndex = x;
                            cboposY.SelectedIndex = y;
                            cboposZ.SelectedIndex = z;
                            usar = true;
                        }
                    } while (!usar);
                    break;
            }
            ataque(0);//Al final procede a hacer el ataque
            ///(simulador de pensar)
            //

            while (iterapensar > 0)
            {
                cboposX.SelectedIndex = random.Next(0, 8);
                cboposY.SelectedIndex = random.Next(0, 8);
                cboposZ.SelectedIndex = random.Next(0, 5);
                switch (random.Next(0, 4))
                {
                    case 0:
                        rbtnDisparoA.Select();
                        break;
                    case 1:
                        rbtnDisparoB.Select();
                        break;
                    case 2:
                        rbtnDisparoC.Select();
                        break;
                    case 3:
                        rbtnDisparoD.Select();
                        break;
                }
                iterapensar--;
            }
            ///Fin simulador
            /////Resetea todas las opciones después de eso ya que cambia las listas cbo, el rbtn disparo
            if (chbxHold.Checked)//Si se mantiene la selección
            {
                switch (rbtn)
                {
                    case 'A':
                        rbtnDisparoA.Select();
                        break;
                    case 'B':
                        rbtnDisparoB.Select();
                        break;
                    case 'C':
                        rbtnDisparoC.Select();
                        break;
                    case 'D':
                        rbtnDisparoD.Select();
                        break;
                }
                cboposX.SelectedIndex = recupx;
                cboposY.SelectedIndex = recupy;
                cboposZ.SelectedIndex = recupz;
            }
            else
            {
                rbtnDisparoA.Select();
                cboposX.SelectedIndex = 0;
                cboposY.SelectedIndex = 0;
                cboposZ.SelectedIndex = 0;
            }
            ruleta.Stop();
            ruletF.PlaySync();
        }
        public void showtab(int y, int aux)//Megafunction
        {
            int i, j = y - 1, k, type;
            tab[aux].enviaTab(ref pseudo);
            for (i = 0; i < tamtabx; i++)
                for (k = 0; k < tamtabz; k++)
                {
                    if (pseudo[i, j, k] == Convert.ToChar(254))
                        type = 1;//Vacio (nada no hay no existe)
                    else if (pseudo[i, j, k] == Convert.ToChar(249))
                        type = 2;//Ha sido disparado algo ahí
                    else
                        type = tab[aux].parteveh(i, j, k);//Type se envía a otra función que define que imagen se carga
                    cargatab(type, aux, i, k);//Carga la imagen del tablero tipo A
                }
        }
        private void CargaTablero()//Carga las imagenes
        {
            int vehs = 1;
            if (rbtnA.Checked)
            {
                showtab(Convert.ToInt32(cboNivel.SelectedItem.ToString()), 0);
                this.BackColor = Color.DarkKhaki;
                vehs = 0;
            }
            else if (rbtnB.Checked)
            {
                showtab(Convert.ToInt32(cboNivel.SelectedItem.ToString()), 1);
                this.BackColor = Color.Gray;
                vehs = 1;
            }
            lblAviones.Text = "Aviones: " + player[vehs].getAviones().ToString();
            lblbarcos.Text = "Barcos: " + player[vehs].getBarcos().ToString();
            lblsubg.Text = "Subs grandes: " + player[vehs].getSub_g().ToString();
            lblsubp.Text = "Subs pequeños: " + player[vehs].getSub_p().ToString();
            lblturnos.Text = " Turno" + Environment.NewLine + "número" + Environment.NewLine + "   " + turnos.ToString();
            switch (dificultad)
            {
                case 1:
                    lbldificultad.Text = "Dificultad:" + Environment.NewLine + "   Fácil" + Environment.NewLine;
                    lbldificultad.BackColor = Color.Magenta;
                    break;
                case 2:
                    lbldificultad.Text = "Dificultad:" + Environment.NewLine + "  Normal" + Environment.NewLine;
                    lbldificultad.BackColor = Color.White;
                    break;
                case 3:
                    lbldificultad.Text = "Dificultad:" + Environment.NewLine + " Difícil" + Environment.NewLine;
                    lbldificultad.BackColor = Color.Blue;
                    break;
                case 4:
                    lbldificultad.Text = "Dificultad:" + Environment.NewLine + " EXTREMA" + Environment.NewLine;
                    lbldificultad.BackColor = Color.Red;
                    break;
            }
        }
        private void cargatab(int type, int tablero, int x, int z)//Recibe el tipo de imagen, en que tablero y la picture box
        {//Muestra las imágenes correspondientes del array
         //Todas las imágenes
            ///Summary
            ///254=vacío
            ///253=Avión
            ///252=Barco
            ///251=Sub grande
            ///250=Sub pequeño
            ///de ahi al restarle 10  c/u indica que fue atacado
            ///otros 10 (230) indica que se hundió por falta de vidas
            //Bitmap Myimage = new Bitmap(path);
            Bitmap[] Imagenes = new Bitmap[60];
            int index = 0;
            //Se cargan en el tablero:
            Imagenes[0] = Multimedia.c254;
            switch (type)
            {
                case 1://Vacío
                    index = 0;
                    break;
                case 2:
                    Imagenes[1] = Multimedia.c249;
                    index = 1;
                    break;
                case 111:
                    Imagenes[2] = Multimedia.c2531;
                    index = 2;
                    break;
                case 112:
                    Imagenes[3] = Multimedia.c2532;
                    index = 3;
                    break;
                case 113:
                    Imagenes[4] = Multimedia.c2533;
                    index = 4;
                    break;
                case 114:
                    Imagenes[5] = Multimedia.c2534;
                    index = 5;
                    break;
                case 115:
                    Imagenes[6] = Multimedia.c2535;
                    index = 6;
                    break;
                case 116:
                    Imagenes[7] = Multimedia.c2536;
                    index = 7;
                    break;
                case 121:
                    Imagenes[8] = Multimedia.c2431;
                    index = 8;
                    break;
                case 122:
                    Imagenes[9] = Multimedia.c2432;
                    index = 9;
                    break;
                case 123:
                    Imagenes[10] = Multimedia.c2433;
                    index = 10;
                    break;
                case 124:
                    Imagenes[11] = Multimedia.c2434;
                    index = 11;
                    break;
                case 125:
                    Imagenes[12] = Multimedia.c2435;
                    index = 12;
                    break;
                case 126:
                    Imagenes[13] = Multimedia.c2436;
                    index = 13;
                    break;
                case 131:
                    Imagenes[14] = Multimedia.c2331;
                    index = 14;
                    break;
                case 132:
                    Imagenes[15] = Multimedia.c2332;
                    index = 15;
                    break;
                case 133:
                    Imagenes[16] = Multimedia.c2333;
                    index = 16;
                    break;
                case 134:
                    Imagenes[17] = Multimedia.c2334;
                    index = 17;
                    break;
                case 135:
                    Imagenes[18] = Multimedia.c2335;
                    index = 18;
                    break;
                case 136:
                    Imagenes[19] = Multimedia.c2336;
                    index = 19;
                    break;
                //Barcos
                case 211:
                    Imagenes[20] = Multimedia.c2521;
                    index = 20;
                    break;
                case 212:
                    Imagenes[21] = Multimedia.c2522;
                    index = 21;
                    break;
                case 213:
                    Imagenes[22] = Multimedia.c2523;
                    index = 22;
                    break;
                case 214:
                    Imagenes[23] = Multimedia.c2524;
                    index = 23;
                    break;
                case 215:
                    Imagenes[24] = Multimedia.c2525;
                    index = 24;
                    break;
                case 216:
                    Imagenes[25] = Multimedia.c2526;
                    index = 25;
                    break;
                case 217:
                    Imagenes[26] = Multimedia.c2527;
                    index = 26;
                    break;
                case 218:
                    Imagenes[27] = Multimedia.c2528;
                    index = 27;
                    break;
                case 221:
                    Imagenes[28] = Multimedia.c2421;
                    index = 28;
                    break;
                case 222:
                    Imagenes[29] = Multimedia.c2422;
                    index = 29;
                    break;
                case 223:
                    Imagenes[30] = Multimedia.c2423;
                    index = 30;
                    break;
                case 224:
                    Imagenes[31] = Multimedia.c2424;
                    index = 31;
                    break;
                case 225:
                    Imagenes[32] = Multimedia.c2425;
                    index = 32;
                    break;
                case 226:
                    Imagenes[33] = Multimedia.c2426;
                    index = 33;
                    break;
                case 227:
                    Imagenes[34] = Multimedia.c2427;
                    index = 34;
                    break;
                case 228:
                    Imagenes[35] = Multimedia.c2428;
                    index = 35;
                    break;
                case 231:
                    Imagenes[36] = Multimedia.c2321;
                    index = 36;
                    break;
                case 232:
                    Imagenes[37] = Multimedia.c2322;
                    index = 37;
                    break;
                case 233:
                    Imagenes[38] = Multimedia.c2323;
                    index = 38;
                    break;
                case 234:
                    Imagenes[39] = Multimedia.c2324;
                    index = 39;
                    break;
                case 235:
                    Imagenes[40] = Multimedia.c2325;
                    index = 40;
                    break;
                case 236:
                    Imagenes[41] = Multimedia.c2326;
                    index = 41;
                    break;
                case 237:
                    Imagenes[42] = Multimedia.c2327;
                    index = 42;
                    break;
                case 238:
                    Imagenes[43] = Multimedia.c2328;
                    index = 43;
                    break;
                //Subamrinos grandes
                case 311:
                    Imagenes[44] = Multimedia.c2511;
                    index = 44;
                    break;
                case 312:
                    Imagenes[45] = Multimedia.c2512;
                    index = 45;
                    break;
                case 313:
                    Imagenes[46] = Multimedia.c2513;
                    index = 46;
                    break;
                case 314:
                    Imagenes[47] = Multimedia.c2514;
                    index = 47;
                    break;
                case 321:
                    Imagenes[48] = Multimedia.c2411;
                    index = 48;
                    break;
                case 322:
                    Imagenes[49] = Multimedia.c2412;
                    index = 49;
                    break;
                case 323:
                    Imagenes[50] = Multimedia.c2413;
                    index = 50;
                    break;
                case 324:
                    Imagenes[51] = Multimedia.c2414;
                    index = 51;
                    break;
                case 331:
                    Imagenes[52] = Multimedia.c2311;
                    index = 52;
                    break;
                case 332:
                    Imagenes[53] = Multimedia.c2312;
                    index = 53;
                    break;
                case 333:
                    Imagenes[54] = Multimedia.c2313;
                    index = 54;
                    break;
                case 334:
                    Imagenes[55] = Multimedia.c2314;
                    index = 55;
                    break;
                //Submarino pequeño
                case 411:
                    Imagenes[56] = Multimedia.c2501;
                    index = 56;
                    break;
                case 412:
                    Imagenes[57] = Multimedia.c2502;
                    index = 57;
                    break;
                case 421:
                    Imagenes[58] = Multimedia.c2401;
                    index = 58;
                    break;
                case 422:
                    Imagenes[59] = Multimedia.c2402;
                    index = 59;
                    break;
                default:
                    index = 0;
                    break;
            }
            if (tablero == 1)
            {//Se carga el tablero anterior pero con cambios ocultando lo necesario
                if (type > 110 && type < 117)
                    index = 0;
                else if (type > 210 && type < 219)
                    index = 0;
                else if (type > 310 && type < 315)
                    index = 0;
                else if (type > 410 && type < 413)
                    index = 0;
            }
            //Switch con todas las picture pox
            switch (x)//Como está tipo arreglo es uno adelante X y Z
            {
                case 0:
                    switch (z)
                    {
                        case 0:
                            picAI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picAII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picAIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picAIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picAV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 1:
                    switch (z)
                    {
                        case 0:
                            picBI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picBII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picBIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picBIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picBV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 2:
                    switch (z)
                    {
                        case 0:
                            picCI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picCII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picCIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picCIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picCV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 3:
                    switch (z)
                    {
                        case 0:
                            picDI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picDII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picDIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picDIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picDV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 4:
                    switch (z)
                    {
                        case 0:
                            picEI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picEII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picEIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picEIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picEV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 5:
                    switch (z)
                    {
                        case 0:
                            picFI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picFII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picFIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picFIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picFV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 6:
                    switch (z)
                    {
                        case 0:
                            picGI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picGII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picGIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picGIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picGV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
                case 7:
                    switch (z)
                    {
                        case 0:
                            picHI.Image = (Image)Imagenes[index];
                            break;
                        case 1:
                            picHII.Image = (Image)Imagenes[index];
                            break;
                        case 2:
                            picHIII.Image = (Image)Imagenes[index];
                            break;
                        case 3:
                            picHIV.Image = (Image)Imagenes[index];
                            break;
                        case 4:
                            picHV.Image = (Image)Imagenes[index];
                            break;
                    }
                    break;
            }
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            hitmark.Play();
            btnInicio.Enabled = false;
            btnQuedarse.Visible = true;
            btnIrse.Visible = true;
            lblConfSalir.Visible = true;
        }

        private void btnIrse_Click(object sender, EventArgs e)
        {
            hitmark.PlaySync();
            frmInicio2 regresar = new frmInicio2();
            regresar.Show();
            this.Hide();
        }

        private void cboNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaTablero();
        }

        private void frmUnjugador_Load(object sender, EventArgs e)
        {
            CargaTablero();
        }

        private void rbtnA_CheckedChanged(object sender, EventArgs e)
        {
            hitmark.Play();
            if (rbtnA.Checked == true)
            {
                showtab(Convert.ToInt32(cboNivel.SelectedItem.ToString()), 0);
                this.BackColor = Color.DarkKhaki;
                lblFlota.Text = Environment.NewLine + "       MI" + Environment.NewLine + "TERRITORIO";
            }
            else
            {
                showtab(Convert.ToInt32(cboNivel.SelectedItem.ToString()), 1);
                this.BackColor = Color.Gray;
                lblFlota.Text = Environment.NewLine + "TERRITORIO" + Environment.NewLine + "  ENEMIGO";
            }
            CargaTablero();
        }

        private void rbtnB_CheckedChanged(object sender, EventArgs e)
        {
            CargaTablero();
        }

        private void btnQuedarse_Click(object sender, EventArgs e)
        {
            hitmark.Play();
            btnInicio.Enabled = true;
            btnQuedarse.Visible = false;
            btnIrse.Visible = false;
            lblConfSalir.Visible = false;
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            lblmensage.Visible = true;
            lblmensage.Text = "¿Confirmas el ataque en esta posición?";
            //Hacer visibles los botones
            bool procede = true;//Procede a menos que se demuestre lo contrario
            if (rbtnDisparoB.Checked)
            {
                if (disparo2[0].getmun() < 1)//Si hay munición se pide la confirmación
                {
                    lblmensage.Text = "¡No cuentas con munición B!";
                    procede = false;
                }
            }
            else if (rbtnDisparoC.Checked)
            {
                if (disparo3[0].getmun() < 1)//Si hay munición se pide la confirmación
                {
                    lblmensage.Text = "¡No cuentas con munición C!";
                    procede = false;
                }
            }
            else if (rbtnDisparoD.Checked)
            {
                if (disparo4[0].getmun() < 1)//Si hay munición se pide la confirmación
                {
                    lblmensage.Text = "¡No cuentas con munición D!";
                    procede = false;
                }
            }
            if (procede)//Si todo va bien, se procede a pedir confirmación, sino se
            {
                //Deshabilitar
                rbtnDisparoA.Enabled = false;
                rbtnDisparoB.Enabled = false;
                rbtnDisparoC.Enabled = false;
                rbtnDisparoD.Enabled = false;
                cboposX.Enabled = false;
                cboposY.Enabled = false;
                cboposZ.Enabled = false;
                btnAtacar.Enabled = false;
                //Pedir confirmación, si se niega, se rehabilita lo anterior
                btnNoConfirmo.Visible = true;
                btnConfirmo.Visible = true;
            }
        }

        private void rbtnDisparoA_CheckedChanged(object sender, EventArgs e)
        {
            rbtnDisparoschange();
        }

        private void rbtnDisparoB_CheckedChanged(object sender, EventArgs e)
        {
            rbtnDisparoschange();
        }

        private void rbtnDisparoC_CheckedChanged(object sender, EventArgs e)
        {
            rbtnDisparoschange();
        }

        private void rbtnDisparoD_CheckedChanged(object sender, EventArgs e)
        {
            rbtnDisparoschange();
        }

        private void rbtnDisparoschange()
        {//Hace los cambios necesarios cada vez que se cambia de disparo
            cboposX.Enabled = true;
            cboposY.Enabled = true;
            if (rbtnDisparoB.Checked)
            {
                //Se fija la capa y en 0
                cboposY.SelectedIndex = 0;
                cboposY.Enabled = false;
            }
            else if (rbtnDisparoC.Checked)
            {
                //Se fija la capa x en 0
                cboposX.SelectedIndex = 7;
                cboposX.Enabled = false;
            }
            CargaTablero();
        }
        private void btnNoConfirmo_Click(object sender, EventArgs e)
        {
            espera.Stop();
            hitmark.Play();
            rbtnDisparoA.Enabled = true;
            rbtnDisparoB.Enabled = true;
            rbtnDisparoC.Enabled = true;
            rbtnDisparoD.Enabled = true;
            cboposX.Enabled = true;
            cboposY.Enabled = true;
            cboposZ.Enabled = true;
            btnAtacar.Enabled = true;
            //Deshabilitar
            lblmensage.Visible = false;
            btnConfirmo.Visible = false;
            btnNoConfirmo.Visible = false;
        }

        private void btnConfirmo_Click(object sender, EventArgs e)
        {
            int resultp1;
            espera.Stop();
            hitmark.PlaySync();
            //Rehabilitar como en No confirmo, pero además proceder
            rbtnDisparoA.Enabled = true;
            rbtnDisparoB.Enabled = true;
            rbtnDisparoC.Enabled = true;
            rbtnDisparoD.Enabled = true;
            cboposX.Enabled = true;
            cboposY.Enabled = true;
            cboposZ.Enabled = true;
            btnAtacar.Enabled = true;
            //Deshabilitar
            lblmensage.Visible = false;
            btnConfirmo.Visible = false;
            btnNoConfirmo.Visible = false;
            //Comienza el ataque y respuestas enemigas con las funciones
            //Vacia los reportes:
            lblReporte.Text = "Reporte: ";//Se vacian porque van a concatenarse
            lblRepEnemigo.Text = "Reporte enemigo: ";
            resultp1 = ataque(1);//Es lo mismo para ambos jugadores, pero para el 1 se envía de objetivo el numero 1
            if ((player[1].getAviones() + player[1].getBarcos() + player[1].getSub_g() + player[1].getSub_p() > 0))//Si le quedan aviones al jugador 2 procede a su ataque
                automata();
            int gana = 0;//Si es 1, gana el jugador 1, si es 2 el bot
            if ((player[1].getAviones() + player[1].getBarcos() + player[1].getSub_g() + player[1].getSub_p() < 1))
            {//Si ya no hay ninguno
                endgame = true;
                gana = 1;
                SoundPlayer win1 = new SoundPlayer(Multimedia.Youwinexpert);
                SoundPlayer win2 = new SoundPlayer(Multimedia.Youwin);
                if (dificultad == 4)
                    win1.Play();
                else
                    win2.Play();
            }
            else if ((player[0].getAviones() + player[0].getBarcos() + player[0].getSub_g() + player[0].getSub_p() < 1))
            {
                SoundPlayer lose = new SoundPlayer(Multimedia.Youlose);
                lose.Play();
                endgame = true;
                gana = 2;
            }
            //Cargar radio buttons
            string[] dificult = { "Fácil", "Normal", "Difícil", "¿¡Extrema!?, Te otorgamos nuestra mención honorífica", "Extrema" };
            string[] desenlace = { "Has vencido al Teniente Brigs. Al rendirse y ser interrogado nos ha dado información del paradero de alguien del que sospechabamos hace tiempo que tenía intenciones de atracar una isla militar cercana con objetivos desconocidos. Tu próxima misión es derrotarlo y hacerle hablar para que nos de más detalles de sus malévolos planes. Ahora hemos dado la orden a nuestras tropas de avanzar y encontrarlo, se le conoce como: Capitán Deugustador. Está oculto (por ahora) en una ubicación del Océano Pacífico. Puede que esta batalla se te haya hecho sencilla, sin embargo no te confíes no sabemos que puede tramar el Caitán Deustador. Buena suerte y bien hecho. (Te han ascendido a General de Brigada)", "Has vencido al Capitán Degustador. Sabíamos que lo lograrías! Mientras intentaba huír en un pequeño navío logramos alcanzarlo y arestarlo, sin embargo aún desconocemos a qué armada o país pertenecía y porqué poseía tales armas y navíos de guerra, sin embargo lo que si conseguimos descubrir en el vehículo donde huía fue un mapa que lleva a... ¿¡Mitad del mar mediterráneo!?. Parece que no hay nada ahí, pero en su mapa aparece una isla oculta que se logra apreciar a contraluz (esto lo descubró nuestro equipo de inteligencia cuando lo mandamos a analizar). El equipo de inteligencia parece haber descubierto además de que hay una nota al pie que dice: 'Para tí mi Capitán, el 22.34% de los dominios que conseguiremos al concretar nuestro plan. Tú eliges cuales, solo sigue el plan y serás recompensado. Pd. No olvides traer los suministros militares para hacer crecer nuestra armada. Firma: General Farid'. Ahora sabemos quién está detrás de todo esto, parece que quiere suministros para financiar su ataque, lo que no sabemos es que planea atacar ni cuando. Debemos atraparlo antes de que se entere que capturamos al Capitán Degustador o se esconderá y no podremos dar con él. Mientras tanto lo felicitamos y por medio de la presente le hago saber de su ascenso a General de División! Tenga cuidado, algo me dice que este enemigo es mucho más inteligente que los dos anteriores pero confío en que es digno del rango que posee y logrará evitar que concrete sus planes. buena suerte General de División ", "Tras una larga batalla contra el General Farid, muchas de nuestras tropas fueron derrotadas, se alcanza ver a una misteriosa nave que sale del último vehículo de la flota enemiga que quedaba en pie. Decidimos seguirlo hasta una cueva que se ubicaba en la isla del mapa. Al acercarnos nos damos cuenta de que estaba llena de armas y había unos cuantos navíos por lo que decidimos retirarnos discretamente. Hemos marcado la ubicación en el mapa e iremos a registrarla en caunto reagrupemos una nueva flota. En cunto a Farid, fue hundido junto con la flota así que no nos pudo decir nada de los planes, recuperamos poco más que escombros. Esa isla misteriosa es la única pista que nos queda de los planes que tenía. Debemos atar los cabos sueltos. Has sido ascendido a Teniente General, hay que celebrarlo en lo que nuestras tropas se reagrupan! No debería ser tan difícil ahora que el General Farid ha sido derrotado, la próxima batalla seerá pan comido. Tómese un descanso, se lo ha ganado.", "(Tras una ardua batalla parece ser que soy el último que queda juto a los hombres de este navío, nunca habría esperado que tendríamos tantas perdidas, parece ser que las anteriores batallas fueron para apreder de nosotros y analizar nuestras debeilidades. Ahora el General de nuestra armada se ha ido nunca pensé que un pirata tuviera a su alcance tal armamento). (Meses después recibo una carta del cuartel general, algo polvosa y con una textura inusual y extraña que dice): Lamentamos sinceramente las pérdidas que tuvimos la batalla de hace unos meses y de su General *******. Sin embargo al usted ser el nuevo General debe enterarse del reporte post misión así que está adjunto a este documento: (EL documento adjunto es breve): El terrorista conocido como Parche el Pirata buscaba reunir no una armada, sino armas para contrabandear alrededor del mundo y había un vial de una sustancia aún desconocida que los científicos del laborio están investigando. Se desconoce si tenían planes además de contrabando de armas pero por el momento es la información que poseemos, le mantendremos al tanto (termina). Está firmada como PeP (lo que sea que signifique, no había oido escuchar de una organización así en el ejército pero supongo que es parte de inteligencia). Por el momento creo que tomaré un receso, me comienza a dar sueño. Fin del reporte. (Nota Final: Esperamos te hayas divertido y sabemos que el haber logrado pasar el nivel final es algo complicado así que gracias por perseverar. Esperamos que hayas desarrollado estrategias para este juego, analizado cuales son las mejores maneras de usar las municiones, en donde y lo importante que es conocer a tu enemigo. Pero lo más importante que te lo hayas pasado bien ;)  )" };
            SonidoResutante(resultp1);//Hace sonar según sea el caso
            if (!endgame)//Si no se ha terminado el juego
            {
                turnos++;
                CargaTablero();
            }
            else
            {
                btnAtacar.Enabled = false;
                if (gana == 1)
                {
                    rchtxtNotas.Text = "C:/Resultados de la partida: " + Environment.NewLine + Environment.NewLine + "Felicidades cadete, has superado la dificultad " + dificult[dificultad - 1] + Environment.NewLine + Environment.NewLine + desenlace[dificultad - 1];
                }
                else if (gana == 2)
                {//ganó 2
                    if (dificultad == 4)//Si es extrema toma el indice siguiente
                        dificultad++;
                    rchtxtNotas.Text = "C:/Resultados de la partida: " + Environment.NewLine + Environment.NewLine + "Lástima, no has logrado superar la dificultad " + dificult[dificultad - 1] + ". Tal vez la próxima lo logres, usa las municiones y tu inteligencia para lograrlo, ¡tú puedes!";
                }
                rchtxtNotas.ReadOnly = true;
            }
        }

        private void frmUnjugador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tLPTableroN2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void retiraveh(string tipo, int objetivo)
        {
            switch (tipo)
            {
                case "Avion":
                    player[objetivo].retira("Avion");//Se hunde el vehículo en jugador
                    break;
                case "Barco":
                    player[objetivo].retira("Barco");//Se hunde el vehículo en jugador
                    break;
                case "Submarino grande":
                    player[objetivo].retira("Sub_g");//Se hunde el vehículo en jugador
                    break;
                case "Submarino pequeño":
                    player[objetivo].retira("Sub_p");//Se hunde el vehículo en jugador
                    break;
            }
        }
        private void SonidoResutante(int caso)
        {
            SoundPlayer Fallado = new SoundPlayer(Multimedia.Aguaimpacto);
            SoundPlayer Acertado = new SoundPlayer(Multimedia.Contacto);
            SoundPlayer A = new SoundPlayer(Multimedia.Clock);
            SoundPlayer B = new SoundPlayer(Multimedia.Bombacayendo);
            SoundPlayer C = new SoundPlayer(Multimedia.torpedo);
            SoundPlayer D = new SoundPlayer(Multimedia.Kaboom);
            switch (caso)
            {
                case 11://1er numero es fallado o acertado 1=fallado,2=acertado. El segundo es el tipo de disparo usado A,B,C o D
                    A.PlaySync();
                    Fallado.Play();
                    break;
                case 12:
                    B.PlaySync();
                    Fallado.Play();
                    break;
                case 13:
                    C.PlaySync();
                    Fallado.Play();
                    break;
                case 14:
                    D.PlaySync();
                    Fallado.Play();
                    break;
                case 21:
                    A.PlaySync();
                    Acertado.Play();
                    break;
                case 22:
                    B.PlaySync();
                    Acertado.Play();
                    break;
                case 23:
                    C.PlaySync();
                    Acertado.Play();
                    break;
                case 24:
                    D.PlaySync();
                    Acertado.Play();
                    break;
            }
        }
        private int ataque(int objetivo)
        {//Toma todo lo necesario del formulario
            int resultp1 = 0;
            int Origen = 0;
            string vehhundido;
            if (objetivo == 0)
                Origen = 1;
            int x, y, z, auxpos;
            x = Convert.ToInt32(cboposX.SelectedIndex.ToString());//Al ser indice toma desde posición 0
            y = Convert.ToInt32(cboposY.SelectedIndex.ToString());
            z = Convert.ToInt32(cboposZ.SelectedIndex.ToString());
            //Obtenemos tablero objetivo
            tab[objetivo].enviaTab(ref pseudo);
            lblReporte.Visible = true;
            lblRepEnemigo.Visible = true;
            //Según el disparo seleccionado y ya validada la munición ataca y luego verifica si se hunde para agregarlo al reporte
            if (rbtnDisparoA.Checked)
            {
                if (disparo1[0].phant(pseudo, x, y, z))
                {
                    if (Origen == 0)
                    {
                        resultp1 = 11;
                        lblReporte.Text = lblReporte.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                    }
                    else
                        lblRepEnemigo.Text = lblRepEnemigo.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                }
                else
                {
                    if (disparo1[0].disp(ref pseudo, x, y, z))
                    {//Ataca y verifica si se hunde
                        if (Origen == 0)
                        {
                            resultp1 = 21;
                            lblReporte.Text = lblReporte.Text + "Acertaste disparo A lanzado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Acertó el disparo A lanzado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        if (tab[objetivo].aciertauno(ref x, ref y, ref z))
                        {//Si comprueba que está hundido después del ataque
                            vehhundido = tab[objetivo].buscayretira(x, y, z);
                            if (Origen == 0)
                                lblReporte.Text = lblReporte.Text + ". Has hundido: " + vehhundido;
                            else
                                lblRepEnemigo.Text = lblRepEnemigo.Text + ". Ha hundido: " + vehhundido;
                            retiraveh(vehhundido, objetivo);//Retiramos de jugador lo hundido
                        }
                    }
                    else
                    {
                        if (Origen == 0)
                        {
                            resultp1 = 11;
                            lblReporte.Text = lblReporte.Text + "Fallaste disparo A lanzado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Falló el disparo A lanzado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                    }
                }
            }
            else if (rbtnDisparoB.Checked)
            {
                if (disparo2[Origen].pantom(pseudo, x, y, z, tamtaby))
                {
                    disparo2[Origen].disparo(ref pseudo, x, y, z, tamtaby);//Hace el dipsparo para reducir munición
                    if (Origen == 0)
                    {
                        resultp1 = 12;
                        lblReporte.Text = lblReporte.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                    }
                    else
                        lblRepEnemigo.Text = lblRepEnemigo.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                }
                else
                {//Se usa if aunque se escribe dos veces la instruccion de disparo, sino el caso entraria en el else
                    auxpos = disparo2[Origen].disparo(ref pseudo, x, y, z, tamtaby);
                    if (auxpos > -1)
                    {//Verifica hundimientos
                        if (Origen == 0)
                        {
                            resultp1 = 22;
                            lblReporte.Text = lblReporte.Text + "Acertaste disparo B, impactó en: " + cboposX.SelectedItem.ToString() + ", " + (auxpos + 1).ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Acertó disparo B impactado en: " + cboposX.SelectedItem.ToString() + ", " + (auxpos + 1).ToString() + ", " + cboposZ.SelectedItem.ToString();
                        y = auxpos;
                        if (tab[objetivo].aciertauno(ref x, ref y, ref z))
                        {//Si comprueba que está hundido después del ataque
                            vehhundido = tab[objetivo].buscayretira(x, y, z);
                            if (Origen == 0)
                                lblReporte.Text = lblReporte.Text + ". Has hundido: " + vehhundido;//Busca con las coordenadas pasadas por referncia y lo hunde
                            else
                                lblRepEnemigo.Text = lblRepEnemigo.Text + ". Ha hundido: " + vehhundido;//Busca con las coordenadas pasadas por referncia y lo hunde
                            retiraveh(vehhundido, objetivo);//Retiramos de jugador lo hundido
                        }
                    }
                    else
                    {
                        if (Origen == 0)
                        {
                            resultp1 = 12;
                            lblReporte.Text = lblReporte.Text + "Disparo B fallido, lanzado desde: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Falló el disparo B lanzado desde: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                    }
                }
            }
            else if (rbtnDisparoC.Checked)
            {
                if (disparo3[Origen].phantom(pseudo, y, z, tamtabx))
                {
                    disparo3[Origen].disparo(ref pseudo, y, z, tamtabx);//Hace el dipsparo para reducir munición
                    if (Origen == 0)
                    {
                        resultp1 = 13;
                        lblReporte.Text = lblReporte.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                    }
                    else
                        lblRepEnemigo.Text = lblRepEnemigo.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                }
                else
                {//Se usa if aunque se escribe dos veces la instruccion de disparo, sino el caso entraria en el else
                    auxpos = disparo3[Origen].disparo(ref pseudo, y, z, tamtabx);
                    int auxselected;
                    if (auxpos > -1)
                    {
                        //Asigna el item en la combo X, como no es un numero como el caso del disparo anterior debe hacerse para los reportes
                        auxselected = cboposX.SelectedIndex;
                        cboposX.SelectedIndex = auxpos;
                        if (Origen == 0)
                        {
                            resultp1 = 23;
                            lblReporte.Text = lblReporte.Text + "Acertaste disparo C, impactó en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Acertó un disparo C impactado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        cboposX.SelectedIndex = auxselected;//Se recupera el índice que se tenía
                        //
                        x = auxpos;
                        if (tab[objetivo].aciertauno(ref x, ref y, ref z))
                        {//Si comprueba que está hundido después del ataque
                            vehhundido = tab[objetivo].buscayretira(x, y, z);
                            if (Origen == 0)
                                lblReporte.Text = lblReporte.Text + ". Has hundido: " + vehhundido;//Busca con las coordenadas pasadas por referncia y lo hunde
                            else
                                lblRepEnemigo.Text = lblRepEnemigo.Text + ". Ha hundido: " + vehhundido;//Busca con las coordenadas pasadas por referncia y lo hunde
                            retiraveh(vehhundido, objetivo);//Retiramos de jugador lo hundido
                        }
                    }
                    else
                    {
                        if (Origen == 0)
                        {
                            resultp1 = 13;
                            lblReporte.Text = lblReporte.Text + "Disparo C fallido, lanzado desde: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Disparo C fallido, lanzado desde: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                    }

                }
            }
            else if (rbtnDisparoD.Checked)
            {
                int pi = 0, pj = 0, pk = 0, li = 0, lj = 0, lk = 0;
                if (disparo4[Origen].phantom(pseudo, x, y, z, tamtabx, tamtaby, tamtabz))
                {
                    disparo4[Origen].disparo(ref pseudo, x, y, z, tamtabx, tamtaby, tamtabz, ref pi, ref pj, ref pk, ref li, ref lj, ref lk);//Hace el dipsparo para reducir munición
                    if (Origen == 0)
                    {
                        resultp1 = 14;
                        lblReporte.Text = lblReporte.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                    }
                    else
                        lblRepEnemigo.Text = lblRepEnemigo.Text + "Disparo desperdiciado, la zona ya había sido atacada o hundida";
                }
                else
                {//Se usa if aunque se escribe dos veces la instruccion de disparo, sino el caso entraria en el else
                    auxpos = disparo4[Origen].disparo(ref pseudo, x, y, z, tamtabx, tamtaby, tamtabz, ref pi, ref pj, ref pk, ref li, ref lj, ref lk);
                    if (auxpos > 0)//Si hubo algún impacto
                    {
                        if (Origen == 0)
                        {
                            resultp1 = 24;
                            lblReporte.Text = lblReporte.Text + "Acertaste disparo D, impactó en " + auxpos.ToString() + " objetivo(s)";
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Acertó el disparo D impactado en " + auxpos.ToString() + " objetivo(s)";
                        //Como este disparo se evalua en varias partes a la vez:
                        int av = 0, ba = 0, sg = 0, sp = 0;
                        if (tab[objetivo].unoomas(pi, pj, pk, li, lj, lk, ref av, ref ba, ref sg, ref sp))
                        {//Indica si hunde uno con true y ahi mismo los retira
                            if (Origen == 0)
                                lblReporte.Text = lblReporte.Text + ". Has hundido:";//Busca con los parámetros por referencia cuantos de c/u se hundieron
                            else
                                lblRepEnemigo.Text = lblRepEnemigo.Text + ". Ha hundido:";
                            if (av > 0)
                            {
                                if (Origen == 0)
                                    lblReporte.Text = lblReporte.Text + " Avion(es): " + av.ToString();
                                else
                                    lblRepEnemigo.Text = lblRepEnemigo.Text + " Avion(es): " + av.ToString();
                                do
                                {
                                    retiraveh("Avion", objetivo);//Retiramos de jugador lo hundido
                                    av--;
                                } while (av > 0);
                            }
                            if (ba > 0)
                            {
                                if (Origen == 0)
                                    lblReporte.Text = lblReporte.Text + " Barco(s): " + ba.ToString();
                                else
                                    lblRepEnemigo.Text = lblRepEnemigo.Text + " Barco(s): " + ba.ToString();
                                do
                                {
                                    retiraveh("Barco", objetivo);
                                    ba--;
                                } while (ba > 0);
                            }
                            if (sg > 0)
                            {
                                if (Origen == 0)
                                    lblReporte.Text = lblReporte.Text + " Submarino(s) grande(s): " + sg.ToString();
                                else
                                    lblRepEnemigo.Text = lblRepEnemigo.Text + " Submarino(s) grande(s): " + sg.ToString();
                                do
                                {
                                    retiraveh("Submarino grande", objetivo);
                                    sg--;
                                } while (sg > 0);
                            }
                            if (sp > 0)
                            {
                                if (Origen == 0)
                                    lblReporte.Text = lblReporte.Text + " Submarino(s) pequeño(s): " + sp.ToString();
                                else
                                    lblRepEnemigo.Text = lblRepEnemigo.Text + " Submarino(s) pequeño(s): " + sp.ToString();
                                do
                                {
                                    retiraveh("Submarino pequeño", objetivo);
                                    sp--;
                                } while (sp > 0);
                            }
                        }
                    }
                    else
                    {
                        if (Origen == 0)
                        {
                            resultp1 = 14;
                            lblReporte.Text = lblReporte.Text + "Disparo D fallido, lanzado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                        }
                        else
                            lblRepEnemigo.Text = lblRepEnemigo.Text + "Falló disparo D lanzado en: " + cboposX.SelectedItem.ToString() + ", " + cboposY.SelectedItem.ToString() + ", " + cboposZ.SelectedItem.ToString();
                    }
                }
            }
            CargaTablero();
            lblmunB.Text = "B: " + Convert.ToString(disparo2[0].getmun());
            lblmunC.Text = "C: " + Convert.ToString(disparo3[0].getmun());
            lblmunD.Text = "D: " + Convert.ToString(disparo4[0].getmun());
            return resultp1;
        }
        private void btnMusica_Click(object sender, EventArgs e)
        {
            espera.PlayLooping();
        }
    }
}
