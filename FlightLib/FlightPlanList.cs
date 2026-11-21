using System;
using System.Collections.Generic;
using System.IO;

namespace FlightLib
{
    // lista de planes de vuelo
    public class FlightPlanList
    {
        List<FlightPlan> lista = new List<FlightPlan>();

        // crea la lista vacia
        public FlightPlanList()
        { }

        // añade un vuelo a la lista, devuelve 0
        public int AddFlightPlan(FlightPlan p)
        {
            lista.Add(p);
            return 0;
        }

        // carga los vuelos de un fichero de texto y devuelve la lista de errores que encuentre
        // si hay algun error no se cambia la lista
        // cada linea: id compañia velocidad xinicial yinicial xfinal yfinal (separados por un espacio)
        public List<string> CargarDesdeArchivo(string rutaArchivo)
        {
            List<string> errores = new List<string>();
            List<FlightPlan> nuevos = new List<FlightPlan>();

            StreamReader R = new StreamReader(rutaArchivo);
            string linea = R.ReadLine();

            int numeroLinea = 1;
            while (linea != null)
            {
                string[] campos = linea.Split(' ');

                if (linea.Trim() == "")
                {
                    // las lineas vacias se ignoran
                }
                else if (campos.Length != 7)
                {
                    errores.Add("Línea " + numeroLinea + ": tiene " + campos.Length + " datos y deben ser 7.");
                }
                else
                {
                    int erroresAntes = errores.Count; // para saber si esta linea ha dado algun error

                    string id = campos[0];
                    string compania = campos[1];

                    // dos espacios seguidos dan un campo vacio
                    bool hayVacio = false;
                    for (int i = 0; i < campos.Length; i++)
                    {
                        if (campos[i] == "")
                            hayVacio = true;
                    }
                    if (hayVacio)
                        errores.Add("Línea " + numeroLinea + ": hay dos espacios seguidos.");

                    // el id no se puede repetir
                    for (int i = 0; i < nuevos.Count; i++)
                    {
                        if (nuevos[i].GetId() == id)
                        {
                            errores.Add("Línea " + numeroLinea + ": identificador repetido: " + id);
                            break;
                        }
                    }

                    // velocidad y posiciones tienen que ser numeros
                    double velocidad = 0, ix = 0, iy = 0, fx = 0, fy = 0;
                    try
                    {
                        velocidad = Convert.ToDouble(campos[2]);
                        ix = Convert.ToDouble(campos[3]);
                        iy = Convert.ToDouble(campos[4]);
                        fx = Convert.ToDouble(campos[5]);
                        fy = Convert.ToDouble(campos[6]);
                    }
                    catch (FormatException)
                    {
                        errores.Add("Línea " + numeroLinea + ": la velocidad o alguna posición no es un número.");
                    }

                    if (errores.Count == erroresAntes && velocidad <= 0)
                        errores.Add("Línea " + numeroLinea + ": la velocidad tiene que ser mayor que 0.");

                    // si la linea esta bien creamos el vuelo
                    if (errores.Count == erroresAntes)
                        nuevos.Add(new FlightPlan(id, compania, ix, iy, fx, fy, velocidad));
                }

                linea = R.ReadLine();
                numeroLinea++;
            }
            R.Close();

            if (errores.Count == 0 && nuevos.Count == 0)
                errores.Add("El archivo no contiene planes de vuelo.");

            // solo nos quedamos con los vuelos nuevos si no ha habido errores
            if (errores.Count == 0)
                lista = nuevos;

            return errores;
        }

        // guarda los vuelos en un fichero con el mismo formato que el de entrada
        // la posicion actual se guarda como inicial, para seguir la simulacion desde ahi
        public void GuardarEnArchivo(string rutaArchivo)
        {
            StreamWriter W = new StreamWriter(rutaArchivo);

            for (int i = 0; i < lista.Count; i++)
            {
                FlightPlan vuelo = lista[i];
                W.WriteLine(vuelo.GetId() + " " + vuelo.GetCompañia() + " " + vuelo.GetVelocidad() + " " +
                            vuelo.GetCurrentPosition().GetX() + " " + vuelo.GetCurrentPosition().GetY() + " " +
                            vuelo.GetFinalPosition().GetX() + " " + vuelo.GetFinalPosition().GetY());
            }

            W.Close();
        }

        // devuelve el vuelo de la posicion i (null si no existe)
        public FlightPlan GetFlightPlan(int i)
        {
            if (i >= 0 && i < lista.Count)
                return lista[i];
            else
                return null;
        }

        // devuelve cuantos vuelos hay
        public int GetNumber()
        {
            return lista.Count;
        }

        // mueve todos los vuelos ese tiempo
        public void Mover(int tiempo)
        {
            // mueve todos los vuelos ese tiempo, si ya han llegado todos no hace nada

            if (HanLlegadoTodos())
                return;

            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Mover(tiempo);
            }
        }
        

        // true si ahora mismo hay algun par de vuelos demasiado cerca
        public bool HayConflicto(double distanciaSeguridad)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[i].Distance(lista[j]) < 2 * distanciaSeguridad)
                        return true;
                }
            }
            return false;
        }

        // true si el vuelo i esta demasiado cerca de algun otro (para pintar su circulo en rojo)
        public bool EstaEnConflicto(int i, double distanciaSeguridad)
        {
            for (int j = 0; j < lista.Count; j++)
            {
                if (i != j && lista[i].Distance(lista[j]) < 2 * distanciaSeguridad)
                    return true;
            }
            return false;
        }

        // true si algun par de vuelos va a entrar en conflicto mas adelante
        public bool PredecirConflictos(double distanciaSeguridad, double tiempoCiclo)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[i].PredecirConflicto(lista[j], distanciaSeguridad, tiempoCiclo))
                        return true;
                }
            }
            return false;
        }

        // intenta quitar todos los conflictos previstos cambiando velocidades
        // devuelve true si lo consigue
        public bool ResolverConflictos(double distanciaSeguridad, double tiempoCiclo)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[i].PredecirConflicto(lista[j], distanciaSeguridad, tiempoCiclo))
                    {
                        bool res = lista[i].ResolverConflicto(lista[j], distanciaSeguridad, tiempoCiclo);
                        if (!res)
                            return false;
                    }
                }
            }
            // al frenar un vuelo puede salir un conflicto con otro que ya habiamos mirado
            return !PredecirConflictos(distanciaSeguridad, tiempoCiclo);
        }

        // vuelve todos los vuelos a su posicion inicial
        public void Reiniciar()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Reiniciar();
            }
        }

        // deshace el ultimo paso de todos los vuelos
        // devuelve true si se ha movido alguno
        public bool Retroceder()
        {
            bool alguno = false;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Retroceder() == true)
                {
                    alguno = true;
                }
            }
            return alguno;
        }

        // true si todos los vuelos han llegado
        public bool HanLlegadoTodos()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].HasArrived())
                    return false;
            }
            return true;
        }

        // escribe todos los vuelos en la consola
        public void EscribeConsola()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].EscribeConsola();
            }
        }
    }
}
