using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Pilaposiciones
    {
        nodo cima = null;
        // cima nos dice cual es el ultimo elemento agregado a la lista y si es nulo quiere decir que la lista esta vacia.
        public void Apilar (Position p)
        {
            nodo nuevo = new nodo();
            nuevo.dato = p;
            nuevo.siguiente = cima;
            cima = nuevo;
            // creamos un nuevo nodo con una poscion y pasamos de cima. ahora la cima apunta hacia la nueva posicion.
        }
        public Position desapilar()
        {
            if (cima == null)
            {
                return null;
            }
            else
            {
                Position p = cima.dato;
                cima = cima.siguiente;
                return p;
                //guardamos la posicion de cima y lo bajamos uno, al final devolvemos la posicion que estaba en cima.
                // con el if nos aseguramos de que no se intente desapilar una lista vacia.
            }
        }
        public bool vacia()
        {
            if (cima == null)
                return true;
            else
                return false;
            // si cima es nulo, la lista esta vacia, sino no.

        }
        public void vaciar()
        {
            cima = null;
            // para vaciar la lista, simplemente hacemos que cima apunte a nulo.
        }
    }
}
