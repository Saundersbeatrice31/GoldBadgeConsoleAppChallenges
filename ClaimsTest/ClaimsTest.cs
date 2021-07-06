using _02_Claim;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimsTest
    {
        private ClaimsRepo _repo;
        private Claims _content;
        [TestInitialize]
        public void Arrange()
        {
            DateTime dates = new DateTime(2020, 6, 29);
            _repo = new ClaimsRepo();
            _content = new Claims(3, "Car", "Accident happened somewhere", 1200,dates,dates);
            _repo.AddClaimsToQueue(_content);
        }
        //Add method
        [TestMethod]
        public void AddClaimsToList_ShouldGetNotNull()
        {
            //Arrange
            Claims content = new Claims();
            content.ClaimType = "Home";
            ClaimsRepo repository = new ClaimsRepo();
            //ACT
            repository.AddClaimsToQueue(content);
            Claims claimsFromDirectory = repository.GetByClaimType("Home");
            //Assert
            Assert.IsNotNull(claimsFromDirectory);

        }
        //update
        [TestMethod]
        public void UpdatingExistingClaims_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
             DateTime date = new DateTime(2019, 6, 29);
            Claims newContent = new Claims(5, "Car", "Accident happened somewhere", 1200,  date , date);
            //ACT
            bool updateResult = _repo.UpdateExistingClaims("Car", newContent);
            //Assert
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteClaims_ShouldReturnTrue()

        {
            //Arrange
            Queue<Claims> content = _repo.GetClaimsContentQueue();
            int startingCount = content.Count;

            //Act
            _repo.RemoveClaimsFromQueue();

            //Assert
            int endingCount = content.Count;
            Assert.AreNotEqual(startingCount, endingCount);
        }

    }
}
