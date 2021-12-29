using System;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            inicializa();//Inicializa ciertos componentes en el código (Se encuentra al final de la clase)
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {//Cuando el usuario da click en ingresar hay varios casos
            String aux = "";//Para la hora del día que sea
            if (DateTime.Now.Hour < 12)
                aux += "      ¡Buenos días";
            else if (DateTime.Now.Hour < 19)
                aux += "      ¡Buenas tardes!";
            else
                aux += "      ¡Buena noche!";
            switch (Clases.InicioSesion.login(txtUsr.Text, txtPass.Text))//Devuelve el tipo de usuario, o un valor de 0 si no encontró al mismo
            {
                case 0://No limpiamos los campos por si se equivocó en algo mínimo. A futuro se planea implementar la recuperación de contraseña por correo
                    MessageBox.Show("Nombre de usuario y contraseña no corresponden a un usuario" + Environment.NewLine + "Ingresalos correctamente o crea una cuenta si aún no tienes una");
                    break;
                case 1://Tiene acceso a un formulario con los datos de todos en cada juego. A futuro se planea que pueda editar los perfiles y agregar administradores secundarios
                    MessageBox.Show("¡Bienvenido Administrador!" + Environment.NewLine + aux);
                    break;
                case 2://Este caso aún no se habilita, se planeaba hacer a futuro para agregarle muchas más funciones
                    MessageBox.Show("¡Bienvenido admin!" + Environment.NewLine + aux);
                    break;
                case 3://Tiene acceso a su perfil, donde puede participar en los juegos y ver las puntuaciones más altas así como las suyas
                    FrmUsrHub frmUsrHub = new FrmUsrHub(txtUsr.Text);
                    MessageBox.Show(aux + Environment.NewLine + "¡Bienvenido Jugador!" + Environment.NewLine + "¿Listo para un reto?");
                    frmUsrHub.Show();
                    this.Hide();
                    break;
                //No usamos default porque el método login devuelve solo esos valores
            }
        }
        /// <summary>
        /// EVENTOS
        /// </summary>
        private void btnSignUp_Click(object sender, EventArgs e)
        {//Lo manda al formulario de registro
            FrmSignUp frmSignUp = new FrmSignUp();
            frmSignUp.Show();
            this.Hide();
        }

        private void FrmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {//Si cierra el formulario, cerramos la aplicación
            Application.Exit();
        }

        private void txtUsr_KeyPress(object sender, KeyPressEventArgs e)
        {//Validamos que solo puedan ingresarse mayúsculas 
            Clases.Validaciones.onlyLettersNubers(e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// OTRAS FUNCIONES
        /// </summary>
        private void inicializa()
        {
            tLPUser.BackColor = Color.Transparent;
            tLPPass.BackColor = Color.Transparent;
            tLPLogUp.BackColor = Color.Transparent;
            tLPaceptar.BackColor = Color.Transparent;
        }
    }
}
