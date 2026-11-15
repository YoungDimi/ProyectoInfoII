using System;
using System.Collections.Generic;
using System.IO;
namespace FlightLib
{
    // Clase que almacena y gestiona una lista de planes de vuelo
    public class FlightPlanList
    {
        List<FlightPlan> lista = new List<FlightPlan>();
        public FlightPlanList()
        { }

        // Agrega un plan de vuelo a la lista, devuelve 0 si se agrega correctamente
        public int AddFlightPlan(FlightPlan p)
        {
            lista.Add(p);
            return 0;
        }

        // Carga los planes de vuelo desde un archivo de texto, devolviendo una lista de errores si los hubiera
        // Si hay algún error, la lista de vuelos no se modifica.
        // FORMATO DEL ARCHIVO: cada línea contiene 7 campos separados por un espacio en blanco:
        // identificador, compañia, velocidad, pos. inicial x, pos. inicial y, pos. final x, pos. final y
        public List<string> CargarDesdeArchivo(string rutaArchivo)
        {
            List<string> errores = new List<string>();
            List<FlightPlan> nuevos = new List<FlightPlan>();
            
            StreamReader R = new StreamReader(rutaArchivo); // Leemos el archivo
            string linea = R.ReadLine(); // Leemos la primera línea

            int numeroLinea = 1;
            while (linea != null)
            {
                string[] campos = linea.Split(' '); // Separamos los campos por un carácter en blanco

                if (linea.Trim() == "")
                {
                    // línea vacía: la ignoramos
                }
                else if (campos.Length != 7) // Comprobamos que haya 7 campos
                {
                    errores.Add("Línea " + numeroLinea + ": tiene " + campos.Length + " datos y deben ser 7.");
                }
                else
                {
                    int erroresAntes = errores.Count; // para saber si esta línea genera algún error

                    string id = campos[0];
                    string compania = campos[1];

                    // Comprobamos que no haya dos espacios seguidos (darían campos vacíos)
                    bool hayVacio = false;
                    for (int i = 0; i < campos.Length; i++)
                    {
                        if (campos[i] == "")
                            hayVacio = true;
                    }
                    if (hayVacio)
                        errores.Add("Línea " + numeroLinea + ": hay dos espacios seguidos.");

                    // Comprobamos que el identificador no esté repetido
                    for (int i = 0; i < nuevos.Count; i++)
                    {
                        if (nuevos[i].GetId() == id)
                        {
                            errores.Add("Línea " + numeroLinea + ": identificador repetido: " + id);
                            break;
                        }
                    }

                    // Convertimos los números a double. Si alguno no es un número, avisamos de la línea
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
                    // Comprobamos que la velocidad sea positiva
                    if (errores.Count == erroresAntes && velocidad <= 0)
                        errores.Add("Línea " + numeroLinea + ": la velocidad tiene que ser mayor que 0.");

                    // Si la línea no ha dado ningún error, creamos el vuelo
                    if (errores.Count == erroresAntes)
                        nuevos.Add(new FlightPlan(id, compania, ix, iy, fx, fy, velocidad));
                }
                
                linea = R.ReadLine(); // Leemos la siguiente línea
                numeroLinea++;
            }
            R.Close();

            // Comprobamos si el archivo contiene planes de vuelo
            if (errores.Count == 0 && nuevos.Count == 0)
                errores.Add("El archivo no contiene planes de vuelo.");

            // Solo cambiamos la lista si no ha habido errores
            if (errores.Count == 0)
                lista = nuevos;

            return errores;
        }


        // Obtiene un plan de vuelo de la lista por su índice
        public FlightPlan GetFlightPlan(int i)
        {
            if (i >= 0 && i < lista.Count)
                return lista[i];
            else
                return null;
        }
        // Obtiene el número total de planes de vuelo en la lista
        public int GetNumber()
        {
            return lista.Count;
        }
        // Mueve todos los planes de vuelo en la lista un tiempo dado
        public void Mover(int tiempo)
        {
            for(int i = 0; i < lista.Count; i++)
            {
                lista[i].Mover(tiempo);
            }
        }
        // Comprueba si hay algún par de vuelos en conflicto en el instante actual, dada la distancia de seguridad
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

        // Comprueba si un vuelo específico (por índice) está en conflicto con cualquier otro vuelo en la lista, dada la distancia de seguridad
        // Se usa para pintar su círculo de seguridad en rojo si está en conflicto
        public bool EstaEnConflicto(int i, double distanciaSeguridad)
        {
            for (int j = 0; j < lista.Count; j++)
            {
                if (i != j && lista[i].Distance(lista[j]) < 2 * distanciaSeguridad)
                    return true;
            }
            return false;
        }

        // Predice si habrá conflicto futuro entre, al menos, un par de vuelos de la lista.
        // Devuelve true si se predice conflicto
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
        // Intenta resolver todos los conflictos futuros entre los vuelos de la lista ajustando sus velocidades.
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
            // frenar un vuelo puede haber creado un conflicto con un par ya revisado
            return !PredecirConflictos(distanciaSeguridad, tiempoCiclo);
        }
        // Devuelve todos los vuelos a su posición inicial
        public void Reiniciar()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Reiniciar();
            }
        }
        // Hace retroceder un ciclo a todos los vuelos.
        // Devuelve true si al menos uno se ha movido.
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
        // Comprueba si todos los vuelos han llegado a su destino
        public bool HanLlegadoTodos()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].HasArrived())
                    return false;
            }
            return true;
        }
        // Escribe en la consola la información de todos los planes de vuelo en la lista
        public void EscribeConsola()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].EscribeConsola();
            }
        }
    }
}
