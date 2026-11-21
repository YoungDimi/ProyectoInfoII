using GestionUsuarios;
using System;
using System.Windows.Forms;

namespace Formularios
{
    // ventana de login, sale antes que principal
    public partial class FormLogin : Form

    {
        Gestion mi_base = new Gestion();
        bool autenticado = false; // true cuando el usuario entra bien
        bool baseAbierta = false; // true si se ha podido abrir la base de datos

        public FormLogin()
        {
            InitializeComponent();
        }

        // devuelve true si el usuario ha entrado bien
        public bool GetAutenticado()
        {
            return autenticado;
        }

        // abre la base de datos, si no la encuentra avisa y bloquea los botones
        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (mi_base.Iniciar() == -1)
            {
                MessageBox.Show("No se encuentra la base de datos de usuarios (BaseDatos\\usuarios.db).");
                entrarButton.Enabled = false;
                registrarButton.Enabled = false;
            }
            else
            {
                baseAbierta = true;
            }
        }

        // comprueba el usuario y la contraseña, si estan bien cierra el login
        private void entrarButton_Click(object sender, EventArgs e)
        {
            string nombre = usuarioBox.Text;
            string password = passwordBox.Text;

            if (nombre == "" || password == "")
            {
                MessageBox.Show("Escribe el usuario y la contraseña.");
                return;
            }
            // con una comilla la sentencia sql no funcionaria
            if (nombre.Contains("'") || password.Contains("'"))
            {
                MessageBox.Show("El usuario y la contraseña no pueden llevar comillas (').");
                return;
            }
            if (mi_base.Autenticar(nombre, password) == true)
            {
                autenticado = true;
                Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        }

        // registra un usuario nuevo si no existe ya
        private void registrarButton_Click(object sender, EventArgs e)
        {
            string nombre = usuarioBox.Text;
            string password = passwordBox.Text;

            if (nombre == "" || password == "")
            {
                MessageBox.Show("Escribe el usuario y la contraseña que quieres usar.");
                return;
            }

            // con una comilla la sentencia sql no funcionaria
            if (nombre.Contains("'") || password.Contains("'"))
            {
                MessageBox.Show("El usuario y la contraseña no pueden llevar comillas (').");
                return;
            }

            if (mi_base.ExisteUsuario(nombre) == true)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre. Elige otro.");
                return;
            }

            if (mi_base.Registrar(nombre, password) == 0)
                MessageBox.Show("Usuario registrado. Ya puedes pulsar Entrar.");
            else
                MessageBox.Show("No se ha podido registrar el usuario.");
        }

        // al cerrar el login se cierra la base de datos
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (baseAbierta == true)
                mi_base.Cerrar();
        }
    }
}
