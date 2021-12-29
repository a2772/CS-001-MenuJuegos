using System;
using System.Media;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class frmReglas : Form
    {
        SoundPlayer play = new SoundPlayer(Multimedia.Fondo2);
        SoundPlayer hit = new SoundPlayer(Multimedia.HitmarkII);
        public frmReglas()
        {
            InitializeComponent();
            play.PlayLooping();
        }
        private void hideall()
        {//Oculta todos los picturebox
            pic1.Visible = false;
            pic2.Visible = false;
            pic3.Visible = false;
            pic4.Visible = false;
            pic5.Visible = false;
            pic6.Visible = false;
            pic7.Visible = false;
            pic8.Visible = false;
            pic9.Visible = false;
            rchtxtinfo.Text = "";
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            play.Stop();
            hit.PlaySync();
            frmInicio2 inicio = new frmInicio2();
            inicio.Show();
            this.Hide();
        }

        private void frmReglas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void rbtn1_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn1.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Tabla VS:" + Environment.NewLine + Environment.NewLine + "En esta sección del tablero se mostrará el nombre que hayas elegido y el nombre de tu rival en función de la dificultad a la que te hayas decidido enfrentar (para saber más de las dificultades, en la sección de consejos vienen algunos tips de cuál elegir y cuando). En esta sección también puedes regresar al menú de inicio si así lo deseas (te pide confirmación por lo que no saldrás por accidente) pero ten en cuenta que esto hará que pierdas tu partida actual.";
                pic1.Visible = true;
            }
        }

        private void rbtn2_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn2.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Guia:" + Environment.NewLine + Environment.NewLine + "Aquí podrás consultar lo que hace cada disparo y que tablero es cuál (algo que te ayudará mucho en tus primeras partidas), además te muestra la simbología y que significa cada casilla del tablero (en secciones más adelantes hablaremos de la simbología y las armas).";
                pic2.Visible = true;
            }
        }

        private void rbtn3_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn3.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Consola de ataque:" + Environment.NewLine + Environment.NewLine + "En esta consola podrás proceder a realizar el ataque al enemigo. Su funcionamiento consise en dos áreas:" + Environment.NewLine + Environment.NewLine + "Área de selección de disparo: donde seleccionas el tipo de arma que veremos en la sección 'Municiones y Barcos'." + Environment.NewLine + Environment.NewLine + "Área de selección de casilla: Donde seleccionarás la(s) casilla(s) según la munición que hayas elegido (te darás cuenta de que algunas municiones bloquean ciertas ubicaciones, esto lo trataremos más adelante). Una vez que selecciones las coordenadas verás más abajo una opción de 'Mantener selección'. Te recomendamos dejarla activada si lo que quieres es que las opciones de disparo no se reinicien tras cada ataque." + Environment.NewLine + Environment.NewLine + "Una vez que Seleccionas el disparo y la ubicación, da click en ataque y se te pedirá una confirmación. Una vez que revises que está todo correcto, da click en 'Sí', de lo contrario y si quieres cambiar alguna selección, da click en 'No'. (Nota: La ruleta que suena es el rival mientras elige un disparo y una ubicación)";
                pic3.Visible = true;
            }
        }

        private void rbtn4_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn4.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Consola de notas:" + Environment.NewLine + Environment.NewLine + "En esta consola podrás hacer anotaciones durante la partida como recordatorios para objetivos que planees hundir despues para aprovechar algún tipo de disparo, contar las municiones que ha usado el enemigo si consideras que es necesario (estas municiones no puedes verlas durante la partida), entre otros usos que puedes encontrar." + Environment.NewLine + Environment.NewLine + "Además, esta sección mostrará cuando la partida haya concluido (ya sea porque venciste o porque venció tu enemigo) con un sonido distintivo, los resultados y un breve mensaje de la conclusión de la batalla. No puede haber empate, si ganas primero el juego terminará.";
                pic4.Visible = true;
            }
        }

        private void rbtn7_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn7.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Tableros:" + Environment.NewLine + Environment.NewLine + "Aquí se muestran tus vehículos, zonas atacadas y hundidas con una simbología que indica su estado, en el tablero B que es el enemigo no puedes ver sus vehículos hasta que los impactas. TODOS los vehículos miran hacia la derecha, ten eso en cuenta";
                pic7.Visible = true;
            }
        }

        private void rbtn5_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn5.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Reportes post Ataque:" + Environment.NewLine + Environment.NewLine + "Aquí aparece lo que ocurrió con tu ataque y lo que hizo tu enemigo, puedes tomar notas de lo que ha usado tu enemigo si lo consideras útil o visualizar tu tablero A (véase en Tableros) y ver que es lo que te fue atacado";
                pic5.Visible = true;
            }
        }

        private void rbtn6_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn6.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Municiones y Barcos:" + Environment.NewLine + Environment.NewLine + "Municiones: Aparece la cantidad de municiones, no lo pierdas de vista y aprovéchalas. Munición A: Golpea en una ubicación específica X,Y,Z. Munición B: Golpea en una ubicación específica, pero recorre desde la ubicación Y=1 (desde arriba donde están los aviones) hasta encontrar un objetivo o hasta que se acabe la zona de juego. Munición C: Recorre como el disparo B pero de manera horizontal desde el frente de la armada enemiga (comienza desde la posición H hacia A). Munición D: Golpea las casillas a su alrededor pudiendo formar un área de ataque de hasta 3X3X3." + Environment.NewLine + Environment.NewLine + "Barcos(vehículos, todos miden 1 de alto):" + Environment.NewLine + "Aviones: Cuentas con 2, son como se muestra en la imagen de 'Visualizar Tablero'. Se ubican en la capa 1 y 2 y cuenta con 2 vidas (las vidas son los impactos que debe recibir para ser derribado)" + Environment.NewLine + "Barcos: Cuentas con 1 y mide 2X4. Se ubica en la capa 3 y cuenta con 6 vidas" + Environment.NewLine + "Submarinos grandes (1X4 con 3 vidas) y pequeños (1X2 con 2 vidas): Ocupan las capas 4 a 8 y cuentas con 5 grandes y 8 pequeños" + Environment.NewLine + Environment.NewLine + "Otros: También puedes seleccionar el tablero que quieres visualizar, la capa del mismo, la dificultad y el turno actual. El tablero A es es tuyo y el B es el enemigo, en la parte de simbología puedes ver que significa cada casilla";
                pic6.Visible = true;
            }
        }

        private void rbtn8_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn8.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Visualizar Tablero:" + Environment.NewLine + Environment.NewLine + "Aquí se muestran de manera general como se ve el tablero o Interfaz de juego.";
                pic8.Visible = true;
            }
        }

        private void rbtn9_CheckedChanged(object sender, EventArgs e)
        {
            hideall();
            if (rbtn9.Checked)
            {//Imagen y texto
                rchtxtinfo.Text = "Simbología:" + Environment.NewLine + Environment.NewLine + "Aquí se muestra la simbología de cada casilla.";
                pic9.Visible = true;
            }
        }
    }
}
