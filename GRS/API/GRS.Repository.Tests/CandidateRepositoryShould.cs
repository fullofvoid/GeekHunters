using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GRS.DataAccess;
using System.Linq;
using GRS.DataAccess.Models;
using System.Collections.Generic;
using Autofac;
using System.Reflection;
using System.Data.Entity;

namespace GRS.Repository.Tests
{
    [TestClass]
    public class CandidateRepositoryShould
    {
        private static Candidate candidate1 = null;
        private static Candidate candidate2 = null;
        private static Skill skill1 = null;
        private static Skill skill2 = null;
        private static long[] candidate1Skills = null;
        private static Candidate[] candidateArray =null;
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            candidate1 = new Candidate() { Id = 1, FirstName = "Candidate1FirstName", LastName = "Candidate1LastName" };
            candidate2 = new Candidate() { Id = 2, FirstName = "Candidate2FirstName", LastName = "Candidate2LastName" };
            skill1 = new Skill() { Id = 1, Name = "Skill1" };
            skill2 = new Skill() { Id = 2, Name = "Skill2" };
            candidate1Skills = new long[] { 1, 2 };
            candidateArray = new Candidate[] { candidate1, candidate2 };

        }
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
        //[TestMethod]
        //public void GetAllCandidatesSuccessfuly()
        //{
        //    var mock1 = new Mock<IDbSet<Candidate>>();
        //    mock1.Setup(x => x.ToArray()).Returns(candidateArray);

        //    var mock2 = new Mock<CandidateEntities>();
        //    mock2.Setup(x => x.Candidates).Returns(mock1.Object);

        //    var builder = new ContainerBuilder();
        //    builder.RegisterInstance<ICandidateEntities>(mock2.Object);
        //    var container = builder.Build();
        //    DBContextResolver.Config(container);
            
        //    CandidateRepository candidateRepo = new CandidateRepository();
        //    candidateRepo.GetAllCandidates();
        //    mock2.Verify(m => m.Candidates, Times.Once());
            
        //}
    }
}
