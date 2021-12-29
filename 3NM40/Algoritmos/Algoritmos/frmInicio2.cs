using System;
using System.Media;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class frmInicio2 : Form
    {
        SoundPlayer play = new SoundPlayer(Multimedia.Sonido_Fondo);
        SoundPlayer hitmark = new SoundPlayer(Multimedia.HitmarkII);
        public frmInicio2()
        {
            InitializeComponent();
            play.PlayLooping();
        }

        private void frmInicio2_Load(object sender, EventArgs e)
        {
            SoundPlayer sonidofondo = new SoundPlayer(@"~\");
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            hitmark.PlaySync();
            Application.Exit();
        }

        private void btn1player_Click(object sender, EventArgs e)
        {
            play.Stop();
            hitmark.PlaySync();
            frmPreMatchUno uno = new frmPreMatchUno();
            uno.Show();
            this.Hide();
        }

        private void btnReglas_Click(object sender, EventArgs e)
        {
            play.Stop();
            hitmark.PlaySync();
            frmReglas rules = new frmReglas();
            rules.Show();
            this.Hide();
        }

        private void frmInicio2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnConsejos_Click(object sender, EventArgs e)
        {
            play.Stop();
            frmConsejos cons = new frmConsejos();
            cons.Show();
            this.Hide();
        }
    }
}
