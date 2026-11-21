using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionUsuarios;

namespace Formularios
{
    public partial class FormLogin : Form

    {
        Gestion mi_base = new Gestion(); // para trabajar con la base de datos de usuarios
        bool autenticado = false;        // pasa a true cuando el usuario entra correctamente
        bool baseAbierta = false;        // true si se ha podido abrir la base de datos
        public FormLogin()
        {
            InitializeComponent();
        }
        // Devuelve true si el usuario se ha identificado correctamente
        public bool GetAutenticado()
        {
            return autenticado;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // abrimos la base de datos; si no se encuentra el fichero, avisamos y no dejamos entrar
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

        private void entrarButton_Click(object sender, EventArgs e)
        {
            string nombre = usuarioBox.Text;
            string password = passwordBox.Text;

            if (nombre == "" || password == "")
            {
                MessageBox.Show("Escribe el usuario y la contraseña.");
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

        private void registrarButton_Click(object sender, EventArgs e)
        {
            string nombre = usuarioBox.Text;
            string password = passwordBox.Text;

            if (nombre == "" || password == "")
            {
                MessageBox.Show("Escribe el usuario y la contraseña que quieres usar.");
                return;
            }

            // una comilla simple rompería la sentencia SQL
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

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // al cerrar el login, cerramos la conexión con la base de datos (si se llegó a abrir)
            if (baseAbierta == true)
                mi_base.Cerrar();
        }
    }
}
