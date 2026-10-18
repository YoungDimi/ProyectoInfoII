using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position initialPosition;
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // Metodos
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

        public void Restart()
        {
            this.currentPosition = new Position(
                initialPosition.GetX(),
                initialPosition.GetY());
        }

        public double Distance(FlightPlan plan)
        {
            return currentPosition.Distancia(plan.GetCurrentPosition());
        }
        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);
            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }
        public Boolean EstaDestino() 
        { 
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;
            return resultado;
        } 

        public Boolean Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;
            
            return conflicto;
        }
        public Boolean PredecirConflicto(FlightPlan b, double distanciaSeguridad, double cycleTime)
        {
            if (cycleTime <= 0)
                return false;
            // Si ambos vuelos están parados, calculamos el confilicto en la posición actual
            if (velocidad <= 0 && b.GetVelocidad() <= 0)
                return Conflicto(b, distanciaSeguridad);

            // Creamos copias de los planes de vuelo en la posición actual para simular el movimiento
            FlightPlan a1 = new FlightPlan(
                id, 
                currentPosition.GetX(),
                currentPosition.GetY(), 
                finalPosition.GetX(), 
                finalPosition.GetY(), 
                velocidad);

            FlightPlan b1 = new FlightPlan(
                b.GetId(),
                b.GetCurrentPosition().GetX(),
                b.GetCurrentPosition().GetY(),
                b.GetFinalPosition().GetX(),
                b.GetFinalPosition().GetY(),
                b.GetVelocidad());

            // Comprobamos si hay conflicto en la posición actual
            if (a1.Conflicto(b1, distanciaSeguridad))
                return true;

            // Simulamos el movimiento de ambos vuelos hasta que uno de ellos llegue a su destino o se acabe el tiempo de simulación
            int pasos = 0;
            int maxPasos = 1000000;
            while ((!a1.EstaDestino() || !b1.EstaDestino()) && pasos < maxPasos)
            {
                a1.Mover(cycleTime);
                b1.Mover(cycleTime);
                if (a1.Conflicto(b1, distanciaSeguridad))
                    return true;
                pasos++;
            }
            
            return false;
        }
        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.EstaDestino())
                Console.WriteLine("El vuelo ha llegado a su destino");
            Console.WriteLine("******************************");
        }

        public Boolean hasArrived()
        {
            return currentPosition.Distancia(finalPosition) < 0.01;
        }
    }
}
