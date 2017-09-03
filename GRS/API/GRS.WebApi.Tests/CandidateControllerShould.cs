using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRS.WebApi.Services;
using Moq;
using GRS.Repository;
using System.Linq;
using GRS.DataAccess.Models;
using GRS.WebApi.Controllers;
using GRS.WebApi.Models;

namespace GRS.WebApi.Tests
{
    [TestClass]
    public class CandidateControllerShould
    {
        private static CandidateDetailViewModel candidateDetailViewModel = null;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            candidateDetailViewModel = new CandidateDetailViewModel()
            {
                Id = 1,
                FirstName = "Candidate1FirstName",
                LastName = "Candidate1LastName",
                Skills = new long[] { 1, 2 }
            };

        }
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
        [TestMethod]
        public void GetSuccessfuly()
        {
            bool calledGetAll = false;
            var mockRep = new Mock<ICandidateServices>();
            mockRep.Setup(x => x.GetAll()).Callback(()=> calledGetAll = true);
            CandidateController candidateController = new CandidateController(mockRep.Object); ;

            var vm = candidateController.Get();
            Assert.IsTrue(calledGetAll);
        }
        [TestMethod]
        public void GetDetailSuccessfuly()
        {
            bool calledGetDetail = false;
            var mockRep = new Mock<ICandidateServices>();
            mockRep.Setup(x => x.GetDetail(1)).Callback(() => calledGetDetail = true);
            CandidateController candidateController = new CandidateController(mockRep.Object); ;

            var vm = candidateController.Get(1);
            Assert.IsTrue(calledGetDetail);
        }
        [TestMethod]
        public void GetBySkillSuccessfuly()
        {
            bool calledGetBySkill = false;
            var mockRep = new Mock<ICandidateServices>();
            mockRep.Setup(x => x.GetBySkill(1)).Callback(() => calledGetBySkill = true);
            CandidateController candidateController = new CandidateController(mockRep.Object); ;

            var vm = candidateController.GetBySkill(1);
            Assert.IsTrue(calledGetBySkill);
        }
        [TestMethod]
        public void PostSuccessfuly()
        {
            bool calledUpdate = false;
            var mockRep = new Mock<ICandidateServices>();
            mockRep.Setup(x => x.Update(candidateDetailViewModel)).Callback(() => calledUpdate = true);
            CandidateController candidateController = new CandidateController(mockRep.Object); ;

            candidateController.Post(candidateDetailViewModel);
            Assert.IsTrue(calledUpdate);
        }

        [TestMethod]
        public void PutSuccessfuly()
        {
            bool calledInsert = false;
            var mockRep = new Mock<ICandidateServices>();
            mockRep.Setup(x => x.Insert(candidateDetailViewModel)).Callback(() => calledInsert = true);
            CandidateController candidateController = new CandidateController(mockRep.Object); ;

            candidateController.Put(candidateDetailViewModel);
            Assert.IsTrue(calledInsert);
        }

        [TestMethod]
        public void DeleteSuccessfuly()
        {
            bool calledDeleteCandidate = false;
            var mockRep = new Mock<ICandidateServices>();
            mockRep.Setup(x => x.DeleteCandidate(1)).Callback(() => calledDeleteCandidate = true);
            CandidateController candidateController = new CandidateController(mockRep.Object); ;

            candidateController.Delete(1);
            Assert.IsTrue(calledDeleteCandidate);
        }

    }
}
