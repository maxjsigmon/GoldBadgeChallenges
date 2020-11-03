using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _04_KomodoOutings_Repo
{
    public class OutingsRepo
    {
        public List<Outings> _outingsRepo = new List<Outings>();

        public List<Outings> SeeAllOutings()
        {
            return _outingsRepo;
        }

        public bool AddOuting(Outings outing)
        {
            int startingCount = _outingsRepo.Count;
            _outingsRepo.Add(outing);
            bool wasAdded = (_outingsRepo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Outings GetOutingByType(EventType eventType)
        {
            foreach (Outings outings in _outingsRepo)
            {
                if (outings.EventType == eventType)
                {
                    return outings;
                }
            }
            return null;
        }

        public double GetTotalByEventType(EventType eventType)
        {
            double totalCost = 0;
            foreach (Outings outing in _outingsRepo)
            {
                if (outing.EventType == eventType)
                {
                    totalCost += outing.TotalCost;
                }
            }
            return totalCost;
        }

        public double GetAllOutingsTotal()
        {
            double totalCost = 0;
            foreach (Outings outings in _outingsRepo)
            {
                totalCost += outings.TotalCost;
            }
            return totalCost;
        }
    }
}
