using System;
using System.Collections.Generic;

namespace FlightLib
{
    // plan de vuelo de un avion
    public class FlightPlan
    {
        string id;
        string compañia;
        Position initialPosition;
        Position currentPosition;
        Position finalPosition;
        double velocidad;
        Stack<Position> historial = new Stack<Position>(); // posiciones anteriores, para deshacer pasos

        // crea el vuelo, la posicion actual empieza siendo la inicial
        public FlightPlan(string id, string compañia, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.compañia = compañia;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // gets y sets de los atributos
        public string GetId()
        { return id; }

        public void SetId(string id)
        { this.id = id; }

        public string GetCompañia()
        { return compañia; }

        public void SetCompañia(string compañia)
        { this.compañia = compañia; }

        public Position GetCurrentPosition()
        { return currentPosition; }

        public Position GetInitialPosition()
        { return initialPosition; }

        public void SetCurrentPosition(Position currentPosition)
        { this.currentPosition = currentPosition; }

        public Position GetFinalPosition()
        { return finalPosition; }

        public void SetFinalPosition(Position finalPosition)
        { this.finalPosition = finalPosition; }

        public double GetVelocidad()
        { return velocidad; }

        public void SetVelocidad(double velocidad)
        { this.velocidad = velocidad; }

        // devuelve la distancia entre este vuelo y el que recibe
        public double Distance(FlightPlan plan)
        {
            return currentPosition.Distancia(plan.GetCurrentPosition());
        }

        // mueve el avion hacia su destino lo que recorre en ese tiempo
        // antes guarda donde estaba en la pila para poder deshacer
        public void Mover(double tiempo)
        {
            
            // guardamos donde estaba para poder deshacer
            historial.Push(new Position(currentPosition.GetX(), currentPosition.GetY()));

            // distancia que recorre en este tiempo
            double distancia = tiempo * this.velocidad / 60;

            // seno y coseno de la direccion hacia el destino
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            // nueva posicion
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            // si se pasaria del destino, se queda en el destino
            Position nextPosition = new Position(x, y);
            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }

        // true si ahora mismo los circulos de seguridad de los dos vuelos se tocan
        public Boolean Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;

            if (this.currentPosition.Distancia(b.currentPosition) < 2 * distanciaSeguridad)
                conflicto = true;

            return conflicto;
        }

        // true si este vuelo y b se van a acercar demasiado antes de que alguno llegue a su destino
        // calcula el momento en que estan mas cerca (cada avion va en linea recta a velocidad constante)
        public Boolean PredecirConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            // recorrido que le falta a cada avion
            double dx_a = this.GetFinalPosition().GetX() - this.GetCurrentPosition().GetX();
            double dy_a = this.GetFinalPosition().GetY() - this.GetCurrentPosition().GetY();
            double L_a = Math.Sqrt(dx_a * dx_a + dy_a * dy_a);

            double dx_b = b.GetFinalPosition().GetX() - b.GetCurrentPosition().GetX();
            double dy_b = b.GetFinalPosition().GetY() - b.GetCurrentPosition().GetY();
            double L_b = Math.Sqrt(dx_b * dx_b + dy_b * dy_b);

            // velocidad de cada uno separada en x e y
            double v_a = this.GetVelocidad() / 60;
            double v_b = b.GetVelocidad() / 60;

            double vx_a = 0, vy_a = 0;
            if (L_a > 0)
            {
                vx_a = v_a * dx_a / L_a;
                vy_a = v_a * dy_a / L_a;
            }

            double vx_b = 0, vy_b = 0;
            if (L_b > 0)
            {
                vx_b = v_b * dx_b / L_b;
                vy_b = v_b * dy_b / L_b;
            }

            // tiempo hasta que el primero de los dos llega
            double t_a = double.MaxValue;
            if (v_a > 0)
                t_a = L_a / v_a;
            double t_b = double.MaxValue;
            if (v_b > 0)
                t_b = L_b / v_b;
            double t_min_destino = Math.Min(t_a, t_b);

            // posicion y velocidad de b vistas desde a
            double delta_x0 = b.GetCurrentPosition().GetX() - this.GetCurrentPosition().GetX();
            double delta_y0 = b.GetCurrentPosition().GetY() - this.GetCurrentPosition().GetY();

            double w_x = vx_b - vx_a;
            double w_y = vy_b - vy_a;

            // momento de distancia minima (derivada = 0), sin pasarnos de cuando llega el primero
            double w2 = w_x * w_x + w_y * w_y;
            double t_min = 0;
            if (w2 > 0)
                t_min = -(delta_x0 * w_x + delta_y0 * w_y) / w2;

            if (t_min < 0)
                t_min = 0;
            else if (t_min > t_min_destino)
                t_min = t_min_destino;

            // distancia en ese momento
            double d_min = Math.Sqrt(Math.Pow(delta_x0 + w_x * t_min, 2) + Math.Pow(delta_y0 + w_y * t_min, 2));

            if (d_min < distanciaSeguridad * 2)
                return true;
            else
                return false;
        }

        // baja la velocidad de b hasta que ya no haya conflicto con este vuelo
        // devuelve false si no se consigue (y entonces deja la velocidad como estaba)
        public bool ResolverConflicto(FlightPlan b, double securityDistance, double cycleTime)
        {
            double velocidadOriginal = b.GetVelocidad();
            double nuevaVelocidad = velocidadOriginal;

            // le quitamos un 10% cada vez, como mucho hasta el 10% de la original
            while (this.PredecirConflicto(b, securityDistance, cycleTime)
                   && nuevaVelocidad > velocidadOriginal * 0.1)
            {
                nuevaVelocidad = nuevaVelocidad * 0.9;
                b.SetVelocidad(nuevaVelocidad);
            }

            if (this.PredecirConflicto(b, securityDistance, cycleTime))
            {
                b.SetVelocidad(velocidadOriginal); // no se ha podido
                return false;
            }
            else
            {
                return true;
            }
        }

        // escribe los datos del vuelo en la consola
        public void EscribeConsola()
        {
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
                Console.WriteLine("El vuelo ha llegado a su destino");
        }

        // true si ya ha llegado a su destino
        public Boolean HasArrived()
        {
            return currentPosition.Distancia(finalPosition) < 0.01;
        }

        // vuelve a la posicion inicial y vacia la pila (ya no hay nada que deshacer)
        public void Reiniciar()
        {
            this.currentPosition = new Position(initialPosition.GetX(), initialPosition.GetY());
            historial.Clear();
        }

        // vuelve a la posicion de antes del ultimo movimiento
        // devuelve false si no habia nada guardado
        public Boolean Retroceder()
        {
            if (historial.Count == 0)
            {
                return false;
            }
            else
            {
                currentPosition = historial.Pop();
                return true;
            }
        }
    }
}
