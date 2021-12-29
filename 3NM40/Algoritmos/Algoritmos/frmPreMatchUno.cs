using System;
using System.Media;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class frmPreMatchUno : Form
    {
        SoundPlayer load = new SoundPlayer(Multimedia.Sonido_barcos);
        public frmPreMatchUno()
        {
            InitializeComponent();
            load.PlayLooping();
            cboDificultad.Items.Clear();
            cboDificultad.Items.Add("Fácil");
            cboDificultad.Items.Add("Normal");
            cboDificultad.Items.Add("Difícil");
            cboDificultad.Items.Add("EXTREMA");
            cboDificultad.SelectedIndex = 0;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            load.Stop();
            frmInicio2 regresar = new frmInicio2();
            regresar.Show();
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "")
            {
                load.Stop();
                frmUnjugador INICIO = new frmUnjugador(cboDificultad.SelectedIndex + 1, txtnombre.Text);
                INICIO.Show();
                this.Hide();
            }
            else
                lblmensaje.Visible = true;
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            cValidaciones valida = new cValidaciones();
            valida.SoloLetrasSEspacios(e);
        }

        private void frmPreMatchUno_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
