using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{            
    public class Claims
    {
        //Plain Old C# Object --POCO
        public int ClaimsId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
              return  ReturnIsValid();
            }
        }

        //Constructors
        public Claims() { }
        public Claims(int claimsId, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOFClaim)
        {
            ClaimsId = claimsId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOFClaim;            
        }
        public bool ReturnIsValid()
        {
            TimeSpan accident = DateOfClaim - DateOfIncident;
            if (accident.TotalDays <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}

