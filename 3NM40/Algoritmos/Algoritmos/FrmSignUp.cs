using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
            inicializa();
        }

        private Clases.Usuario addUsr()
        {
            bool valid = true;//Validamos que se pueda formar la CURP
            Clases.Usuario usuario = new Clases.Usuario();
            try
            {
                if (usuario.valNomAps(txtNombres.Text) != "")//Validamos que sean correctos los nombres
                {
                    lblError.Text = usuario.valNomAps(txtNombres.Text);
                    valid = false;
                }
                else//De otro modo extraemos
                {
                    usuario.setFechaNac(dtpFecha.Value);
                    usuario.setNombres(txtNombres.Text);
                    usuario.setIdSexo(cboSexo.SelectedIndex + 1);
                    usuario.setIdTipoUser(3);//En este formulario solo se dan de alta jugadores
                    usuario.setPasswd(txtPass.Text);
                    //Parte de la foto
                    ImageConverter imageConverter = new ImageConverter();
                    Byte[] xByte = (Byte[])imageConverter.ConvertTo(picFoto.Image, typeof(Byte[]));
                    try
                    {
                        usuario.setFoto(xByte);
                    }
                    catch (Exception)
                    {

                    }
                    //Conexión a DB para la entidad y además sacamos el Usrname (CURP)
                    char[] sexo = cboSexo.Text.ToCharArray();
                    usuario.setUsrName(usuario.subCurp(Char.ToUpper(sexo[0]), Clases.Usuario.getCveEntidad(cboLugarNac.SelectedIndex + 1), txtHomoclave.Text));
                    //ahorita asignamos en la DB (si sale algo mal se manda el error)
                    if (!Clases.InicioSesion.signUp(usuario))//Si al darlo de alta marca falso
                    {
                        usuario = null;//marcado como no apto
                        lblError.Text += "Los datos que has registrado ya existen, si olvidaste tu password ponte en contacto con el administrador de la app: ";
                    }
                    else
                    {
                        MessageBox.Show("¡Usuario creado!" + Environment.NewLine + "Ingresa con tu CURP y contraseña en el inicio" + Environment.NewLine + "Tu Usuario: " + usuario.getUsrName());
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text += "Ha ocurrido un error, revisa tus datos: " + ex.Message;
                usuario = null;
            }
            if (!valid)
            {
                lblError.Text += "Revisa tus nombres, no son correctos. Recuerda poner Nombre y apellidos";
                usuario = null;
            }
            return usuario;
        }
        //Lenado de drop down lists
        private DataTable llenadoddl(String sp)
        {
            return Clases.InicioSesion.llenadoddl(sp);
        }
        /// <summary>
        /// EVENTOS
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String direccion = "";
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";
            BuscarImagen.FileName = direccion;
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                direccion = BuscarImagen.FileName;
                string Direction = BuscarImagen.FileName;
                this.picFoto.ImageLocation = Direction;
                picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void btnMuestra_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                btnMuestra.Text = "mostrar";
                txtPass.PasswordChar = '*';
            }
            else
            {
                btnMuestra.Text = "ocultar";
                txtPass.PasswordChar = '\0';
            }
        }

        private void FrmSignUp_Resize(object sender, EventArgs e)
        {
            float size = this.Size.Width / 674F;//La unidad=674;
            lblFecha.Font = new Font(lblFecha.Font.Name, 11F * size, lblFecha.Font.Style, lblFecha.Font.Unit);
            lblNombres.Font = new Font(lblNombres.Font.Name, 11F * size, lblNombres.Font.Style, lblNombres.Font.Unit);
            lblSexo.Font = new Font(lblSexo.Font.Name, 11F * size, lblSexo.Font.Style, lblSexo.Font.Unit);
            lblPass.Font = new Font(lblPass.Font.Name, 11F * size, lblPass.Font.Style, lblPass.Font.Unit);
            lblPassConf.Font = new Font(lblPassConf.Font.Name, 11F * size, lblPassConf.Font.Style, lblPassConf.Font.Unit);
            lblHomoclave.Font = new Font(lblHomoclave.Font.Name, 11F * size, lblHomoclave.Font.Style, lblHomoclave.Font.Unit);
            lblFoto.Font = new Font(lblFoto.Font.Name, 11F * size, lblFoto.Font.Style, lblFoto.Font.Unit);
            //Text Boxes
            txtNombres.Font = new Font(txtNombres.Font.Name, 11F * size, txtNombres.Font.Style, txtNombres.Font.Unit);
            txtPass.Font = new Font(txtPass.Font.Name, 11F * size, txtPass.Font.Style, txtPass.Font.Unit);
            txtPassConf.Font = new Font(txtPassConf.Font.Name, 11F * size, txtPassConf.Font.Style, txtPassConf.Font.Unit);
            txtHomoclave.Font = new Font(txtHomoclave.Font.Name, 11F * size, txtHomoclave.Font.Style, txtHomoclave.Font.Unit);
            dtpFecha.Font = new Font(dtpFecha.Font.Name, 11F * size, dtpFecha.Font.Style, dtpFecha.Font.Unit);
            cboSexo.Font = new Font(cboSexo.Font.Name, 11F * size, cboSexo.Font.Style, cboSexo.Font.Unit);
            cboLugarNac.Font = new Font(cboLugarNac.Font.Name, 11F * size, cboLugarNac.Font.Style, cboLugarNac.Font.Unit);
            //Mensajes
            lblMssPass.Font = new Font(lblMssPass.Font.Name, 6F * size, lblMssPass.Font.Style, lblMssPass.Font.Unit);
            lblMssNombres.Font = new Font(lblMssNombres.Font.Name, 6F * size, lblMssNombres.Font.Style, lblMssNombres.Font.Unit);
            lblError.Font = new Font(lblError.Font.Name, 5F * size, lblError.Font.Style, lblError.Font.Unit);
            lblLugar.Font = new Font(lblLugar.Font.Name, 6F * size, lblLugar.Font.Style, lblLugar.Font.Unit);
            //Botones
            btnBuscar.Font = new Font(btnBuscar.Font.Name, 10F * size, btnBuscar.Font.Style, btnBuscar.Font.Unit);
            btnMuestra.Font = new Font(btnBuscar.Font.Name, 7F * size, btnBuscar.Font.Style, btnBuscar.Font.Unit);
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.TextLength == 20)
                lblMssPass.Visible = true;
            else
                lblMssPass.Visible = false;
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            bool valid = true;
            Clases.Usuario usuario;
            lblError.Text = "";//Reiniciamos etiqueta que muestralos errores
            if (txtPass.TextLength < 4)
            {
                lblError.Text += Environment.NewLine + "->La contraseña debe tener 4 caracteres como mínimo";
                valid = false;
            }
            if (txtPass.Text != txtPassConf.Text) 
            {
                lblError.Text += Environment.NewLine + "->Las contraseñas no coinciden";
                valid = false;
            }
            if(txtNombres.Text == "")
            {
                lblError.Text += Environment.NewLine + "->No has ingresado tu nombre y apellidos";
                valid = false;
            }
            if(txtHomoclave.TextLength != 2)
            {
                lblError.Text += Environment.NewLine + "->Ingresa los dos ultimos dígitos de tu CURP";
                valid = false;
            }
            if (dtpFecha.Value >= DateTime.Today.Date)
            {
                lblError.Text += Environment.NewLine + "->La fecha no puede ser mayor o igual a hoy";
                valid = false;
            }
            else if (Clases.Usuario.getEdad(dtpFecha.Value) < 8 || Clases.Usuario.getEdad(dtpFecha.Value) > 110)//edad mínima de 8 años
            {
                lblError.Text += Environment.NewLine + "->Debes tener 8 años mínimo para registrarte y a lo más 110";
                valid = false;
            }
            if (valid)//Si pasa la validación tipo 1, se valida que no exista ya el usuario y que los nombres estén correctos para formar la CURP
            {
                //Añadimos datos de usuario al usuario
                usuario = addUsr();//añade usuario y devuelve nullo si no pasa las validaciones de tipo II
                if (usuario != null)
                {
                    FrmInicio frmInicio = new FrmInicio();
                    frmInicio.Show();
                    this.Hide();
                }
            }
        }

        private void FrmSignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// OTRAS FUNCIONES
        /// </summary>
        private void inicializa()
        {
            cboSexo.DataSource = llenadoddl("spFillSexos");//Llenamos sexos
            cboSexo.DisplayMember = "sexo";
            cboSexo.ValueMember = "idSexo";
            cboLugarNac.DataSource = llenadoddl("spFillEntFed");//Llenamos Entidades
            cboLugarNac.DisplayMember = "entFed";
            cboLugarNac.ValueMember = "idEntFed";
            tLPButtons.BackColor = Color.Transparent;
            tLPDatos.BackColor = Color.Transparent;
            tLPFoto.BackColor = Color.Transparent;
        }
    }
}
