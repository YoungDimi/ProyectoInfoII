using System;
using System.Windows.Forms;

namespace Formularios
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // primero el login; solo si el usuario se identifica se abre el programa
            FormLogin login = new FormLogin();
            login.ShowDialog();

            if (login.GetAutenticado() == true)
                Application.Run(new Principal());
        }
    }
}
