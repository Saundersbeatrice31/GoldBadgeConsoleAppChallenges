using _03_Insurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_InsuranceTest
{
    [TestClass]
    public class InsuranceTests
    {
        private KInsuranceRepo _repo;
        private KInsurance _content;
        [TestInitialize]
        public void Insurances()
        {
            _repo = new KInsuranceRepo();
            _content = new KInsurance(252, new List<string>() { "A7", "A8", "A9" });
            _repo.AddContentToDictionary(_content.BadgeId, _content.DoorNames);
        }
        //Add method
        [TestMethod]
        public void AddClaimsToList_ShouldGetNotNull()
        {
            //Arrange
            KInsurance badge = new KInsurance(203);
            KInsuranceRepo repo = new KInsuranceRepo();

            //Act
            bool addResult = repo.AddBadge(badge);

            //Assert
            Assert.IsTrue(addResult);


        }
        [TestMethod]
        public void DisplayAllBagdes_ShouldReturnCorrectCollection() 
        {

            //Arrange
            KInsurance badge = new KInsurance(245);
            KInsuranceRepo repo = new KInsuranceRepo();
            repo.AddBadge(badge);

            //Act
            Dictionary<int, List<string>> badges = repo.DisplayAllBadges();
            bool hasBadges = badges.ContainsKey(badge.BadgeId);

            //Assert
            Assert.IsTrue(hasBadges);
        }
        [TestMethod]

        public void UpdatingExistingClaims_ShouldReturnTrue()
        {
            //Arrange
            KInsurance oldBadge = new KInsurance(001, new List<string> { "A1", "A2" });
            KInsurance newBadge = new KInsurance(001, new List<string> { "A2", "A3", "B5" });
            KInsuranceRepo repo = new KInsuranceRepo();
            repo.AddBadge(oldBadge);

            //Act
            bool updateResult = repo.UpdateExistingBadge(oldBadge.BadgeId, newBadge);

            //Assert
            Assert.IsTrue(updateResult);

        }
        [TestMethod]
        public void GetBadgeByID_ShouldReturnCorrectBadge() //Read
        {
            //Arrange
            KInsurance badge = new KInsurance(001, new List<string> { "A1", "A2" });
            KInsuranceRepo repo = new KInsuranceRepo();
            repo.AddBadge(badge);
            int badgeID = 001;
            //Act
            KInsurance searchResult = repo.GetBadgeByID(badgeID);

            //Assert
            Assert.AreEqual(searchResult.BadgeId, badgeID);
        }
        //update

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue() 
        {
            //Arrange
            KInsurance badge = new KInsurance(256, new List<string> { "A5", "A6" });
            KInsuranceRepo repo = new KInsuranceRepo();
            repo.AddBadge(badge);
            int badgeID = 256;
            //Act
            KInsurance oldBadge = repo.GetBadgeByID(badgeID);
            bool removeResult = repo.DeleteBadge(oldBadge);

            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}

