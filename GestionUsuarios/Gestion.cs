using System.Data;
using System.Data.SQLite;
using System.IO;

namespace GestionUsuarios
{
    // Clase con las operaciones sobre la base de datos de usuarios
    public class Gestion
    {
        SQLiteConnection cnx; // conexión con la base de datos

        // Abre la base de datos de usuarios.
        // Devuelve 0 si se ha abierto bien y -1 si no se encuentra el fichero.
        public int Iniciar()
        {
            string ruta = "..\\..\\..\\BaseDatos\\usuarios.db";

            if (File.Exists(ruta) == false)
                return -1;

            string dataSource = "Data Source=" + ruta;
            cnx = new SQLiteConnection(dataSource);
            cnx.Open();
            return 0;
        }

        // Cierra la base de datos
        public void Cerrar()
        {
            cnx.Close();
        }
        // Comprueba si el nombre y la contraseña corresponden a un usuario registrado.
        // Devuelve true si son correctos y false si no.
        public bool Autenticar(string nombre, string password)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM usuarios WHERE nombre='" + nombre + "' AND password='" + password + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }

        // Comprueba si ya existe un usuario con ese nombre.
        // Devuelve true si existe y false si no.
        public bool ExisteUsuario(string nombre)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM usuarios WHERE nombre='" + nombre + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        // Añade un usuario nuevo a la base de datos.
        // Devuelve 0 si se ha registrado y -1 si no se ha podido.
        public int Registrar(string nombre, string password)
        {
            string sql = "INSERT INTO usuarios VALUES ('" + nombre + "', '" + password + "')";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int filas = command.ExecuteNonQuery();

            if (filas == 1)
                return 0;
            else
                return -1;
        }

    }
}