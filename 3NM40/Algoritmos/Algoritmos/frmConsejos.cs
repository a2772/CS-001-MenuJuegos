using System;
using System.Media;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class frmConsejos : Form
    {
        SoundPlayer fondo3 = new SoundPlayer(Multimedia.Fondo3);
        public frmConsejos()
        {
            InitializeComponent();
            fondo3.PlayLooping();
        }

        private void frmConsejos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void rbtnMunicion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMunicion.Checked)
                rchtxtConsejo.Text = "Como ya leiste en las reglas, hay 4 tipos de munición (A,B,C y D). Te" + Environment.NewLine + "adelantamos que el mejor uso de los disparos especial será el de revelar" + Environment.NewLine + "las ubicaciones de los vehículos, en vez de usarlas para destruir.Ahora" + Environment.NewLine + "te daremos unos consejos de cómo utilizarlas y cuando:" + Environment.NewLine + Environment.NewLine + "- Munición tipo D: Como ya se mencionó en las reglas, su área de acción" + Environment.NewLine + "o impacto es la mayor de todos, ya que es la única que no se detiene al" + Environment.NewLine + "impactar un objetivo.Por esto mismo y como tu objetivo principal es el" + Environment.NewLine + "de ubicar los diferentes navíos de guerra, te recomendamos usarla" + Environment.NewLine + "primero y en una zona central.Ahora a que nos referimos con una zona" + Environment.NewLine + "central, pues a una zona que no sea obviamente una orilla (capas 1, 8, I," + Environment.NewLine + "V, A, H) pero también que, si la lanzas por ejemplo en la capa Y = 2, " + Environment.NewLine + "tengas en cuenta el tamaño de los aviones y que puedes abarcar una" + Environment.NewLine + "mejor área si la utilizas en una coordenada E en vez de una C, pues así" + Environment.NewLine + "al menos, si el avión está pegado atinarás a la cabeza, al avión de una" + Environment.NewLine + "capa inferior si es que lo hay e incluso al barco, revelando 3 objetivos" + Environment.NewLine + "con un solo disparo y terminandolos con un disparo básico tipo A.Lo" + Environment.NewLine + "mismo podría pasar si decides lanzarla en una capa inferior para revelar" + Environment.NewLine + "varios submarinos, lanzala a partir de la ubicación X = C, si quieres" + Environment.NewLine + " revelar submarinos pequeños, o combina lanzando este disparo en D" + Environment.NewLine + "y utilizando disparos verticales en la posición B para revelar submarinos" + Environment.NewLine + "en esa capa y si no están ahi, en las inferiores. El resto de los usos" + Environment.NewLine + "que le des depende de tu imaginación e ingenio." + Environment.NewLine + Environment.NewLine + "- Munición tipo C: Bueno, ahora es el turno de la munición tipo C, esta" + Environment.NewLine + "puede recorrer desde la ubicación X = H hasta el inicio, por lo que es bueno" + Environment.NewLine + "  que la combines con una bomba tipo D y en las filas que no haya cubierto," + Environment.NewLine + "usarla como buscador." + Environment.NewLine + Environment.NewLine + "- Munición tipo B: Esta munición es útil para cuando recorres capas" + Environment.NewLine + "superiores, pues recorrerá desde la más alta hasta la última, úsala cuando" + Environment.NewLine + "quieras atacar una ubicación en específico y estés en una capa alta, así," + Environment.NewLine + "si fallas en esa capa, tienes probabilidad de acertar en las inferiores." + Environment.NewLine + Environment.NewLine + "- Munición tipo A: Útil para terminar de hundir los vehículos revelados," + Environment.NewLine + "intenta utilizarla al final(cuando hayas usado las demás) o si quieres hundir" + Environment.NewLine + "ya algún objetivo." + Environment.NewLine + "Combina de manera adecuada las municiones y obtendrás la victoria." + Environment.NewLine;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            fondo3.Stop();
            frmInicio2 inicio = new frmInicio2();
            inicio.Show();
            this.Hide();
        }

        private void rbtnNavios_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNavios.Checked)
                rchtxtConsejo.Text = "En cuanto a las armadas, se asignan de manera aleatoria (ten en cuenta" + Environment.NewLine + "que, al enfrentarte a un bot, esto no afecta en como se desempeña y" + Environment.NewLine + "ayuda a ahorrar tiempo). Sin embargo hay algunas cosas que debes" + Environment.NewLine + "tener en cuenta: La primera es que cada vehículo tiene su espacio(los" + Environment.NewLine + "aviones las capas superiores, los barcos la superficie y los submarinos" + Environment.NewLine + "las capas dentro del mar) pero además entre ellos nunca se encontrarán" + Environment.NewLine + "pegados por así decirlo, pues mantendrán una distancia de una" + Environment.NewLine + "coordenada entre ellos(en X o Z unicamente, si pueden estár en" + Environment.NewLine + "diagonal, tenlo en cuanta cuando los busques).Otra cosa es que, " + Environment.NewLine + "los submarinos tienen las mismas probabilidades de aparecer en" + Environment.NewLine + "cualquier capa, el barco solo en una, pero los aviones no. Éstos lo más" + Environment.NewLine + "probable es que haya uno en cada capa, se debe a que la probabilidad" + Environment.NewLine + "de que se cumpla la condición de que estén separados por una" + Environment.NewLine + "coordenada es más baja por lo que puede ocurrir pero es poco" + Environment.NewLine + "probable y si ocurre, estarán cada uno en un extremo." + Environment.NewLine + "" + Environment.NewLine + "Además ten en cuenta el número de vidas de cada vehículo:" + Environment.NewLine + "            submarinos pequeños 2 vidas y 2 ubicaciones(2X1), submarinos grandes" + Environment.NewLine + " 3 vidas y 4 ubicaciones(4X1), barco o portaaviones 6 vidas y 8(2X4)" + Environment.NewLine + "ubicaciones y por último el avión con 2 vidas y 6 ubicaciones(4X1 +" + Environment.NewLine + "2 de las alas ubicadas detrás de la cabeza o cabina)." + Environment.NewLine + "" + Environment.NewLine + "Por último recuerda que todos los vehículos miran hacia la derecha, así" + Environment.NewLine + "que no habrá ninguno en otra orientación." + Environment.NewLine;
        }

        private void rbtnOponentes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOponentes.Checked)
                rchtxtConsejo.Text = "Por último, los oponentes a los que te enfrentas se comportan diferente" + Environment.NewLine + "en función de la dificultad seleccionada. Verás que los de la dificultad" + Environment.NewLine + "Difícil y extrema juegan más o menos de acuerdo con estos consejos." + Environment.NewLine + "Por ello te sugerimos que si es una de tus primeras partidas y quieres" + Environment.NewLine + "solo aprender a jugar eligas la dificultad fácil o normal, en ellas será" + Environment.NewLine + "difícil que pierdas, en las otras dos la cosa se complica bastante, te las" + Environment.NewLine + "recomendamos para partidas ya más avanzadas y cuando domines estos" + Environment.NewLine + "consejos y tengas estrategias ya planteadas. La dificultad extrema es" + Environment.NewLine + "algo difícil de vencer pero no es imposible, se ha comprobado que" + Environment.NewLine + "puede ser derrotada pero debes dominar el juego como un verdadero" + Environment.NewLine + "maestro, si la logras superar tienes todo nuestro respeto." + Environment.NewLine + "" + Environment.NewLine + "Sin más esperamos que estos consejos te sirvan para iniciar y aprender" + Environment.NewLine + "más rápido las mejores estrategias y usos de las armas que tienes a tu" + Environment.NewLine + "disposición y los más importante, ¡Diviértete!" + Environment.NewLine;
        }

        private void rbtnempezar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnempezar.Checked)
                rchtxtConsejo.Text = "Para empezar puedes iniciar una partida en Fácil si aún no" + Environment.NewLine + "comprendes bien lo de las municiones, ver como afecta cada" + Environment.NewLine + "una en el tablero y comenzar tu diseño de estrategia." + Environment.NewLine + "" + Environment.NewLine + "Otra cosa que puedes hacer es jugar con el nivel más alto" + Environment.NewLine + "y observar que movimientos hace al principio." + Environment.NewLine + "" + Environment.NewLine + "Sin embargo no intentes completar primero esa dificultad," + Environment.NewLine + "pues te parecerá muy complicada. Busca concretar una partida" + Environment.NewLine + "en el nivel más sencillo o en normal, luego ve si puedes dominar" + Environment.NewLine + "la dificultad Difícil y cuando lo hagas podrás considerar probar" + Environment.NewLine + "la última." + Environment.NewLine + "" + Environment.NewLine + "Recuerda que si lo necesitas en algún momento, consulta esta" + Environment.NewLine + "sección y ve si algo puede ayudarte a mejorar." + Environment.NewLine;
        }

        private void frmConsejos_Load(object sender, EventArgs e)
        {

        }
    }
}
