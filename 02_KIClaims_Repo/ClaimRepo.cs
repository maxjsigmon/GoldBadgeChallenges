using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KIClaims_Repo
{
    public class ClaimRepo
    {
        public Queue<Claims> repo = new Queue<Claims>();
        public bool EnqueueNewClaim(Claims newClaim)
        {
            int startingCount = repo.Count;
            repo.Enqueue(newClaim);
            bool wasAdded = (repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<Claims> GetClaims()
        {
            return repo;
        }

        public void SeeNextClaim()
        {
            Console.WriteLine(repo.Peek());
        }
    }
}
