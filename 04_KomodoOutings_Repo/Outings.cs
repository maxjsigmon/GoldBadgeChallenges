using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutings_Repo
{
    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert}
    public class Outings
    {
        public EventType EventType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost
        {
            get
            {
                double totalCost = CostPerPerson * NumberOfAttendees;
                return totalCost;
            }
        }

        public Outings () { }

        public Outings(EventType eventType, int numberOfAttendees, DateTime date, double costPerPerson)
        {
            EventType = eventType;
            NumberOfAttendees = numberOfAttendees;
            Date = date;
            CostPerPerson = costPerPerson;
        }
    }
}
