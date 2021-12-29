using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Algoritmos
{
    public partial class FrmUsrHub : Form
    {
        Clases.Usuario usuario = new Clases.Usuario();
        String NombreDeUsuario;
        public FrmUsrHub(String nomUsuario)
        {
            NombreDeUsuario = nomUsuario;
            InitializeComponent();
            inicializa();
        }

        private DataTable llenaDDL(String sp)
        {
            return Clases.InicioSesion.llenadoddl(sp);
        }

        /// <summary>
        /// EVENTOS
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            //Parte de la foto
            ImageConverter imageConverter = new ImageConverter();
            Byte[] xByte = (Byte[])imageConverter.ConvertTo(picFoto.Image, typeof(Byte[]));
            try
            {
                this.usuario.setFoto(xByte);
            }
            catch (Exception) { }
            Clases.Actualizaciones.updtFoto(this.usuario);
        }

        private void btnBuscaFoto_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            String direccion = "";
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";
            BuscarImagen.FileName = direccion;
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                string Direction = BuscarImagen.FileName;
                this.picFoto.ImageLocation = Direction;
                picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void FrmUsrHub_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void inicializa()
        {
            //Obtenemos el usuario
            this.usuario = Clases.Consultas.getUsrByUsrname(NombreDeUsuario);
            //Llenamos las drop down list:
            cboMenu.DataSource = llenaDDL("spFillMenu");//Llenamos sexos
            cboMenu.DisplayMember = "menu";
            cboMenu.ValueMember = "idMenu";
            //Llenamos las drop down list:
            cboJuegos.DataSource = llenaDDL("spFillJuegos");//Llenamos sexos
            cboJuegos.DisplayMember = "juego";
            cboJuegos.ValueMember = "idJuego";
            //Inicializando otros componentes con valores específicos
            panLBottom.BackColor = Color.Transparent;
            panLUpper.BackColor = Color.Transparent;
            panRBottom.BackColor = Color.Transparent;
            panRUpper.BackColor = Color.Transparent;
            dGVPuntos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dGVPuntos.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            if (usuario.getFoto() != null)
            {//Si tiene imagen
                try
                {
                    /*
                    SqlConnection con = Clases.Conexion.getConn();
                    SqlDataAdapter da = new SqlDataAdapter("select foto from tbPasswords where idPassword = 2", con);
                    DataTable dt;
                    dt = new DataTable();
                    da.Fill(dt);
                    dgvaux.DataSource = dt;
                    MemoryStream ms = new MemoryStream((byte[])dgvaux.CurrentRow.Cells[0].Value);
                    picFoto.Image = Image.FromStream(ms);*/
                }
                catch (Exception) { }
            }
            txtEdad.Text = Clases.Usuario.getEdad(usuario.getFechaNac()).ToString();
            txtUsrName.Text = usuario.getUsrName();
            txtPunt.Text = Clases.Consultas.getPunctTotal(usuario).ToString();
            if (Clases.Consultas.getPunctTotal(usuario) > 0)
                txtPunt.BackColor = Color.Aquamarine;
            if (Clases.Consultas.getPunctTotal(usuario) > 2000)
            {
                txtPunt.BackColor = Color.Green;
                txtPunt.ForeColor = Color.Silver;
            }
            if (Clases.Consultas.getPunctTotal(usuario) > 6000)
            {
                txtPunt.BackColor = Color.Red;
                txtPunt.ForeColor = Color.White;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void btnLetsPlay_Click(object sender, EventArgs e)
        {
            if (cboMenu.SelectedIndex == 0)
            {//Es juego
                switch (cboJuegos.SelectedIndex)
                {
                    case 0:
                        Pacman pacman = new Pacman(usuario.getUsrName());
                        pacman.Show();
                        this.Hide();
                        break;
                    case 1:
                        frmInicio2 subZero = new frmInicio2();//Por el momento no está habilitado
                        subZero.Show();
                        this.Hide();
                        break;
                }
            }
            else//Es actividad
            {
                switch (cboJuegos.SelectedIndex)
                {
                    case 0:
                        Process.Start("Caballo.exe");
                        break;
                }
            }
        }

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboMenu.SelectedIndex)
            {
                case 0:
                    //Llenamos las drop down list:
                    cboJuegos.DataSource = llenaDDL("spFillJuegos");//Llenamos sexos
                    cboJuegos.DisplayMember = "juego";
                    cboJuegos.ValueMember = "idJuego";
                    btnLetsPlay.Text = "Abrir Juego";
                    break;
                case 1:
                    //Llenamos las drop down list:
                    cboJuegos.DataSource = llenaDDL("spFillActividades");//Llenamos sexos
                    cboJuegos.DisplayMember = "actividad";
                    cboJuegos.ValueMember = "idActividad";
                    btnLetsPlay.Text = "Abrir Actividad";
                    break;
            }
        }
    }
}
