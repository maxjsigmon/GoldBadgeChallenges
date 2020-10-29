using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadge_Repo
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _employeeBadge = new Dictionary<int, List<string>>();

        public void AddToDictionary()
        {
            Dictionary<int, List<string>> employeeBadge = new Dictionary<int, List<string>>();
            employeeBadge.Add(123, List<string>);
        }
    }



}
