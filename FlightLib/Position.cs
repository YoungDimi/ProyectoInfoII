using System;

namespace FlightLib
{
    // punto (x, y) del espacio aereo
    public class Position
    {
        double x;
        double y;

        // crea el punto
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // gets de las coordenadas
        public double GetX()
        { return x; }

        public double GetY()
        { return y; }

        // devuelve la distancia hasta el punto b
        public double Distancia(Position b)
        {
            double resultado = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return resultado;
        }
    }
}
