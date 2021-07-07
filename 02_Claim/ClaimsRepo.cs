using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Claim.Claims;

namespace _02_Claim
{
    public class ClaimsRepo
    {
        //FakeDatabase
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();
        //Create
        public void AddClaimsToQueue(Claims content)
        {
            _queueOfClaims.Enqueue(content);
        }
        //Read
        public Queue<Claims> GetClaimsContentQueue()
        {
            return _queueOfClaims;
        }
        //update
        public bool UpdateExistingClaims(string originalClaim, Claims newClaim)
        {
            //Find the claim
            Claims existingClaim = GetByClaimType(originalClaim);

            //update the claims content
            if (existingClaim != null)
            {
                existingClaim.ClaimType = newClaim.ClaimType;
                existingClaim.ClaimAmount = newClaim.ClaimAmount;
                existingClaim.ClaimsId = newClaim.ClaimsId;
                existingClaim.DateOfClaim = newClaim.DateOfClaim;
                existingClaim.Description = newClaim.Description;
                existingClaim.DateOfIncident = newClaim.DateOfIncident;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public void RemoveClaimsFromQueue()
        {
            _queueOfClaims.Dequeue();
        }
        //helper Method
        public Claims GetByClaimType(string claimType)
        {
            foreach (Claims content in _queueOfClaims)
            {
                if (content.ClaimType.ToLower() == claimType.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}
