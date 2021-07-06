using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insurance
{
   
    public class KInsurance
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        //constructors
        public KInsurance() { }
        public KInsurance(int id)
        {
            BadgeId = id;
        }
        public KInsurance(int badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
        }               
    }
}
