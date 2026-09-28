using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        FlightPlan[] vector = new FlightPlan[10];
        int number = 0;
        public FlightPlanList()
        { }

        public int AddFlightPlan(FlightPlan p)
        {
            if (number < 10)
            {
                vector[number] = p;
                number++;
                return 0;
            }
            else
                return -1;
        }
        public FlightPlan GetFlightPlan(int i)
        {
            if (i >= 0 && i < number)
                return vector[i];
            else
                return null;
        }

        public void Mover(int tiempo)
        {
            for(int i = 0; i < number; i++)
            {
                vector[i].Mover(tiempo);
            }
        }

        public void EscribeConsola()
        {
            for (int i = 0; i < number; i++)
            {
                vector[i].EscribeConsola();
            }
        }
    }
}
