using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRS.WebApi.Services;
using Moq;
using GRS.Repository;
using System.Linq;
using GRS.DataAccess.Models;

namespace GRS.WebApi.Tests
{
    [TestClass]
    public class SkillServicesShould
    {
        
        private static Candidate candidate1=null;
        private static Candidate candidate2=null;
        private static Skill skill1 = null;
        private static Skill skill2 = null;
        private static long[] candidate1Skills = null;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            candidate1 = new Candidate() { Id = 1, FirstName = "Candidate1FirstName", LastName = "Candidate1LastName" };
            candidate2 = new Candidate() { Id = 2, FirstName = "Candidate2FirstName", LastName = "Candidate2LastName" };
            skill1 = new Skill() {Id=1, Name = "Skill1" };
            skill2 = new Skill() {Id=2, Name = "Skill2"  };
            candidate1Skills = new long[] { 1, 2 };
        }
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
        [TestMethod]
        public void GetAllSuccessfuly()
        {
            var mockRep = new Mock<ICandidateRepository>();
            mockRep.Setup(x => x.GetAllSkills()).Returns(new Skill[] { skill1, skill2 });
            mockRep.Setup(x => x.GetAllCandidates()).Returns(new Candidate[] { candidate1, candidate2 });
            CandidateServices candidateService = new CandidateServices(mockRep.Object); ;

            var vm = candidateService.GetAll();
            Assert.IsTrue(vm.Candidates.ToArray().Length == 2 && vm.Skills.ToArray().Length == 2);
        }

        [TestMethod]
        public void GetDetailSuccessfuly()
        {
            var mockRep = new Mock<ICandidateRepository>();
            mockRep.Setup(x => x.GetCandidate(1)).Returns(candidate1);
            mockRep.Setup(x => x.GetCandidateSkills(1)).Returns(candidate1Skills);
            CandidateServices candidateService = new CandidateServices(mockRep.Object); ;

            var vm = candidateService.GetDetail(1);
            Assert.IsTrue(vm.Id == candidate1.Id
                && vm.FirstName == candidate1.FirstName
                && vm.LastName == candidate1.LastName
                && vm.Skills.ToArray().Length == 2);
        }
        [TestMethod]
        public void ShouldDeleteCandidateSuccesfuly()
        {
            bool deleted = false;
            var mockRep = new Mock<ICandidateRepository>();
            mockRep.Setup(x => x.Delete(1)).Callback(()=> deleted = true);
            mockRep.Setup(x => x.GetCandidateSkills(1)).Returns(new long[] { 1, 2 });
            CandidateServices candidateService = new CandidateServices(mockRep.Object); ;

            candidateService.DeleteCandidate(1);
            Assert.IsTrue(deleted);
        }
        [TestMethod]
        public void ShouldInsertSuccesfuly()
        {
            bool inserted = false;
            var mockRep = new Mock<ICandidateRepository>();
            mockRep.Setup(x => x.Insert(candidate1.FirstName, candidate1.LastName, candidate1Skills)).Callback(() => inserted = true);
            CandidateServices candidateService = new CandidateServices(mockRep.Object); ;

            candidateService.Insert(new Models.CandidateDetailViewModel() {
                Id = candidate1.Id,
                FirstName = candidate1.FirstName,
                LastName = candidate1.LastName,
                Skills = candidate1Skills
            });
            Assert.IsTrue(inserted);
        }
        [TestMethod]
        public void ShouldUpdateSuccesfuly()
        {
            bool updated = false;
            var mockRep = new Mock<ICandidateRepository>();
            mockRep.Setup(x => x.UpdateCandidate(candidate1.Id, candidate1.FirstName, candidate1.LastName, candidate1Skills)).Callback(() => updated = true);
            CandidateServices candidateService = new CandidateServices(mockRep.Object); ;

            candidateService.Update(new Models.CandidateDetailViewModel()
            {
                Id = candidate1.Id,
                FirstName = candidate1.FirstName,
                LastName = candidate1.LastName,
                Skills = candidate1Skills
            });
            Assert.IsTrue(updated);
        }
        [TestMethod]
        public void GetBySkillSuccessfuly()
        {
            var mockRep = new Mock<ICandidateRepository>();
            mockRep.Setup(x => x.GetCandidateBySkill(1)).Returns(new Candidate[] { candidate1});
            CandidateServices candidateService = new CandidateServices(mockRep.Object); ;

            var vm = candidateService.GetBySkill(1);
            var returnCandidates = vm.Candidates.ToArray();
            Assert.IsTrue(
                returnCandidates.Length ==1
                && returnCandidates[0].Id == candidate1.Id
                && returnCandidates[0].FirstName == candidate1.FirstName
                && returnCandidates[0].LastName == candidate1.LastName);
        }
    }
}
