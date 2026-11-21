using System.Data;
using System.Data.SQLite;
using System.IO;

namespace GestionUsuarios
{
    // funciones de la base de datos de usuarios
    public class Gestion
    {
        SQLiteConnection cnx;

        // abre la base de datos
        // devuelve 0 si va bien y -1 si no encuentra el fichero
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

        // cierra la base de datos
        public void Cerrar()
        {
            cnx.Close();
        }

        // devuelve true si el nombre y la contraseña son de un usuario registrado
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

        // devuelve true si ya hay un usuario con ese nombre
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

        // añade un usuario nuevo
        // devuelve 0 si va bien y -1 si no
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
