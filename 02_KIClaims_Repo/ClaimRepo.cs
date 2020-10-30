using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KIClaims_Repo
{
    public class ClaimRepo
    {
        public Queue<Claims> repo = new Queue<Claims>();
        public int _highestClaimNumber = 1;
        public bool EnqueueNewClaim(Claims newClaim)
        {
            int startingCount = repo.Count;
            repo.Enqueue(newClaim);
            bool wasAdded = (repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public int GetClaimID()
        {
            return _highestClaimNumber++;
        }

        public Queue<Claims> GetClaims()
        {
            return repo;
        }

        

        public Queue<Claims> SeeNextClaim()
        {
            repo.
        }
    }
}
