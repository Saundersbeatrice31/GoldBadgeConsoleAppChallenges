using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insurance
{
    public class KInsuranceRepo
    {
        private  Dictionary<int, List<string>> _dictionaryOfBadges = new Dictionary<int,List<string>>();
        public void AddContentToDictionary(int BadgeId, List<string>doorNames)
        {
            _dictionaryOfBadges.Add( BadgeId,doorNames );
        }

        //DisplayAllBadges
        public Dictionary<int, List<string>> DisplayAllBadges()
        {
            return _dictionaryOfBadges;
        }
        public KInsurance GetBadgeByID(int BadgeId)
        {
            if (_dictionaryOfBadges.ContainsKey(BadgeId))
            {
                KInsurance badge = new KInsurance(BadgeId);
                badge.DoorNames = _dictionaryOfBadges[BadgeId];
                return badge;
            }
            return null;
        }
            
        //update
        public void UpdateExistingBadges(int BadgeId, List<string> doorNames)
        {
            _dictionaryOfBadges[BadgeId] = doorNames;
        }
        public bool UpdateExistingBadge(int oldBadgeID, KInsurance newBadge)
        {
            KInsurance oldBadge = GetBadgeByID(oldBadgeID);

            if (oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.DoorNames = newBadge.DoorNames;
                return true;
            }
            else { return false; }
        }

        public bool AddBadge(KInsurance badge)
        {
            int startingCount = _dictionaryOfBadges.Count;

            _dictionaryOfBadges.Add(badge.BadgeId, badge.DoorNames);

            bool wasAdded = (_dictionaryOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }
       
        public bool DeleteBadge(KInsurance badge)
        {
            bool deleteBadge = _dictionaryOfBadges.Remove(badge.BadgeId);
            return deleteBadge;
        }
    }
}
