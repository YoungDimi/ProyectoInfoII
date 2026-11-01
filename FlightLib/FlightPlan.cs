using System;

namespace FlightLib
{
    public class FlightPlan
    {
      

        string id; // identificador
        Position initialPosition;
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        public string GetId()
        { return id; }

        public void SetId(string id)
        { this.id = id; }

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

     
        public double Distance(FlightPlan plan)
        {
            return currentPosition.Distancia(plan.GetCurrentPosition());
        }
        public void Mover(double tiempo)
        // mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);
            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }

        // dice si AHORA MISMO hay conflicto: los círculos de seguridad se tocan
        public Boolean Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;

            if (this.currentPosition.Distancia(b.currentPosition) < 2 * distanciaSeguridad)
                conflicto = true;

            return conflicto;
        }

        public Boolean PredecirConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            // Posición de cada avión (MRU en cada eje), con velocidad dividida en ejes
            double dx_a = this.GetFinalPosition().GetX() - this.GetCurrentPosition().GetX();
            double dy_a = this.GetFinalPosition().GetY() - this.GetCurrentPosition().GetY();
            double L_a = Math.Sqrt(dx_a * dx_a + dy_a * dy_a);

            double dx_b = b.GetFinalPosition().GetX() - b.GetCurrentPosition().GetX();
            double dy_b = b.GetFinalPosition().GetY() - b.GetCurrentPosition().GetY();
            double L_b = Math.Sqrt(dx_b * dx_b + dy_b * dy_b);

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

            // Encontramos el tiempo minimo en el que uno de los dos aviones llega a su destino
            double t_a = double.MaxValue;
            if (v_a > 0)
                t_a = L_a / v_a;
            double t_b = double.MaxValue;
            if (v_b > 0)
                t_b = L_b / v_b;
            double t_min_destino = Math.Min(t_a, t_b);


            // Posición y velocidad relativas (B respecto a A)
            double delta_x0 = b.GetCurrentPosition().GetX() - this.GetCurrentPosition().GetX();
            double delta_y0 = b.GetCurrentPosition().GetY() - this.GetCurrentPosition().GetY();

            double w_x = vx_b - vx_a;
            double w_y = vy_b - vy_a;

            // Encontramos el tiempo de mínima distancia (derivada = 0) y la limitamos al tiempo mínimo en el que uno de los dos aviones llega a su destino
            double w2 = w_x * w_x + w_y * w_y;
            double t_min = 0;
            if (w2 > 0)
                t_min = -(delta_x0 * w_x + delta_y0 * w_y) / w2;

            if (t_min < 0)
                t_min = 0;
            else if (t_min > t_min_destino)
                t_min = t_min_destino;

            // Calculamos la distancia mínima
            double d_min = Math.Sqrt(Math.Pow(delta_x0 + w_x * t_min, 2) + Math.Pow(delta_y0 + w_y * t_min, 2));

            

            if (d_min < distanciaSeguridad * 2)
                return true;
            else
                return false;

        }
        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
                Console.WriteLine("El vuelo ha llegado a su destino");
            
        }

        public Boolean HasArrived()
        {
            return currentPosition.Distancia(finalPosition) < 0.01;
        }
        public void Reiniciar() 
        {
            this.currentPosition = new Position(initialPosition.GetX(), initialPosition.GetY());
        }
    }
}
